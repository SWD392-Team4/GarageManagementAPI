using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductSell : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "invoicesellproduct_productatgarageid_foreign",
                table: "InvoiceSellProduct");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductAtGarageId",
                table: "InvoiceSellProduct",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceSellProduct_ProductAtGarage_ProductAtGarageId",
                table: "InvoiceSellProduct",
                column: "ProductAtGarageId",
                principalTable: "ProductAtGarage",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceSellProduct_ProductAtGarage_ProductAtGarageId",
                table: "InvoiceSellProduct");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductAtGarageId",
                table: "InvoiceSellProduct",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "invoicesellproduct_productatgarageid_foreign",
                table: "InvoiceSellProduct",
                column: "ProductAtGarageId",
                principalTable: "ProductAtGarage",
                principalColumn: "Id");
        }
    }
}
