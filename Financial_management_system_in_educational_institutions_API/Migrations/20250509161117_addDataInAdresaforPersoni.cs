using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial_management_system_in_educational_institutions_API.Migrations
{
    /// <inheritdoc />
    public partial class addDataInAdresaforPersoni : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "shared",
                table: "tblAdresat",
                columns: new[] { "Id", "Rruga", "Qyteti", "Shteti", "KodiPostal", "CreatedAt", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Rr. Nëna Terezë 12", "Prishtinë", "Kosovë", "10000", DateTime.Now, null },
                    { 2, "Rr. Sheshi i Lirisë 8", "Prizren", "Kosovë", "20000", DateTime.Now, null },
                    { 3, "Rr. Mbretëresha Teutë 5", "Pejë", "Kosovë", "30000", DateTime.Now, null },
                    { 4, "Rr. Ismail Qemali 15", "Gjakovë", "Kosovë", "50000", DateTime.Now, null },
                    { 5, "Rr. Dritan Hoxha 9", "Ferizaj", "Kosovë", "70000", DateTime.Now, null },
                    { 6, "Rr. UÇK 22", "Mitrovicë", "Kosovë", "40000", DateTime.Now, null },
                    { 7, "Rr. Adem Jashari 10", "Gjilan", "Kosovë", "60000", DateTime.Now, null },
                    { 8, "Rr. Iliria 7", "Vushtrri", "Kosovë", "45000", DateTime.Now, null },
                    { 9, "Rr. Bill Clinton 3", "Podujevë", "Kosovë", "11000", DateTime.Now, null },
                    { 10, "Rr. Skënderbeu 11", "Deçan", "Kosovë", "23000", DateTime.Now, null }
                }
            );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
