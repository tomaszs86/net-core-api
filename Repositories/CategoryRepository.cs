using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using net_core_api.Models;

namespace net_core_api.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();  
        Task<int> Add(Category category);      
    }

    public class CategoryRepository : ICategoryRepository
    {
        private readonly NetCoreApiContext _context;

        public CategoryRepository(NetCoreApiContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAll()
        {
            return await _context.Categories.Include(c=>c.Product).ToListAsync();
        }

        public async Task<int> Add(Category category) {
            
            _context.Entry(category).State = EntityState.Added;
            int result = await (_context.SaveChangesAsync());

            return result;

        }    
    }
}