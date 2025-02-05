using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeInfoConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EmployeeInfo",
                columns: new[] { "Id", "CitizenIdentification", "CreatedAt", "DateOfBirth", "Gender", "UpdatedAt", "WorkplaceId" },
                values: new object[,]
                {
                    { new Guid("1230a288-3e5e-4ee1-a75c-3fd7af6480a0"), "1234", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), new DateOnly(1, 1, 1), true, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), new Guid("e3dbf2c8-899d-4b2a-91f7-d2315d3f3bcb") },
                    { new Guid("b78245a2-a2bf-45b4-8572-b2c3f1948629"), "5124", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), new DateOnly(1, 1, 1), true, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), new Guid("e3dbf2c8-899d-4b2a-91f7-d2315d3f3bcb") },
                    { new Guid("de0d20e6-17e6-40e8-8274-c89a66e64fa5"), "782135", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), new DateOnly(1, 1, 1), true, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), new Guid("c1aeb9e5-8c74-4b09-bc57-d4c3df7857f9") },
                    { new Guid("e2060ff5-5fb9-4b20-a11a-bf6ae4716ad5"), "616747", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), new DateOnly(1, 1, 1), false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), new Guid("c1aeb9e5-8c74-4b09-bc57-d4c3df7857f9") },
                    { new Guid("f8a4e60d-3113-4f25-8477-be205b0860c9"), "66316", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), new DateOnly(1, 1, 1), true, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), new Guid("e3dbf2c8-899d-4b2a-91f7-d2315d3f3bcb") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeInfo",
                keyColumn: "Id",
                keyValue: new Guid("1230a288-3e5e-4ee1-a75c-3fd7af6480a0"));

            migrationBuilder.DeleteData(
                table: "EmployeeInfo",
                keyColumn: "Id",
                keyValue: new Guid("b78245a2-a2bf-45b4-8572-b2c3f1948629"));

            migrationBuilder.DeleteData(
                table: "EmployeeInfo",
                keyColumn: "Id",
                keyValue: new Guid("de0d20e6-17e6-40e8-8274-c89a66e64fa5"));

            migrationBuilder.DeleteData(
                table: "EmployeeInfo",
                keyColumn: "Id",
                keyValue: new Guid("e2060ff5-5fb9-4b20-a11a-bf6ae4716ad5"));

            migrationBuilder.DeleteData(
                table: "EmployeeInfo",
                keyColumn: "Id",
                keyValue: new Guid("f8a4e60d-3113-4f25-8477-be205b0860c9"));
        }
    }
}
