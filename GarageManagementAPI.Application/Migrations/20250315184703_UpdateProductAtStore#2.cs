using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductAtStore2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "productatgarage_prodycid_foreign",
                table: "ProductAtGarage");

            migrationBuilder.AddColumn<Guid>(
                name: "GarageId",
                table: "ProductAtGarage",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ProductAtGarage_GarageId",
                table: "ProductAtGarage",
                column: "GarageId");

            migrationBuilder.AddForeignKey(
                name: "productatgarage_productid_foreign",
                table: "ProductAtGarage",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "productatgarage_workplaceId_foreign",
                table: "ProductAtGarage",
                column: "GarageId",
                principalTable: "Workplace",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "productatgarage_productid_foreign",
                table: "ProductAtGarage");

            migrationBuilder.DropForeignKey(
                name: "productatgarage_workplaceId_foreign",
                table: "ProductAtGarage");

            migrationBuilder.DropIndex(
                name: "IX_ProductAtGarage_GarageId",
                table: "ProductAtGarage");

            migrationBuilder.DropColumn(
                name: "GarageId",
                table: "ProductAtGarage");

            migrationBuilder.AddForeignKey(
                name: "productatgarage_prodycid_foreign",
                table: "ProductAtGarage",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
