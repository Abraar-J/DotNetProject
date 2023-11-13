using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeUdemy.Data;
using PracticeUdemy.Models;

namespace PracticeUdemy.Repository
{
    public class CatagoryRepo : ICatagory
    {
        private readonly ProductCatagoryDbContext _dbcontext;

        public CatagoryRepo(ProductCatagoryDbContext productCatagoryDbContext)
        {
            this._dbcontext = productCatagoryDbContext;
        }

        public async Task<Catagory> CreateAsync(Catagory catagory)
        {
            await _dbcontext.catagories.AddAsync(catagory);
            await _dbcontext.SaveChangesAsync();
            return catagory;
        }

        public async Task<Catagory?> DeleteAsync(Guid id)
        {
            var catagoryid = await _dbcontext.catagories.FirstOrDefaultAsync(a => a.id == id);
            if (catagoryid == null)
            {
                return null;
            }

            _dbcontext.catagories.Remove(catagoryid);
            await _dbcontext.SaveChangesAsync();
            return catagoryid;
        }

        public async Task<List<Catagory>> GetAll()
        {
            return await _dbcontext.catagories.ToListAsync();
            
        }

        public async Task<Catagory?> GetById(Guid id)
        {
            var domainmodel = _dbcontext.catagories.Find(id);
            if (domainmodel == null)
            {
                return null;
            }
            return domainmodel;
        }

        public async Task<Catagory?> UpdateAsync(Guid id, Catagory catagory)
        {
            var catagoryid = await _dbcontext.catagories.FindAsync(id);
            if (catagoryid == null)
            {
                return null;
            }


            catagoryid.catagoryname = catagory.catagoryname;


            // await _dbcontext.catagories.Update(catagoryid);
            await _dbcontext.SaveChangesAsync();

            return catagoryid;
        }
    }
}
