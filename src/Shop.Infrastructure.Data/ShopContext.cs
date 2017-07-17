using Microsoft.EntityFrameworkCore;
using Shop.Core.Constants;
using Shop.Core.Entites;

namespace Shop.Infrastructure.Data
{
    public class ShopContext : DbContext
    {
        //private readonly string _databaseName = Constants.DefaultDatabaseName;

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
    }
}
