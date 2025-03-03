using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "ServiceImage");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "ProductImage");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "PackageImage");

            migrationBuilder.AddColumn<string>(
                name: "ImageId",
                table: "ServiceImage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageLink",
                table: "ServiceImage",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageId",
                table: "ProductImage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageLink",
                table: "ProductImage",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageId",
                table: "PackageImage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageLink",
                table: "PackageImage",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "ServiceImage");

            migrationBuilder.DropColumn(
                name: "ImageLink",
                table: "ServiceImage");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "ProductImage");

            migrationBuilder.DropColumn(
                name: "ImageLink",
                table: "ProductImage");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "PackageImage");

            migrationBuilder.DropColumn(
                name: "ImageLink",
                table: "PackageImage");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "ServiceImage",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "ProductImage",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "PackageImage",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }
    }
}
