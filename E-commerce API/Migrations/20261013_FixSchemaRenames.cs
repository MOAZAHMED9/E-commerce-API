using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commerce_API.Migrations
{
    public partial class FixSchemaRenames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Non-destructive renames to align DB with corrected model names.
            migrationBuilder.RenameTable(name: "Categore", newName: "Categories");

            // Rename Products foreign key column + index
            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoreId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.RenameColumn(name: "CategoreId", table: "Products", newName: "CategoryId");

            // Orders: rename columns
            migrationBuilder.RenameColumn(name: "stutes", table: "Order", newName: "Status");
            migrationBuilder.RenameColumn(name: "totalPrice", table: "Order", newName: "TotalPrice");
            migrationBuilder.RenameColumn(name: "shippingAddress", table: "Order", newName: "ShippingAddress");

            // CartItems: quantity -> Quantity
            migrationBuilder.RenameColumn(name: "quantity", table: "CartItems", newName: "Quantity");

            // Reviews: rate/comment -> Rating/Comment
            migrationBuilder.RenameColumn(name: "rate", table: "Reviews", newName: "Rating");
            migrationBuilder.RenameColumn(name: "comment", table: "Reviews", newName: "Comment");

            // Users: Password -> PasswordHash
            migrationBuilder.RenameColumn(name: "Password", table: "Users", newName: "PasswordHash");

            // Change unique index on Reviews to include OrderId. Drop old index if present.
            try
            {
                migrationBuilder.DropIndex(name: "IX_Reviews_UserId_ProductId", table: "Reviews");
            }
            catch { }

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId_ProductId_OrderId",
                table: "Reviews",
                columns: new[] { "UserId", "ProductId", "OrderId" },
                unique: true,
                filter: "[IsDeleted] = 0");

            // Expand PasswordHash capacity (non-destructive for existing shorter values)
            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Revert index changes
            try
            {
                migrationBuilder.DropIndex(name: "IX_Reviews_UserId_ProductId_OrderId", table: "Reviews");
            }
            catch { }

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId_ProductId",
                table: "Reviews",
                columns: new[] { "UserId", "ProductId" },
                unique: true);

            // Revert column renames
            migrationBuilder.RenameColumn(name: "PasswordHash", table: "Users", newName: "Password");

            migrationBuilder.RenameColumn(name: "Comment", table: "Reviews", newName: "comment");
            migrationBuilder.RenameColumn(name: "Rating", table: "Reviews", newName: "rate");

            migrationBuilder.RenameColumn(name: "Quantity", table: "CartItems", newName: "quantity");

            migrationBuilder.RenameColumn(name: "ShippingAddress", table: "Order", newName: "shippingAddress");
            migrationBuilder.RenameColumn(name: "TotalPrice", table: "Order", newName: "totalPrice");
            migrationBuilder.RenameColumn(name: "Status", table: "Order", newName: "stutes");

            migrationBuilder.RenameColumn(name: "CategoryId", table: "Products", newName: "CategoreId");
            migrationBuilder.RenameIndex(name: "IX_Products_CategoryId", table: "Products", newName: "IX_Products_CategoreId");

            migrationBuilder.RenameTable(name: "Categories", newName: "Categore");

            // Revert Password column size
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);
        }
    }
}
