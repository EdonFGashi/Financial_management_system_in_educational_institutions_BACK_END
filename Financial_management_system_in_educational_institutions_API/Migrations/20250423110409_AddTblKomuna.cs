using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial_management_system_in_educational_institutions_API.Migrations
{
    /// <inheritdoc />
    public partial class AddTblKomuna : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblKomuna",
                columns: table => new
                {
                    komunaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    qyteti = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nrPopullsis = table.Column<int>(type: "int", nullable: false),
                    buxhetiAktual = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ditaNdarjesAuto = table.Column<bool>(type: "bit", nullable: false),
                    accId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblKomuna", x => x.komunaId);
                    table.ForeignKey(
                        name: "FK_tblKomuna_tblAccounts_accId",
                        column: x => x.accId,
                        principalTable: "tblAccounts",
                        principalColumn: "accId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "tblAccounts",
                keyColumn: "accId",
                keyValue: 1,
                column: "twoFAtime",
                value: new DateTime(2025, 4, 23, 13, 4, 9, 395, DateTimeKind.Local).AddTicks(9982));

            migrationBuilder.UpdateData(
                table: "tblAccounts",
                keyColumn: "accId",
                keyValue: 2,
                column: "twoFAtime",
                value: new DateTime(2025, 4, 23, 13, 4, 9, 396, DateTimeKind.Local).AddTicks(49));

            migrationBuilder.CreateIndex(
                name: "IX_tblKomuna_accId",
                table: "tblKomuna",
                column: "accId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblKomuna");

            migrationBuilder.UpdateData(
                table: "tblAccounts",
                keyColumn: "accId",
                keyValue: 1,
                column: "twoFAtime",
                value: new DateTime(2025, 4, 21, 23, 6, 32, 886, DateTimeKind.Local).AddTicks(4578));

            migrationBuilder.UpdateData(
                table: "tblAccounts",
                keyColumn: "accId",
                keyValue: 2,
                column: "twoFAtime",
                value: new DateTime(2025, 4, 21, 23, 6, 32, 886, DateTimeKind.Local).AddTicks(4710));
        }
    }
}
