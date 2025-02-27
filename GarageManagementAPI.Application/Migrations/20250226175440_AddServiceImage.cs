using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class AddServiceImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "serviceimage_id_foreign",
                table: "ServiceImage");

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("2124d8bd-9436-4e0d-aeab-9bf74b48c21f"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("26359641-c72e-4aa5-b746-5a34b0fc6196"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("2f74ef10-2a1e-4451-b83a-57f3a83e5784"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("350ee7fe-833c-4bf3-9f6c-522315408b0e"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("6ee36e8a-3ebb-4b17-9ead-bcc03c04dfa6"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("7efad641-6447-44d8-9524-6d95d3f41c45"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("b5e82e9b-eb98-470b-b358-ee28f1d54063"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("bcf8f84a-d676-4c14-bc00-edf0c9805e64"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("ca57e05a-21d3-409b-bf0c-6820d3347f37"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("ea826dcf-4a60-4e2f-a315-69732535e49f"));

            migrationBuilder.AddForeignKey(
                name: "serviceimage_id_foreign",
                table: "ServiceImage",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "serviceimage_id_foreign",
                table: "ServiceImage");

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "Id", "Action", "CarCategoryId", "CarPartId", "CreatedAt", "Description", "EstimatedHours", "ServiceCategory", "ServiceName", "Status", "UpdatedAt", "WorkNature" },
                values: new object[,]
                {
                    { new Guid("2124d8bd-9436-4e0d-aeab-9bf74b48c21f"), "Replace Fuel Filter", new Guid("2eaed576-3f1e-43aa-b92d-4b45990df71f"), new Guid("0131e761-bdeb-4fd0-8aba-b3cc0769d0c4"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Replacing the fuel filter to ensure clean fuel delivery to the engine.", 1, "Fuel System", "Fuel Filter Replacement", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Maintenance" },
                    { new Guid("26359641-c72e-4aa5-b746-5a34b0fc6196"), "Recharge AC System", new Guid("47b2ccc3-0570-4d9a-acbe-4d95d03001c7"), new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Recharging the AC system to restore cooling efficiency.", 1, "Air Conditioning", "AC Recharge", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Maintenance" },
                    { new Guid("2f74ef10-2a1e-4451-b83a-57f3a83e5784"), "Replace Transmission Fluid", new Guid("69246d30-53c9-4804-a89b-f692919172de"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Changing transmission fluid to ensure smooth gear shifts.", 2, "Transmission", "Transmission Fluid Change", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Regular Maintenance" },
                    { new Guid("350ee7fe-833c-4bf3-9f6c-522315408b0e"), "Rotate Tires", new Guid("e0101ba3-df29-4df3-a0d1-68bb0853a86b"), new Guid("855f8a55-c9d0-4532-81ee-6da2bd0db1f6"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Rotating tires to ensure even wear and extend tire life.", 1, "Tires", "Tire Rotation", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Regular Maintenance" },
                    { new Guid("6ee36e8a-3ebb-4b17-9ead-bcc03c04dfa6"), "Replace Windscreen Wipers", new Guid("d8123055-c15d-4932-90ba-127e415c36b4"), new Guid("4b3039f3-b460-46be-aa39-e43d4c29af19"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Replacing worn-out windscreen wipers to ensure clear visibility during rain.", 1, "Windscreen", "Windscreen Wiper Replacement", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Replacement" },
                    { new Guid("7efad641-6447-44d8-9524-6d95d3f41c45"), "Flush Radiator", new Guid("a0eeb005-f9e8-49fa-ad32-de352a0a04ab"), new Guid("84062c49-1fe2-4b97-86c4-49e4d0f5449b"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Flushing the radiator to remove debris and old coolant.", 2, "Cooling System", "Radiator Flush", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Maintenance" },
                    { new Guid("b5e82e9b-eb98-470b-b358-ee28f1d54063"), "Replace Muffler", new Guid("2d31f83e-1508-48ab-934c-93d46266b57b"), new Guid("d263567a-41b2-407d-b40d-6bad18eb32ca"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Replacing the muffler to reduce noise and improve exhaust flow.", 2, "Exhaust System", "Muffler Replacement", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Repair" },
                    { new Guid("bcf8f84a-d676-4c14-bc00-edf0c9805e64"), "Replace Cabin Air Filter", new Guid("ab9b4f29-fea5-4d09-a0b3-02dd5dedc6e5"), new Guid("4b3039f3-b460-46be-aa39-e43d4c29af19"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Replacing the cabin air filter to improve air quality inside the vehicle.", 1, "Interior", "Cabin Air Filter Replacement", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Maintenance" },
                    { new Guid("ca57e05a-21d3-409b-bf0c-6820d3347f37"), "Replace Headlight Bulb", new Guid("12ca3969-c9ff-4b3e-91d0-1fe421c9d2f4"), new Guid("2c74b21a-5ec4-4dce-b376-b6b0601d7a84"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Replacing a burnt-out headlight bulb to ensure proper visibility.", 1, "Lighting", "Headlight Bulb Replacement", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Replacement" },
                    { new Guid("ea826dcf-4a60-4e2f-a315-69732535e49f"), "Replace Car Battery", new Guid("b88688ec-8e1c-46a2-999f-f1b8e92b8f24"), new Guid("abadc9e1-c8e6-4f40-b078-47f609d1cf79"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Replacing old battery with a new one to ensure proper electrical function.", 1, "Electrical System", "Battery Replacement", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Replacement" }
                });

            migrationBuilder.AddForeignKey(
                name: "serviceimage_id_foreign",
                table: "ServiceImage",
                column: "Id",
                principalTable: "Service",
                principalColumn: "Id");
        }
    }
}
