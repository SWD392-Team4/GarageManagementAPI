using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class CraeteAppointmentReplacementPartProductAtGarage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "appointmentreplacementpart_productatgarageid_foreign",
                table: "AppointmentReplacementPart");

            migrationBuilder.CreateTable(
                name: "AppointmentReplacementPart_ProductAtGarage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductAtGarageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppointmentReplacementPartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuantityUsed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentReplacementPart_ProductAtGarage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentReplacementPart_ProductAtGarage_AppointmentReplacementPart_AppointmentReplacementPartId",
                        column: x => x.AppointmentReplacementPartId,
                        principalTable: "AppointmentReplacementPart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentReplacementPart_ProductAtGarage_ProductAtGarage_ProductAtGarageId",
                        column: x => x.ProductAtGarageId,
                        principalTable: "ProductAtGarage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentReplacementPart_ProductAtGarage_AppointmentReplacementPartId",
                table: "AppointmentReplacementPart_ProductAtGarage",
                column: "AppointmentReplacementPartId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentReplacementPart_ProductAtGarage_ProductAtGarageId",
                table: "AppointmentReplacementPart_ProductAtGarage",
                column: "ProductAtGarageId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentReplacementPart_ProductAtGarage_ProductAtGarageId",
                table: "AppointmentReplacementPart",
                column: "ProductAtGarageId",
                principalTable: "ProductAtGarage",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentReplacementPart_ProductAtGarage_ProductAtGarageId",
                table: "AppointmentReplacementPart");

            migrationBuilder.DropTable(
                name: "AppointmentReplacementPart_ProductAtGarage");

            migrationBuilder.AddForeignKey(
                name: "appointmentreplacementpart_productatgarageid_foreign",
                table: "AppointmentReplacementPart",
                column: "ProductAtGarageId",
                principalTable: "ProductAtGarage",
                principalColumn: "Id");
        }
    }
}
