using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "CreatedAt", "ProductBarcode", "ProductCategoryId", "ProductDescription", "ProductName", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"), new Guid("abadc9e1-c8e6-4f40-b078-47f609d1cf79"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "6291041500213", new Guid("c29a6297-20cd-449d-8ca8-6353e7cd4505"), "The Smartphone XYZ Pro is a premium device featuring a 6.7-inch AMOLED display with 4K resolution and HDR10+ technology. Powered by the Snapdragon 888 chipset, 12GB of RAM, and 256GB of internal storage, this phone delivers smooth performance for all tasks. The 108MP main camera supports 8K video recording, and the 5000mAh battery supports 65W fast charging.", "Toyota Camry", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("cee5a4d8-de84-4482-9da9-302e2290cb0f"), new Guid("855f8a55-c9d0-4532-81ee-6da2bd0db1f6"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "5901234123457", new Guid("40c29595-cbfe-4226-bbd4-61ac6874ffbc"), "The UltraBook 2023 is an ultra-thin and lightweight laptop, weighing just 1.2kg, with a 14-inch 2.5K resolution display. It is equipped with a 12th Gen Intel Core i7 processor, 16GB of RAM, and a 512GB SSD. With up to 12 hours of battery life and Thunderbolt 4 connectivity, it is perfect for mobile work and entertainment.", "Ford Mustang", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("e9a7beda-ff63-4ac5-92cb-b7fa152c41c2"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "4006381333931", new Guid("6e8f9461-9115-4847-83b9-60067db961ab"), "The Mirrorless Alpha Z9 is the perfect choice for professional photographers. With a 45MP full-frame sensor, 6K video recording, and 5-axis image stabilization, this camera delivers sharp and true-to-life image quality. It also offers a continuous shooting speed of up to 20 frames per second.", "Volkswagen Golf", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"), new Guid("abadc9e1-c8e6-4f40-b078-47f609d1cf79"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "9780201379624", new Guid("4584997b-918a-4422-90d9-434bf2315458"), "The SoundWave 360 Smart Speaker features an integrated AI virtual assistant and supports voice control. With 360-degree surround sound and 50W of power, it delivers an immersive audio experience. It connects wirelessly via Bluetooth 5.0 and Wi-Fi, and is compatible with smart home devices.", "Honda Civic", "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("cee5a4d8-de84-4482-9da9-302e2290cb0f"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("e9a7beda-ff63-4ac5-92cb-b7fa152c41c2"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"));
        }
    }
}
