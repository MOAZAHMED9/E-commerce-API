using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commerce_API.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnIsDeletedAndGloubalFilter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ShoppingCarts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Reviews",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OrderItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Order",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Categore",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CartItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), false });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), false });

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), false });

            migrationBuilder.UpdateData(
                table: "Categore",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), false });

            migrationBuilder.UpdateData(
                table: "Categore",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), false });

            migrationBuilder.UpdateData(
                table: "Categore",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), false });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), false });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), false });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), false });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), false });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreateAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), false });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), false });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), false });

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), false });

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "IsDeleted" },
                values: new object[] { new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), false });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "IsDeleted", "Password" },
                values: new object[] { new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), false, "$2a$11$j8PnFPfkEgzxZRnIKxt9I.KEeRpDDC8gkwWN.ne1yg62eRBZMlBJG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "IsDeleted", "Password" },
                values: new object[] { new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), false, "$2a$11$AK9n1QKCfpcZcsm8eog7UOWNMjH1dBQiWVST5LEkr197q0tbwaCga" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateAt", "IsDeleted", "Password" },
                values: new object[] { new DateTime(2026, 9, 25, 15, 5, 42, 734, DateTimeKind.Utc).AddTicks(8165), false, "$2a$11$SSjPkOkWdESUekbbO0s7EesXaSUF8ChGrkGzwCWkTxyeWkVa533qW" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Categore");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CartItems");

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 12, 4, 45, 249, DateTimeKind.Utc).AddTicks(4676));

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 12, 4, 45, 249, DateTimeKind.Utc).AddTicks(4676));

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 12, 4, 45, 249, DateTimeKind.Utc).AddTicks(4676));

            migrationBuilder.UpdateData(
                table: "Categore",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 12, 4, 45, 249, DateTimeKind.Utc).AddTicks(4676));

            migrationBuilder.UpdateData(
                table: "Categore",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 12, 4, 45, 249, DateTimeKind.Utc).AddTicks(4676));

            migrationBuilder.UpdateData(
                table: "Categore",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 12, 4, 45, 249, DateTimeKind.Utc).AddTicks(4676));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 12, 4, 45, 249, DateTimeKind.Utc).AddTicks(4676));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 12, 4, 45, 249, DateTimeKind.Utc).AddTicks(4676));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 12, 4, 45, 249, DateTimeKind.Utc).AddTicks(4676));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 12, 4, 45, 249, DateTimeKind.Utc).AddTicks(4676));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 12, 4, 45, 249, DateTimeKind.Utc).AddTicks(4676));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 12, 4, 45, 249, DateTimeKind.Utc).AddTicks(4676));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 12, 4, 45, 249, DateTimeKind.Utc).AddTicks(4676));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 12, 4, 45, 249, DateTimeKind.Utc).AddTicks(4676));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 12, 4, 45, 249, DateTimeKind.Utc).AddTicks(4676));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 12, 4, 45, 249, DateTimeKind.Utc).AddTicks(4676));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 12, 4, 45, 249, DateTimeKind.Utc).AddTicks(4676));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 12, 4, 45, 249, DateTimeKind.Utc).AddTicks(4676));

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 12, 4, 45, 249, DateTimeKind.Utc).AddTicks(4676));

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 12, 4, 45, 249, DateTimeKind.Utc).AddTicks(4676));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "Password" },
                values: new object[] { new DateTime(2026, 9, 24, 12, 4, 45, 249, DateTimeKind.Utc).AddTicks(4676), "Admin123" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "Password" },
                values: new object[] { new DateTime(2026, 9, 24, 12, 4, 45, 249, DateTimeKind.Utc).AddTicks(4676), "Customer123" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateAt", "Password" },
                values: new object[] { new DateTime(2026, 9, 24, 12, 4, 45, 249, DateTimeKind.Utc).AddTicks(4676), "Customer456" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email");
        }
    }
}
