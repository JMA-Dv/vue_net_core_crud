using Core.Model;
using Core.Model.Identity;
using Core.Model.Orders;
using Core.Model.Products;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.Data.Config;
using Persistence.Data.Config.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Data
{
    public class AppDbContext: IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //The configuration for each entity and relationshim could be here but it's cleaner if it's separated in different classes
            base.OnModelCreating(modelBuilder);

            new ClientConfig(modelBuilder.Entity<Client>());
            new ProductConfig(modelBuilder.Entity<Product>());
            new OrderDetailConfig(modelBuilder.Entity<OrderDetail>());
            new OrderConfig(modelBuilder.Entity<Order>());
            new RoleConfig(modelBuilder.Entity<ApplicationRole>());
            new UserConfig(modelBuilder.Entity<ApplicationUser>());

        }
    }
}
