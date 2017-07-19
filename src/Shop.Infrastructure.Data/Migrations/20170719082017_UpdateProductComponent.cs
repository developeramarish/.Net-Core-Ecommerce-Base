using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Infrastructure.Data.Migrations
{
    public partial class UpdateProductComponent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComponentSlot_Products_ProductId",
                table: "ComponentSlot");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductComponents_ComponentSlot_ComponentSlotId",
                table: "ProductComponents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComponentSlot",
                table: "ComponentSlot");

            migrationBuilder.DropColumn(
                name: "IsDirty",
                table: "ComponentSlot");

            migrationBuilder.RenameTable(
                name: "ComponentSlot",
                newName: "ComponentSlots");

            migrationBuilder.RenameIndex(
                name: "IX_ComponentSlot_ProductId",
                table: "ComponentSlots",
                newName: "IX_ComponentSlots_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComponentSlots",
                table: "ComponentSlots",
                column: "ComponentSlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComponentSlots_Products_ProductId",
                table: "ComponentSlots",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductComponents_ComponentSlots_ComponentSlotId",
                table: "ProductComponents",
                column: "ComponentSlotId",
                principalTable: "ComponentSlots",
                principalColumn: "ComponentSlotId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComponentSlots_Products_ProductId",
                table: "ComponentSlots");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductComponents_ComponentSlots_ComponentSlotId",
                table: "ProductComponents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComponentSlots",
                table: "ComponentSlots");

            migrationBuilder.RenameTable(
                name: "ComponentSlots",
                newName: "ComponentSlot");

            migrationBuilder.RenameIndex(
                name: "IX_ComponentSlots_ProductId",
                table: "ComponentSlot",
                newName: "IX_ComponentSlot_ProductId");

            migrationBuilder.AddColumn<bool>(
                name: "IsDirty",
                table: "ComponentSlot",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComponentSlot",
                table: "ComponentSlot",
                column: "ComponentSlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComponentSlot_Products_ProductId",
                table: "ComponentSlot",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductComponents_ComponentSlot_ComponentSlotId",
                table: "ProductComponents",
                column: "ComponentSlotId",
                principalTable: "ComponentSlot",
                principalColumn: "ComponentSlotId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
