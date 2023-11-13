using PracticeUdemy.Models;

namespace PracticeUdemy.Repository
{
    public interface IProduct
    {
        Task<Product> Create (Product product);

        Task<List<Product>> GetAll ();
        Task<Product?> GetById(Guid id);

        Task<Product?> Update (Guid id, Product product);

        Task<Product?> Delete(Guid id);

        Task<List<Product>> GetAllProducts (string? filterOn=null,string? filterQuery=null,string? bySort=null,bool isAsscending=true);
    }
}
