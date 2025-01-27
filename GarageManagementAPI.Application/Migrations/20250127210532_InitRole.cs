using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class InitRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb739"), null, "Cashier", "CASHIER" },
                    { new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"), null, "Mechanic", "MECHANIC" },
                    { new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"), null, "Customer", "CUSTOMER" },
                    { new Guid("b10aa072-2522-41d9-8e12-c20f28082a0e"), null, "WarehouseManager", "WAREHOUSEMANAGER" },
                    { new Guid("ef3629ba-332e-4c46-9fa8-54444803f925"), null, "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb739"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b10aa072-2522-41d9-8e12-c20f28082a0e"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ef3629ba-332e-4c46-9fa8-54444803f925"));
        }
    }
}
