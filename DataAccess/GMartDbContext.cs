using System;
using Microsoft.EntityFrameworkCore;
using GMartWebServices.Models;

namespace GMartWebServices.DataAccess
{
    public class GMartDbContext : DbContext// DbContext  
    {
        public GMartDbContext(DbContextOptions<GMartDbContext> options) : base(options)
        {
                Console.WriteLine("From dbcontext constructor");
        }

        public DbSet<Product> Products { get; set; }
    }
}
