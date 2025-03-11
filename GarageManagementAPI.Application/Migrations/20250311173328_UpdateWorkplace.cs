using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWorkplace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GarageId",
                table: "GoodsIssued",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_GoodsIssued_GarageId",
                table: "GoodsIssued",
                column: "GarageId");

            migrationBuilder.AddForeignKey(
                name: "goodsissued_garageid_foreign",
                table: "GoodsIssued",
                column: "GarageId",
                principalTable: "Workplace",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "goodsissued_garageid_foreign",
                table: "GoodsIssued");

            migrationBuilder.DropIndex(
                name: "IX_GoodsIssued_GarageId",
                table: "GoodsIssued");

            migrationBuilder.DropColumn(
                name: "GarageId",
                table: "GoodsIssued");
        }
    }
}
