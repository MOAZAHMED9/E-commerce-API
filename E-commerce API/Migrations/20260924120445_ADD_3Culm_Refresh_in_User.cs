using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commerce_API.Migrations
{
    /// <inheritdoc />
    public partial class ADD_3Culm_Refresh_in_User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiresAt",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefreshTokenHash",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenRevokedAt",
                table: "Users",
                type: "datetime2",
                nullable: true);

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
                columns: new[] { "CreateAt", "RefreshTokenExpiresAt", "RefreshTokenHash", "RefreshTokenRevokedAt" },
                values: new object[] { new DateTime(2026, 9, 24, 12, 4, 45, 249, DateTimeKind.Utc).AddTicks(4676), null, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "RefreshTokenExpiresAt", "RefreshTokenHash", "RefreshTokenRevokedAt" },
                values: new object[] { new DateTime(2026, 9, 24, 12, 4, 45, 249, DateTimeKind.Utc).AddTicks(4676), null, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateAt", "RefreshTokenExpiresAt", "RefreshTokenHash", "RefreshTokenRevokedAt" },
                values: new object[] { new DateTime(2026, 9, 24, 12, 4, 45, 249, DateTimeKind.Utc).AddTicks(4676), null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiresAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RefreshTokenHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RefreshTokenRevokedAt",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622));

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622));

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622));

            migrationBuilder.UpdateData(
                table: "Categore",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622));

            migrationBuilder.UpdateData(
                table: "Categore",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622));

            migrationBuilder.UpdateData(
                table: "Categore",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622));

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622));

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2026, 9, 24, 10, 38, 34, 816, DateTimeKind.Utc).AddTicks(622));
        }
    }
}
