using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataProductImg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductImage",
                columns: new[] { "Id", "CreatedAt", "ImageId", "ImageLink", "ProductId", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("306fd99b-7914-4c4d-a92b-f3d998f3b772"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "N/A", "https://example.com/images/5.jpg", new Guid("e9a7beda-ff63-4ac5-92cb-b7fa152c41c2"), "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("71bd8b35-0d22-4783-8638-78eb48bd5629"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "N/A", "https://example.com/images/1.jpg", new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"), "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("867a1f57-a7dc-4d8a-95f0-9b1e1b086809"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "N/A", "https://example.com/images/3.jpg", new Guid("ac103ccc-bd82-44ca-adb7-5b478b95965a"), "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("91f09ff2-24ed-4d60-b3c5-5e76204a90ff"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "N/A", "https://example.com/images/2.jpg", new Guid("cee5a4d8-de84-4482-9da9-302e2290cb0f"), "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b3126c73-0e1e-40fd-8dec-f7c4d2789dd9"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "N/A", "https://example.com/images/4.jpg", new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"), "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: new Guid("306fd99b-7914-4c4d-a92b-f3d998f3b772"));

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: new Guid("71bd8b35-0d22-4783-8638-78eb48bd5629"));

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: new Guid("867a1f57-a7dc-4d8a-95f0-9b1e1b086809"));

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: new Guid("91f09ff2-24ed-4d60-b3c5-5e76204a90ff"));

            migrationBuilder.DeleteData(
                table: "ProductImage",
                keyColumn: "Id",
                keyValue: new Guid("b3126c73-0e1e-40fd-8dec-f7c4d2789dd9"));
        }
    }
}
