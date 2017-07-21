using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Infrastructure.Data.Migrations
{
    public partial class ChangePriceStorage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PricePreTax",
                table: "ProductComponents",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "PricePreTax",
                table: "Products",
                newName: "Price");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "ProductComponents",
                newName: "PricePreTax");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "PricePreTax");
        }
    }
}
