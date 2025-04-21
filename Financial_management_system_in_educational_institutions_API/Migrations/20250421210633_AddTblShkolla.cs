using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial_management_system_in_educational_institutions_API.Migrations
{
    /// <inheritdoc />
    public partial class AddTblShkolla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblShkolla",
                columns: table => new
                {
                    shkollaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emriShkolles = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    drejtori = table.Column<int>(type: "int", nullable: false),
                    lokacioni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nrNxenesve = table.Column<int>(type: "int", nullable: false),
                    buxhetiAktual = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    autoNdarja = table.Column<bool>(type: "bit", nullable: false),
                    accId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblShkolla", x => x.shkollaId);
                    table.ForeignKey(
                        name: "FK_tblShkolla_tblAccounts_accId",
                        column: x => x.accId,
                        principalTable: "tblAccounts",
                        principalColumn: "accId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblShkolla_tblPersons_drejtori",
                        column: x => x.drejtori,
                        principalTable: "tblPersons",
                        principalColumn: "numriPersonal",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_tblShkolla_accId",
                table: "tblShkolla",
                column: "accId");

            migrationBuilder.CreateIndex(
                name: "IX_tblShkolla_drejtori",
                table: "tblShkolla",
                column: "drejtori");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblShkolla");

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
    }
}
