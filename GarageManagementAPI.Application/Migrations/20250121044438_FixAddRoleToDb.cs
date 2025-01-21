using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class FixAddRoleToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2bad4a96-6dff-4fa3-9c2e-6899264fb739", null, "Cashier", "CASHIER" },
                    { "3c5c548b-b789-41b5-b216-48ddfb5e732a", null, "Mechanic", "MECHANIC" },
                    { "7d2b39a7-3d9d-4583-acd5-985611a29a5b", null, "Customer", "CUSTOMER" },
                    { "b10aa072-2522-41d9-8e12-c20f28082a0e", null, "WarehouseManager", "WAREHOUSEMANAGER" },
                    { "ef3629ba-332e-4c46-9fa8-54444803f925", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2bad4a96-6dff-4fa3-9c2e-6899264fb739");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "3c5c548b-b789-41b5-b216-48ddfb5e732a");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "7d2b39a7-3d9d-4583-acd5-985611a29a5b");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "b10aa072-2522-41d9-8e12-c20f28082a0e");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ef3629ba-332e-4c46-9fa8-54444803f925");
        }
    }
}
