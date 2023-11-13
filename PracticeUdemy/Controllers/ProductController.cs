using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticeUdemy.Dto;
using PracticeUdemy.Models;
using PracticeUdemy.Repository;

namespace PracticeUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProductController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IProduct product;

        public ProductController(IMapper mapper,IProduct product)
        {
            this.mapper = mapper;
            this.product = product;
        }

        [HttpPost]

        public async Task < IActionResult> Create ([FromBody] ProductCreateDto ProductDto1)
        {
            // mapping dto model to domain model 
           var domainmodel= mapper.Map<Product>(ProductDto1);

            var returndomainmodel=await product.Create(domainmodel);

            return Ok(mapper.Map<ProductDto>(returndomainmodel));

        }
        [HttpGet]
        [Authorize(Roles ="Reader")]

        public async Task<IActionResult> GetAll()
        {
            var domainmodel = await product.GetAll();
            return Ok(mapper.Map<List<ProductNavigationalDto>>(domainmodel));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            var domainmodel = await product.GetById(id);
            if (domainmodel == null)
            {
                return null;
            }
            return Ok(mapper.Map<ProductNavigationalDto>(domainmodel));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdatePoductDto updatePoductDto )
        {
            var domainmodel = mapper.Map<Product>(updatePoductDto);
            var domainresult= await product.Update(id,domainmodel);
            if (domainresult == null)
            {
                return null;
            }
            return Ok(mapper.Map<ProductDto>(domainresult));
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            var domainmodel= await product.Delete(id);
            if (domainmodel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<ProductDto>(domainmodel));
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetByFilter([FromQuery] string? filterOn, [FromQuery] string? filterQuery, [FromQuery] string? sortBy, [FromQuery] bool? isAsscending)
        {
            var domainmodel= await product.GetAllProducts(filterOn, filterQuery , sortBy ,isAsscending ?? true);

            return Ok(mapper.Map<List<ProductNavigationalDto>>(domainmodel));

        }
     }
}
