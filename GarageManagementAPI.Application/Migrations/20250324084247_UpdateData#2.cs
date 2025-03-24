using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class UpdateData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: new Guid("c9bb6d84-350a-4ecb-ad5c-51d1924efee1"));

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: new Guid("f4b8eff5-c7d2-4625-adb1-f4af19a922dd"));

            migrationBuilder.DeleteData(
                table: "ProductHistory",
                keyColumn: "Id",
                keyValue: new Guid("15516af1-3245-4926-8dfe-bea85b6ec125"));

            migrationBuilder.DeleteData(
                table: "ProductHistory",
                keyColumn: "Id",
                keyValue: new Guid("1b17747e-ae0a-4c6e-9ff7-d6539c6cd6b6"));

            migrationBuilder.DeleteData(
                table: "ProductHistory",
                keyColumn: "Id",
                keyValue: new Guid("423c3aa7-0281-4de1-95f2-53fe332417f2"));

            migrationBuilder.DeleteData(
                table: "ProductHistory",
                keyColumn: "Id",
                keyValue: new Guid("5047c4b3-458a-4fbe-8df4-35f4b23dc439"));

            migrationBuilder.DeleteData(
                table: "ProductHistory",
                keyColumn: "Id",
                keyValue: new Guid("77f4ebf6-ed84-4fc2-8a58-3419d1464ee4"));

            migrationBuilder.DeleteData(
                table: "ProductHistory",
                keyColumn: "Id",
                keyValue: new Guid("8258d59b-2955-4d2f-bced-ce747d6f303f"));

            migrationBuilder.DeleteData(
                table: "ProductHistory",
                keyColumn: "Id",
                keyValue: new Guid("913522ad-480e-4bc8-8932-79e3b4178016"));

            migrationBuilder.DeleteData(
                table: "ProductHistory",
                keyColumn: "Id",
                keyValue: new Guid("a660df09-451d-4f1e-bf73-152cd2ede38e"));

            migrationBuilder.DeleteData(
                table: "ProductHistory",
                keyColumn: "Id",
                keyValue: new Guid("d806f85f-da06-4030-b98c-3c5561c14305"));

            migrationBuilder.DeleteData(
                table: "ProductHistory",
                keyColumn: "Id",
                keyValue: new Guid("de79c933-78d0-4498-becf-97d7228d39fd"));

            migrationBuilder.DeleteData(
                table: "ProductHistory",
                keyColumn: "Id",
                keyValue: new Guid("f28b16c7-781c-4c11-9c31-1a3152c335e5"));

            migrationBuilder.DeleteData(
                table: "ProductHistory",
                keyColumn: "Id",
                keyValue: new Guid("fb7c7840-f5d2-4f36-97f8-e722e45ef441"));

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

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: new Guid("3a891899-546f-4380-aee2-81c7939a0f99"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "Id", "Category", "CreatedAt", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("3a891899-546f-4380-aee2-81c7939a0f99"), "Home & Kitchen", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c9bb6d84-350a-4ecb-ad5c-51d1924efee1"), "Clothing", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f4b8eff5-c7d2-4625-adb1-f4af19a922dd"), "Electronics", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "BrandId", "CreatedAt", "ProductBarcode", "ProductCategoryId", "ProductDescription", "ProductName", "ProductPrice", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"), new Guid("abadc9e1-c8e6-4f40-b078-47f609d1cf79"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "6291041500213", new Guid("3a891899-546f-4380-aee2-81c7939a0f99"), "The Smartphone XYZ Pro is a premium device featuring a 6.7-inch AMOLED display with 4K resolution and HDR10+ technology. Powered by the Snapdragon 888 chipset, 12GB of RAM, and 256GB of internal storage, this phone delivers smooth performance for all tasks. The 108MP main camera supports 8K video recording, and the 5000mAh battery supports 65W fast charging.", "Toyota Camry", 1500m, "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 40, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("cee5a4d8-de84-4482-9da9-302e2290cb0f"), new Guid("855f8a55-c9d0-4532-81ee-6da2bd0db1f6"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "5901234123457", new Guid("3a891899-546f-4380-aee2-81c7939a0f99"), "The UltraBook 2023 is an ultra-thin and lightweight laptop, weighing just 1.2kg, with a 14-inch 2.5K resolution display. It is equipped with a 12th Gen Intel Core i7 processor, 16GB of RAM, and a 512GB SSD. With up to 12 hours of battery life and Thunderbolt 4 connectivity, it is perfect for mobile work and entertainment.", "Ford Mustang", 1200m, "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("e9a7beda-ff63-4ac5-92cb-b7fa152c41c2"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "4006381333931", new Guid("3a891899-546f-4380-aee2-81c7939a0f99"), "The Mirrorless Alpha Z9 is the perfect choice for professional photographers. With a 45MP full-frame sensor, 6K video recording, and 5-axis image stabilization, this camera delivers sharp and true-to-life image quality. It also offers a continuous shooting speed of up to 20 frames per second.", "Volkswagen Golf", 800m, "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"), new Guid("abadc9e1-c8e6-4f40-b078-47f609d1cf79"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "9780201379624", new Guid("3a891899-546f-4380-aee2-81c7939a0f99"), "The SoundWave 360 Smart Speaker features an integrated AI virtual assistant and supports voice control. With 360-degree surround sound and 50W of power, it delivers an immersive audio experience. It connects wirelessly via Bluetooth 5.0 and Wi-Fi, and is compatible with smart home devices.", "Honda Civic", 300m, "Active", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "ProductHistory",
                columns: new[] { "Id", "CreatedAt", "ProductId", "ProductPrice" },
                values: new object[,]
                {
                    { new Guid("15516af1-3245-4926-8dfe-bea85b6ec125"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"), 1300m },
                    { new Guid("1b17747e-ae0a-4c6e-9ff7-d6539c6cd6b6"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 38, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), new Guid("cee5a4d8-de84-4482-9da9-302e2290cb0f"), 120m },
                    { new Guid("423c3aa7-0281-4de1-95f2-53fe332417f2"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 38, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"), 120m },
                    { new Guid("5047c4b3-458a-4fbe-8df4-35f4b23dc439"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), new Guid("cee5a4d8-de84-4482-9da9-302e2290cb0f"), 1300m },
                    { new Guid("77f4ebf6-ed84-4fc2-8a58-3419d1464ee4"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 40, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"), 1500m },
                    { new Guid("8258d59b-2955-4d2f-bced-ce747d6f303f"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), new Guid("e9a7beda-ff63-4ac5-92cb-b7fa152c41c2"), 1300m },
                    { new Guid("913522ad-480e-4bc8-8932-79e3b4178016"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 40, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), new Guid("e9a7beda-ff63-4ac5-92cb-b7fa152c41c2"), 1500m },
                    { new Guid("a660df09-451d-4f1e-bf73-152cd2ede38e"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 40, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), new Guid("cee5a4d8-de84-4482-9da9-302e2290cb0f"), 1500m },
                    { new Guid("d806f85f-da06-4030-b98c-3c5561c14305"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 38, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), new Guid("e9a7beda-ff63-4ac5-92cb-b7fa152c41c2"), 120m },
                    { new Guid("de79c933-78d0-4498-becf-97d7228d39fd"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 38, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"), 120m },
                    { new Guid("f28b16c7-781c-4c11-9c31-1a3152c335e5"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 40, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"), 1500m },
                    { new Guid("fb7c7840-f5d2-4f36-97f8-e722e45ef441"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"), 1300m }
                });

            migrationBuilder.InsertData(
                table: "ProductImage",
                columns: new[] { "Id", "CreatedAt", "ImageId", "ImageLink", "ProductId", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("306fd99b-7914-4c4d-a92b-f3d998f3b772"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "N/A", "https://example.com/images/5.jpg", new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"), "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("71bd8b35-0d22-4783-8638-78eb48bd5629"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "N/A", "https://example.com/images/1.jpg", new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"), "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("867a1f57-a7dc-4d8a-95f0-9b1e1b086809"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "N/A", "https://example.com/images/3.jpg", new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"), "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("91f09ff2-24ed-4d60-b3c5-5e76204a90ff"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "N/A", "https://example.com/images/2.jpg", new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"), "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b3126c73-0e1e-40fd-8dec-f7c4d2789dd9"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "N/A", "https://example.com/images/4.jpg", new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"), "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });
        }
    }
}
