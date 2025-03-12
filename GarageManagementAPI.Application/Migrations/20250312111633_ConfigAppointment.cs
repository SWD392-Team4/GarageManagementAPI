using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class ConfigAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "appointmentdetail_updatebycustomerid_foreign",
                table: "AppointmentDetail");

            migrationBuilder.DropForeignKey(
                name: "appointmentdetail_updatebyemployeeid_foreign",
                table: "AppointmentDetail");

            migrationBuilder.DropForeignKey(
                name: "appointmentdetailpackage_updatebycustomerid_foreign",
                table: "AppointmentDetailPackage");

            migrationBuilder.DropForeignKey(
                name: "appointmentdetailpackage_updatebyemployeeid_foreign",
                table: "AppointmentDetailPackage");

            migrationBuilder.RenameColumn(
                name: "UpdateByEmployeeId",
                table: "AppointmentDetailPackage",
                newName: "UserId1");

            migrationBuilder.RenameColumn(
                name: "UpdateByCustomerId",
                table: "AppointmentDetailPackage",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentDetailPackage_UpdateByEmployeeId",
                table: "AppointmentDetailPackage",
                newName: "IX_AppointmentDetailPackage_UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentDetailPackage_UpdateByCustomerId",
                table: "AppointmentDetailPackage",
                newName: "IX_AppointmentDetailPackage_UserId");

            migrationBuilder.RenameColumn(
                name: "UpdateByEmployeeId",
                table: "AppointmentDetail",
                newName: "UserId1");

            migrationBuilder.RenameColumn(
                name: "UpdateByCustomerId",
                table: "AppointmentDetail",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentDetail_UpdateByEmployeeId",
                table: "AppointmentDetail",
                newName: "IX_AppointmentDetail_UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentDetail_UpdateByCustomerId",
                table: "AppointmentDetail",
                newName: "IX_AppointmentDetail_UserId");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"),
                columns: new[] { "ProductPrice", "UpdatedAt" },
                values: new object[] { 1500m, new DateTimeOffset(new DateTime(2025, 2, 25, 0, 40, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("cee5a4d8-de84-4482-9da9-302e2290cb0f"),
                column: "ProductPrice",
                value: 1200m);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("e9a7beda-ff63-4ac5-92cb-b7fa152c41c2"),
                column: "ProductPrice",
                value: 800m);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"),
                column: "ProductPrice",
                value: 300m);

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

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentDetail_Users_UserId",
                table: "AppointmentDetail",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentDetail_Users_UserId1",
                table: "AppointmentDetail",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentDetailPackage_Users_UserId",
                table: "AppointmentDetailPackage",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentDetailPackage_Users_UserId1",
                table: "AppointmentDetailPackage",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentDetail_Users_UserId",
                table: "AppointmentDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentDetail_Users_UserId1",
                table: "AppointmentDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentDetailPackage_Users_UserId",
                table: "AppointmentDetailPackage");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentDetailPackage_Users_UserId1",
                table: "AppointmentDetailPackage");

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

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "AppointmentDetailPackage",
                newName: "UpdateByEmployeeId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AppointmentDetailPackage",
                newName: "UpdateByCustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentDetailPackage_UserId1",
                table: "AppointmentDetailPackage",
                newName: "IX_AppointmentDetailPackage_UpdateByEmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentDetailPackage_UserId",
                table: "AppointmentDetailPackage",
                newName: "IX_AppointmentDetailPackage_UpdateByCustomerId");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "AppointmentDetail",
                newName: "UpdateByEmployeeId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AppointmentDetail",
                newName: "UpdateByCustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentDetail_UserId1",
                table: "AppointmentDetail",
                newName: "IX_AppointmentDetail_UpdateByEmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentDetail_UserId",
                table: "AppointmentDetail",
                newName: "IX_AppointmentDetail_UpdateByCustomerId");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"),
                columns: new[] { "ProductPrice", "UpdatedAt" },
                values: new object[] { 0m, new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("cee5a4d8-de84-4482-9da9-302e2290cb0f"),
                column: "ProductPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("e9a7beda-ff63-4ac5-92cb-b7fa152c41c2"),
                column: "ProductPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"),
                column: "ProductPrice",
                value: 0m);

            migrationBuilder.AddForeignKey(
                name: "appointmentdetail_updatebycustomerid_foreign",
                table: "AppointmentDetail",
                column: "UpdateByCustomerId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "appointmentdetail_updatebyemployeeid_foreign",
                table: "AppointmentDetail",
                column: "UpdateByEmployeeId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "appointmentdetailpackage_updatebycustomerid_foreign",
                table: "AppointmentDetailPackage",
                column: "UpdateByCustomerId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "appointmentdetailpackage_updatebyemployeeid_foreign",
                table: "AppointmentDetailPackage",
                column: "UpdateByEmployeeId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
