using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class AddConstraintPackageCondition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "packagecondition_conditiontype_conditionvalue_unique",
                table: "PackageCondition");

            migrationBuilder.CreateIndex(
                name: "packagecondition_conditiontype_conditionvalue_unique",
                table: "PackageCondition",
                columns: new[] { "PackageId", "ConditionType", "ConditionValue" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "packagecondition_conditiontype_conditionvalue_unique",
                table: "PackageCondition");

            migrationBuilder.CreateIndex(
                name: "packagecondition_conditiontype_conditionvalue_unique",
                table: "PackageCondition",
                columns: new[] { "ConditionType", "ConditionValue" },
                unique: true);
        }
    }
}
