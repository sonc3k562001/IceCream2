﻿using Microsoft.EntityFrameworkCore;

namespace Ice_Cream.Models
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options): base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Customer> Customers { get; set; }
        
    }
}
