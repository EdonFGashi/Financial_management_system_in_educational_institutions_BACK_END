using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial_management_system_in_educational_institutions_API.Migrations
{
    /// <inheritdoc />
    public partial class fullDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblShkolla_tblAccounts_accId",
                table: "tblShkolla");

            migrationBuilder.DropForeignKey(
                name: "FK_tblShkolla_tblPersons_drejtori",
                table: "tblShkolla");

            migrationBuilder.DropIndex(
                name: "IX_tblShkolla_accId",
                table: "tblShkolla");

            migrationBuilder.AlterColumn<string>(
                name: "lokacioni",
                table: "tblShkolla",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "emriShkolles",
                table: "tblShkolla",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AccountaccId",
                table: "tblShkolla",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "createdAt",
                table: "tblShkolla",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updatedAt",
                table: "tblShkolla",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Adresat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rruga = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Qyteti = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Shteti = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    KodiPostal = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventariAktual",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emri = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Pershkrimi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Sasia = table.Column<int>(type: "int", nullable: false),
                    Shifra = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShkollaId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventariAktual", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventariAktual_tblShkolla_ShkollaId",
                        column: x => x.ShkollaId,
                        principalTable: "tblShkolla",
                        principalColumn: "shkollaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NdarjetBuxhetit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShkollaId = table.Column<int>(type: "int", nullable: false),
                    Shuma = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Auto = table.Column<bool>(type: "bit", nullable: false),
                    Shenime = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NdarjetBuxhetit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NdarjetBuxhetit_tblShkolla_ShkollaId",
                        column: x => x.ShkollaId,
                        principalTable: "tblShkolla",
                        principalColumn: "shkollaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Domain = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StafiShkolles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numriPersonal = table.Column<int>(type: "int", nullable: false),
                    pozita = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    paga = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    numriOreve = table.Column<int>(type: "int", nullable: false),
                    shkollaId = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StafiShkolles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StafiShkolles_tblPersons_numriPersonal",
                        column: x => x.numriPersonal,
                        principalTable: "tblPersons",
                        principalColumn: "numriPersonal",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StafiShkolles_tblShkolla_shkollaId",
                        column: x => x.shkollaId,
                        principalTable: "tblShkolla",
                        principalColumn: "shkollaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tenderi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pershkrimi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Sherbimi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Shuma = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenderi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kompania",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emri = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PronariId = table.Column<int>(type: "int", nullable: false),
                    Sherbimi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Lokacioni = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NrXhirologaris = table.Column<int>(type: "int", nullable: false),
                    AdresaId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kompania", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kompania_Adresat_AdresaId",
                        column: x => x.AdresaId,
                        principalTable: "Adresat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kompania_tblAccounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "tblAccounts",
                        principalColumn: "accId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kompania_tblPersons_PronariId",
                        column: x => x.PronariId,
                        principalTable: "tblPersons",
                        principalColumn: "numriPersonal",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ndalesat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Arsyeja = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ShumaNdaleses = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Aprovuari = table.Column<bool>(type: "bit", nullable: false),
                    StafiShkollesId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ndalesat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ndalesat_StafiShkolles_StafiShkollesId",
                        column: x => x.StafiShkollesId,
                        principalTable: "StafiShkolles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OretShtese",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StafiShkollesId = table.Column<int>(type: "int", nullable: false),
                    DataAngazhimit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NrOreve = table.Column<int>(type: "int", nullable: false),
                    PagesaPerOre = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Shenime = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OretShtese", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OretShtese_StafiShkolles_StafiShkollesId",
                        column: x => x.StafiShkollesId,
                        principalTable: "StafiShkolles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Marreveshja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KomunaId = table.Column<int>(type: "int", nullable: false),
                    KompaniaId = table.Column<int>(type: "int", nullable: false),
                    NgaData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeriMeData = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TenderiId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marreveshja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Marreveshja_Kompania_KompaniaId",
                        column: x => x.KompaniaId,
                        principalTable: "Kompania",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Marreveshja_Tenderi_TenderiId",
                        column: x => x.TenderiId,
                        principalTable: "Tenderi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Marreveshja_tblKomuna_KomunaId",
                        column: x => x.KomunaId,
                        principalTable: "tblKomuna",
                        principalColumn: "komunaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Produkti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emri = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Pershkrimi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Cmimi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SasiaNeStok = table.Column<int>(type: "int", nullable: false),
                    Origjina = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Prodhuesi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Fotografia = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    KompaniaId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produkti_Kompania_KompaniaId",
                        column: x => x.KompaniaId,
                        principalTable: "Kompania",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Porosite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPorosise = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sasia = table.Column<int>(type: "int", nullable: false),
                    Paguar = table.Column<bool>(type: "bit", nullable: false),
                    Shenime = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ShkollaId = table.Column<int>(type: "int", nullable: false),
                    ProduktiId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Porosite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Porosite_Produkti_ProduktiId",
                        column: x => x.ProduktiId,
                        principalTable: "Produkti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Porosite_tblShkolla_ShkollaId",
                        column: x => x.ShkollaId,
                        principalTable: "tblShkolla",
                        principalColumn: "shkollaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagesat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPageses = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TVSH = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    NrFletPageses = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PorositeId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagesat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagesat_Porosite_PorositeId",
                        column: x => x.PorositeId,
                        principalTable: "Porosite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "tblAccounts",
                keyColumn: "accId",
                keyValue: 1,
                column: "twoFAtime",
                value: new DateTime(2025, 4, 28, 1, 22, 26, 136, DateTimeKind.Local).AddTicks(7315));

            migrationBuilder.UpdateData(
                table: "tblAccounts",
                keyColumn: "accId",
                keyValue: 2,
                column: "twoFAtime",
                value: new DateTime(2025, 4, 28, 1, 22, 26, 136, DateTimeKind.Local).AddTicks(7394));

            migrationBuilder.CreateIndex(
                name: "IX_tblShkolla_AccountaccId",
                table: "tblShkolla",
                column: "AccountaccId");

            migrationBuilder.CreateIndex(
                name: "IX_InventariAktual_ShkollaId",
                table: "InventariAktual",
                column: "ShkollaId");

            migrationBuilder.CreateIndex(
                name: "IX_Kompania_AccountId",
                table: "Kompania",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Kompania_AdresaId",
                table: "Kompania",
                column: "AdresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Kompania_PronariId",
                table: "Kompania",
                column: "PronariId");

            migrationBuilder.CreateIndex(
                name: "IX_Marreveshja_KompaniaId",
                table: "Marreveshja",
                column: "KompaniaId");

            migrationBuilder.CreateIndex(
                name: "IX_Marreveshja_KomunaId",
                table: "Marreveshja",
                column: "KomunaId");

            migrationBuilder.CreateIndex(
                name: "IX_Marreveshja_TenderiId",
                table: "Marreveshja",
                column: "TenderiId");

            migrationBuilder.CreateIndex(
                name: "IX_Ndalesat_StafiShkollesId",
                table: "Ndalesat",
                column: "StafiShkollesId");

            migrationBuilder.CreateIndex(
                name: "IX_NdarjetBuxhetit_ShkollaId",
                table: "NdarjetBuxhetit",
                column: "ShkollaId");

            migrationBuilder.CreateIndex(
                name: "IX_OretShtese_StafiShkollesId",
                table: "OretShtese",
                column: "StafiShkollesId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagesat_PorositeId",
                table: "Pagesat",
                column: "PorositeId");

            migrationBuilder.CreateIndex(
                name: "IX_Porosite_ProduktiId",
                table: "Porosite",
                column: "ProduktiId");

            migrationBuilder.CreateIndex(
                name: "IX_Porosite_ShkollaId",
                table: "Porosite",
                column: "ShkollaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produkti_KompaniaId",
                table: "Produkti",
                column: "KompaniaId");

            migrationBuilder.CreateIndex(
                name: "IX_StafiShkolles_numriPersonal",
                table: "StafiShkolles",
                column: "numriPersonal");

            migrationBuilder.CreateIndex(
                name: "IX_StafiShkolles_shkollaId",
                table: "StafiShkolles",
                column: "shkollaId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblShkolla_tblAccounts_AccountaccId",
                table: "tblShkolla",
                column: "AccountaccId",
                principalTable: "tblAccounts",
                principalColumn: "accId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblShkolla_tblPersons_drejtori",
                table: "tblShkolla",
                column: "drejtori",
                principalTable: "tblPersons",
                principalColumn: "numriPersonal",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblShkolla_tblAccounts_AccountaccId",
                table: "tblShkolla");

            migrationBuilder.DropForeignKey(
                name: "FK_tblShkolla_tblPersons_drejtori",
                table: "tblShkolla");

            migrationBuilder.DropTable(
                name: "InventariAktual");

            migrationBuilder.DropTable(
                name: "Marreveshja");

            migrationBuilder.DropTable(
                name: "Ndalesat");

            migrationBuilder.DropTable(
                name: "NdarjetBuxhetit");

            migrationBuilder.DropTable(
                name: "OretShtese");

            migrationBuilder.DropTable(
                name: "Pagesat");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Tenderi");

            migrationBuilder.DropTable(
                name: "StafiShkolles");

            migrationBuilder.DropTable(
                name: "Porosite");

            migrationBuilder.DropTable(
                name: "Produkti");

            migrationBuilder.DropTable(
                name: "Kompania");

            migrationBuilder.DropTable(
                name: "Adresat");

            migrationBuilder.DropIndex(
                name: "IX_tblShkolla_AccountaccId",
                table: "tblShkolla");

            migrationBuilder.DropColumn(
                name: "AccountaccId",
                table: "tblShkolla");

            migrationBuilder.DropColumn(
                name: "createdAt",
                table: "tblShkolla");

            migrationBuilder.DropColumn(
                name: "updatedAt",
                table: "tblShkolla");

            migrationBuilder.AlterColumn<string>(
                name: "lokacioni",
                table: "tblShkolla",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "emriShkolles",
                table: "tblShkolla",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

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
                name: "IX_tblShkolla_accId",
                table: "tblShkolla",
                column: "accId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblShkolla_tblAccounts_accId",
                table: "tblShkolla",
                column: "accId",
                principalTable: "tblAccounts",
                principalColumn: "accId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblShkolla_tblPersons_drejtori",
                table: "tblShkolla",
                column: "drejtori",
                principalTable: "tblPersons",
                principalColumn: "numriPersonal",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
