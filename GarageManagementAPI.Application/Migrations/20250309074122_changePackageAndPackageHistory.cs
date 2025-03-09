using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class changePackageAndPackageHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CarCategoryId",
                table: "PackageHistory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PackageHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PackageName",
                table: "PackageHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ServiceCategory",
                table: "PackageHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "PackageHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ServiceCategory",
                table: "Package",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<decimal>(
                name: "PackagePrice",
                table: "Package",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Package",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TimeUnit",
                table: "Package",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UsageLimit",
                table: "Package",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ValidityPeriod",
                table: "Package",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarCategoryId",
                table: "PackageHistory");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "PackageHistory");

            migrationBuilder.DropColumn(
                name: "PackageName",
                table: "PackageHistory");

            migrationBuilder.DropColumn(
                name: "ServiceCategory",
                table: "PackageHistory");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "PackageHistory");

            migrationBuilder.DropColumn(
                name: "PackagePrice",
                table: "Package");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Package");

            migrationBuilder.DropColumn(
                name: "TimeUnit",
                table: "Package");

            migrationBuilder.DropColumn(
                name: "UsageLimit",
                table: "Package");

            migrationBuilder.DropColumn(
                name: "ValidityPeriod",
                table: "Package");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceCategory",
                table: "Package",
                type: "int",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);
        }
    }
}
