using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductAtGarage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "ProductAtGarage");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ProductAtGarage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "ProductAtGarage",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "ProductAtGarage",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
