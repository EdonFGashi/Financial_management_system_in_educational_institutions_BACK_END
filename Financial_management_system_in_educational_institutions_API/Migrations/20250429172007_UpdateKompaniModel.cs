using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial_management_system_in_educational_institutions_API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateKompaniModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lokacioni",
                table: "Kompania");

            migrationBuilder.UpdateData(
                table: "tblAccounts",
                keyColumn: "accId",
                keyValue: 1,
                column: "twoFAtime",
                value: new DateTime(2025, 4, 29, 19, 20, 6, 704, DateTimeKind.Local).AddTicks(9853));

            migrationBuilder.UpdateData(
                table: "tblAccounts",
                keyColumn: "accId",
                keyValue: 2,
                column: "twoFAtime",
                value: new DateTime(2025, 4, 29, 19, 20, 6, 704, DateTimeKind.Local).AddTicks(9927));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Lokacioni",
                table: "Kompania",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "tblAccounts",
                keyColumn: "accId",
                keyValue: 1,
                column: "twoFAtime",
                value: new DateTime(2025, 4, 29, 13, 18, 53, 965, DateTimeKind.Local).AddTicks(111));

            migrationBuilder.UpdateData(
                table: "tblAccounts",
                keyColumn: "accId",
                keyValue: 2,
                column: "twoFAtime",
                value: new DateTime(2025, 4, 29, 13, 18, 53, 965, DateTimeKind.Local).AddTicks(345));
        }
    }
}
