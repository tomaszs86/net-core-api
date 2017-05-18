using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using net_core_api.Models;

namespace net_core_api.Models
{
    public class NetCoreApiContext : DbContext
    {
        public NetCoreApiContext(DbContextOptions<NetCoreApiContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}