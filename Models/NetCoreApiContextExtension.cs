using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.net_core_api;

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

            var products = new List<Product>() {
                new Product() { Name = "Coca Cola",
                Categories = new List<Category>()
                     {
                         new Category() {
                             Name = "Drinks"
                         },
                          new Category() {
                             Name = "Soft Drinks"
                          }
                     }                
                 },
                new Product() { Name = "Sprite" }
            };

            context.Products.AddRange(products);
            context.SaveChanges();
            
        }
    }
}