using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using net_core_api.Models;

namespace net_core_api.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();        
        void Add(Product item);
        Product Find(int key);
        void Remove(int key);
        void Update(Product item);
        Category GetCategoriesForProduct(int productId, int categoryId);
        void AddCategoryForProduct(int productId, Category category);
        bool ProductExists(int productId);        

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

        public void Add(Product item)
        {
            _context.Products.Add(item);
            _context.SaveChanges();
        }

        public Product Find(int key)
        {            
            return _context.Products.Include(c => c.Categories).Where(c => c.Key == key).FirstOrDefault();
        }

        public void Remove(int key)
        {
            var entity = _context.Products.First(t => t.Key == key);
            _context.Products.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Product item)
        {
            _context.Products.Update(item);
            _context.SaveChanges();
        }

        public Category GetCategoriesForProduct(int productId, int categoryId)
        {
            return _context.Categories
               .Where(p => p.ProductId == productId && p.Key == categoryId).FirstOrDefault();
        }

        public void AddCategoryForProduct(int productId, Category category)
        {
            var product = Find(productId);
            product.Categories.Add(category);
        }

        public bool ProductExists(int productId)
        {
            return _context.Products.Any(c => c.Key == productId);
        }
    }
}