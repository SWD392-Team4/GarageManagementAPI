using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class AddConfigAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "invoice_appointmentid_foreign",
                table: "Invoice");

            migrationBuilder.AddColumn<Guid>(
                name: "AppointmentId",
                table: "Invoice",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CancellationCode",
                table: "Appointment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CancellationMethod",
                table: "Appointment",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CancellationReason",
                table: "Appointment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CancellationToken",
                table: "Appointment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CancelledAt",
                table: "Appointment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VerificationCode",
                table: "Appointment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_AppointmentId",
                table: "Invoice",
                column: "AppointmentId",
                unique: true,
                filter: "[AppointmentId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "invoice_appointmentid_foreign",
                table: "Invoice",
                column: "AppointmentId",
                principalTable: "Appointment",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "invoice_appointmentid_foreign",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_AppointmentId",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "CancellationCode",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "CancellationMethod",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "CancellationReason",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "CancellationToken",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "CancelledAt",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "VerificationCode",
                table: "Appointment");

            migrationBuilder.AddForeignKey(
                name: "invoice_appointmentid_foreign",
                table: "Invoice",
                column: "Id",
                principalTable: "Appointment",
                principalColumn: "Id");
        }
    }
}
