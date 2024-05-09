using ETAppApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETAppApi.Persistence.Contexts
{
    public  class ETAppContext:DbContext
    {
        public ETAppContext(DbContextOptions options):base(options) { }


        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<Customer> Customers{ get; set; }
    }
}
