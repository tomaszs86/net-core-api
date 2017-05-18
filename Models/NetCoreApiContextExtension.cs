using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_core_api.Models
{
    public static class MvcContextExtensions
    {
        public static void EnsureSeedDataForContext(this NetCoreApiContext context)
        {
         
            if (context.Products.Any())
            {
                return;
            }

            var categories = new List<Category>() {
                new Category() { Key = 1, Name = "Drinks"},
                new Category() { Key = 2, Name = "Soft Drinks"}
            };

            context.Categories.AddRange(categories);
            context.SaveChanges();

            var products = new List<Product>() {
                new Product() { Key = 1, Name = "Coca Cola", Price = 59, IsActive = true, Description = "Simple product",
                Categories = new List<Category>()
                     {
                        context.Categories.Where(x=>x.Key == 1).FirstOrDefault(),
                        context.Categories.Where(x=>x.Key == 2).FirstOrDefault()
                     }                
                 },
                new Product() { Key = 2, Name = "Sprite", Price = 49, IsActive = true, Description = "Simple product" }
            };

            context.Products.AddRange(products);
            context.SaveChanges();
            
        }
    }
}