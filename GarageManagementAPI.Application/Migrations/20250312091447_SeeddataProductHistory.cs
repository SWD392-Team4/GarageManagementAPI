using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class SeeddataProductHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductHistory",
                columns: new[] { "Id", "CreatedAt", "ProductId", "ProductPrice" },
                values: new object[,]
                {
                    { new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"), 1200m },
                    { new Guid("537c1813-334d-41c0-987b-0ed1509475f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("e9a7beda-ff63-4ac5-92cb-b7fa152c41c2"), 200m },
                    { new Guid("cee5a4d8-de84-4482-9da9-302e2290cb0f"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"), 500m },
                    { new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"), 520m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductHistory",
                keyColumn: "Id",
                keyValue: new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"));

            migrationBuilder.DeleteData(
                table: "ProductHistory",
                keyColumn: "Id",
                keyValue: new Guid("537c1813-334d-41c0-987b-0ed1509475f7"));

            migrationBuilder.DeleteData(
                table: "ProductHistory",
                keyColumn: "Id",
                keyValue: new Guid("cee5a4d8-de84-4482-9da9-302e2290cb0f"));

            migrationBuilder.DeleteData(
                table: "ProductHistory",
                keyColumn: "Id",
                keyValue: new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"));
        }
    }
}
