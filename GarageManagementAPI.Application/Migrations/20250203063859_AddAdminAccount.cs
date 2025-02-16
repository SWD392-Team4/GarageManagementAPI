using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "Image", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("1230a288-3e5e-4ee1-a75c-3fd7af6480a0"), 0, "6daf287a-eba6-437d-b358-018a073059c9", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "hanhthse171828@fpt.edu.vn", true, "Hanh", null, "Trần", true, null, "HANHTHSE171828@FPT.EDU.VN", "HANHTHSE171828", "AQAAAAIAAYagAAAAEM1Ha9Qvsjr4ZYn0G3EVnXw9NCOzJAUH5/8W+aVGNQYFCdX3oOOSMtJTvohWbcohuA==", "0902596147", true, null, null, "P7XZM6YDXPFYIY32RM5TXWUN54ISRUSB", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "hanhthse171828" },
                    { new Guid("b78245a2-a2bf-45b4-8572-b2c3f1948629"), 0, "ea354e65-522c-4931-99e2-cff427b74b14", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "tannhnse171836@fpt.edu.vn", true, "Tân", null, "Nguyễn", true, null, "TANNHNSE171836@FPT.EDU.VN", "TANNHNSE171836", "AQAAAAIAAYagAAAAEIAkdif146dK+20v4+41Unot91RU8IPXdeCTz7BFJuTHznQt/EeVm4wX5Uj9l0XYmA==", "0902596148", true, null, null, "KLYQWCV3ZURKCJ7LH2HXECD27E5CC3YZ", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "tannhnse171836" },
                    { new Guid("de0d20e6-17e6-40e8-8274-c89a66e64fa5"), 0, "db2f38c8-64ae-438f-a28d-34074e1e4a42", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "khanhbdse173224@fpt.edu.vn", true, "Khánh", null, "Bùi", true, null, "KHANHBDSE173224@FPT.EDU.VN", "KHANHBDSE173224", "AQAAAAIAAYagAAAAEM8HN46vRsKmlCeYqZXwtRzylfbdmE/IlaRy8NUGvve7BEWIU2SR93NV4bw/bEe8Iw==", "0902596149", true, null, null, "NNC3W4EI4NHQTPOCMMT6KJZVZUAYSQXT", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "khanhbdse173224" },
                    { new Guid("e2060ff5-5fb9-4b20-a11a-bf6ae4716ad5"), 0, "0834ee87-36fb-4002-844d-12adb9910e3c", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "giangnthse183257@fpt.edu.vn", true, "Giang", null, "Nguyễn", true, null, "GIANGNTHSE183257@FPT.EDU.VN", "GIANGNTHSE183257", "AQAAAAIAAYagAAAAEJxI/AyF6NXvHVHrfnu9kLzmRHOHOq8dDZwRUD9GWWkzLee8u4C8TmYw4A6R3bInDg==", "0902596142", true, null, null, "CKQPC56VA55WBN7KB3AXN4PKT4HHRQDA", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "giangnthse183257" },
                    { new Guid("f8a4e60d-3113-4f25-8477-be205b0860c9"), 0, "34ab88bc-a7f7-49b1-bdda-50c2a0850b64", new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "tanlhnse171831@fpt.edu.vn", true, "Tân", null, "Lê", true, null, "TANLHNSE171831@FPT.EDU.VN", "TANLHNSE171831", "AQAAAAIAAYagAAAAEE8W3WHfSOaP5A3wiInfQ85VBHjz7kBqx4jZUgJenP7T1ArBJU3JQvHEguudGCBChA==", "0902596143", true, null, null, "R44AGPSXQCFMH6LRBGSWBK3PZKZP6LUT", "Active", false, new DateTimeOffset(new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "tanlhnse171831" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("ef3629ba-332e-4c46-9fa8-54444803f925"), new Guid("1230a288-3e5e-4ee1-a75c-3fd7af6480a0") },
                    { new Guid("ef3629ba-332e-4c46-9fa8-54444803f925"), new Guid("b78245a2-a2bf-45b4-8572-b2c3f1948629") },
                    { new Guid("ef3629ba-332e-4c46-9fa8-54444803f925"), new Guid("de0d20e6-17e6-40e8-8274-c89a66e64fa5") },
                    { new Guid("ef3629ba-332e-4c46-9fa8-54444803f925"), new Guid("e2060ff5-5fb9-4b20-a11a-bf6ae4716ad5") },
                    { new Guid("ef3629ba-332e-4c46-9fa8-54444803f925"), new Guid("f8a4e60d-3113-4f25-8477-be205b0860c9") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ef3629ba-332e-4c46-9fa8-54444803f925"), new Guid("1230a288-3e5e-4ee1-a75c-3fd7af6480a0") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ef3629ba-332e-4c46-9fa8-54444803f925"), new Guid("b78245a2-a2bf-45b4-8572-b2c3f1948629") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ef3629ba-332e-4c46-9fa8-54444803f925"), new Guid("de0d20e6-17e6-40e8-8274-c89a66e64fa5") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ef3629ba-332e-4c46-9fa8-54444803f925"), new Guid("e2060ff5-5fb9-4b20-a11a-bf6ae4716ad5") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ef3629ba-332e-4c46-9fa8-54444803f925"), new Guid("f8a4e60d-3113-4f25-8477-be205b0860c9") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1230a288-3e5e-4ee1-a75c-3fd7af6480a0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b78245a2-a2bf-45b4-8572-b2c3f1948629"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("de0d20e6-17e6-40e8-8274-c89a66e64fa5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e2060ff5-5fb9-4b20-a11a-bf6ae4716ad5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f8a4e60d-3113-4f25-8477-be205b0860c9"));
        }
    }
}
