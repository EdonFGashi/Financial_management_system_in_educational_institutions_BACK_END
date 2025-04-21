using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial_management_system_in_educational_institutions_API.Migrations
{
    /// <inheritdoc />
    public partial class AddTblPerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblPersons",
                columns: table => new
                {
                    numriPersonal = table.Column<int>(type: "int", nullable: false),
                    emri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mbiemri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nacionaliteti = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    qyteti = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shteti = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gjinia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dataLindjes = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPersons", x => x.numriPersonal);
                });

            migrationBuilder.UpdateData(
                table: "tblAccounts",
                keyColumn: "accId",
                keyValue: 1,
                column: "twoFAtime",
                value: new DateTime(2025, 4, 20, 23, 42, 34, 384, DateTimeKind.Local).AddTicks(6894));

            migrationBuilder.UpdateData(
                table: "tblAccounts",
                keyColumn: "accId",
                keyValue: 2,
                column: "twoFAtime",
                value: new DateTime(2025, 4, 20, 23, 42, 34, 384, DateTimeKind.Local).AddTicks(6962));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblPersons");

            migrationBuilder.UpdateData(
                table: "tblAccounts",
                keyColumn: "accId",
                keyValue: 1,
                column: "twoFAtime",
                value: new DateTime(2025, 4, 5, 21, 39, 37, 727, DateTimeKind.Local).AddTicks(7212));

            migrationBuilder.UpdateData(
                table: "tblAccounts",
                keyColumn: "accId",
                keyValue: 2,
                column: "twoFAtime",
                value: new DateTime(2025, 4, 5, 21, 39, 37, 727, DateTimeKind.Local).AddTicks(7272));
        }
    }
}
