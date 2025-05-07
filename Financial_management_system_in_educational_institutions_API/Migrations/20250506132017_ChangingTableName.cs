using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial_management_system_in_educational_institutions_API.Migrations
{
    /// <inheritdoc />
    public partial class ChangingTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_Permissions_OpetaionsOperationId",
                table: "RolePermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions");

            migrationBuilder.RenameTable(
                name: "Permissions",
                newName: "Operations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Operations",
                table: "Operations",
                column: "OperationId");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_Operations_OpetaionsOperationId",
                table: "RolePermissions",
                column: "OpetaionsOperationId",
                principalTable: "Operations",
                principalColumn: "OperationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_Operations_OpetaionsOperationId",
                table: "RolePermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Operations",
                table: "Operations");

            migrationBuilder.RenameTable(
                name: "Operations",
                newName: "Permissions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions",
                column: "OperationId");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_Permissions_OpetaionsOperationId",
                table: "RolePermissions",
                column: "OpetaionsOperationId",
                principalTable: "Permissions",
                principalColumn: "OperationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
