using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataProductHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductHistory",
                columns: new[] { "Id", "CreatedAt", "ProductId", "ProductPrice", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("2254581b-c244-4c41-b5e4-c353629c2105"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"), 300m, "None", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("22d61e55-50e5-4dcd-bf40-209fc2fcae12"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("cee5a4d8-de84-4482-9da9-302e2290cb0f"), 520m, "None", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("537c1813-334d-41c0-987b-0ed1509475f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("e9a7beda-ff63-4ac5-92cb-b7fa152c41c2"), 200m, "None", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("72d247fb-5249-4ce1-a400-fce2559e7db0"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("ac103ccc-bd82-44ca-adb7-5b478b95965a"), 1200m, "None", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("97b8ca2f-9784-4262-a57e-5695f3f0f642"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("ac103ccc-bd82-44ca-adb7-5b478b95965a"), 450m, "None", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e5e319f9-ef2a-4ab7-a847-5f0d3c7a1caf"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"), 150m, "None", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e9a0d0d3-3a43-406a-b465-b630c5d93f6f"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"), 500m, "None", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductHistory",
                keyColumn: "Id",
                keyValue: new Guid("2254581b-c244-4c41-b5e4-c353629c2105"));

            migrationBuilder.DeleteData(
                table: "ProductHistory",
                keyColumn: "Id",
                keyValue: new Guid("22d61e55-50e5-4dcd-bf40-209fc2fcae12"));

            migrationBuilder.DeleteData(
                table: "ProductHistory",
                keyColumn: "Id",
                keyValue: new Guid("537c1813-334d-41c0-987b-0ed1509475f7"));

            migrationBuilder.DeleteData(
                table: "ProductHistory",
                keyColumn: "Id",
                keyValue: new Guid("72d247fb-5249-4ce1-a400-fce2559e7db0"));

            migrationBuilder.DeleteData(
                table: "ProductHistory",
                keyColumn: "Id",
                keyValue: new Guid("97b8ca2f-9784-4262-a57e-5695f3f0f642"));

            migrationBuilder.DeleteData(
                table: "ProductHistory",
                keyColumn: "Id",
                keyValue: new Guid("e5e319f9-ef2a-4ab7-a847-5f0d3c7a1caf"));

            migrationBuilder.DeleteData(
                table: "ProductHistory",
                keyColumn: "Id",
                keyValue: new Guid("e9a0d0d3-3a43-406a-b465-b630c5d93f6f"));
        }
    }
}
