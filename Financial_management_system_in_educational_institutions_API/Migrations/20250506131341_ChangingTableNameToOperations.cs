using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial_management_system_in_educational_institutions_API.Migrations
{
    /// <inheritdoc />
    public partial class ChangingTableNameToOperations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_Permissions_PermissionId",
                table: "RolePermissions");

            migrationBuilder.RenameColumn(
                name: "PermissionId",
                table: "RolePermissions",
                newName: "OpetaionsOperationId");

            migrationBuilder.RenameIndex(
                name: "IX_RolePermissions_PermissionId",
                table: "RolePermissions",
                newName: "IX_RolePermissions_OpetaionsOperationId");

            migrationBuilder.RenameColumn(
                name: "PermissionId",
                table: "Permissions",
                newName: "OperationId");

            migrationBuilder.AddColumn<int>(
                name: "OperationId",
                table: "RolePermissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_Permissions_OpetaionsOperationId",
                table: "RolePermissions",
                column: "OpetaionsOperationId",
                principalTable: "Permissions",
                principalColumn: "OperationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_Permissions_OpetaionsOperationId",
                table: "RolePermissions");

            migrationBuilder.DropColumn(
                name: "OperationId",
                table: "RolePermissions");

            migrationBuilder.RenameColumn(
                name: "OpetaionsOperationId",
                table: "RolePermissions",
                newName: "PermissionId");

            migrationBuilder.RenameIndex(
                name: "IX_RolePermissions_OpetaionsOperationId",
                table: "RolePermissions",
                newName: "IX_RolePermissions_PermissionId");

            migrationBuilder.RenameColumn(
                name: "OperationId",
                table: "Permissions",
                newName: "PermissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_Permissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "PermissionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
