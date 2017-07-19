using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Shop.Infrastructure.Data;
using Shop.Core.Enums;

namespace Shop.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ShopContext))]
    [Migration("20170719080400_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Shop.Core.Entites.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("AddressLine2")
                        .HasMaxLength(100);

                    b.Property<string>("AddressLine3")
                        .HasMaxLength(100);

                    b.Property<string>("AddressLine4")
                        .HasMaxLength(100);

                    b.Property<string>("AddressReference")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("CountryCode")
                        .HasMaxLength(10);

                    b.Property<string>("County")
                        .HasMaxLength(100);

                    b.Property<int?>("CustomerId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("Postcode")
                        .HasMaxLength(25);

                    b.Property<string>("Udprn")
                        .HasMaxLength(50);

                    b.HasKey("AddressId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Shop.Core.Entites.Basket", b =>
                {
                    b.Property<int>("BasketId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BasketReference")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<int?>("CustomerId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<int?>("DiscountCodeId");

                    b.Property<int>("ShippingMethod");

                    b.HasKey("BasketId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DiscountCodeId");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("Shop.Core.Entites.ComponentSlot", b =>
                {
                    b.Property<int>("ComponentSlotId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ComponentSlotReference")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<bool>("IsDirty");

                    b.Property<int?>("ProductId");

                    b.Property<bool>("Required");

                    b.Property<string>("SlotName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("ComponentSlotId");

                    b.HasIndex("ProductId");

                    b.ToTable("ComponentSlot");
                });

            modelBuilder.Entity("Shop.Core.Entites.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustomerReference")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("EmailAddress")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .HasMaxLength(250);

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("TelephoneNumber")
                        .HasMaxLength(250);

                    b.Property<string>("Title")
                        .HasMaxLength(25);

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Shop.Core.Entites.DiscountCode", b =>
                {
                    b.Property<int>("DiscountCodeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClaimLimit");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<decimal>("DiscountAmount");

                    b.Property<string>("DiscountCodeReference")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<int>("DiscountCodeType");

                    b.Property<int>("NumberClaimed");

                    b.HasKey("DiscountCodeId");

                    b.ToTable("DiscountCodes");
                });

            modelBuilder.Entity("Shop.Core.Entites.Media", b =>
                {
                    b.Property<int>("MediaId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<int>("Index");

                    b.Property<string>("MediaReference")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<int>("MediaType");

                    b.Property<int?>("ProductComponentId");

                    b.Property<int?>("ProductId");

                    b.Property<string>("Url")
                        .HasMaxLength(2000);

                    b.HasKey("MediaId");

                    b.HasIndex("ProductComponentId");

                    b.HasIndex("ProductId");

                    b.ToTable("Media");
                });

            modelBuilder.Entity("Shop.Core.Entites.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BillingAddressAddressId");

                    b.Property<int?>("CustomerId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<int?>("DiscountCodeId");

                    b.Property<string>("OrderReference")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<int?>("PaymentId");

                    b.Property<int?>("ShippingAddressAddressId");

                    b.Property<int?>("ShippingMethodShippingDetailsId");

                    b.HasKey("OrderId");

                    b.HasIndex("BillingAddressAddressId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DiscountCodeId");

                    b.HasIndex("PaymentId");

                    b.HasIndex("ShippingAddressAddressId");

                    b.HasIndex("ShippingMethodShippingDetailsId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Shop.Core.Entites.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("PaymentReference")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("PaymentServiceProvider");

                    b.Property<string>("PspChargeId");

                    b.HasKey("PaymentId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Shop.Core.Entites.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AvailableForOrder");

                    b.Property<bool>("Configureable");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<decimal>("PricePreTax");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasMaxLength(10000);

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("ProductReference")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("ProductShortDescription")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<decimal>("ShippingWeightKg");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Shop.Core.Entites.ProductComponent", b =>
                {
                    b.Property<int>("ProductComponentId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AvailableForOrder");

                    b.Property<int?>("ComponentSlotId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<decimal>("PricePreTax");

                    b.Property<string>("ProductComponentDescription")
                        .IsRequired()
                        .HasMaxLength(10000);

                    b.Property<string>("ProductComponentName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("ProductComponentReference")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<int?>("ProductConfigurationId");

                    b.Property<decimal>("ShippingWeightKg");

                    b.HasKey("ProductComponentId");

                    b.HasIndex("ComponentSlotId");

                    b.HasIndex("ProductConfigurationId");

                    b.ToTable("ProductComponents");
                });

            modelBuilder.Entity("Shop.Core.Entites.ProductComponentCompatibility", b =>
                {
                    b.Property<int>("ProductComponentCompatibilityId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ComponentProductComponentId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<string>("ProductComponentCompatibilityReference")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<int?>("ProductId");

                    b.HasKey("ProductComponentCompatibilityId");

                    b.HasIndex("ComponentProductComponentId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductComponentCompatibilities");
                });

            modelBuilder.Entity("Shop.Core.Entites.ProductConfiguration", b =>
                {
                    b.Property<int>("ProductConfigurationId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BaseProductProductId");

                    b.Property<int?>("BasketId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<int?>("OrderId");

                    b.Property<string>("ProductConfigurationReference")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("ProductConfigurationId");

                    b.HasIndex("BaseProductProductId");

                    b.HasIndex("BasketId");

                    b.HasIndex("OrderId");

                    b.ToTable("ProductConfigurations");
                });

            modelBuilder.Entity("Shop.Core.Entites.ShippingDetails", b =>
                {
                    b.Property<int>("ShippingDetailsId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<DateTime>("DateUpdated");

                    b.Property<DateTime?>("DeliveredDate");

                    b.Property<DateTime?>("EstimatedDeliveryDate");

                    b.Property<DateTime?>("EstimatedShippingDate");

                    b.Property<decimal>("PricePaid");

                    b.Property<DateTime?>("ShippedDate");

                    b.Property<string>("ShippingDetailsReference")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<int>("ShippingMethod");

                    b.Property<int>("ShippingProvider");

                    b.Property<string>("TrackingReference");

                    b.Property<string>("TrackingUrl");

                    b.HasKey("ShippingDetailsId");

                    b.ToTable("ShippingDetails");
                });

            modelBuilder.Entity("Shop.Core.Entites.Address", b =>
                {
                    b.HasOne("Shop.Core.Entites.Customer")
                        .WithMany("Addresses")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("Shop.Core.Entites.Basket", b =>
                {
                    b.HasOne("Shop.Core.Entites.Customer")
                        .WithMany("Baskets")
                        .HasForeignKey("CustomerId");

                    b.HasOne("Shop.Core.Entites.DiscountCode", "DiscountCode")
                        .WithMany()
                        .HasForeignKey("DiscountCodeId");
                });

            modelBuilder.Entity("Shop.Core.Entites.ComponentSlot", b =>
                {
                    b.HasOne("Shop.Core.Entites.Product")
                        .WithMany("ComponentSlots")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("Shop.Core.Entites.Media", b =>
                {
                    b.HasOne("Shop.Core.Entites.ProductComponent")
                        .WithMany("Media")
                        .HasForeignKey("ProductComponentId");

                    b.HasOne("Shop.Core.Entites.Product")
                        .WithMany("Media")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("Shop.Core.Entites.Order", b =>
                {
                    b.HasOne("Shop.Core.Entites.Address", "BillingAddress")
                        .WithMany()
                        .HasForeignKey("BillingAddressAddressId");

                    b.HasOne("Shop.Core.Entites.Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId");

                    b.HasOne("Shop.Core.Entites.DiscountCode", "DiscountCode")
                        .WithMany()
                        .HasForeignKey("DiscountCodeId");

                    b.HasOne("Shop.Core.Entites.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentId");

                    b.HasOne("Shop.Core.Entites.Address", "ShippingAddress")
                        .WithMany()
                        .HasForeignKey("ShippingAddressAddressId");

                    b.HasOne("Shop.Core.Entites.ShippingDetails", "ShippingMethod")
                        .WithMany()
                        .HasForeignKey("ShippingMethodShippingDetailsId");
                });

            modelBuilder.Entity("Shop.Core.Entites.ProductComponent", b =>
                {
                    b.HasOne("Shop.Core.Entites.ComponentSlot", "ComponentSlot")
                        .WithMany()
                        .HasForeignKey("ComponentSlotId");

                    b.HasOne("Shop.Core.Entites.ProductConfiguration")
                        .WithMany("Components")
                        .HasForeignKey("ProductConfigurationId");
                });

            modelBuilder.Entity("Shop.Core.Entites.ProductComponentCompatibility", b =>
                {
                    b.HasOne("Shop.Core.Entites.ProductComponent", "Component")
                        .WithMany()
                        .HasForeignKey("ComponentProductComponentId");

                    b.HasOne("Shop.Core.Entites.Product", "Product")
                        .WithMany("CompatibleComponents")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("Shop.Core.Entites.ProductConfiguration", b =>
                {
                    b.HasOne("Shop.Core.Entites.Product", "BaseProduct")
                        .WithMany()
                        .HasForeignKey("BaseProductProductId");

                    b.HasOne("Shop.Core.Entites.Basket")
                        .WithMany("ProductConfigurations")
                        .HasForeignKey("BasketId");

                    b.HasOne("Shop.Core.Entites.Order")
                        .WithMany("Products")
                        .HasForeignKey("OrderId");
                });
        }
    }
}
