using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCancellationMethod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CancelledAt",
                table: "Appointment",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ApprovedAt",
                table: "Appointment",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RejectByEmployeeId",
                table: "Appointment",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_RejectByEmployeeId",
                table: "Appointment",
                column: "RejectByEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "appointment_rejectbyemployeeid_foreign",
                table: "Appointment",
                column: "RejectByEmployeeId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "appointment_rejectbyemployeeid_foreign",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_RejectByEmployeeId",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "ApprovedAt",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "RejectByEmployeeId",
                table: "Appointment");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CancelledAt",
                table: "Appointment",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);
        }
    }
}
