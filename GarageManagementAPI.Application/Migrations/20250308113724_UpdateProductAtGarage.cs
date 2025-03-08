using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductAtGarage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "productatgarage_goodsissueddetailid_foreign",
                table: "ProductAtGarage");

            migrationBuilder.DropForeignKey(
                name: "productatwarehouse_goodsreceiveddetailid_foreign",
                table: "ProductAtWarehouse");

            migrationBuilder.AddColumn<Guid>(
                name: "GoodsReceivedDetailId",
                table: "ProductAtWarehouse",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "GoodsIssuedDetailId",
                table: "ProductAtGarage",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ProductAtWarehouse_GoodsReceivedDetailId",
                table: "ProductAtWarehouse",
                column: "GoodsReceivedDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductAtGarage_GoodsIssuedDetailId",
                table: "ProductAtGarage",
                column: "GoodsIssuedDetailId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "productatgarage_goodsissueddetailid_foreign",
                table: "ProductAtGarage",
                column: "GoodsIssuedDetailId",
                principalTable: "GoodsIssuedDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "productatwarehouse_goodsreceiveddetailid_foreign",
                table: "ProductAtWarehouse",
                column: "GoodsReceivedDetailId",
                principalTable: "GoodsReceivedDetail",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "productatgarage_goodsissueddetailid_foreign",
                table: "ProductAtGarage");

            migrationBuilder.DropForeignKey(
                name: "productatwarehouse_goodsreceiveddetailid_foreign",
                table: "ProductAtWarehouse");

            migrationBuilder.DropIndex(
                name: "IX_ProductAtWarehouse_GoodsReceivedDetailId",
                table: "ProductAtWarehouse");

            migrationBuilder.DropIndex(
                name: "IX_ProductAtGarage_GoodsIssuedDetailId",
                table: "ProductAtGarage");

            migrationBuilder.DropColumn(
                name: "GoodsReceivedDetailId",
                table: "ProductAtWarehouse");

            migrationBuilder.DropColumn(
                name: "GoodsIssuedDetailId",
                table: "ProductAtGarage");

            migrationBuilder.AddForeignKey(
                name: "productatgarage_goodsissueddetailid_foreign",
                table: "ProductAtGarage",
                column: "Id",
                principalTable: "GoodsIssuedDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "productatwarehouse_goodsreceiveddetailid_foreign",
                table: "ProductAtWarehouse",
                column: "Id",
                principalTable: "GoodsReceivedDetail",
                principalColumn: "Id");
        }
    }
}
