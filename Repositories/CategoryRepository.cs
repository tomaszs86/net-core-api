using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.net_core_api;
using Microsoft.EntityFrameworkCore;
using net_core_api.Models;

namespace net_core_api.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();        
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
    }
}