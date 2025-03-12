using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class AddGoodsIssuedDetail_ProductAtWarehouse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "goodsissueddetail_productatwarehouseid_foreign",
                table: "GoodsIssuedDetail");

            migrationBuilder.DropIndex(
                name: "goodsissueddetail_productatwarehouseid_index",
                table: "GoodsIssuedDetail");

            migrationBuilder.DropColumn(
                name: "ProductAtWareHouseId",
                table: "GoodsIssuedDetail");

            migrationBuilder.AddColumn<Guid>(
                name: "GoodsIssuedDetail_ProductAtWarehouseConfiguration",
                table: "GoodsIssued",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "GoodsIssuedDetail_ProductAtWarehouse",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GoodsIssuedDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductAtWarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuantityUsed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsIssuedDetail_ProductAtWarehouse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoodsIssuedDetail_ProductAtWarehouse_GoodsIssuedDetail_GoodsIssuedDetailId",
                        column: x => x.GoodsIssuedDetailId,
                        principalTable: "GoodsIssuedDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoodsIssuedDetail_ProductAtWarehouse_ProductAtWarehouse_ProductAtWarehouseId",
                        column: x => x.ProductAtWarehouseId,
                        principalTable: "ProductAtWarehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GoodsIssuedDetail_ProductAtWarehouse_GoodsIssuedDetailId",
                table: "GoodsIssuedDetail_ProductAtWarehouse",
                column: "GoodsIssuedDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsIssuedDetail_ProductAtWarehouse_ProductAtWarehouseId",
                table: "GoodsIssuedDetail_ProductAtWarehouse",
                column: "ProductAtWarehouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoodsIssuedDetail_ProductAtWarehouse");

            migrationBuilder.DropColumn(
                name: "GoodsIssuedDetail_ProductAtWarehouseConfiguration",
                table: "GoodsIssued");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductAtWareHouseId",
                table: "GoodsIssuedDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "goodsissueddetail_productatwarehouseid_index",
                table: "GoodsIssuedDetail",
                column: "ProductAtWareHouseId");

            migrationBuilder.AddForeignKey(
                name: "goodsissueddetail_productatwarehouseid_foreign",
                table: "GoodsIssuedDetail",
                column: "ProductAtWareHouseId",
                principalTable: "ProductAtWarehouse",
                principalColumn: "Id");
        }
    }
}
