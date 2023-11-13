using System.Runtime.InteropServices;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeUdemy.CustomeActionFilters;
using PracticeUdemy.Data;
using PracticeUdemy.Dto;
using PracticeUdemy.Models;
using PracticeUdemy.Repository;

namespace PracticeUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class CatagoryController : ControllerBase
    {
        private readonly ProductCatagoryDbContext _dbcontext;
        private readonly ICatagory catagory;
        private readonly IMapper mapper;

        public CatagoryController(ProductCatagoryDbContext productCatagoryDbContext ,ICatagory catagory , IMapper mapper)
        {
            this._dbcontext=productCatagoryDbContext;
            this.catagory = catagory;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task< IActionResult> GetAll()
        {

            var catagorylist = await catagory.GetAll();

            /* var catagorydto = new List<CatagoryDto>();

             foreach(var catagory in catagorylist)
             {
                 catagorydto.Add(new CatagoryDto()
                 {
                     id=catagory.id,
                     catagoryname=catagory.catagoryname
                 });
             }*/
            var catagorydto=mapper.Map<List<CatagoryDto>>(catagorylist);



            return Ok(catagorydto);
        }
        [HttpPost]
        [ValidateModel]
        public async Task <IActionResult> Create([FromBody] UpdateCatagory catagories)
        {
            var catagorydomainmodel = new Catagory();
            catagorydomainmodel.catagoryname= catagories.catagoryname;
            await catagory.CreateAsync(catagorydomainmodel);


            /* var catagotydto = new CatagoryDto();
             catagotydto.id = catagorydomainmodel.id;
             catagotydto.catagoryname = catagorydomainmodel.catagoryname; */

            var catagotydto= mapper.Map<CatagoryDto>(catagorydomainmodel); 

            return CreatedAtAction(nameof(GetById), new { id = catagotydto.id }, catagotydto);
        }

        [HttpGet]
        [Route("{id:Guid}")]

        public async Task<IActionResult> GetById(Guid id)
        {
            //var catagaryid = _dbcontext.catagories.Find(id);
            var catagaryid = await catagory.GetById(id);
            if (catagaryid == null)
            {   
                return NotFound();
            }

            /* var catagorydto = new CatagoryDto();
             catagorydto.id = catagaryid.id;
             catagorydto.catagoryname=catagaryid.catagoryname; */

            var catagorydto = mapper.Map<CatagoryDto>(catagaryid);

            return Ok(catagorydto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task <IActionResult> Update([FromRoute] Guid id,[FromBody] UpdateCatagory catagories)
        {
            var domainmodel = new Catagory();
            domainmodel.catagoryname = catagories.catagoryname;

            var catagoryid = await catagory.UpdateAsync(id, domainmodel);
            if (catagoryid == null)
            {
                return NotFound();
            }
            
            
            


           /* var catagorydto = new CatagoryDto();
            catagorydto.id = catagoryid.id;
            catagorydto.catagoryname = catagoryid.catagoryname; */


            var catagorydto = mapper.Map<CatagoryDto>(catagoryid);

            return Ok(catagorydto);
        }


        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task  <IActionResult> Delete([FromRoute] Guid id)
        {
            var catagoryid = await catagory.DeleteAsync(id);
            if (catagoryid == null)
            {
                return NotFound();
            }





            /* var catagorydto = new CatagoryDto
             {
                 id= catagoryid.id,
                 catagoryname= catagoryid.catagoryname,
             };*/


            var catagorydto = mapper.Map<CatagoryDto>(catagoryid);
            return Ok(catagorydto);
        }
    }
}
