using Microsoft.EntityFrameworkCore;
using PracticeUdemy.Models;

namespace PracticeUdemy.Data
{
    public class ProductCatagoryDbContext:DbContext
    {
        public ProductCatagoryDbContext(DbContextOptions<ProductCatagoryDbContext> dbContextOptions):base(dbContextOptions)
        {

        }
        public DbSet<Product> products { get; set; }
        public DbSet<Catagory> catagories { get; set; }
    }
}
