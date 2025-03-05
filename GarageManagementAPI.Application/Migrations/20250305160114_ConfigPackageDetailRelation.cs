using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class ConfigPackageDetailRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "packagedetail_packagehistoryid_foreign",
                table: "PackageDetail");

            migrationBuilder.DropForeignKey(
                name: "packagedetail_serviceid_foreign",
                table: "PackageDetail");

            migrationBuilder.DropPrimaryKey(
                name: "packagedetail_packagehistoryid_serviceid_primary",
                table: "PackageDetail");

            migrationBuilder.DropIndex(
                name: "IX_PackageDetail_ServiceId",
                table: "PackageDetail");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PackageImage");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "PackageImage");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "PackageImage");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PackageDetail");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceCategory",
                table: "Package",
                type: "int",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PackageDetail",
                table: "PackageDetail",
                columns: new[] { "ServiceId", "PackageHistoryId" });

            migrationBuilder.CreateIndex(
                name: "IX_PackageDetail_PackageHistoryId",
                table: "PackageDetail",
                column: "PackageHistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_PackageDetail_PackageHistory_PackageHistoryId",
                table: "PackageDetail",
                column: "PackageHistoryId",
                principalTable: "PackageHistory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PackageDetail_Service_ServiceId",
                table: "PackageDetail",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackageDetail_PackageHistory_PackageHistoryId",
                table: "PackageDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_PackageDetail_Service_ServiceId",
                table: "PackageDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PackageDetail",
                table: "PackageDetail");

            migrationBuilder.DropIndex(
                name: "IX_PackageDetail_PackageHistoryId",
                table: "PackageDetail");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "PackageImage",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "PackageImage",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "PackageImage",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "PackageDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "ServiceCategory",
                table: "Package",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 255);

            migrationBuilder.AddPrimaryKey(
                name: "packagedetail_packagehistoryid_serviceid_primary",
                table: "PackageDetail",
                columns: new[] { "PackageHistoryId", "ServiceId" });

            migrationBuilder.CreateIndex(
                name: "IX_PackageDetail_ServiceId",
                table: "PackageDetail",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "packagedetail_packagehistoryid_foreign",
                table: "PackageDetail",
                column: "PackageHistoryId",
                principalTable: "PackageHistory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "packagedetail_serviceid_foreign",
                table: "PackageDetail",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id");
        }
    }
}
