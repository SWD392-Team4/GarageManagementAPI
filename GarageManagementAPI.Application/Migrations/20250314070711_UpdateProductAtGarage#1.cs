using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductAtGarage1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "ProductAtGarage",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ProductAtGarage_ProductId",
                table: "ProductAtGarage",
                column: "ProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "productatgarage_productid_foreign",
                table: "ProductAtGarage",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "productatgarage_productid_foreign",
                table: "ProductAtGarage");

            migrationBuilder.DropIndex(
                name: "IX_ProductAtGarage_ProductId",
                table: "ProductAtGarage");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductAtGarage");
        }
    }
}
