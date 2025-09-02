using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Infra.Repository;


namespace Store.Infra.Context
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; } = null!;

        public DbSet<Discount> Discounts { get; set; }

        public DbSet<Delivery> Deliveries { get; set; }

        public DbSet<DeliveryFee> DeliveryFees { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Role> Roles { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreDbContext).Assembly);

            modelBuilder.Ignore<Flunt.Notifications.Notification>();
        }
    }
}