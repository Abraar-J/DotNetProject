using PracticeUdemy.Models;

namespace PracticeUdemy.Repository
{
    public interface ICatagory
    {
        Task <List<Catagory>>GetAll();

        Task<Catagory?> GetById (Guid id);
        Task <Catagory> CreateAsync(Catagory catagory);

        Task<Catagory?> UpdateAsync (Guid id ,Catagory catagory);

        Task <Catagory?> DeleteAsync (Guid id);
    }

}
