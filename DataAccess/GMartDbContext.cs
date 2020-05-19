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

        public GMartDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            Console.WriteLine("Dbcontext onconfiguring:before using sql connection");
            optionBuilder.UseSqlServer("server=localhost:1433,database=MoviesDB,userid=sa,password=SAadmin123,MultipleActiveResultSet=true");
            Console.WriteLine("Dbcontext onconfiguring:after using sql connection");
        }

        public DbSet<Product> Products { get; set; }
    }
}
