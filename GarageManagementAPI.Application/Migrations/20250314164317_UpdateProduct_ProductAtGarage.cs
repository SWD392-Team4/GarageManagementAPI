using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProduct_ProductAtGarage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "productatgarage_productid_foreign",
                table: "ProductAtGarage");

            migrationBuilder.DropIndex(
                name: "IX_ProductAtGarage_ProductId",
                table: "ProductAtGarage");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAtGarage_ProductId",
                table: "ProductAtGarage",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "productatgarage_prodycid_foreign",
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
                name: "productatgarage_prodycid_foreign",
                table: "ProductAtGarage");

            migrationBuilder.DropIndex(
                name: "IX_ProductAtGarage_ProductId",
                table: "ProductAtGarage");

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
    }
}
