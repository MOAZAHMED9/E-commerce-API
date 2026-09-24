using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_commerce_API.Migrations
{
    /// <inheritdoc />
    public partial class BuildDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categore", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    CategoreId = table.Column<int>(type: "int", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categore_CategoreId",
                        column: x => x.CategoreId,
                        principalTable: "Categore",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    totalPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    stutes = table.Column<int>(type: "int", nullable: false),
                    shippingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    priceAtPurchase = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rate = table.Column<int>(type: "int", nullable: false),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categore",
                columns: new[] { "Id", "CreateAt", "CreateBy", "Description", "Name", "UpdateAt", "UpdateBy" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622), "System", "Electronic devices and accessories", "Electronics", null, null },
                    { 2, new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622), "System", "Men and women clothes", "Clothes", null, null },
                    { 3, new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622), "System", "Home and kitchen appliances", "Home Appliances", null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateAt", "CreateBy", "Email", "IsActive", "Password", "Phone", "Role", "UpdateAt", "UpdateBy", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622), "System", "admin@example.com", true, "Admin123", "01012345678", 2, null, null, "Admin" },
                    { 2, new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622), "System", "moaz@example.com", true, "Customer123", "01112345678", 1, null, null, "MoazAhmed" },
                    { 3, new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622), "System", "ahmed@example.com", true, "Customer456", "01212345678", 1, null, null, "AhmedAli" }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "CreateAt", "CreateBy", "UpdateAt", "UpdateBy", "UserId", "shippingAddress", "stutes", "totalPrice" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622), "System", null, null, 2, "Cairo, Egypt", 3, 50000m },
                    { 2, new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622), "System", null, null, 3, "Giza, Egypt", 1, 1800m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoreId", "CreateAt", "CreateBy", "Description", "IsAvailable", "Name", "Price", "Stock", "UpdateAt", "UpdateBy" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622), "System", "Apple iPhone 15 128GB", true, "iPhone 15", 45000m, 10, null, null },
                    { 2, 1, new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622), "System", "Samsung Galaxy S24 256GB", true, "Samsung Galaxy S24", 35000m, 15, null, null },
                    { 3, 1, new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622), "System", "Bluetooth wireless headphones", true, "Wireless Headphones", 2500m, 30, null, null },
                    { 4, 2, new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622), "System", "Cotton T-Shirt", true, "T-Shirt", 600m, 50, null, null },
                    { 5, 3, new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622), "System", "Automatic coffee machine", true, "Coffee Machine", 5000m, 8, null, null }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "Id", "CreateAt", "CreateBy", "UpdateAt", "UpdateBy", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622), "System", null, null, 2 },
                    { 2, new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622), "System", null, null, 3 }
                });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "Id", "CreateAt", "CreateBy", "ProductId", "ShoppingCartId", "UpdateAt", "UpdateBy", "quantity" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622), "System", 1, 1, null, null, 1 },
                    { 2, new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622), "System", 3, 1, null, null, 2 },
                    { 3, new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622), "System", 4, 2, null, null, 3 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "CreateAt", "CreateBy", "OrderId", "ProductId", "Quantity", "UpdateAt", "UpdateBy", "priceAtPurchase" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622), "System", 1, 1, 1, null, null, 45000m },
                    { 2, new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622), "System", 1, 3, 2, null, null, 2500m },
                    { 3, new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622), "System", 2, 4, 3, null, null, 600m }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "CreateAt", "CreateBy", "OrderId", "ProductId", "UpdateAt", "UpdateBy", "UserId", "comment", "rate" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622), "System", 1, 1, null, null, 2, "Excellent product and very good quality.", 9 },
                    { 2, new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622), "System", 2, 4, null, null, 3, "Good quality and comfortable.", 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ShoppingCartId",
                table: "CartItems",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoreId",
                table: "Products",
                column: "CategoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IsAvailable",
                table: "Products",
                column: "IsAvailable");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Price",
                table: "Products",
                column: "Price");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_OrderId",
                table: "Reviews",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId_ProductId",
                table: "Reviews",
                columns: new[] { "UserId", "ProductId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_UserId",
                table: "ShoppingCarts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categore");
        }
    }
}
