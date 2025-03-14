using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class ConfigAppointmentDtail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PackageHistoryId",
                table: "AppointmentDetail",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentDetail_PackageHistoryId",
                table: "AppointmentDetail",
                column: "PackageHistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentDetail_PackageHistory_PackageHistoryId",
                table: "AppointmentDetail",
                column: "PackageHistoryId",
                principalTable: "PackageHistory",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentDetail_PackageHistory_PackageHistoryId",
                table: "AppointmentDetail");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentDetail_PackageHistoryId",
                table: "AppointmentDetail");

            migrationBuilder.DropColumn(
                name: "PackageHistoryId",
                table: "AppointmentDetail");
        }
    }
}
