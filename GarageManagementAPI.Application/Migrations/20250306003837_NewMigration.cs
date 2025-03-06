using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "packagehistory_packageid_packageprice_validityperiod_timeunit_usagelimit_unique",
                table: "PackageHistory");

            migrationBuilder.CreateIndex(
                name: "packagehistory_packageid_packageprice_validityperiod_timeunit_usagelimit",
                table: "PackageHistory",
                columns: new[] { "PackageId", "PackagePrice", "ValidityPeriod", "TimeUnit", "UsageLimit" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "packagehistory_packageid_packageprice_validityperiod_timeunit_usagelimit",
                table: "PackageHistory");

            migrationBuilder.CreateIndex(
                name: "packagehistory_packageid_packageprice_validityperiod_timeunit_usagelimit_unique",
                table: "PackageHistory",
                columns: new[] { "PackageId", "PackagePrice", "ValidityPeriod", "TimeUnit", "UsageLimit" },
                unique: true);
        }
    }
}
