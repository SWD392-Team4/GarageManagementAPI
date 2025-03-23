using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class ConfigInvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "replacementpart_productatgarageid_foreign",
                table: "ReplacementPart");

            migrationBuilder.DropIndex(
                name: "replacementpart_invoiceappointmentdetailid_producthistoryid_productatgarageid_unique",
                table: "ReplacementPart");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "ReplacementPart");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "InvoiceServiceDetail");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductAtGarageId",
                table: "ReplacementPart",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateTable(
                name: "ReplacementPart_ProductAtGarage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductAtGarageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReplacementPartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuantityUsed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReplacementPart_ProductAtGarage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReplacementPart_ProductAtGarage_ProductAtGarage_ProductAtGarageId",
                        column: x => x.ProductAtGarageId,
                        principalTable: "ProductAtGarage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReplacementPart_ProductAtGarage_ReplacementPart_ReplacementPartId",
                        column: x => x.ReplacementPartId,
                        principalTable: "ReplacementPart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReplacementPart_ProductAtGarage_ProductAtGarageId",
                table: "ReplacementPart_ProductAtGarage",
                column: "ProductAtGarageId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplacementPart_ProductAtGarage_ReplacementPartId",
                table: "ReplacementPart_ProductAtGarage",
                column: "ReplacementPartId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReplacementPart_ProductAtGarage_ProductAtGarageId",
                table: "ReplacementPart",
                column: "ProductAtGarageId",
                principalTable: "ProductAtGarage",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReplacementPart_ProductAtGarage_ProductAtGarageId",
                table: "ReplacementPart");

            migrationBuilder.DropTable(
                name: "ReplacementPart_ProductAtGarage");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductAtGarageId",
                table: "ReplacementPart",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "ReplacementPart",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "InvoiceServiceDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "replacementpart_invoiceappointmentdetailid_producthistoryid_productatgarageid_unique",
                table: "ReplacementPart",
                columns: new[] { "InvoiceDetailId", "ProductHistoryId", "ProductAtGarageId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "replacementpart_productatgarageid_foreign",
                table: "ReplacementPart",
                column: "ProductAtGarageId",
                principalTable: "ProductAtGarage",
                principalColumn: "Id");
        }
    }
}
