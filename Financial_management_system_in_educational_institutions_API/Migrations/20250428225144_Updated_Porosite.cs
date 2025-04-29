using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial_management_system_in_educational_institutions_API.Migrations
{
    /// <inheritdoc />
    public partial class Updated_Porosite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Paguar",
                table: "Porosite");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "tblAccounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Statusi",
                table: "Porosite",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "tblAccounts",
                keyColumn: "accId",
                keyValue: 1,
                columns: new[] { "email", "twoFAtime" },
                values: new object[] { "rilindja@gmail.com", new DateTime(2025, 4, 29, 0, 51, 43, 975, DateTimeKind.Local).AddTicks(2069) });

            migrationBuilder.UpdateData(
                table: "tblAccounts",
                keyColumn: "accId",
                keyValue: 2,
                columns: new[] { "email", "twoFAtime" },
                values: new object[] { "hasanprishtina@gmail.com", new DateTime(2025, 4, 29, 0, 51, 43, 975, DateTimeKind.Local).AddTicks(2125) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "tblAccounts");

            migrationBuilder.DropColumn(
                name: "Statusi",
                table: "Porosite");

            migrationBuilder.AddColumn<bool>(
                name: "Paguar",
                table: "Porosite",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "tblAccounts",
                keyColumn: "accId",
                keyValue: 1,
                column: "twoFAtime",
                value: new DateTime(2025, 4, 28, 2, 3, 43, 336, DateTimeKind.Local).AddTicks(5841));

            migrationBuilder.UpdateData(
                table: "tblAccounts",
                keyColumn: "accId",
                keyValue: 2,
                column: "twoFAtime",
                value: new DateTime(2025, 4, 28, 2, 3, 43, 336, DateTimeKind.Local).AddTicks(5942));
        }
    }
}
