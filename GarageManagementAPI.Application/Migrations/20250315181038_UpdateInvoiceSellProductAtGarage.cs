using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInvoiceSellProductAtGarage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "invoicesellproduct_producthistoryid_foreign",
                table: "InvoiceSellProduct");

            migrationBuilder.DropIndex(
                name: "invoicesellproduct_producthistoryid_invoiceid_productatgarageid_unique",
                table: "InvoiceSellProduct");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductHistoryId",
                table: "InvoiceSellProduct",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceSellProduct_ProductHistoryId",
                table: "InvoiceSellProduct",
                column: "ProductHistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceSellProduct_ProductHistory_ProductHistoryId",
                table: "InvoiceSellProduct",
                column: "ProductHistoryId",
                principalTable: "ProductHistory",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceSellProduct_ProductHistory_ProductHistoryId",
                table: "InvoiceSellProduct");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceSellProduct_ProductHistoryId",
                table: "InvoiceSellProduct");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductHistoryId",
                table: "InvoiceSellProduct",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "invoicesellproduct_producthistoryid_invoiceid_productatgarageid_unique",
                table: "InvoiceSellProduct",
                columns: new[] { "ProductHistoryId", "InvoiceId", "ProductAtGarageId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "invoicesellproduct_producthistoryid_foreign",
                table: "InvoiceSellProduct",
                column: "ProductHistoryId",
                principalTable: "ProductHistory",
                principalColumn: "Id");
        }
    }
}
