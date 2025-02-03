using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class ConfigCascadeWhendeleteEmployeeInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "employeeinfo_userid_foreign",
                table: "EmployeeInfo");

            migrationBuilder.DropForeignKey(
                name: "employeeinfo_workplaceid_foreign",
                table: "EmployeeInfo");

            migrationBuilder.AlterColumn<Guid>(
                name: "WorkplaceId",
                table: "EmployeeInfo",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "employeeinfo_userid_foreign",
                table: "EmployeeInfo",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "employeeinfo_workplaceid_foreign",
                table: "EmployeeInfo",
                column: "WorkplaceId",
                principalTable: "Workplace",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "employeeinfo_userid_foreign",
                table: "EmployeeInfo");

            migrationBuilder.DropForeignKey(
                name: "employeeinfo_workplaceid_foreign",
                table: "EmployeeInfo");

            migrationBuilder.AlterColumn<Guid>(
                name: "WorkplaceId",
                table: "EmployeeInfo",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "employeeinfo_userid_foreign",
                table: "EmployeeInfo",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "employeeinfo_workplaceid_foreign",
                table: "EmployeeInfo",
                column: "WorkplaceId",
                principalTable: "Workplace",
                principalColumn: "id");
        }
    }
}
