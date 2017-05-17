using System;
using System.Collections.Generic;
using System.Linq;
using api.net_core_api;
using Microsoft.EntityFrameworkCore;
using net_core_api.Models;

namespace net_core_api.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
    }

    public class ProductRepository : IProductRepository
    {
        private readonly NetCoreApiContext _context;

        public ProductRepository(NetCoreApiContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.Include(c=>c.Categories).ToList();
        }
    }
}