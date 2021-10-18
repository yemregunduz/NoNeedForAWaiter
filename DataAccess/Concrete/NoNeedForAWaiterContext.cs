using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;

using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
    public class NoNeedForAWaiterContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.; Database=NoNeedForAWaiterDb;Trusted_Connection= true");
        }
        public DbSet<Category> CATEGORIES { get; set; }
        public DbSet<Table> TABLES_ { get; set; }
        public DbSet<Restaurant> RESTAURANTS { get; set; }
        public DbSet<OrderDetail> ORDERDETAILS { get; set; }
        public DbSet<Product> PRODUCTS { get; set; }
        public DbSet<Order> ORDERS { get; set; }
    }
}
