using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Financial_management_system_in_educational_institutions_API.Migrations
{
    /// <inheritdoc />
    public partial class IncreaseFotografiaLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tblAccounts",
                columns: new[] { "accId", "email", "organisationName", "passwordHash", "role", "salt", "twoFAcode", "twoFAtime", "username" },
                values: new object[,]
                {
                    { 1, "rilindja@gmail.com", "Rilindja", "324refds32q", "kompani", "fdszx", 491593, new DateTime(2025, 4, 29, 13, 18, 53, 965, DateTimeKind.Local).AddTicks(111), "kompania1" },
                    { 2, "hasanprishtina@gmail.com", "Hasan Prishtina", "vdsv2wqc2ws2", "universitet", "adsyx", 154923, new DateTime(2025, 4, 29, 13, 18, 53, 965, DateTimeKind.Local).AddTicks(345), "kompania1" }
                });
        }
    }
}
