using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial_management_system_in_educational_institutions_API.Migrations
{
    /// <inheritdoc />
    public partial class addDataInPersoni : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "shared",
                table: "tblPersons",
                columns: new[] { "NumriPersonal", "Emri", "Mbiemri", "Nacionaliteti", "AdresaId", "Gjinia", "DataLindjes" },
                values: new object[,]
                {
                   { 1000000001, "Besim", "Gashi", "Kosovar", 2, "Mashkull", new DateTime(1987, 10, 29) },
                   { 1000000002, "Liridona", "Rugova", "Kosovare", 2, "Femer", new DateTime(1978, 4, 21) },
                   { 1000000003, "Elira", "Krasniqi", "Kosovare", 5, "Femer", new DateTime(1997, 5, 30) },
                   { 1000000004, "Blerina", "Rugova", "Kosovare", 2, "Femer", new DateTime(1986, 4, 7) },
                   { 1000000005, "Elira", "Hoxha", "Kosovare", 2, "Femer", new DateTime(1980, 11, 5) },
                   { 1000000006, "Besim", "Rugova", "Kosovar", 3, "Mashkull", new DateTime(1971, 11, 23) },
                   { 1000000007, "Ardit", "Shala", "Kosovar", 2, "Mashkull", new DateTime(1989, 5, 7) },
                   { 1000000008, "Ardit", "Morina", "Kosovar", 2, "Mashkull", new DateTime(1976, 10, 29) },
                   { 1000000009, "Granit", "Shala", "Kosovar", 2, "Mashkull", new DateTime(1982, 8, 24) },
                   { 1000000010, "Edon", "Ismaili", "Kosovar", 3, "Mashkull", new DateTime(2000, 11, 21) },
                   { 1000000011, "Granit", "Zeka", "Kosovar", 1, "Mashkull", new DateTime(1968, 10, 13) },
                   { 1000000012, "Edon", "Bytyqi", "Kosovar", 1, "Mashkull", new DateTime(1974, 12, 27) },
                   { 1000000013, "Granit", "Hoxha", "Kosovar", 1, "Mashkull", new DateTime(1986, 11, 14) },
                   { 1000000014, "Edon", "Bytyqi", "Kosovar", 5, "Mashkull", new DateTime(1981, 3, 5) },
                   { 1000000015, "Gentiana", "Rugova", "Kosovare", 5, "Femer", new DateTime(1974, 12, 31) },
                   { 1000000016, "Elira", "Zeka", "Kosovare", 1, "Femer", new DateTime(1996, 1, 15) },
                   { 1000000017, "Edon", "Morina", "Kosovar", 3, "Mashkull", new DateTime(1994, 6, 13) },
                   { 1000000018, "Edon", "Gashi", "Kosovar", 4, "Mashkull", new DateTime(1990, 11, 7) },
                   { 1000000019, "Gentiana", "Shala", "Kosovare", 3, "Femer", new DateTime(1974, 7, 1) },
                   { 1000000020, "Besim", "Hoxha", "Kosovar", 5, "Mashkull", new DateTime(2005, 1, 8) },
                   { 1000000021, "Granit", "Gashi", "Kosovar", 4, "Mashkull", new DateTime(1971, 8, 8) },
                   { 1000000022, "Ardit", "Gashi", "Kosovar", 3, "Mashkull", new DateTime(1969, 1, 21) },
                   { 1000000023, "Liridona", "Gashi", "Kosovare", 2, "Femer", new DateTime(1997, 3, 13) },
                   { 1000000024, "Granit", "Berisha", "Kosovar", 1, "Mashkull", new DateTime(2003, 8, 26) },
                   { 1000000025, "Gentiana", "Shala", "Kosovare", 1, "Femer", new DateTime(1970, 2, 6) },
                   { 1000000026, "Besim", "Shala", "Kosovar", 3, "Mashkull", new DateTime(1981, 8, 16) },
                   { 1000000027, "Elira", "Morina", "Kosovare", 5, "Femer", new DateTime(1983, 6, 2) },
                   { 1000000028, "Ardit", "Morina", "Kosovar", 4, "Mashkull", new DateTime(1990, 7, 11) },
                   { 1000000029, "Liridona", "Rugova", "Kosovare", 1, "Femer", new DateTime(1969, 4, 11) },
                   { 1000000030, "Valdrin", "Shala", "Kosovar", 4, "Mashkull", new DateTime(1971, 8, 20) },
                   { 1000000031, "Granit", "Krasniqi", "Kosovar", 3, "Mashkull", new DateTime(1980, 3, 15) },
                   { 1000000032, "Elira", "Shala", "Kosovare", 1, "Femer", new DateTime(1988, 10, 3) },
                   { 1000000033, "Granit", "Shala", "Kosovar", 1, "Mashkull", new DateTime(1974, 12, 4) },
                   { 1000000034, "Elira", "Zeka", "Kosovare", 1, "Femer", new DateTime(1974, 6, 13) },
                   { 1000000035, "Liridona", "Ismaili", "Kosovare", 4, "Femer", new DateTime(1973, 12, 17) },
                   { 1000000036, "Elira", "Bytyqi", "Kosovare", 1, "Femer", new DateTime(1965, 12, 10) },
                   { 1000000037, "Granit", "Zeka", "Kosovar", 1, "Mashkull", new DateTime(2002, 9, 11) },
                   { 1000000038, "Gentiana", "Hoxha", "Kosovare", 2, "Femer", new DateTime(1992, 6, 11) },
                   { 1000000039, "Valdrin", "Ismaili", "Kosovar", 5, "Mashkull", new DateTime(2002, 1, 3) },
                   { 1000000040, "Elira", "Ismaili", "Kosovare", 1, "Femer", new DateTime(1994, 8, 12) },
                   { 1000000041, "Granit", "Krasniqi", "Kosovar", 3, "Mashkull", new DateTime(1990, 5, 3) },
                   { 1000000042, "Elira", "Hoxha", "Kosovare", 2, "Femer", new DateTime(1974, 3, 27) },
                   { 1000000043, "Alberta", "Ismaili", "Kosovare", 2, "Femer", new DateTime(1990, 9, 19) },
                   { 1000000044, "Valdrin", "Hoxha", "Kosovar", 2, "Mashkull", new DateTime(1977, 2, 1) },
                   { 1000000045, "Blerina", "Berisha", "Kosovare", 3, "Femer", new DateTime(1990, 12, 16) },
                   { 1000000046, "Gentiana", "Zeka", "Kosovare", 3, "Femer", new DateTime(2007, 2, 20) },
                   { 1000000047, "Edon", "Ismaili", "Kosovar", 2, "Mashkull", new DateTime(1986, 5, 12) },
                   { 1000000048, "Edon", "Shala", "Kosovar", 4, "Mashkull", new DateTime(1981, 1, 1) },
                   { 1000000049, "Besim", "Rugova", "Kosovar", 5, "Mashkull", new DateTime(1973, 5, 17) },
                   { 1000000050, "Valdrin", "Rugova", "Kosovar", 5, "Mashkull", new DateTime(2005, 10, 3) },


                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
