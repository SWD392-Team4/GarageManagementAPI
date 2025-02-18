using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataForUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "ImageId", "ImageLink", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("0a1b2c3d-4e5f-6789-abcd-ef0123456789"), 0, "b2e4f7e1-3c1d-4f09-bcf5-6f23d7d56d9b", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic1@gmail.com", true, "Mechanic_1_first_name", "N/A", "N/A", "Mechanic_1_last_name", true, null, "MECHANIC1@gmail.com", "MECHANIC1", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0921122334", true, null, null, "M1N2O3EI4NHQTPOCMMT6KJZVZUAYSQXJ", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic1" },
                    { new Guid("1b2c3d4e-5f67-89ab-cdef-0123456789ab"), 0, "c3f5a8e2-4d2e-4a10-cdf6-7e34f8e67ead", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic2@gmail.com", true, "Mechanic_2_first_name", "N/A", "N/A", "Mechanic_2_last_name", true, null, "MECHANIC2@gmail.com", "MECHANIC2", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0922233445", true, null, null, "K2L3M4EI4NHQTPOCMMT6KJZVZUAYSQXK", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic2" },
                    { new Guid("2c3d4e5f-6789-abcd-ef01-23456789abcd"), 0, "d4a6b9e3-5e3f-4b11-def7-8f45a9e78fbe", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic3@gmail.com", true, "Mechanic_3_first_name", "N/A", "N/A", "Mechanic_3_last_name", true, null, "MECHANIC3@gmail.com", "MECHANIC3", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0923344556", true, null, null, "P5Q6R7EI4NHQTPOCMMT6KJZVZUAYSQXL", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic3" },
                    { new Guid("3d4e5f67-89ab-cdef-0123-456789abcdef"), 0, "e5b7c0e4-6f4a-4c12-ef08-9a56bab89fcf", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic4@gmail.com", true, "Mechanic_4_first_name", "N/A", "N/A", "Mechanic_4_last_name", true, null, "MECHANIC4@gmail.com", "MECHANIC4", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0924455667", true, null, null, "S8T9U0EI4NHQTPOCMMT6KJZVZUAYSQXM", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic4" },
                    { new Guid("4e5f6789-abcd-ef01-2345-6789abcdef01"), 0, "f6c8d1e5-7a5b-4d13-ef19-ab67cbc9ad0a", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic5@gmail.com", true, "Mechanic_5_first_name", "N/A", "N/A", "Mechanic_5_last_name", true, null, "MECHANIC5@gmail.com", "MECHANIC5", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0925566778", true, null, null, "V1W2X3EI4NHQTPOCMMT6KJZVZUAYSQXN", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic5" },
                    { new Guid("5f6789ab-cdef-0123-4567-89abcdef0123"), 0, "a7d9e2f6-8b6c-4e14-ef2a-bc78dcdabd1b", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic6@gmail.com", true, "Mechanic_6_first_name", "N/A", "N/A", "Mechanic_6_last_name", true, null, "MECHANIC6@gmail.com", "MECHANIC6", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0926677889", true, null, null, "Y4Z5A6EI4NHQTPOCMMT6KJZVZUAYSQXO", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic6" },
                    { new Guid("6789abcd-ef01-2345-6789-abcdef012345"), 0, "b8eaf307-9c7d-4f15-ef3b-cd89edcbce2c", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic7@gmail.com", true, "Mechanic_7_first_name", "N/A", "N/A", "Mechanic_7_last_name", true, null, "MECHANIC7@gmail.com", "MECHANIC7", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0927788990", true, null, null, "B7C8D9EI4NHQTPOCMMT6KJZVZUAYSQXP", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic7" },
                    { new Guid("67f4a543-7ff4-4db9-bf4a-748d3f9e13b1"), 0, "c8e7d1a4-22ab-48a4-9c57-12e334c5b0a6", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer2@gmail.com", true, "Customer_2_first_name", "N/A", "N/A", "Customer_2_last_name", true, null, "CUSTOMER2@gmail.com", "CUSTOMER2", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0901234567", true, null, null, "A7D5Q2EI4NHYTPOCMMT6KJZVZUAYSQZT", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer2" },
                    { new Guid("773d6761-8990-4408-be8f-321a7659825a"), 0, "db2f38c8-64ae-438f-a28d-34074e1e4a42", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer1@gmail.com", true, "Customer_1_first_name", "N/A", "N/A", "Customer_1_last_name", true, null, "CUSTOMER1@gmail.com", "CUSTOMER1", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0902596109", true, null, null, "NNC3W4EI4NHQTPOCMMT6KJZVZUAYSQXT", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer1" },
                    { new Guid("789abcde-f012-3456-789a-bcdef0123456"), 0, "c9f0a418-ad8e-4a16-ef4c-de90feacdf3d", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic8@gmail.com", true, "Mechanic_8_first_name", "N/A", "N/A", "Mechanic_8_last_name", true, null, "MECHANIC8@gmail.com", "MECHANIC8", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0928899001", true, null, null, "E0F1G2EI4NHQTPOCMMT6KJZVZUAYSQXQ", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic8" },
                    { new Guid("89abcdef-0123-4567-89ab-cdef01234567"), 0, "da012529-be9f-4b17-ef5d-ef01afbd0e4e", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic9@gmail.com", true, "Mechanic_9_first_name", "N/A", "N/A", "Mechanic_9_last_name", true, null, "MECHANIC9@gmail.com", "MECHANIC9", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0929900112", true, null, null, "H3I4J5EI4NHQTPOCMMT6KJZVZUAYSQXR", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic9" },
                    { new Guid("9abcdef0-1234-5678-9abc-def012345678"), 0, "eb12363a-cf10-4c18-ef6e-f012becd1f5f", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic10@gmail.com", true, "Mechanic_10_first_name", "N/A", "N/A", "Mechanic_10_last_name", true, null, "MECHANIC10@gmail.com", "MECHANIC10", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0930011223", true, null, null, "K6L7M8EI4NHQTPOCMMT6KJZVZUAYSQXS", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic10" },
                    { new Guid("a2e4f1b2-6f2d-42f7-a2b5-3a9b8c1d2e3f"), 0, "35ef5a68-2d9c-68f5-c157-8e94fbbd68bc", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer5@gmail.com", true, "Customer_5_first_name", "N/A", "N/A", "Customer_5_last_name", true, null, "CUSTOMER5@gmail.com", "CUSTOMER5", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0912233445", true, null, null, "P3Q2R1EI4NHQTPOCMMT6KJZVZUAYSQXD", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer5" },
                    { new Guid("abcd1234-ef56-7890-abcd-ef1234567890"), 0, "e89cf584-5b71-4a53-a6c5-4d3fa8db0a67", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "cashier1@gmail.com", true, "Cashier_1_first_name", "N/A", "N/A", "Cashier_1_last_name", true, null, "CASHIER1@gmail.com", "CASHIER1", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0931122334", true, null, null, "U2V3W4EI4NHQTPOCMMT6KJZVZUAYSQXU", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "cashier1" },
                    { new Guid("b3c5d6e7-f8a9-4b0c-8d1e-2f3a4b5c6d7e"), 0, "46ff6b79-3ead-4af6-d268-9fabc0cda79d", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer6@gmail.com", true, "Customer_6_first_name", "N/A", "N/A", "Customer_6_last_name", true, null, "CUSTOMER6@gmail.com", "CUSTOMER6", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0913344556", true, null, null, "S4T5U6EI4NHQTPOCMMT6KJZVZUAYSQXE", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer6" },
                    { new Guid("bcde2345-f678-9012-bcde-f23456789012"), 0, "f90df695-6c82-4b64-b7d6-5e4fb9ec1b78", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "cashier2@gmail.com", true, "Cashier_2_first_name", "N/A", "N/A", "Cashier_2_last_name", true, null, "CASHIER2@gmail.com", "CASHIER2", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0932233445", true, null, null, "X5Y6Z7EI4NHQTPOCMMT6KJZVZUAYSQXV", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "cashier2" },
                    { new Guid("c4d5e6f7-a8b9-4c0d-9e1f-3a4b5c6d7e8f"), 0, "57a07c8a-4fbe-4b07-e379-afbcde1eb8ae", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer7@gmail.com", true, "Customer_7_first_name", "N/A", "N/A", "Customer_7_last_name", true, null, "CUSTOMER7@gmail.com", "CUSTOMER7", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0914455667", true, null, null, "V7W8X9EI4NHQTPOCMMT6KJZVZUAYSQXF", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer7" },
                    { new Guid("cdef3456-7890-1234-cdef-345678901234"), 0, "a1b2c3d4-e5f6-4a7b-8c9d-0a1b2c3d4e5f", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "warehouse1@gmail.com", true, "Warehouse_1_first_name", "N/A", "N/A", "Warehouse_1_last_name", true, null, "WAREHOUSE1@gmail.com", "WAREHOUSE1", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0933344556", true, null, null, "A8B9C0EI4NHQTPOCMMT6KJZVZUAYSQXW", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "warehouse1" },
                    { new Guid("d4b8cfb8-8b97-4d6d-bf1b-90f17fd853f3"), 0, "13cf3846-0b7a-46d3-a935-6c72d9bc469a", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer3@gmail.com", true, "Customer_3_first_name", "N/A", "N/A", "Customer_3_last_name", true, null, "CUSTOMER3@gmail.com", "CUSTOMER3", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0909876543", true, null, null, "K5R8X9EI4NHQTPOCMMT6KJZVZUAYSQXB", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer3" },
                    { new Guid("d5e6f7a8-b9c0-4d1e-8f2a-4b5c6d7e8f90"), 0, "68b18d9b-50cf-4c18-f48a-bcdef1234a0b", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer8@gmail.com", true, "Customer_8_first_name", "N/A", "N/A", "Customer_8_last_name", true, null, "CUSTOMER8@gmail.com", "CUSTOMER8", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0915566778", true, null, null, "Z1A2B3EI4NHQTPOCMMT6KJZVZUAYSQXG", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer8" },
                    { new Guid("def45678-9012-3456-def0-456789012345"), 0, "b2c3d4e5-f6a7-4b8c-9d0e-1b2c3d4e5f60", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "warehouse2@gmail.com", true, "Warehouse_2_first_name", "N/A", "N/A", "Warehouse_2_last_name", true, null, "WAREHOUSE2@gmail.com", "WAREHOUSE2", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0934455667", true, null, null, "D1E2F3EI4NHQTPOCMMT6KJZVZUAYSQXX", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "warehouse2" },
                    { new Guid("e6f7a8b9-c0d1-4e2f-9a3b-5c6d7e8f9012"), 0, "79c29eac-61d0-4d29-a59b-cdef2345b1c2", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer9@gmail.com", true, "Customer_9_first_name", "N/A", "N/A", "Customer_9_last_name", true, null, "CUSTOMER9@gmail.com", "CUSTOMER9", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0916677889", true, null, null, "C4D5E6EI4NHQTPOCMMT6KJZVZUAYSQXH", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer9" },
                    { new Guid("f1a3d7c8-3d50-42b7-9b92-b53717b8e7a8"), 0, "24de4957-1c8b-57e4-b046-7d83eaac57ab", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer4@gmail.com", true, "Customer_4_first_name", "N/A", "N/A", "Customer_4_last_name", true, null, "CUSTOMER4@gmail.com", "CUSTOMER4", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0911122233", true, null, null, "L9M7N8EI4NHQTPOCMMT6KJZVZUAYSQXC", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer4" },
                    { new Guid("f7a8b9c0-d1e2-4f3a-8b4c-6d7e8f901234"), 0, "8ad3afbd-72e1-4e3a-b6ac-def34567c2d3", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer10@gmail.com", true, "Customer_10_first_name", "N/A", "N/A", "Customer_10_last_name", true, null, "CUSTOMER10@gmail.com", "CUSTOMER10", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0917788990", true, null, null, "F7G8H9EI4NHQTPOCMMT6KJZVZUAYSQXI", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer10" }
                });

            migrationBuilder.UpdateData(
                table: "Workplace",
                keyColumn: "id",
                keyValue: new Guid("c1aeb9e5-8c74-4b09-bc57-d4c3df7857f9"),
                columns: new[] { "Name", "PhoneNumber" },
                values: new object[] { "Garage 1", "0983456789" });

            migrationBuilder.UpdateData(
                table: "Workplace",
                keyColumn: "id",
                keyValue: new Guid("e3dbf2c8-899d-4b2a-91f7-d2315d3f3bcb"),
                columns: new[] { "Name", "Status" },
                values: new object[] { "Warehouse 1", "Active" });

            migrationBuilder.InsertData(
                table: "Workplace",
                columns: new[] { "id", "Address", "CreatedAt", "District", "Name", "PhoneNumber", "Province", "Status", "UpdatedAt", "Ward", "WorkplaceType" },
                values: new object[,]
                {
                    { new Guid("4c809c47-7e87-4cec-a883-30e2718fed5e"), "432 Static Ave.", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Another District", "Warehouse 2", "0987084321", "Another Province", "Active", new DateTimeOffset(new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "60890", "Warehouse" },
                    { new Guid("6760cbb7-f1fa-445f-a175-97e3f060c861"), "124 Static St.", new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Static District", "Garage 2", "0983456139", "Static Province", "Active", new DateTimeOffset(new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "12345", "Garage" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeInfo",
                columns: new[] { "Id", "CitizenIdentification", "DateOfBirth", "Gender", "WorkplaceId" },
                values: new object[,]
                {
                    { new Guid("0a1b2c3d-4e5f-6789-abcd-ef0123456789"), "78213515", new DateOnly(1, 1, 1), true, new Guid("c1aeb9e5-8c74-4b09-bc57-d4c3df7857f9") },
                    { new Guid("1b2c3d4e-5f67-89ab-cdef-0123456789ab"), "78213514", new DateOnly(1, 1, 1), true, new Guid("c1aeb9e5-8c74-4b09-bc57-d4c3df7857f9") },
                    { new Guid("2c3d4e5f-6789-abcd-ef01-23456789abcd"), "78213513", new DateOnly(1, 1, 1), true, new Guid("c1aeb9e5-8c74-4b09-bc57-d4c3df7857f9") },
                    { new Guid("3d4e5f67-89ab-cdef-0123-456789abcdef"), "78213512", new DateOnly(1, 1, 1), true, new Guid("c1aeb9e5-8c74-4b09-bc57-d4c3df7857f9") },
                    { new Guid("4e5f6789-abcd-ef01-2345-6789abcdef01"), "78213511", new DateOnly(1, 1, 1), true, new Guid("c1aeb9e5-8c74-4b09-bc57-d4c3df7857f9") },
                    { new Guid("5f6789ab-cdef-0123-4567-89abcdef0123"), "51249", new DateOnly(1, 1, 1), true, new Guid("6760cbb7-f1fa-445f-a175-97e3f060c861") },
                    { new Guid("6789abcd-ef01-2345-6789-abcdef012345"), "51248", new DateOnly(1, 1, 1), true, new Guid("6760cbb7-f1fa-445f-a175-97e3f060c861") },
                    { new Guid("789abcde-f012-3456-789a-bcdef0123456"), "51247", new DateOnly(1, 1, 1), true, new Guid("6760cbb7-f1fa-445f-a175-97e3f060c861") },
                    { new Guid("89abcdef-0123-4567-89ab-cdef01234567"), "51246", new DateOnly(1, 1, 1), true, new Guid("6760cbb7-f1fa-445f-a175-97e3f060c861") },
                    { new Guid("9abcdef0-1234-5678-9abc-def012345678"), "51245", new DateOnly(1, 1, 1), true, new Guid("6760cbb7-f1fa-445f-a175-97e3f060c861") },
                    { new Guid("abcd1234-ef56-7890-abcd-ef1234567890"), "7821354", new DateOnly(1, 1, 1), true, new Guid("c1aeb9e5-8c74-4b09-bc57-d4c3df7857f9") },
                    { new Guid("bcde2345-f678-9012-bcde-f23456789012"), "51243", new DateOnly(1, 1, 1), true, new Guid("6760cbb7-f1fa-445f-a175-97e3f060c861") },
                    { new Guid("cdef3456-7890-1234-cdef-345678901234"), "7821352", new DateOnly(1, 1, 1), true, new Guid("4c809c47-7e87-4cec-a883-30e2718fed5e") },
                    { new Guid("def45678-9012-3456-def0-456789012345"), "51241", new DateOnly(1, 1, 1), true, new Guid("e3dbf2c8-899d-4b2a-91f7-d2315d3f3bcb") }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"), new Guid("0a1b2c3d-4e5f-6789-abcd-ef0123456789") },
                    { new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"), new Guid("1b2c3d4e-5f67-89ab-cdef-0123456789ab") },
                    { new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"), new Guid("2c3d4e5f-6789-abcd-ef01-23456789abcd") },
                    { new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"), new Guid("3d4e5f67-89ab-cdef-0123-456789abcdef") },
                    { new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"), new Guid("4e5f6789-abcd-ef01-2345-6789abcdef01") },
                    { new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"), new Guid("5f6789ab-cdef-0123-4567-89abcdef0123") },
                    { new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"), new Guid("6789abcd-ef01-2345-6789-abcdef012345") },
                    { new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"), new Guid("67f4a543-7ff4-4db9-bf4a-748d3f9e13b1") },
                    { new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"), new Guid("773d6761-8990-4408-be8f-321a7659825a") },
                    { new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"), new Guid("789abcde-f012-3456-789a-bcdef0123456") },
                    { new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"), new Guid("89abcdef-0123-4567-89ab-cdef01234567") },
                    { new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"), new Guid("9abcdef0-1234-5678-9abc-def012345678") },
                    { new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"), new Guid("a2e4f1b2-6f2d-42f7-a2b5-3a9b8c1d2e3f") },
                    { new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb739"), new Guid("abcd1234-ef56-7890-abcd-ef1234567890") },
                    { new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"), new Guid("b3c5d6e7-f8a9-4b0c-8d1e-2f3a4b5c6d7e") },
                    { new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb739"), new Guid("bcde2345-f678-9012-bcde-f23456789012") },
                    { new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"), new Guid("c4d5e6f7-a8b9-4c0d-9e1f-3a4b5c6d7e8f") },
                    { new Guid("b10aa072-2522-41d9-8e12-c20f28082a0e"), new Guid("cdef3456-7890-1234-cdef-345678901234") },
                    { new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"), new Guid("d4b8cfb8-8b97-4d6d-bf1b-90f17fd853f3") },
                    { new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"), new Guid("d5e6f7a8-b9c0-4d1e-8f2a-4b5c6d7e8f90") },
                    { new Guid("b10aa072-2522-41d9-8e12-c20f28082a0e"), new Guid("def45678-9012-3456-def0-456789012345") },
                    { new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"), new Guid("e6f7a8b9-c0d1-4e2f-9a3b-5c6d7e8f9012") },
                    { new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"), new Guid("f1a3d7c8-3d50-42b7-9b92-b53717b8e7a8") },
                    { new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"), new Guid("f7a8b9c0-d1e2-4f3a-8b4c-6d7e8f901234") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeInfo",
                keyColumn: "Id",
                keyValue: new Guid("0a1b2c3d-4e5f-6789-abcd-ef0123456789"));

            migrationBuilder.DeleteData(
                table: "EmployeeInfo",
                keyColumn: "Id",
                keyValue: new Guid("1b2c3d4e-5f67-89ab-cdef-0123456789ab"));

            migrationBuilder.DeleteData(
                table: "EmployeeInfo",
                keyColumn: "Id",
                keyValue: new Guid("2c3d4e5f-6789-abcd-ef01-23456789abcd"));

            migrationBuilder.DeleteData(
                table: "EmployeeInfo",
                keyColumn: "Id",
                keyValue: new Guid("3d4e5f67-89ab-cdef-0123-456789abcdef"));

            migrationBuilder.DeleteData(
                table: "EmployeeInfo",
                keyColumn: "Id",
                keyValue: new Guid("4e5f6789-abcd-ef01-2345-6789abcdef01"));

            migrationBuilder.DeleteData(
                table: "EmployeeInfo",
                keyColumn: "Id",
                keyValue: new Guid("5f6789ab-cdef-0123-4567-89abcdef0123"));

            migrationBuilder.DeleteData(
                table: "EmployeeInfo",
                keyColumn: "Id",
                keyValue: new Guid("6789abcd-ef01-2345-6789-abcdef012345"));

            migrationBuilder.DeleteData(
                table: "EmployeeInfo",
                keyColumn: "Id",
                keyValue: new Guid("789abcde-f012-3456-789a-bcdef0123456"));

            migrationBuilder.DeleteData(
                table: "EmployeeInfo",
                keyColumn: "Id",
                keyValue: new Guid("89abcdef-0123-4567-89ab-cdef01234567"));

            migrationBuilder.DeleteData(
                table: "EmployeeInfo",
                keyColumn: "Id",
                keyValue: new Guid("9abcdef0-1234-5678-9abc-def012345678"));

            migrationBuilder.DeleteData(
                table: "EmployeeInfo",
                keyColumn: "Id",
                keyValue: new Guid("abcd1234-ef56-7890-abcd-ef1234567890"));

            migrationBuilder.DeleteData(
                table: "EmployeeInfo",
                keyColumn: "Id",
                keyValue: new Guid("bcde2345-f678-9012-bcde-f23456789012"));

            migrationBuilder.DeleteData(
                table: "EmployeeInfo",
                keyColumn: "Id",
                keyValue: new Guid("cdef3456-7890-1234-cdef-345678901234"));

            migrationBuilder.DeleteData(
                table: "EmployeeInfo",
                keyColumn: "Id",
                keyValue: new Guid("def45678-9012-3456-def0-456789012345"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"), new Guid("0a1b2c3d-4e5f-6789-abcd-ef0123456789") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"), new Guid("1b2c3d4e-5f67-89ab-cdef-0123456789ab") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"), new Guid("2c3d4e5f-6789-abcd-ef01-23456789abcd") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"), new Guid("3d4e5f67-89ab-cdef-0123-456789abcdef") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"), new Guid("4e5f6789-abcd-ef01-2345-6789abcdef01") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"), new Guid("5f6789ab-cdef-0123-4567-89abcdef0123") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"), new Guid("6789abcd-ef01-2345-6789-abcdef012345") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"), new Guid("67f4a543-7ff4-4db9-bf4a-748d3f9e13b1") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"), new Guid("773d6761-8990-4408-be8f-321a7659825a") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"), new Guid("789abcde-f012-3456-789a-bcdef0123456") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"), new Guid("89abcdef-0123-4567-89ab-cdef01234567") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"), new Guid("9abcdef0-1234-5678-9abc-def012345678") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"), new Guid("a2e4f1b2-6f2d-42f7-a2b5-3a9b8c1d2e3f") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb739"), new Guid("abcd1234-ef56-7890-abcd-ef1234567890") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"), new Guid("b3c5d6e7-f8a9-4b0c-8d1e-2f3a4b5c6d7e") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb739"), new Guid("bcde2345-f678-9012-bcde-f23456789012") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"), new Guid("c4d5e6f7-a8b9-4c0d-9e1f-3a4b5c6d7e8f") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b10aa072-2522-41d9-8e12-c20f28082a0e"), new Guid("cdef3456-7890-1234-cdef-345678901234") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"), new Guid("d4b8cfb8-8b97-4d6d-bf1b-90f17fd853f3") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"), new Guid("d5e6f7a8-b9c0-4d1e-8f2a-4b5c6d7e8f90") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b10aa072-2522-41d9-8e12-c20f28082a0e"), new Guid("def45678-9012-3456-def0-456789012345") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"), new Guid("e6f7a8b9-c0d1-4e2f-9a3b-5c6d7e8f9012") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"), new Guid("f1a3d7c8-3d50-42b7-9b92-b53717b8e7a8") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"), new Guid("f7a8b9c0-d1e2-4f3a-8b4c-6d7e8f901234") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0a1b2c3d-4e5f-6789-abcd-ef0123456789"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1b2c3d4e-5f67-89ab-cdef-0123456789ab"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2c3d4e5f-6789-abcd-ef01-23456789abcd"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3d4e5f67-89ab-cdef-0123-456789abcdef"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4e5f6789-abcd-ef01-2345-6789abcdef01"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5f6789ab-cdef-0123-4567-89abcdef0123"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6789abcd-ef01-2345-6789-abcdef012345"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("67f4a543-7ff4-4db9-bf4a-748d3f9e13b1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("773d6761-8990-4408-be8f-321a7659825a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("789abcde-f012-3456-789a-bcdef0123456"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("89abcdef-0123-4567-89ab-cdef01234567"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9abcdef0-1234-5678-9abc-def012345678"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a2e4f1b2-6f2d-42f7-a2b5-3a9b8c1d2e3f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("abcd1234-ef56-7890-abcd-ef1234567890"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b3c5d6e7-f8a9-4b0c-8d1e-2f3a4b5c6d7e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bcde2345-f678-9012-bcde-f23456789012"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c4d5e6f7-a8b9-4c0d-9e1f-3a4b5c6d7e8f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cdef3456-7890-1234-cdef-345678901234"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d4b8cfb8-8b97-4d6d-bf1b-90f17fd853f3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d5e6f7a8-b9c0-4d1e-8f2a-4b5c6d7e8f90"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("def45678-9012-3456-def0-456789012345"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e6f7a8b9-c0d1-4e2f-9a3b-5c6d7e8f9012"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f1a3d7c8-3d50-42b7-9b92-b53717b8e7a8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f7a8b9c0-d1e2-4f3a-8b4c-6d7e8f901234"));

            migrationBuilder.DeleteData(
                table: "Workplace",
                keyColumn: "id",
                keyValue: new Guid("4c809c47-7e87-4cec-a883-30e2718fed5e"));

            migrationBuilder.DeleteData(
                table: "Workplace",
                keyColumn: "id",
                keyValue: new Guid("6760cbb7-f1fa-445f-a175-97e3f060c861"));

            migrationBuilder.UpdateData(
                table: "Workplace",
                keyColumn: "id",
                keyValue: new Guid("c1aeb9e5-8c74-4b09-bc57-d4c3df7857f9"),
                columns: new[] { "Name", "PhoneNumber" },
                values: new object[] { "Static Company 1", "0123456789" });

            migrationBuilder.UpdateData(
                table: "Workplace",
                keyColumn: "id",
                keyValue: new Guid("e3dbf2c8-899d-4b2a-91f7-d2315d3f3bcb"),
                columns: new[] { "Name", "Status" },
                values: new object[] { "Static Company 2", "Inactive" });
        }
    }
}
