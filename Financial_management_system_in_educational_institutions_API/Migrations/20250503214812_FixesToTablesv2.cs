using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial_management_system_in_educational_institutions_API.Migrations
{
    /// <inheritdoc />
    public partial class FixesToTablesv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblShkolla_AspNetUsers_UserId1",
                schema: "design",
                table: "tblShkolla");

            migrationBuilder.DropIndex(
                name: "IX_tblShkolla_UserId1",
                schema: "design",
                table: "tblShkolla");

            migrationBuilder.DropColumn(
                name: "UserId1",
                schema: "design",
                table: "tblShkolla");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                schema: "design",
                table: "tblShkolla",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_tblShkolla_UserId1",
                schema: "design",
                table: "tblShkolla",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_tblShkolla_AspNetUsers_UserId1",
                schema: "design",
                table: "tblShkolla",
                column: "UserId1",
                principalSchema: "shared",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
