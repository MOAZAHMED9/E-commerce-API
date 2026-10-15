using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_commerce_API.Migrations
{
    /// <inheritdoc />
    public partial class updateagent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categore_CategoreId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Categore");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_UserId_ProductId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems");

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "comment",
                table: "Reviews",
                newName: "Comment");

            migrationBuilder.RenameColumn(
                name: "rate",
                table: "Reviews",
                newName: "Rating");

            migrationBuilder.RenameColumn(
                name: "CategoreId",
                table: "Products",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoreId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.RenameColumn(
                name: "priceAtPurchase",
                table: "OrderItems",
                newName: "PriceAtPurchase");

            migrationBuilder.RenameColumn(
                name: "totalPrice",
                table: "Order",
                newName: "TotalPrice");

            migrationBuilder.RenameColumn(
                name: "shippingAddress",
                table: "Order",
                newName: "ShippingAddress");

            migrationBuilder.RenameColumn(
                name: "stutes",
                table: "Order",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "CartItems",
                newName: "Quantity");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Reviews",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Categorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorys", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId_ProductId_OrderId",
                table: "Reviews",
                columns: new[] { "UserId", "ProductId", "OrderId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId_ShoppingCartId",
                table: "CartItems",
                columns: new[] { "ProductId", "ShoppingCartId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categorys_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categorys_CategoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Categorys");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_UserId_ProductId_OrderId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_ProductId_ShoppingCartId",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "Reviews",
                newName: "comment");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Reviews",
                newName: "rate");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Products",
                newName: "CategoreId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                newName: "IX_Products_CategoreId");

            migrationBuilder.RenameColumn(
                name: "PriceAtPurchase",
                table: "OrderItems",
                newName: "priceAtPurchase");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "Order",
                newName: "totalPrice");

            migrationBuilder.RenameColumn(
                name: "ShippingAddress",
                table: "Order",
                newName: "shippingAddress");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Order",
                newName: "stutes");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "CartItems",
                newName: "quantity");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Users",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "comment",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.CreateTable(
                name: "Categore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categore", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categore",
                columns: new[] { "Id", "CreateAt", "CreateBy", "Description", "IsDeleted", "Name", "UpdateAt", "UpdateBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), "System", "Electronic devices and accessories", false, "Electronics", null, null },
                    { 2, new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), "System", "Men and women clothes", false, "Clothes", null, null },
                    { 3, new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), "System", "Home and kitchen appliances", false, "Home Appliances", null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateAt", "CreateBy", "Email", "IsActive", "IsDeleted", "Password", "Phone", "RefreshTokenExpiresAt", "RefreshTokenHash", "RefreshTokenRevokedAt", "Role", "UpdateAt", "UpdateBy", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), "System", "admin@example.com", true, false, "$2a$11$j8PnFPfkEgzxZRnIKxt9I.KEeRpDDC8gkwWN.ne1yg62eRBZMlBJG", "01012345678", null, null, null, 2, null, null, "Admin" },
                    { 2, new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), "System", "moaz@example.com", true, false, "$2a$11$AK9n1QKCfpcZcsm8eog7UOWNMjH1dBQiWVST5LEkr197q0tbwaCga", "01112345678", null, null, null, 1, null, null, "MoazAhmed" },
                    { 3, new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), "System", "ahmed@example.com", true, false, "$2a$11$SSjPkOkWdESUekbbO0s7EesXaSUF8ChGrkGzwCWkTxyeWkVa533qW", "01212345678", null, null, null, 1, null, null, "AhmedAli" }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "CreateAt", "CreateBy", "IsDeleted", "UpdateAt", "UpdateBy", "UserId", "shippingAddress", "stutes", "totalPrice" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), "System", false, null, null, 2, "Cairo, Egypt", 3, 50000m },
                    { 2, new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), "System", false, null, null, 3, "Giza, Egypt", 1, 1800m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoreId", "CreateAt", "CreateBy", "Description", "IsAvailable", "IsDeleted", "Name", "Price", "Stock", "UpdateAt", "UpdateBy" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), "System", "Apple iPhone 15 128GB", true, false, "iPhone 15", 45000m, 10, null, null },
                    { 2, 1, new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), "System", "Samsung Galaxy S24 256GB", true, false, "Samsung Galaxy S24", 35000m, 15, null, null },
                    { 3, 1, new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), "System", "Bluetooth wireless headphones", true, false, "Wireless Headphones", 2500m, 30, null, null },
                    { 4, 2, new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), "System", "Cotton T-Shirt", true, false, "T-Shirt", 600m, 50, null, null },
                    { 5, 3, new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), "System", "Automatic coffee machine", true, false, "Coffee Machine", 5000m, 8, null, null }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "Id", "CreateAt", "CreateBy", "IsDeleted", "UpdateAt", "UpdateBy", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), "System", false, null, null, 2 },
                    { 2, new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), "System", false, null, null, 3 }
                });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "Id", "CreateAt", "CreateBy", "IsDeleted", "ProductId", "ShoppingCartId", "UpdateAt", "UpdateBy", "quantity" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), "System", false, 1, 1, null, null, 1 },
                    { 2, new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), "System", false, 3, 1, null, null, 2 },
                    { 3, new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), "System", false, 4, 2, null, null, 3 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "CreateAt", "CreateBy", "IsDeleted", "OrderId", "ProductId", "Quantity", "UpdateAt", "UpdateBy", "priceAtPurchase" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), "System", false, 1, 1, 1, null, null, 45000m },
                    { 2, new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), "System", false, 1, 3, 2, null, null, 2500m },
                    { 3, new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), "System", false, 2, 4, 3, null, null, 600m }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "CreateAt", "CreateBy", "IsDeleted", "OrderId", "ProductId", "UpdateAt", "UpdateBy", "UserId", "comment", "rate" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), "System", false, 1, 1, null, null, 2, "Excellent product and very good quality.", 9 },
                    { 2, new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), "System", false, 2, 4, null, null, 3, "Good quality and comfortable.", 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId_ProductId",
                table: "Reviews",
                columns: new[] { "UserId", "ProductId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categore_CategoreId",
                table: "Products",
                column: "CategoreId",
                principalTable: "Categore",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
