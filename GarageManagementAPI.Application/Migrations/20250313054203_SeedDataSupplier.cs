using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataSupplier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Supplier",
                columns: new[] { "Id", "Address", "CreatedAt", "District", "Name", "Province", "Status", "SupplierCategory", "TaxCode", "UpdatedAt", "Wards" },
                values: new object[,]
                {
                    { new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"), "123 Street", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 40, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Ba Dinh", "Trần Huy Hanh", "Hanoi", "Active", "Automotive", "123456789", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 40, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Ward 1" },
                    { new Guid("cee5a4d8-de84-4482-9da9-302e2290cb0f"), "456 Avenue", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 40, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "District 1", "Bùi Duy Khánh", "HCMC", "Active", "Parts", "987654321", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 40, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Ward 2" },
                    { new Guid("e9a7beda-ff63-4ac5-92cb-b7fa152c41c2"), "789 Road", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 40, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Hai Chau", "Nguyễn Hoàng Nhật Tân", "Da Nang", "Active", "Maintenance", "123456799", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 40, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Ward 3" },
                    { new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"), "321 Boulevard", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 40, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Ninh Kieu", "Lê Tân", "Can Tho", "Active", "Electronics", "654321987", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 40, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Ward 4" }
                });

            migrationBuilder.InsertData(
                table: "SupplierContact",
                columns: new[] { "Id", "ContactEmail", "ContactPersonName", "ContactPhoneNumber", "ContactPosition", "CreatedAt", "Status", "SupplierId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"), "john.doe@suppliera.com", "John Doe", "0123456789", "Support", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Inactive", new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("cee5a4d8-de84-4482-9da9-302e2290cb0f"), "jane.smith@supplierb.com", "Jane Smith", "0987654321", "Manager", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Inactive", new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e9a7beda-ff63-4ac5-92cb-b7fa152c41c2"), "michael.j@supplierc.com", "Michael Johnson", "0365478921", "Director", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Inactive", new Guid("e9a7beda-ff63-4ac5-92cb-b7fa152c41c2"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"), "emily.d@supplierd.com", "Sales", "0932154786", "123 Street", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Inactive", new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Supplier",
                keyColumn: "Id",
                keyValue: new Guid("cee5a4d8-de84-4482-9da9-302e2290cb0f"));

            migrationBuilder.DeleteData(
                table: "SupplierContact",
                keyColumn: "Id",
                keyValue: new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"));

            migrationBuilder.DeleteData(
                table: "SupplierContact",
                keyColumn: "Id",
                keyValue: new Guid("cee5a4d8-de84-4482-9da9-302e2290cb0f"));

            migrationBuilder.DeleteData(
                table: "SupplierContact",
                keyColumn: "Id",
                keyValue: new Guid("e9a7beda-ff63-4ac5-92cb-b7fa152c41c2"));

            migrationBuilder.DeleteData(
                table: "SupplierContact",
                keyColumn: "Id",
                keyValue: new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"));

            migrationBuilder.DeleteData(
                table: "Supplier",
                keyColumn: "Id",
                keyValue: new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"));

            migrationBuilder.DeleteData(
                table: "Supplier",
                keyColumn: "Id",
                keyValue: new Guid("e9a7beda-ff63-4ac5-92cb-b7fa152c41c2"));

            migrationBuilder.DeleteData(
                table: "Supplier",
                keyColumn: "Id",
                keyValue: new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"));
        }
    }
}
