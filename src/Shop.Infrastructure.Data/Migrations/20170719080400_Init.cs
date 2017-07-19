using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Shop.Infrastructure.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerReference = table.Column<string>(maxLength: 25, nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    EmailAddress = table.Column<string>(maxLength: 250, nullable: true),
                    Name = table.Column<string>(maxLength: 250, nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    TelephoneNumber = table.Column<string>(maxLength: 250, nullable: true),
                    Title = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "DiscountCodes",
                columns: table => new
                {
                    DiscountCodeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimLimit = table.Column<int>(nullable: false),
                    Code = table.Column<string>(maxLength: 25, nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    DiscountAmount = table.Column<decimal>(nullable: false),
                    DiscountCodeReference = table.Column<string>(maxLength: 25, nullable: false),
                    DiscountCodeType = table.Column<int>(nullable: false),
                    NumberClaimed = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountCodes", x => x.DiscountCodeId);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    PaymentReference = table.Column<string>(maxLength: 100, nullable: false),
                    PaymentServiceProvider = table.Column<int>(nullable: false),
                    PspChargeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AvailableForOrder = table.Column<bool>(nullable: false),
                    Configureable = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    PricePreTax = table.Column<decimal>(nullable: false),
                    ProductDescription = table.Column<string>(maxLength: 10000, nullable: false),
                    ProductName = table.Column<string>(maxLength: 100, nullable: false),
                    ProductReference = table.Column<string>(maxLength: 25, nullable: false),
                    ProductShortDescription = table.Column<string>(maxLength: 500, nullable: false),
                    ShippingWeightKg = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "ShippingDetails",
                columns: table => new
                {
                    ShippingDetailsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    DeliveredDate = table.Column<DateTime>(nullable: true),
                    EstimatedDeliveryDate = table.Column<DateTime>(nullable: true),
                    EstimatedShippingDate = table.Column<DateTime>(nullable: true),
                    PricePaid = table.Column<decimal>(nullable: false),
                    ShippedDate = table.Column<DateTime>(nullable: true),
                    ShippingDetailsReference = table.Column<string>(maxLength: 25, nullable: false),
                    ShippingMethod = table.Column<int>(nullable: false),
                    ShippingProvider = table.Column<int>(nullable: false),
                    TrackingReference = table.Column<string>(nullable: true),
                    TrackingUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingDetails", x => x.ShippingDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressLine1 = table.Column<string>(maxLength: 100, nullable: false),
                    AddressLine2 = table.Column<string>(maxLength: 100, nullable: true),
                    AddressLine3 = table.Column<string>(maxLength: 100, nullable: true),
                    AddressLine4 = table.Column<string>(maxLength: 100, nullable: true),
                    AddressReference = table.Column<string>(maxLength: 25, nullable: false),
                    CountryCode = table.Column<string>(maxLength: 10, nullable: true),
                    County = table.Column<string>(maxLength: 100, nullable: true),
                    CustomerId = table.Column<int>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Postcode = table.Column<string>(maxLength: 25, nullable: true),
                    Udprn = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Addresses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    BasketId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BasketReference = table.Column<string>(maxLength: 25, nullable: false),
                    CustomerId = table.Column<int>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    DiscountCodeId = table.Column<int>(nullable: true),
                    ShippingMethod = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.BasketId);
                    table.ForeignKey(
                        name: "FK_Baskets_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Baskets_DiscountCodes_DiscountCodeId",
                        column: x => x.DiscountCodeId,
                        principalTable: "DiscountCodes",
                        principalColumn: "DiscountCodeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComponentSlot",
                columns: table => new
                {
                    ComponentSlotId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComponentSlotReference = table.Column<string>(maxLength: 25, nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    IsDirty = table.Column<bool>(nullable: false),
                    ProductId = table.Column<int>(nullable: true),
                    Required = table.Column<bool>(nullable: false),
                    SlotName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentSlot", x => x.ComponentSlotId);
                    table.ForeignKey(
                        name: "FK_ComponentSlot_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BillingAddressAddressId = table.Column<int>(nullable: true),
                    CustomerId = table.Column<int>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    DiscountCodeId = table.Column<int>(nullable: true),
                    OrderReference = table.Column<string>(maxLength: 25, nullable: false),
                    PaymentId = table.Column<int>(nullable: true),
                    ShippingAddressAddressId = table.Column<int>(nullable: true),
                    ShippingMethodShippingDetailsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Addresses_BillingAddressAddressId",
                        column: x => x.BillingAddressAddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_DiscountCodes_DiscountCodeId",
                        column: x => x.DiscountCodeId,
                        principalTable: "DiscountCodes",
                        principalColumn: "DiscountCodeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Addresses_ShippingAddressAddressId",
                        column: x => x.ShippingAddressAddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_ShippingDetails_ShippingMethodShippingDetailsId",
                        column: x => x.ShippingMethodShippingDetailsId,
                        principalTable: "ShippingDetails",
                        principalColumn: "ShippingDetailsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductConfigurations",
                columns: table => new
                {
                    ProductConfigurationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BaseProductProductId = table.Column<int>(nullable: true),
                    BasketId = table.Column<int>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    OrderId = table.Column<int>(nullable: true),
                    ProductConfigurationReference = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductConfigurations", x => x.ProductConfigurationId);
                    table.ForeignKey(
                        name: "FK_ProductConfigurations_Products_BaseProductProductId",
                        column: x => x.BaseProductProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductConfigurations_Baskets_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Baskets",
                        principalColumn: "BasketId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductConfigurations_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductComponents",
                columns: table => new
                {
                    ProductComponentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AvailableForOrder = table.Column<bool>(nullable: false),
                    ComponentSlotId = table.Column<int>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    PricePreTax = table.Column<decimal>(nullable: false),
                    ProductComponentDescription = table.Column<string>(maxLength: 10000, nullable: false),
                    ProductComponentName = table.Column<string>(maxLength: 100, nullable: false),
                    ProductComponentReference = table.Column<string>(maxLength: 25, nullable: false),
                    ProductConfigurationId = table.Column<int>(nullable: true),
                    ShippingWeightKg = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductComponents", x => x.ProductComponentId);
                    table.ForeignKey(
                        name: "FK_ProductComponents_ComponentSlot_ComponentSlotId",
                        column: x => x.ComponentSlotId,
                        principalTable: "ComponentSlot",
                        principalColumn: "ComponentSlotId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductComponents_ProductConfigurations_ProductConfigurationId",
                        column: x => x.ProductConfigurationId,
                        principalTable: "ProductConfigurations",
                        principalColumn: "ProductConfigurationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    MediaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Index = table.Column<int>(nullable: false),
                    MediaReference = table.Column<string>(maxLength: 25, nullable: false),
                    MediaType = table.Column<int>(nullable: false),
                    ProductComponentId = table.Column<int>(nullable: true),
                    ProductId = table.Column<int>(nullable: true),
                    Url = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.MediaId);
                    table.ForeignKey(
                        name: "FK_Media_ProductComponents_ProductComponentId",
                        column: x => x.ProductComponentId,
                        principalTable: "ProductComponents",
                        principalColumn: "ProductComponentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Media_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductComponentCompatibilities",
                columns: table => new
                {
                    ProductComponentCompatibilityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComponentProductComponentId = table.Column<int>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    ProductComponentCompatibilityReference = table.Column<string>(maxLength: 25, nullable: false),
                    ProductId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductComponentCompatibilities", x => x.ProductComponentCompatibilityId);
                    table.ForeignKey(
                        name: "FK_ProductComponentCompatibilities_ProductComponents_ComponentProductComponentId",
                        column: x => x.ComponentProductComponentId,
                        principalTable: "ProductComponents",
                        principalColumn: "ProductComponentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductComponentCompatibilities_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_CustomerId",
                table: "Baskets",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_DiscountCodeId",
                table: "Baskets",
                column: "DiscountCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentSlot_ProductId",
                table: "ComponentSlot",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Media_ProductComponentId",
                table: "Media",
                column: "ProductComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_Media_ProductId",
                table: "Media",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BillingAddressAddressId",
                table: "Orders",
                column: "BillingAddressAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DiscountCodeId",
                table: "Orders",
                column: "DiscountCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentId",
                table: "Orders",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippingAddressAddressId",
                table: "Orders",
                column: "ShippingAddressAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippingMethodShippingDetailsId",
                table: "Orders",
                column: "ShippingMethodShippingDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductComponents_ComponentSlotId",
                table: "ProductComponents",
                column: "ComponentSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductComponents_ProductConfigurationId",
                table: "ProductComponents",
                column: "ProductConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductComponentCompatibilities_ComponentProductComponentId",
                table: "ProductComponentCompatibilities",
                column: "ComponentProductComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductComponentCompatibilities_ProductId",
                table: "ProductComponentCompatibilities",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductConfigurations_BaseProductProductId",
                table: "ProductConfigurations",
                column: "BaseProductProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductConfigurations_BasketId",
                table: "ProductConfigurations",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductConfigurations_OrderId",
                table: "ProductConfigurations",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropTable(
                name: "ProductComponentCompatibilities");

            migrationBuilder.DropTable(
                name: "ProductComponents");

            migrationBuilder.DropTable(
                name: "ComponentSlot");

            migrationBuilder.DropTable(
                name: "ProductConfigurations");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "DiscountCodes");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "ShippingDetails");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
