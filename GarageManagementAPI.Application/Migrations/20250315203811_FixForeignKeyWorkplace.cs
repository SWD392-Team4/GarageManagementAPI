using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class FixForeignKeyWorkplace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "productatgarage_workplaceId_foreign",
                table: "ProductAtGarage");

            migrationBuilder.AddForeignKey(
                name: "productatgarage_workplaceId_foreign",
                table: "ProductAtGarage",
                column: "WorkplaceId",
                principalTable: "Workplace",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "productatgarage_workplaceId_foreign",
                table: "ProductAtGarage");

            migrationBuilder.AddForeignKey(
                name: "productatgarage_workplaceId_foreign",
                table: "ProductAtGarage",
                column: "WorkplaceId",
                principalTable: "Workplace",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
