using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class CraeteAppointmentReplacementPartProductAtGarageV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentReplacementPart_ProductAtGarage_ProductAtGarageId",
                table: "AppointmentReplacementPart");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentReplacementPart_ProductAtGarageId",
                table: "AppointmentReplacementPart");

            migrationBuilder.DropColumn(
                name: "ProductAtGarageId",
                table: "AppointmentReplacementPart");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProductAtGarageId",
                table: "AppointmentReplacementPart",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentReplacementPart_ProductAtGarageId",
                table: "AppointmentReplacementPart",
                column: "ProductAtGarageId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentReplacementPart_ProductAtGarage_ProductAtGarageId",
                table: "AppointmentReplacementPart",
                column: "ProductAtGarageId",
                principalTable: "ProductAtGarage",
                principalColumn: "Id");
        }
    }
}
