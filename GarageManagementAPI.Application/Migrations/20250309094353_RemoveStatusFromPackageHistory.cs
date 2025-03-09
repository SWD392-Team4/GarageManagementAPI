using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class RemoveStatusFromPackageHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "packagehistory_packageid_packageprice_validityperiod_timeunit_usagelimit",
                table: "PackageHistory");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "PackageHistory");

            migrationBuilder.CreateIndex(
                name: "IX_PackageHistory_CarCategoryId",
                table: "PackageHistory",
                column: "CarCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageHistory_CreatedAt",
                table: "PackageHistory",
                column: "CreatedAt");

            migrationBuilder.AddForeignKey(
                name: "packagehistory_carcategoryid_foreign",
                table: "PackageHistory",
                column: "CarCategoryId",
                principalTable: "CarCategory",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "packagehistory_carcategoryid_foreign",
                table: "PackageHistory");

            migrationBuilder.DropIndex(
                name: "IX_PackageHistory_CarCategoryId",
                table: "PackageHistory");

            migrationBuilder.DropIndex(
                name: "IX_PackageHistory_CreatedAt",
                table: "PackageHistory");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "PackageHistory",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "packagehistory_packageid_packageprice_validityperiod_timeunit_usagelimit",
                table: "PackageHistory",
                columns: new[] { "PackageId", "PackagePrice", "ValidityPeriod", "TimeUnit", "UsageLimit" });
        }
    }
}
