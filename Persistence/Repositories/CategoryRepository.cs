using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using supermarketapi.Domain.Models;
using supermarketapi.Domain.Repositories;
using supermarketapi.Persistence.Contexts;
using System.Linq;

namespace supermarketapi.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<IEnumerable<Category>> ListAsync(string clientUID)
        {
            //return await _context.Categories
            //                     .AsNoTracking()
            //                     .ToListAsync();

            //return await _context.Categories.ToListAsync();

            return await _context.Categories.Where(p => p.ClientUID == clientUID).ToListAsync();

            // AsNoTracking tells EF Core it doesn't need to track changes on listed entities. Disabling entity
            // tracking makes the code a little faster
        }

        public async Task<Category> ListAsyncId(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Category category)
        {            
            await _context.Categories.AddAsync(category);
        }
               
        public async Task<Category> FindByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public void Update(Category category)
        {
             _context.Categories.Update(category);
        }

        public void Remove(Category category)
        {
            _context.Categories.Remove(category);
        }

        //public void RemoveAll()
        //{
        //    foreach (var category in _context.Categories)
        //    {
        //        _context.Categories.Remove(category);
        //    }
        //}
    }
}