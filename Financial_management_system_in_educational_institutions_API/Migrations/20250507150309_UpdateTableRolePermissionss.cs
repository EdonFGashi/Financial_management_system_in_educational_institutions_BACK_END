using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial_management_system_in_educational_institutions_API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableRolePermissionss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                schema: "shared",
                table: "AspNetUserClaims");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                schema: "shared",
                table: "AspNetUserClaims",
                column: "UserId",
                principalSchema: "shared",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                schema: "shared",
                table: "AspNetUserClaims");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                schema: "shared",
                table: "AspNetUserClaims",
                column: "UserId",
                principalSchema: "shared",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
