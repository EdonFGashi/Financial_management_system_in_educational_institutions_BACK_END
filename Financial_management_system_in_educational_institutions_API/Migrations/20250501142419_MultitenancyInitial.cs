using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Financial_management_system_in_educational_institutions_API.Migrations
{
    /// <inheritdoc />
    public partial class MultitenancyInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventariAktual_tblShkolla_ShkollaId",
                table: "InventariAktual");

            migrationBuilder.DropForeignKey(
                name: "FK_Kompania_Adresat_AdresaId",
                table: "Kompania");

            migrationBuilder.DropForeignKey(
                name: "FK_Kompania_tblAccounts_AccountId",
                table: "Kompania");

            migrationBuilder.DropForeignKey(
                name: "FK_Kompania_tblPersons_PronariId",
                table: "Kompania");

            migrationBuilder.DropForeignKey(
                name: "FK_Marreveshja_Kompania_KompaniaId",
                table: "Marreveshja");

            migrationBuilder.DropForeignKey(
                name: "FK_Marreveshja_Tenderi_TenderiId",
                table: "Marreveshja");

            migrationBuilder.DropForeignKey(
                name: "FK_Marreveshja_tblKomuna_KomunaId",
                table: "Marreveshja");

            migrationBuilder.DropForeignKey(
                name: "FK_Ndalesat_StafiShkolles_StafiShkollesId",
                table: "Ndalesat");

            migrationBuilder.DropForeignKey(
                name: "FK_NdarjetBuxhetit_tblShkolla_ShkollaId",
                table: "NdarjetBuxhetit");

            migrationBuilder.DropForeignKey(
                name: "FK_OretShtese_StafiShkolles_StafiShkollesId",
                table: "OretShtese");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagesat_Porosite_PorositeId",
                table: "Pagesat");

            migrationBuilder.DropForeignKey(
                name: "FK_Porosite_Produkti_ProduktiId",
                table: "Porosite");

            migrationBuilder.DropForeignKey(
                name: "FK_Porosite_tblShkolla_ShkollaId",
                table: "Porosite");

            migrationBuilder.DropForeignKey(
                name: "FK_Produkti_Kompania_KompaniaId",
                table: "Produkti");

            migrationBuilder.DropForeignKey(
                name: "FK_StafiShkolles_tblPersons_numriPersonal",
                table: "StafiShkolles");

            migrationBuilder.DropForeignKey(
                name: "FK_StafiShkolles_tblShkolla_shkollaId",
                table: "StafiShkolles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tenderi",
                table: "Tenderi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StafiShkolles",
                table: "StafiShkolles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produkti",
                table: "Produkti");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Porosite",
                table: "Porosite");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pagesat",
                table: "Pagesat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OretShtese",
                table: "OretShtese");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NdarjetBuxhetit",
                table: "NdarjetBuxhetit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ndalesat",
                table: "Ndalesat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Marreveshja",
                table: "Marreveshja");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kompania",
                table: "Kompania");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventariAktual",
                table: "InventariAktual");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adresat",
                table: "Adresat");

            migrationBuilder.DeleteData(
                table: "tblAccounts",
                keyColumn: "accId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tblAccounts",
                keyColumn: "accId",
                keyValue: 2);

            migrationBuilder.EnsureSchema(
                name: "shared");

            migrationBuilder.RenameTable(
                name: "tblKomuna",
                newName: "tblKomuna",
                newSchema: "shared");

            migrationBuilder.RenameTable(
                name: "Tenderi",
                newName: "tblTenderi");

            migrationBuilder.RenameTable(
                name: "StafiShkolles",
                newName: "tblStafiShkolles");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "tblRoles");

            migrationBuilder.RenameTable(
                name: "Produkti",
                newName: "tblProdukti");

            migrationBuilder.RenameTable(
                name: "Porosite",
                newName: "tblPorosite");

            migrationBuilder.RenameTable(
                name: "Pagesat",
                newName: "tblPagesat");

            migrationBuilder.RenameTable(
                name: "OretShtese",
                newName: "tblOretShtese");

            migrationBuilder.RenameTable(
                name: "NdarjetBuxhetit",
                newName: "tblNdarjetBuxhetit");

            migrationBuilder.RenameTable(
                name: "Ndalesat",
                newName: "tblNdalesat");

            migrationBuilder.RenameTable(
                name: "Marreveshja",
                newName: "tblMarreveshja");

            migrationBuilder.RenameTable(
                name: "Kompania",
                newName: "tblKompania");

            migrationBuilder.RenameTable(
                name: "InventariAktual",
                newName: "tblInventariAktual");

            migrationBuilder.RenameTable(
                name: "Adresat",
                newName: "tblAdresat");

            migrationBuilder.RenameIndex(
                name: "IX_StafiShkolles_shkollaId",
                table: "tblStafiShkolles",
                newName: "IX_tblStafiShkolles_shkollaId");

            migrationBuilder.RenameIndex(
                name: "IX_StafiShkolles_numriPersonal",
                table: "tblStafiShkolles",
                newName: "IX_tblStafiShkolles_numriPersonal");

            migrationBuilder.RenameIndex(
                name: "IX_Produkti_KompaniaId",
                table: "tblProdukti",
                newName: "IX_tblProdukti_KompaniaId");

            migrationBuilder.RenameIndex(
                name: "IX_Porosite_ShkollaId",
                table: "tblPorosite",
                newName: "IX_tblPorosite_ShkollaId");

            migrationBuilder.RenameIndex(
                name: "IX_Porosite_ProduktiId",
                table: "tblPorosite",
                newName: "IX_tblPorosite_ProduktiId");

            migrationBuilder.RenameIndex(
                name: "IX_Pagesat_PorositeId",
                table: "tblPagesat",
                newName: "IX_tblPagesat_PorositeId");

            migrationBuilder.RenameIndex(
                name: "IX_OretShtese_StafiShkollesId",
                table: "tblOretShtese",
                newName: "IX_tblOretShtese_StafiShkollesId");

            migrationBuilder.RenameIndex(
                name: "IX_NdarjetBuxhetit_ShkollaId",
                table: "tblNdarjetBuxhetit",
                newName: "IX_tblNdarjetBuxhetit_ShkollaId");

            migrationBuilder.RenameIndex(
                name: "IX_Ndalesat_StafiShkollesId",
                table: "tblNdalesat",
                newName: "IX_tblNdalesat_StafiShkollesId");

            migrationBuilder.RenameIndex(
                name: "IX_Marreveshja_TenderiId",
                table: "tblMarreveshja",
                newName: "IX_tblMarreveshja_TenderiId");

            migrationBuilder.RenameIndex(
                name: "IX_Marreveshja_KomunaId",
                table: "tblMarreveshja",
                newName: "IX_tblMarreveshja_KomunaId");

            migrationBuilder.RenameIndex(
                name: "IX_Marreveshja_KompaniaId",
                table: "tblMarreveshja",
                newName: "IX_tblMarreveshja_KompaniaId");

            migrationBuilder.RenameIndex(
                name: "IX_Kompania_PronariId",
                table: "tblKompania",
                newName: "IX_tblKompania_PronariId");

            migrationBuilder.RenameIndex(
                name: "IX_Kompania_AdresaId",
                table: "tblKompania",
                newName: "IX_tblKompania_AdresaId");

            migrationBuilder.RenameIndex(
                name: "IX_Kompania_AccountId",
                table: "tblKompania",
                newName: "IX_tblKompania_AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_InventariAktual_ShkollaId",
                table: "tblInventariAktual",
                newName: "IX_tblInventariAktual_ShkollaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblTenderi",
                table: "tblTenderi",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblStafiShkolles",
                table: "tblStafiShkolles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblRoles",
                table: "tblRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblProdukti",
                table: "tblProdukti",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblPorosite",
                table: "tblPorosite",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblPagesat",
                table: "tblPagesat",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblOretShtese",
                table: "tblOretShtese",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblNdarjetBuxhetit",
                table: "tblNdarjetBuxhetit",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblNdalesat",
                table: "tblNdalesat",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblMarreveshja",
                table: "tblMarreveshja",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblKompania",
                table: "tblKompania",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblInventariAktual",
                table: "tblInventariAktual",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblAdresat",
                table: "tblAdresat",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tblInventariAktual_tblShkolla_ShkollaId",
                table: "tblInventariAktual",
                column: "ShkollaId",
                principalTable: "tblShkolla",
                principalColumn: "shkollaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblKompania_tblAccounts_AccountId",
                table: "tblKompania",
                column: "AccountId",
                principalTable: "tblAccounts",
                principalColumn: "accId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblKompania_tblAdresat_AdresaId",
                table: "tblKompania",
                column: "AdresaId",
                principalTable: "tblAdresat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblKompania_tblPersons_PronariId",
                table: "tblKompania",
                column: "PronariId",
                principalTable: "tblPersons",
                principalColumn: "numriPersonal",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblMarreveshja_tblKompania_KompaniaId",
                table: "tblMarreveshja",
                column: "KompaniaId",
                principalTable: "tblKompania",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblMarreveshja_tblKomuna_KomunaId",
                table: "tblMarreveshja",
                column: "KomunaId",
                principalSchema: "shared",
                principalTable: "tblKomuna",
                principalColumn: "komunaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblMarreveshja_tblTenderi_TenderiId",
                table: "tblMarreveshja",
                column: "TenderiId",
                principalTable: "tblTenderi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblNdalesat_tblStafiShkolles_StafiShkollesId",
                table: "tblNdalesat",
                column: "StafiShkollesId",
                principalTable: "tblStafiShkolles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblNdarjetBuxhetit_tblShkolla_ShkollaId",
                table: "tblNdarjetBuxhetit",
                column: "ShkollaId",
                principalTable: "tblShkolla",
                principalColumn: "shkollaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblOretShtese_tblStafiShkolles_StafiShkollesId",
                table: "tblOretShtese",
                column: "StafiShkollesId",
                principalTable: "tblStafiShkolles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblPagesat_tblPorosite_PorositeId",
                table: "tblPagesat",
                column: "PorositeId",
                principalTable: "tblPorosite",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblPorosite_tblProdukti_ProduktiId",
                table: "tblPorosite",
                column: "ProduktiId",
                principalTable: "tblProdukti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblPorosite_tblShkolla_ShkollaId",
                table: "tblPorosite",
                column: "ShkollaId",
                principalTable: "tblShkolla",
                principalColumn: "shkollaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblProdukti_tblKompania_KompaniaId",
                table: "tblProdukti",
                column: "KompaniaId",
                principalTable: "tblKompania",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblStafiShkolles_tblPersons_numriPersonal",
                table: "tblStafiShkolles",
                column: "numriPersonal",
                principalTable: "tblPersons",
                principalColumn: "numriPersonal",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblStafiShkolles_tblShkolla_shkollaId",
                table: "tblStafiShkolles",
                column: "shkollaId",
                principalTable: "tblShkolla",
                principalColumn: "shkollaId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblInventariAktual_tblShkolla_ShkollaId",
                table: "tblInventariAktual");

            migrationBuilder.DropForeignKey(
                name: "FK_tblKompania_tblAccounts_AccountId",
                table: "tblKompania");

            migrationBuilder.DropForeignKey(
                name: "FK_tblKompania_tblAdresat_AdresaId",
                table: "tblKompania");

            migrationBuilder.DropForeignKey(
                name: "FK_tblKompania_tblPersons_PronariId",
                table: "tblKompania");

            migrationBuilder.DropForeignKey(
                name: "FK_tblMarreveshja_tblKompania_KompaniaId",
                table: "tblMarreveshja");

            migrationBuilder.DropForeignKey(
                name: "FK_tblMarreveshja_tblKomuna_KomunaId",
                table: "tblMarreveshja");

            migrationBuilder.DropForeignKey(
                name: "FK_tblMarreveshja_tblTenderi_TenderiId",
                table: "tblMarreveshja");

            migrationBuilder.DropForeignKey(
                name: "FK_tblNdalesat_tblStafiShkolles_StafiShkollesId",
                table: "tblNdalesat");

            migrationBuilder.DropForeignKey(
                name: "FK_tblNdarjetBuxhetit_tblShkolla_ShkollaId",
                table: "tblNdarjetBuxhetit");

            migrationBuilder.DropForeignKey(
                name: "FK_tblOretShtese_tblStafiShkolles_StafiShkollesId",
                table: "tblOretShtese");

            migrationBuilder.DropForeignKey(
                name: "FK_tblPagesat_tblPorosite_PorositeId",
                table: "tblPagesat");

            migrationBuilder.DropForeignKey(
                name: "FK_tblPorosite_tblProdukti_ProduktiId",
                table: "tblPorosite");

            migrationBuilder.DropForeignKey(
                name: "FK_tblPorosite_tblShkolla_ShkollaId",
                table: "tblPorosite");

            migrationBuilder.DropForeignKey(
                name: "FK_tblProdukti_tblKompania_KompaniaId",
                table: "tblProdukti");

            migrationBuilder.DropForeignKey(
                name: "FK_tblStafiShkolles_tblPersons_numriPersonal",
                table: "tblStafiShkolles");

            migrationBuilder.DropForeignKey(
                name: "FK_tblStafiShkolles_tblShkolla_shkollaId",
                table: "tblStafiShkolles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblTenderi",
                table: "tblTenderi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblStafiShkolles",
                table: "tblStafiShkolles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblRoles",
                table: "tblRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblProdukti",
                table: "tblProdukti");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblPorosite",
                table: "tblPorosite");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblPagesat",
                table: "tblPagesat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblOretShtese",
                table: "tblOretShtese");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblNdarjetBuxhetit",
                table: "tblNdarjetBuxhetit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblNdalesat",
                table: "tblNdalesat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblMarreveshja",
                table: "tblMarreveshja");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblKompania",
                table: "tblKompania");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblInventariAktual",
                table: "tblInventariAktual");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblAdresat",
                table: "tblAdresat");

            migrationBuilder.RenameTable(
                name: "tblKomuna",
                schema: "shared",
                newName: "tblKomuna");

            migrationBuilder.RenameTable(
                name: "tblTenderi",
                newName: "Tenderi");

            migrationBuilder.RenameTable(
                name: "tblStafiShkolles",
                newName: "StafiShkolles");

            migrationBuilder.RenameTable(
                name: "tblRoles",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "tblProdukti",
                newName: "Produkti");

            migrationBuilder.RenameTable(
                name: "tblPorosite",
                newName: "Porosite");

            migrationBuilder.RenameTable(
                name: "tblPagesat",
                newName: "Pagesat");

            migrationBuilder.RenameTable(
                name: "tblOretShtese",
                newName: "OretShtese");

            migrationBuilder.RenameTable(
                name: "tblNdarjetBuxhetit",
                newName: "NdarjetBuxhetit");

            migrationBuilder.RenameTable(
                name: "tblNdalesat",
                newName: "Ndalesat");

            migrationBuilder.RenameTable(
                name: "tblMarreveshja",
                newName: "Marreveshja");

            migrationBuilder.RenameTable(
                name: "tblKompania",
                newName: "Kompania");

            migrationBuilder.RenameTable(
                name: "tblInventariAktual",
                newName: "InventariAktual");

            migrationBuilder.RenameTable(
                name: "tblAdresat",
                newName: "Adresat");

            migrationBuilder.RenameIndex(
                name: "IX_tblStafiShkolles_shkollaId",
                table: "StafiShkolles",
                newName: "IX_StafiShkolles_shkollaId");

            migrationBuilder.RenameIndex(
                name: "IX_tblStafiShkolles_numriPersonal",
                table: "StafiShkolles",
                newName: "IX_StafiShkolles_numriPersonal");

            migrationBuilder.RenameIndex(
                name: "IX_tblProdukti_KompaniaId",
                table: "Produkti",
                newName: "IX_Produkti_KompaniaId");

            migrationBuilder.RenameIndex(
                name: "IX_tblPorosite_ShkollaId",
                table: "Porosite",
                newName: "IX_Porosite_ShkollaId");

            migrationBuilder.RenameIndex(
                name: "IX_tblPorosite_ProduktiId",
                table: "Porosite",
                newName: "IX_Porosite_ProduktiId");

            migrationBuilder.RenameIndex(
                name: "IX_tblPagesat_PorositeId",
                table: "Pagesat",
                newName: "IX_Pagesat_PorositeId");

            migrationBuilder.RenameIndex(
                name: "IX_tblOretShtese_StafiShkollesId",
                table: "OretShtese",
                newName: "IX_OretShtese_StafiShkollesId");

            migrationBuilder.RenameIndex(
                name: "IX_tblNdarjetBuxhetit_ShkollaId",
                table: "NdarjetBuxhetit",
                newName: "IX_NdarjetBuxhetit_ShkollaId");

            migrationBuilder.RenameIndex(
                name: "IX_tblNdalesat_StafiShkollesId",
                table: "Ndalesat",
                newName: "IX_Ndalesat_StafiShkollesId");

            migrationBuilder.RenameIndex(
                name: "IX_tblMarreveshja_TenderiId",
                table: "Marreveshja",
                newName: "IX_Marreveshja_TenderiId");

            migrationBuilder.RenameIndex(
                name: "IX_tblMarreveshja_KomunaId",
                table: "Marreveshja",
                newName: "IX_Marreveshja_KomunaId");

            migrationBuilder.RenameIndex(
                name: "IX_tblMarreveshja_KompaniaId",
                table: "Marreveshja",
                newName: "IX_Marreveshja_KompaniaId");

            migrationBuilder.RenameIndex(
                name: "IX_tblKompania_PronariId",
                table: "Kompania",
                newName: "IX_Kompania_PronariId");

            migrationBuilder.RenameIndex(
                name: "IX_tblKompania_AdresaId",
                table: "Kompania",
                newName: "IX_Kompania_AdresaId");

            migrationBuilder.RenameIndex(
                name: "IX_tblKompania_AccountId",
                table: "Kompania",
                newName: "IX_Kompania_AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_tblInventariAktual_ShkollaId",
                table: "InventariAktual",
                newName: "IX_InventariAktual_ShkollaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tenderi",
                table: "Tenderi",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StafiShkolles",
                table: "StafiShkolles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produkti",
                table: "Produkti",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Porosite",
                table: "Porosite",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pagesat",
                table: "Pagesat",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OretShtese",
                table: "OretShtese",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NdarjetBuxhetit",
                table: "NdarjetBuxhetit",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ndalesat",
                table: "Ndalesat",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Marreveshja",
                table: "Marreveshja",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kompania",
                table: "Kompania",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventariAktual",
                table: "InventariAktual",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adresat",
                table: "Adresat",
                column: "Id");

            migrationBuilder.InsertData(
                table: "tblAccounts",
                columns: new[] { "accId", "email", "organisationName", "passwordHash", "role", "salt", "twoFAcode", "twoFAtime", "username" },
                values: new object[,]
                {
                    { 1, "rilindja@gmail.com", "Rilindja", "324refds32q", "kompani", "fdszx", 491593, new DateTime(2025, 4, 29, 13, 18, 53, 965, DateTimeKind.Local).AddTicks(111), "kompania1" },
                    { 2, "hasanprishtina@gmail.com", "Hasan Prishtina", "vdsv2wqc2ws2", "universitet", "adsyx", 154923, new DateTime(2025, 4, 29, 13, 18, 53, 965, DateTimeKind.Local).AddTicks(345), "kompania1" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_InventariAktual_tblShkolla_ShkollaId",
                table: "InventariAktual",
                column: "ShkollaId",
                principalTable: "tblShkolla",
                principalColumn: "shkollaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kompania_Adresat_AdresaId",
                table: "Kompania",
                column: "AdresaId",
                principalTable: "Adresat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kompania_tblAccounts_AccountId",
                table: "Kompania",
                column: "AccountId",
                principalTable: "tblAccounts",
                principalColumn: "accId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kompania_tblPersons_PronariId",
                table: "Kompania",
                column: "PronariId",
                principalTable: "tblPersons",
                principalColumn: "numriPersonal",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Marreveshja_Kompania_KompaniaId",
                table: "Marreveshja",
                column: "KompaniaId",
                principalTable: "Kompania",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Marreveshja_Tenderi_TenderiId",
                table: "Marreveshja",
                column: "TenderiId",
                principalTable: "Tenderi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Marreveshja_tblKomuna_KomunaId",
                table: "Marreveshja",
                column: "KomunaId",
                principalTable: "tblKomuna",
                principalColumn: "komunaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ndalesat_StafiShkolles_StafiShkollesId",
                table: "Ndalesat",
                column: "StafiShkollesId",
                principalTable: "StafiShkolles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NdarjetBuxhetit_tblShkolla_ShkollaId",
                table: "NdarjetBuxhetit",
                column: "ShkollaId",
                principalTable: "tblShkolla",
                principalColumn: "shkollaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OretShtese_StafiShkolles_StafiShkollesId",
                table: "OretShtese",
                column: "StafiShkollesId",
                principalTable: "StafiShkolles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagesat_Porosite_PorositeId",
                table: "Pagesat",
                column: "PorositeId",
                principalTable: "Porosite",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Porosite_Produkti_ProduktiId",
                table: "Porosite",
                column: "ProduktiId",
                principalTable: "Produkti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Porosite_tblShkolla_ShkollaId",
                table: "Porosite",
                column: "ShkollaId",
                principalTable: "tblShkolla",
                principalColumn: "shkollaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produkti_Kompania_KompaniaId",
                table: "Produkti",
                column: "KompaniaId",
                principalTable: "Kompania",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StafiShkolles_tblPersons_numriPersonal",
                table: "StafiShkolles",
                column: "numriPersonal",
                principalTable: "tblPersons",
                principalColumn: "numriPersonal",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StafiShkolles_tblShkolla_shkollaId",
                table: "StafiShkolles",
                column: "shkollaId",
                principalTable: "tblShkolla",
                principalColumn: "shkollaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
