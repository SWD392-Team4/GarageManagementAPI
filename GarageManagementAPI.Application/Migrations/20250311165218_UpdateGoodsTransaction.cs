using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGoodsTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodsTransaction_GoodsIssuedDetail_goodsIssuedDetailId",
                table: "GoodsTransaction");

            migrationBuilder.RenameColumn(
                name: "goodsIssuedDetailId",
                table: "GoodsTransaction",
                newName: "GoodsIssuedDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_GoodsTransaction_goodsIssuedDetailId",
                table: "GoodsTransaction",
                newName: "IX_GoodsTransaction_GoodsIssuedDetailId");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "GoodsTransaction",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsTransaction_GoodsIssuedDetail_GoodsIssuedDetailId",
                table: "GoodsTransaction",
                column: "GoodsIssuedDetailId",
                principalTable: "GoodsIssuedDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodsTransaction_GoodsIssuedDetail_GoodsIssuedDetailId",
                table: "GoodsTransaction");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GoodsTransaction");

            migrationBuilder.RenameColumn(
                name: "GoodsIssuedDetailId",
                table: "GoodsTransaction",
                newName: "goodsIssuedDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_GoodsTransaction_GoodsIssuedDetailId",
                table: "GoodsTransaction",
                newName: "IX_GoodsTransaction_goodsIssuedDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodsTransaction_GoodsIssuedDetail_goodsIssuedDetailId",
                table: "GoodsTransaction",
                column: "goodsIssuedDetailId",
                principalTable: "GoodsIssuedDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
