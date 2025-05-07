using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial_management_system_in_educational_institutions_API.Migrations
{
    /// <inheritdoc />
    public partial class changingToSharedTableOperationsAndRolePermissionss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "RolePermissions",
                newName: "RolePermissions",
                newSchema: "shared");

            migrationBuilder.RenameTable(
                name: "Operations",
                newName: "Operations",
                newSchema: "shared");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "RolePermissions",
                schema: "shared",
                newName: "RolePermissions");

            migrationBuilder.RenameTable(
                name: "Operations",
                schema: "shared",
                newName: "Operations");
        }
    }
}
