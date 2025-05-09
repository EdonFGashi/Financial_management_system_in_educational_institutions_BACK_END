using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial_management_system_in_educational_institutions_API.Migrations
{
    /// <inheritdoc />
    public partial class addAdresaInShared : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "tblAdresat",
                schema: "design",
                newName: "tblAdresat",
                newSchema: "shared");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "tblAdresat",
                schema: "shared",
                newName: "tblAdresat",
                newSchema: "design");
        }
    }
}
