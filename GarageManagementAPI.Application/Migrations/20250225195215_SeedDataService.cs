using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "Id", "Action", "CarCategoryId", "CarPartId", "CreatedAt", "Description", "EstimatedHours", "ServiceCategory", "ServiceName", "Status", "UpdatedAt", "WorkNature" },
                values: new object[,]
                {
                    { new Guid("0be257e7-856d-48d6-ab5a-f984a75b67d5"), "Replace", new Guid("b8e9b4d0-8b60-451a-9810-1132482a0d92"), new Guid("45cdfef2-2b7d-48aa-b8fa-f95c0aa194ad"), new DateTimeOffset(new DateTime(2025, 2, 25, 19, 52, 13, 892, DateTimeKind.Unspecified).AddTicks(6776), new TimeSpan(0, 0, 0, 0, 0)), "Replace old battery with a new one", 1, "Maintenance", "Battery Replacement", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 19, 52, 13, 892, DateTimeKind.Unspecified).AddTicks(6777), new TimeSpan(0, 0, 0, 0, 0)), "Safety" },
                    { new Guid("6a927f4f-cc77-4d6d-963f-96a14a6a4fa9"), "Replace", new Guid("f5bf5757-92b6-4cc2-b86b-1995f28d3fb6"), new Guid("82b56cc1-7122-46ec-817e-b06cd0747f55"), new DateTimeOffset(new DateTime(2025, 2, 25, 19, 52, 13, 892, DateTimeKind.Unspecified).AddTicks(6765), new TimeSpan(0, 0, 0, 0, 0)), "Replace faulty shock absorbers", 3, "Repair", "Shock Absorber Replacement", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 19, 52, 13, 892, DateTimeKind.Unspecified).AddTicks(6765), new TimeSpan(0, 0, 0, 0, 0)), "Performance" },
                    { new Guid("6ebc86c7-82e2-4ce4-b613-ebaac626bd18"), "Replace", new Guid("506b4f2f-68f7-4b69-ab81-1242de996a18"), new Guid("82b56cc1-7122-46ec-817e-b06cd0747f55"), new DateTimeOffset(new DateTime(2025, 2, 25, 19, 52, 13, 892, DateTimeKind.Unspecified).AddTicks(6770), new TimeSpan(0, 0, 0, 0, 0)), "Replace worn-out clutch kit", 4, "Repair", "Clutch Replacement", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 19, 52, 13, 892, DateTimeKind.Unspecified).AddTicks(6771), new TimeSpan(0, 0, 0, 0, 0)), "Performance" },
                    { new Guid("7d0e4fb5-6e8e-48fc-ba2b-daa570f5f96f"), "Replace", new Guid("89bd23de-98f2-4de2-a753-403789911119"), new Guid("82b56cc1-7122-46ec-817e-b06cd0747f55"), new DateTimeOffset(new DateTime(2025, 2, 25, 19, 52, 13, 892, DateTimeKind.Unspecified).AddTicks(6446), new TimeSpan(0, 0, 0, 0, 0)), "Replace engine oil and oil filter", 1, "Maintenance", "Oil Change", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 19, 52, 13, 892, DateTimeKind.Unspecified).AddTicks(6604), new TimeSpan(0, 0, 0, 0, 0)), "Routine" },
                    { new Guid("8d86d786-c02d-43a6-9b3f-3ef15761ba71"), "Replace", new Guid("6f9e4206-d0a0-4366-a997-094827005006"), new Guid("82b56cc1-7122-46ec-817e-b06cd0747f55"), new DateTimeOffset(new DateTime(2025, 2, 25, 19, 52, 13, 892, DateTimeKind.Unspecified).AddTicks(6788), new TimeSpan(0, 0, 0, 0, 0)), "Replace leaking radiator", 3, "Repair", "Radiator Replacement", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 19, 52, 13, 892, DateTimeKind.Unspecified).AddTicks(6788), new TimeSpan(0, 0, 0, 0, 0)), "Performance" },
                    { new Guid("fa7fab24-c298-43cf-b990-341b29a02996"), "Replace", new Guid("1d25e83b-925e-472a-89d9-38c499dbfdea"), new Guid("45cdfef2-2b7d-48aa-b8fa-f95c0aa194ad"), new DateTimeOffset(new DateTime(2025, 2, 25, 19, 52, 13, 892, DateTimeKind.Unspecified).AddTicks(6756), new TimeSpan(0, 0, 0, 0, 0)), "Replace worn-out brake pads", 2, "Repair", "Brake Pad Replacement", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 19, 52, 13, 892, DateTimeKind.Unspecified).AddTicks(6756), new TimeSpan(0, 0, 0, 0, 0)), "Safety" },
                    { new Guid("ff884ca0-1e63-4bc1-84a1-4048a6eb627e"), "Replace", new Guid("61a22ffb-c41d-4365-b067-11213e5579f9"), new Guid("45cdfef2-2b7d-48aa-b8fa-f95c0aa194ad"), new DateTimeOffset(new DateTime(2025, 2, 25, 19, 52, 13, 892, DateTimeKind.Unspecified).AddTicks(6782), new TimeSpan(0, 0, 0, 0, 0)), "Replace damaged muffler", 2, "Repair", "Muffler Replacement", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 19, 52, 13, 892, DateTimeKind.Unspecified).AddTicks(6782), new TimeSpan(0, 0, 0, 0, 0)), "Performance" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("0be257e7-856d-48d6-ab5a-f984a75b67d5"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("6a927f4f-cc77-4d6d-963f-96a14a6a4fa9"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("6ebc86c7-82e2-4ce4-b613-ebaac626bd18"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("7d0e4fb5-6e8e-48fc-ba2b-daa570f5f96f"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("8d86d786-c02d-43a6-9b3f-3ef15761ba71"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("fa7fab24-c298-43cf-b990-341b29a02996"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("ff884ca0-1e63-4bc1-84a1-4048a6eb627e"));
        }
    }
}
