using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResApp.Models
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext(DbContextOptions<MyAppDbContext> options) : base(options)
            {

            }
            public DbSet<Customer> Customers{ get; set; }
            public DbSet<Fooditem> Fooditems { get; set; }
            public DbSet<Payment> Payments { get; set; }
       
    }
}
