using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class ConfigCustomerCar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "customercar_customerid_foreign",
                table: "CustomerCar");

            migrationBuilder.DropForeignKey(
                name: "invoice_customerid_foreign",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "customercar_customerid_index",
                table: "CustomerCar");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "CustomerCar");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Invoice",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_CustomerId",
                table: "Invoice",
                newName: "IX_Invoice_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Users_UserId",
                table: "Invoice",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Users_UserId",
                table: "Invoice");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Invoice",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoice_UserId",
                table: "Invoice",
                newName: "IX_Invoice_CustomerId");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "CustomerCar",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "customercar_customerid_index",
                table: "CustomerCar",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "customercar_customerid_foreign",
                table: "CustomerCar",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "invoice_customerid_foreign",
                table: "Invoice",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
