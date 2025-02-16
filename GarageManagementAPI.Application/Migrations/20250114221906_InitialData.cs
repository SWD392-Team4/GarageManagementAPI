using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "CitizenIdentification", "CompanyId", "DateOfBirth", "Email", "GarageId", "Gender", "Name", "PhoneNumber", "Role", "Status" },
                values: new object[,]
                {
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), "Thành Phố Hồ Chí Minh", "023403128074", new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), new DateOnly(2003, 1, 10), "nhntan124@gmail.com", null, true, "Nguyễn Hoàng Nhựt Tân", "0254677111", "Cashier", "Active" },
                    { new Guid("58a4c24b-7a4d-48f4-b793-a35a1d88c4d5"), "Thành Phố Hồ Chí Minh", "031452126172", new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), new DateOnly(2003, 1, 13), "nhnkhanh@gmail.com", null, true, "Nguyễn Khánh", "0354675122", "Mechanic", "Active" },
                    { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), "Thành Phố Hồ Chí Minh", "079203028046", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), new DateOnly(2003, 11, 17), "nightfury455@gmail.com", null, true, "Lê Hoàng Nhật Tân", "0343663841", "Mechanic", "Active" },
                    { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), "Thành phố Tây Ninh", "031204029041", new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), new DateOnly(2003, 3, 6), "huyhanhoppo@gmail.com", null, true, "Trần Huy Hanh", "0934256427", "Cashier", "Active" }
                });

            migrationBuilder.InsertData(
                table: "Garages",
                columns: new[] { "Id", "Address", "City", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Số 1 Quang Trung, Phường 3, Quận Gò Vấp", "Hồ Chí Minh", "Head Việt Thái Quân", "02871098198" },
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Toà nhà UOA, 6 Tân Trào, Tân Phú, Quận 7", "Hồ Chí Minh", "Revzone Yamaha Motor", "0343663841" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("58a4c24b-7a4d-48f4-b793-a35a1d88c4d5"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"));

            migrationBuilder.DeleteData(
                table: "Garages",
                keyColumn: "Id",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.DeleteData(
                table: "Garages",
                keyColumn: "Id",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
