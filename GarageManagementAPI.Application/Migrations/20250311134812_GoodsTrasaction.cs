using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class GoodsTrasaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductAtWarehouse_Barcode",
                table: "ProductAtWarehouse");

            migrationBuilder.DropColumn(
                name: "Barcode",
                table: "ProductAtWarehouse");

            migrationBuilder.DropColumn(
                name: "Barcode",
                table: "GoodsReceivedDetail");

            migrationBuilder.DropColumn(
                name: "Barcode",
                table: "GoodsIssuedDetail");

            migrationBuilder.CreateTable(
                name: "GoodsTransaction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    goodsIssuedDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GoodsReceivedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoodsTransaction_GoodsIssuedDetail_goodsIssuedDetailId",
                        column: x => x.goodsIssuedDetailId,
                        principalTable: "GoodsIssuedDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoodsTransaction_GoodsReceived_GoodsReceivedId",
                        column: x => x.GoodsReceivedId,
                        principalTable: "GoodsReceived",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GoodsTransaction_goodsIssuedDetailId",
                table: "GoodsTransaction",
                column: "goodsIssuedDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsTransaction_GoodsReceivedId",
                table: "GoodsTransaction",
                column: "GoodsReceivedId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoodsTransaction");

            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                table: "ProductAtWarehouse",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                table: "GoodsReceivedDetail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                table: "GoodsIssuedDetail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAtWarehouse_Barcode",
                table: "ProductAtWarehouse",
                column: "Barcode",
                unique: true);
        }
    }
}
