using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class ConfigIdentityv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RoleId1",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserId1",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_RoleId1",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_UserId1",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "RoleId1",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserRoles");

            migrationBuilder.CreateTable(
                name: "RolesUser",
                columns: table => new
                {
                    RolesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesUser", x => new { x.RolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_RolesUser_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolesUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RolesUser_UsersId",
                table: "RolesUser",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolesUser");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ef3629ba-332e-4c46-9fa8-54444803f925"), new Guid("1230a288-3e5e-4ee1-a75c-3fd7af6480a0") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ef3629ba-332e-4c46-9fa8-54444803f925"), new Guid("b78245a2-a2bf-45b4-8572-b2c3f1948629") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ef3629ba-332e-4c46-9fa8-54444803f925"), new Guid("de0d20e6-17e6-40e8-8274-c89a66e64fa5") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ef3629ba-332e-4c46-9fa8-54444803f925"), new Guid("e2060ff5-5fb9-4b20-a11a-bf6ae4716ad5") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ef3629ba-332e-4c46-9fa8-54444803f925"), new Guid("f8a4e60d-3113-4f25-8477-be205b0860c9") });

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "UserRoles",
                type: "nvarchar(34)",
                maxLength: 34,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId1",
                table: "UserRoles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "UserRoles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId", "Discriminator", "RoleId1", "UserId1" },
                values: new object[,]
                {
                    { new Guid("ef3629ba-332e-4c46-9fa8-54444803f925"), new Guid("1230a288-3e5e-4ee1-a75c-3fd7af6480a0"), "UserRoles", null, null },
                    { new Guid("ef3629ba-332e-4c46-9fa8-54444803f925"), new Guid("b78245a2-a2bf-45b4-8572-b2c3f1948629"), "UserRoles", null, null },
                    { new Guid("ef3629ba-332e-4c46-9fa8-54444803f925"), new Guid("de0d20e6-17e6-40e8-8274-c89a66e64fa5"), "UserRoles", null, null },
                    { new Guid("ef3629ba-332e-4c46-9fa8-54444803f925"), new Guid("e2060ff5-5fb9-4b20-a11a-bf6ae4716ad5"), "UserRoles", null, null },
                    { new Guid("ef3629ba-332e-4c46-9fa8-54444803f925"), new Guid("f8a4e60d-3113-4f25-8477-be205b0860c9"), "UserRoles", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId1",
                table: "UserRoles",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId1",
                table: "UserRoles",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_RoleId1",
                table: "UserRoles",
                column: "RoleId1",
                principalTable: "Roles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserId1",
                table: "UserRoles",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
