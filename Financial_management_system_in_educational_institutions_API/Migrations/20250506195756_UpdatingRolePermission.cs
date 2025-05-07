using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial_management_system_in_educational_institutions_API.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingRolePermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_Operations_OpetaionsOperationId",
                schema: "shared",
                table: "RolePermissions");

            migrationBuilder.DropIndex(
                name: "IX_RolePermissions_OpetaionsOperationId",
                schema: "shared",
                table: "RolePermissions");

            migrationBuilder.DropColumn(
                name: "OpetaionsOperationId",
                schema: "shared",
                table: "RolePermissions");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_OperationId",
                schema: "shared",
                table: "RolePermissions",
                column: "OperationId");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_Operations_OperationId",
                schema: "shared",
                table: "RolePermissions",
                column: "OperationId",
                principalSchema: "shared",
                principalTable: "Operations",
                principalColumn: "OperationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_Operations_OperationId",
                schema: "shared",
                table: "RolePermissions");

            migrationBuilder.DropIndex(
                name: "IX_RolePermissions_OperationId",
                schema: "shared",
                table: "RolePermissions");

            migrationBuilder.AddColumn<int>(
                name: "OpetaionsOperationId",
                schema: "shared",
                table: "RolePermissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_OpetaionsOperationId",
                schema: "shared",
                table: "RolePermissions",
                column: "OpetaionsOperationId");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_Operations_OpetaionsOperationId",
                schema: "shared",
                table: "RolePermissions",
                column: "OpetaionsOperationId",
                principalSchema: "shared",
                principalTable: "Operations",
                principalColumn: "OperationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
