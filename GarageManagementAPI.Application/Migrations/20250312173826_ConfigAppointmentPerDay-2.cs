using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class ConfigAppointmentPerDay2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GarageId",
                table: "AppointmentPerDay",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "ServiceNote",
                table: "AppointmentDetail",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AppointmentPerDay",
                columns: new[] { "Id", "CountPerDay", "GarageId" },
                values: new object[,]
                {
                    { new Guid("c637eb36-0dee-4190-9338-3c5053ea3ea6"), 10, new Guid("c1aeb9e5-8c74-4b09-bc57-d4c3df7857f9") },
                    { new Guid("fa657400-f856-4a91-965d-b20dc194ac66"), 5, new Guid("6760cbb7-f1fa-445f-a175-97e3f060c861") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentPerDay_GarageId",
                table: "AppointmentPerDay",
                column: "GarageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "appointmentperday_garageid_foreign",
                table: "AppointmentPerDay",
                column: "GarageId",
                principalTable: "Workplace",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "appointmentperday_garageid_foreign",
                table: "AppointmentPerDay");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentPerDay_GarageId",
                table: "AppointmentPerDay");

            migrationBuilder.DeleteData(
                table: "AppointmentPerDay",
                keyColumn: "Id",
                keyValue: new Guid("c637eb36-0dee-4190-9338-3c5053ea3ea6"));

            migrationBuilder.DeleteData(
                table: "AppointmentPerDay",
                keyColumn: "Id",
                keyValue: new Guid("fa657400-f856-4a91-965d-b20dc194ac66"));

            migrationBuilder.DropColumn(
                name: "GarageId",
                table: "AppointmentPerDay");

            migrationBuilder.AlterColumn<string>(
                name: "ServiceNote",
                table: "AppointmentDetail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
