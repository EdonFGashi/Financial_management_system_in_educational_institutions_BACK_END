using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial_management_system_in_educational_institutions_API.Migrations
{
    /// <inheritdoc />
    public partial class ChangingDataTypeeeee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_AspNetUserClaims_Id",
                schema: "shared",
                table: "RolePermissions");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "shared",
                table: "RolePermissions",
                newName: "ClaimId");

            migrationBuilder.RenameIndex(
                name: "IX_RolePermissions_Id",
                schema: "shared",
                table: "RolePermissions",
                newName: "IX_RolePermissions_ClaimId");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_AspNetUserClaims_ClaimId",
                schema: "shared",
                table: "RolePermissions",
                column: "ClaimId",
                principalSchema: "shared",
                principalTable: "AspNetUserClaims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_AspNetUserClaims_ClaimId",
                schema: "shared",
                table: "RolePermissions");

            migrationBuilder.RenameColumn(
                name: "ClaimId",
                schema: "shared",
                table: "RolePermissions",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_RolePermissions_ClaimId",
                schema: "shared",
                table: "RolePermissions",
                newName: "IX_RolePermissions_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_AspNetUserClaims_Id",
                schema: "shared",
                table: "RolePermissions",
                column: "Id",
                principalSchema: "shared",
                principalTable: "AspNetUserClaims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
