using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Financial_management_system_in_educational_institutions_API.Migrations
{
    /// <inheritdoc />
    public partial class InsertingSomeAccounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tblAccounts",
                columns: new[] { "accId", "organisationName", "passwordHash", "role", "salt", "twoFAcode", "twoFAtime", "username" },
                values: new object[,]
                {
                    { 1, "Rilindja", "324refds32q", "kompani", "fdszx", 491593, new DateTime(2025, 4, 5, 21, 39, 37, 727, DateTimeKind.Local).AddTicks(7212), "kompania1" },
                    { 2, "Hasan Prishtina", "vdsv2wqc2ws2", "universitet", "adsyx", 154923, new DateTime(2025, 4, 5, 21, 39, 37, 727, DateTimeKind.Local).AddTicks(7272), "kompania1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tblAccounts",
                keyColumn: "accId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tblAccounts",
                keyColumn: "accId",
                keyValue: 2);
        }
    }
}
