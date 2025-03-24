using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                keyValue: new Guid("b3c5d6e7-f8a9-4b0c-8d1e-2f3a4b5c6d7e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c4d5e6f7-a8b9-4c0d-9e1f-3a4b5c6d7e8f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d5e6f7a8-b9c0-4d1e-8f2a-4b5c6d7e8f90"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e6f7a8b9-c0d1-4e2f-9a3b-5c6d7e8f9012"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f7a8b9c0-d1e2-4f3a-8b4c-6d7e8f901234"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "ImageId", "ImageLink", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("5f6789ab-cdef-0123-4567-89abcdef0123"), 0, "a7d9e2f6-8b6c-4e14-ef2a-bc78dcdabd1b", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic6@gmail.com", true, "Mechanic_6_first_name", "N/A", "N/A", "Mechanic_6_last_name", true, null, "MECHANIC6@gmail.com", "MECHANIC6", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0926677889", true, null, null, "Y4Z5A6EI4NHQTPOCMMT6KJZVZUAYSQXO", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic6" },
                    { new Guid("6789abcd-ef01-2345-6789-abcdef012345"), 0, "b8eaf307-9c7d-4f15-ef3b-cd89edcbce2c", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic7@gmail.com", true, "Mechanic_7_first_name", "N/A", "N/A", "Mechanic_7_last_name", true, null, "MECHANIC7@gmail.com", "MECHANIC7", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0927788990", true, null, null, "B7C8D9EI4NHQTPOCMMT6KJZVZUAYSQXP", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic7" },
                    { new Guid("789abcde-f012-3456-789a-bcdef0123456"), 0, "c9f0a418-ad8e-4a16-ef4c-de90feacdf3d", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic8@gmail.com", true, "Mechanic_8_first_name", "N/A", "N/A", "Mechanic_8_last_name", true, null, "MECHANIC8@gmail.com", "MECHANIC8", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0928899001", true, null, null, "E0F1G2EI4NHQTPOCMMT6KJZVZUAYSQXQ", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic8" },
                    { new Guid("89abcdef-0123-4567-89ab-cdef01234567"), 0, "da012529-be9f-4b17-ef5d-ef01afbd0e4e", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic9@gmail.com", true, "Mechanic_9_first_name", "N/A", "N/A", "Mechanic_9_last_name", true, null, "MECHANIC9@gmail.com", "MECHANIC9", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0929900112", true, null, null, "H3I4J5EI4NHQTPOCMMT6KJZVZUAYSQXR", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic9" },
                    { new Guid("9abcdef0-1234-5678-9abc-def012345678"), 0, "eb12363a-cf10-4c18-ef6e-f012becd1f5f", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic10@gmail.com", true, "Mechanic_10_first_name", "N/A", "N/A", "Mechanic_10_last_name", true, null, "MECHANIC10@gmail.com", "MECHANIC10", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0930011223", true, null, null, "K6L7M8EI4NHQTPOCMMT6KJZVZUAYSQXS", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "mechanic10" },
                    { new Guid("b3c5d6e7-f8a9-4b0c-8d1e-2f3a4b5c6d7e"), 0, "46ff6b79-3ead-4af6-d268-9fabc0cda79d", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer6@gmail.com", true, "Customer_6_first_name", "N/A", "N/A", "Customer_6_last_name", true, null, "CUSTOMER6@gmail.com", "CUSTOMER6", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0913344556", true, null, null, "S4T5U6EI4NHQTPOCMMT6KJZVZUAYSQXE", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer6" },
                    { new Guid("c4d5e6f7-a8b9-4c0d-9e1f-3a4b5c6d7e8f"), 0, "57a07c8a-4fbe-4b07-e379-afbcde1eb8ae", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer7@gmail.com", true, "Customer_7_first_name", "N/A", "N/A", "Customer_7_last_name", true, null, "CUSTOMER7@gmail.com", "CUSTOMER7", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0914455667", true, null, null, "V7W8X9EI4NHQTPOCMMT6KJZVZUAYSQXF", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer7" },
                    { new Guid("d5e6f7a8-b9c0-4d1e-8f2a-4b5c6d7e8f90"), 0, "68b18d9b-50cf-4c18-f48a-bcdef1234a0b", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer8@gmail.com", true, "Customer_8_first_name", "N/A", "N/A", "Customer_8_last_name", true, null, "CUSTOMER8@gmail.com", "CUSTOMER8", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0915566778", true, null, null, "Z1A2B3EI4NHQTPOCMMT6KJZVZUAYSQXG", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer8" },
                    { new Guid("e6f7a8b9-c0d1-4e2f-9a3b-5c6d7e8f9012"), 0, "79c29eac-61d0-4d29-a59b-cdef2345b1c2", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer9@gmail.com", true, "Customer_9_first_name", "N/A", "N/A", "Customer_9_last_name", true, null, "CUSTOMER9@gmail.com", "CUSTOMER9", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0916677889", true, null, null, "C4D5E6EI4NHQTPOCMMT6KJZVZUAYSQXH", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer9" },
                    { new Guid("f7a8b9c0-d1e2-4f3a-8b4c-6d7e8f901234"), 0, "8ad3afbd-72e1-4e3a-b6ac-def34567c2d3", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer10@gmail.com", true, "Customer_10_first_name", "N/A", "N/A", "Customer_10_last_name", true, null, "CUSTOMER10@gmail.com", "CUSTOMER10", "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", "0917788990", true, null, null, "F7G8H9EI4NHQTPOCMMT6KJZVZUAYSQXI", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "customer10" }
                });
        }
    }
}
