using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataCarPartCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CarPartCategory",
                columns: new[] { "Id", "CreatedAt", "PartCategory", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("12ca3969-c9ff-4b3e-91d0-1fe421c9d2f4"), new DateTimeOffset(new DateTime(2023, 10, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Electrical System", "Active", new DateTimeOffset(new DateTime(2023, 10, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("2d31f83e-1508-48ab-934c-93d46266b57b"), new DateTimeOffset(new DateTime(2023, 10, 4, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Transmission", "Inactive", new DateTimeOffset(new DateTime(2023, 10, 4, 11, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("2eaed576-3f1e-43aa-b92d-4b45990df71f"), new DateTimeOffset(new DateTime(2023, 10, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brake System", "Active", new DateTimeOffset(new DateTime(2023, 10, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("47b2ccc3-0570-4d9a-acbe-4d95d03001c7"), new DateTimeOffset(new DateTime(2023, 10, 7, 14, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Cooling System", "Active", new DateTimeOffset(new DateTime(2023, 10, 7, 14, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("69246d30-53c9-4804-a89b-f692919172de"), new DateTimeOffset(new DateTime(2023, 10, 9, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Steering System", "Inactive", new DateTimeOffset(new DateTime(2023, 10, 9, 16, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("a0eeb005-f9e8-49fa-ad32-de352a0a04ab"), new DateTimeOffset(new DateTime(2023, 10, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Engine Parts", "Active", new DateTimeOffset(new DateTime(2023, 10, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("ab9b4f29-fea5-4d09-a0b3-02dd5dedc6e5"), new DateTimeOffset(new DateTime(2023, 10, 10, 17, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Interior Parts", "Inactive", new DateTimeOffset(new DateTime(2023, 10, 10, 17, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("b88688ec-8e1c-46a2-999f-f1b8e92b8f24"), new DateTimeOffset(new DateTime(2023, 10, 6, 13, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Exhaust System", "Inactive", new DateTimeOffset(new DateTime(2023, 10, 6, 13, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("d8123055-c15d-4932-90ba-127e415c36b4"), new DateTimeOffset(new DateTime(2023, 10, 8, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Fuel System", "Active", new DateTimeOffset(new DateTime(2023, 10, 8, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("e0101ba3-df29-4df3-a0d1-68bb0853a86b"), new DateTimeOffset(new DateTime(2023, 10, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Suspension", "Active", new DateTimeOffset(new DateTime(2023, 10, 3, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarPartCategory",
                keyColumn: "Id",
                keyValue: new Guid("12ca3969-c9ff-4b3e-91d0-1fe421c9d2f4"));

            migrationBuilder.DeleteData(
                table: "CarPartCategory",
                keyColumn: "Id",
                keyValue: new Guid("2d31f83e-1508-48ab-934c-93d46266b57b"));

            migrationBuilder.DeleteData(
                table: "CarPartCategory",
                keyColumn: "Id",
                keyValue: new Guid("2eaed576-3f1e-43aa-b92d-4b45990df71f"));

            migrationBuilder.DeleteData(
                table: "CarPartCategory",
                keyColumn: "Id",
                keyValue: new Guid("47b2ccc3-0570-4d9a-acbe-4d95d03001c7"));

            migrationBuilder.DeleteData(
                table: "CarPartCategory",
                keyColumn: "Id",
                keyValue: new Guid("69246d30-53c9-4804-a89b-f692919172de"));

            migrationBuilder.DeleteData(
                table: "CarPartCategory",
                keyColumn: "Id",
                keyValue: new Guid("a0eeb005-f9e8-49fa-ad32-de352a0a04ab"));

            migrationBuilder.DeleteData(
                table: "CarPartCategory",
                keyColumn: "Id",
                keyValue: new Guid("ab9b4f29-fea5-4d09-a0b3-02dd5dedc6e5"));

            migrationBuilder.DeleteData(
                table: "CarPartCategory",
                keyColumn: "Id",
                keyValue: new Guid("b88688ec-8e1c-46a2-999f-f1b8e92b8f24"));

            migrationBuilder.DeleteData(
                table: "CarPartCategory",
                keyColumn: "Id",
                keyValue: new Guid("d8123055-c15d-4932-90ba-127e415c36b4"));

            migrationBuilder.DeleteData(
                table: "CarPartCategory",
                keyColumn: "Id",
                keyValue: new Guid("e0101ba3-df29-4df3-a0d1-68bb0853a86b"));
        }
    }
}
