using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Garages_GarageId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Employees");

            migrationBuilder.AlterColumn<Guid>(
                name: "GarageId",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                column: "GarageId",
                value: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("58a4c24b-7a4d-48f4-b793-a35a1d88c4d5"),
                column: "GarageId",
                value: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                column: "GarageId",
                value: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                column: "GarageId",
                value: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Garages_GarageId",
                table: "Employees",
                column: "GarageId",
                principalTable: "Garages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Garages_GarageId",
                table: "Employees");

            migrationBuilder.AlterColumn<Guid>(
                name: "GarageId",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                columns: new[] { "CompanyId", "GarageId" },
                values: new object[] { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("58a4c24b-7a4d-48f4-b793-a35a1d88c4d5"),
                columns: new[] { "CompanyId", "GarageId" },
                values: new object[] { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                columns: new[] { "CompanyId", "GarageId" },
                values: new object[] { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                columns: new[] { "CompanyId", "GarageId" },
                values: new object[] { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), null });

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Garages_GarageId",
                table: "Employees",
                column: "GarageId",
                principalTable: "Garages",
                principalColumn: "Id");
        }
    }
}
