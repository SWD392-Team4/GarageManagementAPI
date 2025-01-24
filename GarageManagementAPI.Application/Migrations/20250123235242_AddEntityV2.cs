using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class AddEntityV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductForCarModel_CarModel_CarModelId",
                table: "ProductForCarModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductForCarModel_Product_ProductId",
                table: "ProductForCarModel");

            migrationBuilder.AddColumn<Guid>(
                name: "CarModelId1",
                table: "ProductForCarModel",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId1",
                table: "ProductForCarModel",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductForCarModel_CarModelId1",
                table: "ProductForCarModel",
                column: "CarModelId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductForCarModel_ProductId1",
                table: "ProductForCarModel",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductForCarModel_CarModel_CarModelId",
                table: "ProductForCarModel",
                column: "CarModelId",
                principalTable: "CarModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductForCarModel_CarModel_CarModelId1",
                table: "ProductForCarModel",
                column: "CarModelId1",
                principalTable: "CarModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductForCarModel_Product_ProductId",
                table: "ProductForCarModel",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductForCarModel_Product_ProductId1",
                table: "ProductForCarModel",
                column: "ProductId1",
                principalTable: "Product",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductForCarModel_CarModel_CarModelId",
                table: "ProductForCarModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductForCarModel_CarModel_CarModelId1",
                table: "ProductForCarModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductForCarModel_Product_ProductId",
                table: "ProductForCarModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductForCarModel_Product_ProductId1",
                table: "ProductForCarModel");

            migrationBuilder.DropIndex(
                name: "IX_ProductForCarModel_CarModelId1",
                table: "ProductForCarModel");

            migrationBuilder.DropIndex(
                name: "IX_ProductForCarModel_ProductId1",
                table: "ProductForCarModel");

            migrationBuilder.DropColumn(
                name: "CarModelId1",
                table: "ProductForCarModel");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "ProductForCarModel");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductForCarModel_CarModel_CarModelId",
                table: "ProductForCarModel",
                column: "CarModelId",
                principalTable: "CarModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductForCarModel_Product_ProductId",
                table: "ProductForCarModel",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
