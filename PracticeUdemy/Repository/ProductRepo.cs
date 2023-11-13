using Microsoft.EntityFrameworkCore;
using PracticeUdemy.Data;
using PracticeUdemy.Models;

namespace PracticeUdemy.Repository
{
    public class ProductRepo:IProduct
    {
        private readonly ProductCatagoryDbContext productCatagoryDbContext;

        public ProductRepo(ProductCatagoryDbContext productCatagoryDbContext)
        {
            this.productCatagoryDbContext = productCatagoryDbContext;
        }

        public async Task<Product> Create(Product product)
        {
            await productCatagoryDbContext.products.AddAsync(product);
            await productCatagoryDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> Delete(Guid id)
        {
            var domainmodel = await productCatagoryDbContext.products.FirstOrDefaultAsync(a=>a.id==id);
            if (domainmodel == null)
            {
                return null;
            }
             productCatagoryDbContext.products.Remove(domainmodel);
            await productCatagoryDbContext.SaveChangesAsync();
            return domainmodel;

            
        }

        public async Task<List<Product>> GetAll()
        {
            return await productCatagoryDbContext.products.Include(a=>a.Catagory).ToListAsync();
        }

        public async Task<List<Product>> GetAllProducts(string? filterOn = null, string? filterQuery = null, string? bySort = null, bool isAsscending = true)
        {
            var productlist =  productCatagoryDbContext.products.Include(a => a.Catagory).AsQueryable();

            //filtering
            if(string.IsNullOrWhiteSpace(filterOn)==false && string.IsNullOrWhiteSpace(filterQuery)==false  )
            {
                if (filterOn.Equals("productname", StringComparison.OrdinalIgnoreCase)) { 
                productlist=productlist.Where(a=>a.productname.Contains(filterQuery));
                }
            }

            //sorting
            if (string.IsNullOrWhiteSpace(bySort) == false)
            {
                if (bySort.Equals("productname", StringComparison.OrdinalIgnoreCase))
                {
                    productlist = isAsscending ? productlist.OrderBy(a => a.productname) : productlist.OrderByDescending(a => a.productname);

                }
            }

            return await productlist.ToListAsync();
        }

        public async Task<Product?> GetById(Guid id)
        {
            var domainmodel = await productCatagoryDbContext.products.Include(a=>a.Catagory).FirstOrDefaultAsync(a => a.id == id);
            if(domainmodel == null)
            {
                return null;
            }
            return domainmodel;
        }

        public async Task<Product?> Update(Guid id, Product product)
        {
            var domainmodel = await productCatagoryDbContext.products.FindAsync(id);
            if (domainmodel == null)
            {
                return null;
            }
            domainmodel.productname=product.productname;
            domainmodel.product_description = product.product_description;
            domainmodel.product_price=product.product_price;
            domainmodel.catagoryid=product.catagoryid;
            await productCatagoryDbContext.SaveChangesAsync();

            return domainmodel; 
        }
    }
}
