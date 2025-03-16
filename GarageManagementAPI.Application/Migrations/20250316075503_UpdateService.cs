using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class UpdateService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("1aef6a6e-7376-42e2-ba86-50954246809e"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("3605af66-e2e0-4189-acfa-78b2151e8108"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("dae53a3d-c422-4242-a6c6-752ad99223ec"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("e320a34f-1e76-48d6-a2fa-a45b7eeddb07"));

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("0af80b56-c94e-4665-9660-2caf6f2faa92"),
                column: "Status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("0b9a2e4d-f0c5-4fd3-81cc-95ab24a98fed"),
                column: "Status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("0fdac649-9fa0-4ed9-8b68-2c51290db904"),
                column: "Status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("108faee1-bdc5-4a21-99ab-1446d7070817"),
                column: "Status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("19e4766f-30d7-4bf7-a5de-c38aa54c39ab"),
                column: "Status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("1d001811-24d7-4f17-9b99-040417ee758c"),
                column: "Status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("1f3cc46a-b312-4100-9efc-12e3c64eb60c"),
                column: "Status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("292e282b-441e-4eae-b4d3-fa66e998093d"),
                column: "Status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("2e7f0139-ca6b-4261-b8b1-92025af17c23"),
                column: "Status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("2f7203ad-ff0a-4fc6-b6bd-ff75f4855633"),
                column: "Status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("2ffc838c-bc9c-4f50-9aae-c1626d28f948"),
                column: "Status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("41e56392-31fc-4013-bcf1-a5a3348bce68"),
                column: "Status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("465f7c43-42ad-446a-88a3-1de98daff9d5"),
                column: "Status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("49dcb9e8-cc88-417b-9cc2-da9223cba7bb"),
                column: "Status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("5699cd29-fc73-4495-86c2-d3854f3844c6"),
                column: "Status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("5764887f-1f3e-43d8-8ff2-4ec5acf2b625"),
                column: "Status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("5c0b84e8-48df-41cd-a9b3-ff376d0c8d01"),
                column: "Status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("679799ff-ac1e-4db5-95c0-611bbb151930"),
                column: "Status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("6fc59687-aaf1-4fdc-821f-6fa276232515"),
                column: "Status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("804addd4-32e2-40e2-8836-cba4314a37cb"),
                column: "Status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("8cff9d86-e1f4-4ccd-9d4a-50d9b631d2ff"),
                column: "Status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("8e09e528-ef74-4687-993d-33447cbc7b46"),
                column: "Status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("8e8f9751-ea57-41f1-aebe-653d7c2707e2"),
                column: "Status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("95417c69-fadd-45f8-94f9-70b89bbded4e"),
                column: "Status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("9d2bc061-81f1-46c7-96e4-97b9b7cd8f94"),
                column: "Status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("9fc6018f-efcf-45c3-9208-a4b4eac755fb"),
                column: "Status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("a1d96353-b314-4c19-ba52-c95252d838ed"),
                column: "Status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("aaa8c312-e261-4a4b-8dee-ef1f9548df6a"),
                column: "Status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("ae0292b9-460b-453b-a7e3-94f5e37c72b1"),
                column: "Status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("ae25aa47-7d00-4d8d-b858-6b68f2fa1461"),
                column: "Status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("bb3b64ea-6cf2-47cb-9ead-3914cb0505ad"),
                column: "Status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("ca325344-f16a-44e5-b1cf-2b2c33375b16"),
                column: "Status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("ca9e6960-f038-4e9f-97c9-9190378129a4"),
                column: "Status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("d55973be-a40f-435b-8078-d489c74d0fd7"),
                column: "Status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("dbd23c8d-f822-4924-926e-c47d67bfb11c"),
                column: "Status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("dd5961c4-d25d-4ccc-87d1-5d2509e9d2a0"),
                column: "Status",
                value: "Active");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("0af80b56-c94e-4665-9660-2caf6f2faa92"),
                column: "Status",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("0b9a2e4d-f0c5-4fd3-81cc-95ab24a98fed"),
                column: "Status",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("0fdac649-9fa0-4ed9-8b68-2c51290db904"),
                column: "Status",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("108faee1-bdc5-4a21-99ab-1446d7070817"),
                column: "Status",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("19e4766f-30d7-4bf7-a5de-c38aa54c39ab"),
                column: "Status",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("1d001811-24d7-4f17-9b99-040417ee758c"),
                column: "Status",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("1f3cc46a-b312-4100-9efc-12e3c64eb60c"),
                column: "Status",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("292e282b-441e-4eae-b4d3-fa66e998093d"),
                column: "Status",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("2e7f0139-ca6b-4261-b8b1-92025af17c23"),
                column: "Status",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("2f7203ad-ff0a-4fc6-b6bd-ff75f4855633"),
                column: "Status",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("2ffc838c-bc9c-4f50-9aae-c1626d28f948"),
                column: "Status",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("41e56392-31fc-4013-bcf1-a5a3348bce68"),
                column: "Status",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("465f7c43-42ad-446a-88a3-1de98daff9d5"),
                column: "Status",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("49dcb9e8-cc88-417b-9cc2-da9223cba7bb"),
                column: "Status",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("5699cd29-fc73-4495-86c2-d3854f3844c6"),
                column: "Status",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("5764887f-1f3e-43d8-8ff2-4ec5acf2b625"),
                column: "Status",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("5c0b84e8-48df-41cd-a9b3-ff376d0c8d01"),
                column: "Status",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("679799ff-ac1e-4db5-95c0-611bbb151930"),
                column: "Status",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("6fc59687-aaf1-4fdc-821f-6fa276232515"),
                column: "Status",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("804addd4-32e2-40e2-8836-cba4314a37cb"),
                column: "Status",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("8cff9d86-e1f4-4ccd-9d4a-50d9b631d2ff"),
                column: "Status",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("8e09e528-ef74-4687-993d-33447cbc7b46"),
                column: "Status",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("8e8f9751-ea57-41f1-aebe-653d7c2707e2"),
                column: "Status",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("95417c69-fadd-45f8-94f9-70b89bbded4e"),
                column: "Status",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("9d2bc061-81f1-46c7-96e4-97b9b7cd8f94"),
                column: "Status",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("9fc6018f-efcf-45c3-9208-a4b4eac755fb"),
                column: "Status",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("a1d96353-b314-4c19-ba52-c95252d838ed"),
                column: "Status",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("aaa8c312-e261-4a4b-8dee-ef1f9548df6a"),
                column: "Status",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("ae0292b9-460b-453b-a7e3-94f5e37c72b1"),
                column: "Status",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("ae25aa47-7d00-4d8d-b858-6b68f2fa1461"),
                column: "Status",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("bb3b64ea-6cf2-47cb-9ead-3914cb0505ad"),
                column: "Status",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("ca325344-f16a-44e5-b1cf-2b2c33375b16"),
                column: "Status",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("ca9e6960-f038-4e9f-97c9-9190378129a4"),
                column: "Status",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("d55973be-a40f-435b-8078-d489c74d0fd7"),
                column: "Status",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("dbd23c8d-f822-4924-926e-c47d67bfb11c"),
                column: "Status",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("dd5961c4-d25d-4ccc-87d1-5d2509e9d2a0"),
                column: "Status",
                value: "0");

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "Id", "Action", "CarCategoryId", "CarPartId", "CreatedAt", "Description", "EstimatedHours", "Price", "ServiceCategory", "ServiceName", "Status", "UpdatedAt", "WorkNature" },
                values: new object[,]
                {
                    { new Guid("1aef6a6e-7376-42e2-ba86-50954246809e"), "Lubricate", new Guid("6f9e4206-d0a0-4366-a997-094827005006"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Lubricating the differential to reduce wear and maintain performance.", 1, 0m, "Maintenance", "Differential Lubrication", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Preventive" },
                    { new Guid("3605af66-e2e0-4189-acfa-78b2151e8108"), "Repair", new Guid("61a22ffb-c41d-4365-b067-11213e5579f9"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Repairing the brake system to ensure reliable stopping performance.", 2, 0m, "Repair", "Brake System Repair", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Corrective" },
                    { new Guid("dae53a3d-c422-4242-a6c6-752ad99223ec"), "Refill", new Guid("fc000760-6615-4f3b-96cc-7607ba6609a8"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Refilling the coolant to ensure the engine runs at optimal temperatures.", 1, 0m, "Maintenance", "Coolant Refill", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Preventive" },
                    { new Guid("e320a34f-1e76-48d6-a2fa-a45b7eeddb07"), "Replace", new Guid("d4018b86-eb87-4114-9b9e-5fae1034cbd8"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Replacing brake pads to maintain effective stopping power.", 2, 0m, "Repair", "Brake Pad Replacement", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Corrective" }
                });
        }
    }
}
