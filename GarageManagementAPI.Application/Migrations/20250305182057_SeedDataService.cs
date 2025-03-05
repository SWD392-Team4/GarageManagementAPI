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
                    { new Guid("0af80b56-c94e-4665-9660-2caf6f2faa92"), "Inspect", new Guid("d4018b86-eb87-4114-9b9e-5fae1034cbd8"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Routine engine inspection to detect early signs of wear.", 1, "Maintenance", "Regular Engine Inspection", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Preventive" },
                    { new Guid("0b9a2e4d-f0c5-4fd3-81cc-95ab24a98fed"), "Polish", new Guid("13f81bcb-5943-4cfe-9a1f-c38c9dac0969"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Thorough cleaning and polishing of the cabin to restore a premium feel.", 2, "Detailing", "Interior Detailing & Polishing", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Aesthetic" },
                    { new Guid("0fdac649-9fa0-4ed9-8b68-2c51290db904"), "Replace", new Guid("1d25e83b-925e-472a-89d9-38c499dbfdea"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Replacing the air filter to maintain optimal engine performance.", 1, "Maintenance", "Air Filter Replacement", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Preventive" },
                    { new Guid("108faee1-bdc5-4a21-99ab-1446d7070817"), "Clean", new Guid("89bd23de-98f2-4de2-a753-403789911119"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "A complete exterior wash to remove dirt and restore shine.", 1, "CarWash", "Exterior Wash & Clean", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Aesthetic" },
                    { new Guid("19e4766f-30d7-4bf7-a5de-c38aa54c39ab"), "Repair", new Guid("1d25e83b-925e-472a-89d9-38c499dbfdea"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Repairing malfunctioning brake components for safety.", 2, "Repair", "Brake System Repair", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Corrective" },
                    { new Guid("1aef6a6e-7376-42e2-ba86-50954246809e"), "Lubricate", new Guid("6f9e4206-d0a0-4366-a997-094827005006"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Lubricating the differential to reduce wear and maintain performance.", 1, "Maintenance", "Differential Lubrication", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Preventive" },
                    { new Guid("1d001811-24d7-4f17-9b99-040417ee758c"), "Update", new Guid("7ebb6c15-8e16-439c-bd07-b998c4b26ab3"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Updating the infotainment software to incorporate the latest features.", 2, "Upgrade", "Infotainment Software Update", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Digital" },
                    { new Guid("1f3cc46a-b312-4100-9efc-12e3c64eb60c"), "Lubricate", new Guid("5aa5a48b-686e-426e-a54e-c5e59bbc7373"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Lubricating the differential to reduce friction in off-road conditions.", 1, "Maintenance", "Differential Lubrication", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Preventive" },
                    { new Guid("292e282b-441e-4eae-b4d3-fa66e998093d"), "Upgrade", new Guid("5191690b-1d10-476e-b4f5-4044218e64c2"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Upgrading the infotainment system for enhanced connectivity and features.", 3, "Upgrade", "Infotainment System Upgrade", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Enhancement" },
                    { new Guid("2e7f0139-ca6b-4261-b8b1-92025af17c23"), "Repair", new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Replacing worn brake pads to restore optimal braking performance.", 2, "Repair", "Brake Pad Replacement", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Corrective" },
                    { new Guid("2f7203ad-ff0a-4fc6-b6bd-ff75f4855633"), "Clean", new Guid("fc000760-6615-4f3b-96cc-7607ba6609a8"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Exterior wash designed specifically for subcompact cars.", 1, "CarWash", "Compact Car Exterior Wash", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Aesthetic" },
                    { new Guid("2ffc838c-bc9c-4f50-9aae-c1626d28f948"), "Align", new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Adjusting wheel angles to ensure even tire wear and improved handling.", 2, "Maintenance", "Wheel Alignment Service", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Corrective" },
                    { new Guid("3605af66-e2e0-4189-acfa-78b2151e8108"), "Repair", new Guid("61a22ffb-c41d-4365-b067-11213e5579f9"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Repairing the brake system to ensure reliable stopping performance.", 2, "Repair", "Brake System Repair", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Corrective" },
                    { new Guid("41e56392-31fc-4013-bcf1-a5a3348bce68"), "Polish", new Guid("f5bf5757-92b6-4cc2-b86b-1995f28d3fb6"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Comprehensive interior detailing to restore and maintain a luxurious cabin finish.", 3, "Detailing", "Full Interior Detailing", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Aesthetic" },
                    { new Guid("465f7c43-42ad-446a-88a3-1de98daff9d5"), "Upgrade", new Guid("a0ded8b7-8094-4ece-8cf7-d1670080ef60"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Upgrading the exhaust system to boost performance and achieve a sporty sound.", 3, "Upgrade", "Sport Exhaust Upgrade", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Enhancement" },
                    { new Guid("49dcb9e8-cc88-417b-9cc2-da9223cba7bb"), "Update", new Guid("b8e9b4d0-8b60-451a-9810-1132482a0d92"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Updating software to optimize battery performance and safety.", 2, "Upgrade", "Battery Management Software Update", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Digital" },
                    { new Guid("5699cd29-fc73-4495-86c2-d3854f3844c6"), "Replace", new Guid("a0ded8b7-8094-4ece-8cf7-d1670080ef60"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Changing engine oil to maintain performance and extend engine life.", 1, "Maintenance", "Engine Oil Change", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Preventive" },
                    { new Guid("5764887f-1f3e-43d8-8ff2-4ec5acf2b625"), "Inspect", new Guid("13f81bcb-5943-4cfe-9a1f-c38c9dac0969"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Inspecting brake fluid levels and condition to ensure reliable braking.", 1, "Maintenance", "Brake Fluid Inspection", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Preventive" },
                    { new Guid("5c0b84e8-48df-41cd-a9b3-ff376d0c8d01"), "Replace", new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Changing transmission fluid to ensure smooth gear shifts and prolong transmission life.", 2, "Maintenance", "Transmission Fluid Change", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Preventive" },
                    { new Guid("679799ff-ac1e-4db5-95c0-611bbb151930"), "Replace", new Guid("506b4f2f-68f7-4b69-ab81-1242de996a18"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Replacing worn wiper blades to maintain clear visibility during rain.", 1, "Maintenance", "Windshield Wiper Replacement", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Preventive" },
                    { new Guid("6fc59687-aaf1-4fdc-821f-6fa276232515"), "Repair", new Guid("d904d7f0-674a-48dd-ae45-794d8e257583"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Repairing the drive shaft to restore proper power transmission.", 3, "Repair", "Drive Shaft Repair", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Corrective" },
                    { new Guid("804addd4-32e2-40e2-8836-cba4314a37cb"), "Repair", new Guid("983fba7a-11b2-4cdc-8ef0-64ddf6dfbfc4"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Repairing suspension components to improve ride comfort and safety.", 3, "Repair", "Suspension Repair", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Corrective" },
                    { new Guid("8cff9d86-e1f4-4ccd-9d4a-50d9b631d2ff"), "Repair", new Guid("961975c1-3dd5-4ed0-b260-b324b1c32eed"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Repairing the electric motor to restore hybrid performance.", 3, "Repair", "Electric Motor Repair", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Corrective" },
                    { new Guid("8e09e528-ef74-4687-993d-33447cbc7b46"), "Upgrade", new Guid("48b990a0-cce6-4d09-9a7e-e6d1a76bdb46"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Upgrading the exhaust for enhanced performance and aggressive sound.", 3, "Upgrade", "Performance Exhaust Upgrade", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Enhancement" },
                    { new Guid("8e8f9751-ea57-41f1-aebe-653d7c2707e2"), "Lubricate", new Guid("5191690b-1d10-476e-b4f5-4044218e64c2"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Lubricating engine components to reduce friction and wear.", 1, "Maintenance", "Engine Oil Lubrication", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Preventive" },
                    { new Guid("95417c69-fadd-45f8-94f9-70b89bbded4e"), "Refill", new Guid("d904d7f0-674a-48dd-ae45-794d8e257583"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Refilling the coolant system to prevent overheating.", 1, "Maintenance", "Coolant Refill Service", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Preventive" },
                    { new Guid("9d2bc061-81f1-46c7-96e4-97b9b7cd8f94"), "Repair", new Guid("48b990a0-cce6-4d09-9a7e-e6d1a76bdb46"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Comprehensive repair of engine components to restore peak performance.", 4, "Repair", "Engine Overhaul Repair", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Corrective" },
                    { new Guid("9fc6018f-efcf-45c3-9208-a4b4eac755fb"), "Lubricate", new Guid("61a22ffb-c41d-4365-b067-11213e5579f9"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Lubricating the power steering system for smooth steering response.", 1, "Maintenance", "Power Steering Fluid Lubrication", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Preventive" },
                    { new Guid("a1d96353-b314-4c19-ba52-c95252d838ed"), "Upgrade", new Guid("f5bf5757-92b6-4cc2-b86b-1995f28d3fb6"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Upgrading the infotainment system with advanced features for a superior experience.", 3, "Upgrade", "Advanced Infotainment Upgrade", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Enhancement" },
                    { new Guid("aaa8c312-e261-4a4b-8dee-ef1f9548df6a"), "Inspect", new Guid("961975c1-3dd5-4ed0-b260-b324b1c32eed"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Performing diagnostic tests to ensure hybrid system efficiency.", 1, "Maintenance", "Hybrid System Diagnostic Inspection", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Preventive" },
                    { new Guid("ae0292b9-460b-453b-a7e3-94f5e37c72b1"), "Clean", new Guid("506b4f2f-68f7-4b69-ab81-1242de996a18"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Cleaning the roof mechanism to ensure smooth operation and a spotless finish.", 1, "CarWash", "Convertible Roof Cleaning", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Aesthetic" },
                    { new Guid("ae25aa47-7d00-4d8d-b858-6b68f2fa1461"), "Inspect", new Guid("983fba7a-11b2-4cdc-8ef0-64ddf6dfbfc4"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Conducting a comprehensive inspection to fine-tune engine performance.", 1, "Maintenance", "Engine Tune-Up Inspection", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Preventive" },
                    { new Guid("bb3b64ea-6cf2-47cb-9ead-3914cb0505ad"), "Repair", new Guid("5aa5a48b-686e-426e-a54e-c5e59bbc7373"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Repairing suspension mounts to ensure durability on rough terrain.", 3, "Repair", "Suspension Mount Repair", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Corrective" },
                    { new Guid("ca325344-f16a-44e5-b1cf-2b2c33375b16"), "Polish", new Guid("7ebb6c15-8e16-439c-bd07-b998c4b26ab3"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Polishing leather seats to maintain a luxurious and refined interior.", 2, "Detailing", "Leather Seat Polishing", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Aesthetic" },
                    { new Guid("ca9e6960-f038-4e9f-97c9-9190378129a4"), "Repair", new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Repairing faulty suspension components to restore ride quality.", 3, "Repair", "Suspension System Repair", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Corrective" },
                    { new Guid("d55973be-a40f-435b-8078-d489c74d0fd7"), "Upgrade", new Guid("6f9e4206-d0a0-4366-a997-094827005006"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Upgrading the ECU for improved performance and responsiveness.", 3, "Upgrade", "Performance ECU Upgrade", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Enhancement" },
                    { new Guid("dae53a3d-c422-4242-a6c6-752ad99223ec"), "Refill", new Guid("fc000760-6615-4f3b-96cc-7607ba6609a8"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Refilling the coolant to ensure the engine runs at optimal temperatures.", 1, "Maintenance", "Coolant Refill", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Preventive" },
                    { new Guid("dbd23c8d-f822-4924-926e-c47d67bfb11c"), "Restore", new Guid("89bd23de-98f2-4de2-a753-403789911119"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Restoring headlight clarity to improve nighttime visibility.", 1, "Detailing", "Headlight Restoration", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Aesthetic" },
                    { new Guid("dd5961c4-d25d-4ccc-87d1-5d2509e9d2a0"), "Inspect", new Guid("b8e9b4d0-8b60-451a-9810-1132482a0d92"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Inspecting high voltage cables for damage or wear to ensure EV safety.", 1, "Maintenance", "High Voltage Cable Inspection", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Preventive" },
                    { new Guid("e320a34f-1e76-48d6-a2fa-a45b7eeddb07"), "Replace", new Guid("d4018b86-eb87-4114-9b9e-5fae1034cbd8"), new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Replacing brake pads to maintain effective stopping power.", 2, "Repair", "Brake Pad Replacement", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Corrective" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("0af80b56-c94e-4665-9660-2caf6f2faa92"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("0b9a2e4d-f0c5-4fd3-81cc-95ab24a98fed"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("0fdac649-9fa0-4ed9-8b68-2c51290db904"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("108faee1-bdc5-4a21-99ab-1446d7070817"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("19e4766f-30d7-4bf7-a5de-c38aa54c39ab"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("1aef6a6e-7376-42e2-ba86-50954246809e"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("1d001811-24d7-4f17-9b99-040417ee758c"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("1f3cc46a-b312-4100-9efc-12e3c64eb60c"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("292e282b-441e-4eae-b4d3-fa66e998093d"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("2e7f0139-ca6b-4261-b8b1-92025af17c23"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("2f7203ad-ff0a-4fc6-b6bd-ff75f4855633"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("2ffc838c-bc9c-4f50-9aae-c1626d28f948"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("3605af66-e2e0-4189-acfa-78b2151e8108"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("41e56392-31fc-4013-bcf1-a5a3348bce68"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("465f7c43-42ad-446a-88a3-1de98daff9d5"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("49dcb9e8-cc88-417b-9cc2-da9223cba7bb"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("5699cd29-fc73-4495-86c2-d3854f3844c6"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("5764887f-1f3e-43d8-8ff2-4ec5acf2b625"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("5c0b84e8-48df-41cd-a9b3-ff376d0c8d01"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("679799ff-ac1e-4db5-95c0-611bbb151930"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("6fc59687-aaf1-4fdc-821f-6fa276232515"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("804addd4-32e2-40e2-8836-cba4314a37cb"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("8cff9d86-e1f4-4ccd-9d4a-50d9b631d2ff"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("8e09e528-ef74-4687-993d-33447cbc7b46"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("8e8f9751-ea57-41f1-aebe-653d7c2707e2"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("95417c69-fadd-45f8-94f9-70b89bbded4e"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("9d2bc061-81f1-46c7-96e4-97b9b7cd8f94"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("9fc6018f-efcf-45c3-9208-a4b4eac755fb"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("a1d96353-b314-4c19-ba52-c95252d838ed"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("aaa8c312-e261-4a4b-8dee-ef1f9548df6a"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("ae0292b9-460b-453b-a7e3-94f5e37c72b1"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("ae25aa47-7d00-4d8d-b858-6b68f2fa1461"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("bb3b64ea-6cf2-47cb-9ead-3914cb0505ad"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("ca325344-f16a-44e5-b1cf-2b2c33375b16"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("ca9e6960-f038-4e9f-97c9-9190378129a4"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("d55973be-a40f-435b-8078-d489c74d0fd7"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("dae53a3d-c422-4242-a6c6-752ad99223ec"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("dbd23c8d-f822-4924-926e-c47d67bfb11c"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("dd5961c4-d25d-4ccc-87d1-5d2509e9d2a0"));

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: new Guid("e320a34f-1e76-48d6-a2fa-a45b7eeddb07"));
        }
    }
}
