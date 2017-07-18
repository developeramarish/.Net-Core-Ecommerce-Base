using Microsoft.EntityFrameworkCore;
using Shop.Core.Entites;

namespace Shop.Infrastructure.Data
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DiscountCode> DiscountCodes { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductComponent> ProductComponents { get; set; }
        public DbSet<ProductComponentCompatibility> ProductComponentCompatibilities { get; set; }
        public DbSet<ProductConfiguration> ProductConfigurations { get; set; }
        public DbSet<ShippingDetails> ShippingDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Ensure the IsDirty check (LifetimeBase) is not mapped to the db
            modelBuilder.Entity<Address>().Ignore(x => x.IsDirty);
            modelBuilder.Entity<Basket>().Ignore(x => x.IsDirty);
            modelBuilder.Entity<Customer>().Ignore(x => x.IsDirty);
            modelBuilder.Entity<DiscountCode>().Ignore(x => x.IsDirty);
            modelBuilder.Entity<Media>().Ignore(x => x.IsDirty);
            modelBuilder.Entity<Order>().Ignore(x => x.IsDirty);
            modelBuilder.Entity<Payment>().Ignore(x => x.IsDirty);
            modelBuilder.Entity<Product>().Ignore(x => x.IsDirty);
            modelBuilder.Entity<ProductComponent>().Ignore(x => x.IsDirty);
            modelBuilder.Entity<ProductComponentCompatibility>().Ignore(x => x.IsDirty);
            modelBuilder.Entity<ProductConfiguration>().Ignore(x => x.IsDirty);
            modelBuilder.Entity<ShippingDetails>().Ignore(x => x.IsDirty);
        }
    }
}
