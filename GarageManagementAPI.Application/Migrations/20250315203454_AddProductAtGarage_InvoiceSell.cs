using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class AddProductAtGarage_InvoiceSell : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GarageId",
                table: "ProductAtGarage",
                newName: "WorkplaceId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductAtGarage_GarageId",
                table: "ProductAtGarage",
                newName: "IX_ProductAtGarage_WorkplaceId");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "InvoiceSellProduct",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "InvoiceSellProduct_ProductAtGarage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductductAtGarageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductAtGarageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceSellProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuantityUsed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceSellProduct_ProductAtGarage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceSellProduct_ProductAtGarage_InvoiceSellProduct_InvoiceSellProductId",
                        column: x => x.InvoiceSellProductId,
                        principalTable: "InvoiceSellProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceSellProduct_ProductAtGarage_ProductAtGarage_ProductAtGarageId",
                        column: x => x.ProductAtGarageId,
                        principalTable: "ProductAtGarage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceSellProduct_ProductAtGarage_InvoiceSellProductId",
                table: "InvoiceSellProduct_ProductAtGarage",
                column: "InvoiceSellProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceSellProduct_ProductAtGarage_ProductAtGarageId",
                table: "InvoiceSellProduct_ProductAtGarage",
                column: "ProductAtGarageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceSellProduct_ProductAtGarage");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "InvoiceSellProduct");

            migrationBuilder.RenameColumn(
                name: "WorkplaceId",
                table: "ProductAtGarage",
                newName: "GarageId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductAtGarage_WorkplaceId",
                table: "ProductAtGarage",
                newName: "IX_ProductAtGarage_GarageId");
        }
    }
}
