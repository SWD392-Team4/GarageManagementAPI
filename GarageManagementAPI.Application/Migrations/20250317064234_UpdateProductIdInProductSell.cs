using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductIdInProductSell : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "InvoiceSellProduct",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceSellProduct_ProductId",
                table: "InvoiceSellProduct",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "invoicesellproduct_productid_foreign",
                table: "InvoiceSellProduct",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "invoicesellproduct_productid_foreign",
                table: "InvoiceSellProduct");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceSellProduct_ProductId",
                table: "InvoiceSellProduct");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "InvoiceSellProduct");
        }
    }
}
