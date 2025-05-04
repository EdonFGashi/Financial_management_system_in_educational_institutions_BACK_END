using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Financial_management_system_in_educational_institutions_API.Migrations
{
    /// <inheritdoc />
    public partial class FixesToTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "shared");

            migrationBuilder.EnsureSchema(
                name: "design");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "shared",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblAccounts",
                schema: "shared",
                columns: table => new
                {
                    accId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    organisationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    passwordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    twoFAcode = table.Column<int>(type: "int", nullable: false),
                    twoFAtime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAccounts", x => x.accId);
                });

            migrationBuilder.CreateTable(
                name: "tblAdresat",
                schema: "design",
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
                    table.PrimaryKey("PK_tblAdresat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblRoles",
                schema: "design",
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
                    table.PrimaryKey("PK_tblRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblTenderi",
                schema: "design",
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
                    table.PrimaryKey("PK_tblTenderi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "shared",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "shared",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblPersons",
                schema: "design",
                columns: table => new
                {
                    NumriPersonal = table.Column<int>(type: "int", nullable: false),
                    Emri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mbiemri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nacionaliteti = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdresaId = table.Column<int>(type: "int", nullable: false),
                    Gjinia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataLindjes = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPersons", x => x.NumriPersonal);
                    table.ForeignKey(
                        name: "FK_tblPersons_tblAdresat_AdresaId",
                        column: x => x.AdresaId,
                        principalSchema: "design",
                        principalTable: "tblAdresat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "shared",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "shared",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "shared",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "shared",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "shared",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KomunaId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "shared",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "shared",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblKompania",
                schema: "design",
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblKompania", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblKompania_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "shared",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblKompania_tblAdresat_AdresaId",
                        column: x => x.AdresaId,
                        principalSchema: "design",
                        principalTable: "tblAdresat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblKompania_tblPersons_PronariId",
                        column: x => x.PronariId,
                        principalSchema: "design",
                        principalTable: "tblPersons",
                        principalColumn: "NumriPersonal",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblKomuna",
                schema: "shared",
                columns: table => new
                {
                    KomunaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qyteti = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NrPopullsis = table.Column<int>(type: "int", nullable: true),
                    BuxhetiAktual = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    DitaNdarjesAuto = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblKomuna", x => x.KomunaId);
                    table.ForeignKey(
                        name: "FK_tblKomuna_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "shared",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblShkolla",
                schema: "design",
                columns: table => new
                {
                    shkollaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    emriShkolles = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    drejtori = table.Column<int>(type: "int", nullable: false),
                    nrNxenesve = table.Column<int>(type: "int", nullable: false),
                    AdresaId = table.Column<int>(type: "int", nullable: false),
                    buxhetiAktual = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    autoNdarja = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblShkolla", x => x.shkollaId);
                    table.ForeignKey(
                        name: "FK_tblShkolla_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "shared",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblShkolla_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalSchema: "shared",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblShkolla_tblAdresat_AdresaId",
                        column: x => x.AdresaId,
                        principalSchema: "design",
                        principalTable: "tblAdresat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblShkolla_tblPersons_drejtori",
                        column: x => x.drejtori,
                        principalSchema: "design",
                        principalTable: "tblPersons",
                        principalColumn: "NumriPersonal",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblProdukti",
                schema: "design",
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
                    table.PrimaryKey("PK_tblProdukti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblProdukti_tblKompania_KompaniaId",
                        column: x => x.KompaniaId,
                        principalSchema: "design",
                        principalTable: "tblKompania",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblMarreveshja",
                schema: "design",
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
                    table.PrimaryKey("PK_tblMarreveshja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblMarreveshja_tblKompania_KompaniaId",
                        column: x => x.KompaniaId,
                        principalSchema: "design",
                        principalTable: "tblKompania",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblMarreveshja_tblKomuna_KomunaId",
                        column: x => x.KomunaId,
                        principalSchema: "shared",
                        principalTable: "tblKomuna",
                        principalColumn: "KomunaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblMarreveshja_tblTenderi_TenderiId",
                        column: x => x.TenderiId,
                        principalSchema: "design",
                        principalTable: "tblTenderi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblInventariAktual",
                schema: "design",
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
                    table.PrimaryKey("PK_tblInventariAktual", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblInventariAktual_tblShkolla_ShkollaId",
                        column: x => x.ShkollaId,
                        principalSchema: "design",
                        principalTable: "tblShkolla",
                        principalColumn: "shkollaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblNdarjetBuxhetit",
                schema: "design",
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
                    table.PrimaryKey("PK_tblNdarjetBuxhetit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblNdarjetBuxhetit_tblShkolla_ShkollaId",
                        column: x => x.ShkollaId,
                        principalSchema: "design",
                        principalTable: "tblShkolla",
                        principalColumn: "shkollaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblStafiShkolles",
                schema: "design",
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
                    table.PrimaryKey("PK_tblStafiShkolles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblStafiShkolles_tblPersons_numriPersonal",
                        column: x => x.numriPersonal,
                        principalSchema: "design",
                        principalTable: "tblPersons",
                        principalColumn: "NumriPersonal",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblStafiShkolles_tblShkolla_shkollaId",
                        column: x => x.shkollaId,
                        principalSchema: "design",
                        principalTable: "tblShkolla",
                        principalColumn: "shkollaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblPorosite",
                schema: "design",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPorosise = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sasia = table.Column<int>(type: "int", nullable: false),
                    Statusi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shenime = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ShkollaId = table.Column<int>(type: "int", nullable: false),
                    ProduktiId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPorosite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblPorosite_tblProdukti_ProduktiId",
                        column: x => x.ProduktiId,
                        principalSchema: "design",
                        principalTable: "tblProdukti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblPorosite_tblShkolla_ShkollaId",
                        column: x => x.ShkollaId,
                        principalSchema: "design",
                        principalTable: "tblShkolla",
                        principalColumn: "shkollaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblNdalesat",
                schema: "design",
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
                    table.PrimaryKey("PK_tblNdalesat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblNdalesat_tblStafiShkolles_StafiShkollesId",
                        column: x => x.StafiShkollesId,
                        principalSchema: "design",
                        principalTable: "tblStafiShkolles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblOretShtese",
                schema: "design",
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
                    table.PrimaryKey("PK_tblOretShtese", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblOretShtese_tblStafiShkolles_StafiShkollesId",
                        column: x => x.StafiShkollesId,
                        principalSchema: "design",
                        principalTable: "tblStafiShkolles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblPagesat",
                schema: "design",
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
                    table.PrimaryKey("PK_tblPagesat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblPagesat_tblPorosite_PorositeId",
                        column: x => x.PorositeId,
                        principalSchema: "design",
                        principalTable: "tblPorosite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "shared",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "shared",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "shared",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "shared",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "shared",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "shared",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_KomunaId",
                schema: "shared",
                table: "AspNetUsers",
                column: "KomunaId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "shared",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tblInventariAktual_ShkollaId",
                schema: "design",
                table: "tblInventariAktual",
                column: "ShkollaId");

            migrationBuilder.CreateIndex(
                name: "IX_tblKompania_AdresaId",
                schema: "design",
                table: "tblKompania",
                column: "AdresaId");

            migrationBuilder.CreateIndex(
                name: "IX_tblKompania_PronariId",
                schema: "design",
                table: "tblKompania",
                column: "PronariId");

            migrationBuilder.CreateIndex(
                name: "IX_tblKompania_UserId",
                schema: "design",
                table: "tblKompania",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblKomuna_UserId",
                schema: "shared",
                table: "tblKomuna",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMarreveshja_KompaniaId",
                schema: "design",
                table: "tblMarreveshja",
                column: "KompaniaId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMarreveshja_KomunaId",
                schema: "design",
                table: "tblMarreveshja",
                column: "KomunaId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMarreveshja_TenderiId",
                schema: "design",
                table: "tblMarreveshja",
                column: "TenderiId");

            migrationBuilder.CreateIndex(
                name: "IX_tblNdalesat_StafiShkollesId",
                schema: "design",
                table: "tblNdalesat",
                column: "StafiShkollesId");

            migrationBuilder.CreateIndex(
                name: "IX_tblNdarjetBuxhetit_ShkollaId",
                schema: "design",
                table: "tblNdarjetBuxhetit",
                column: "ShkollaId");

            migrationBuilder.CreateIndex(
                name: "IX_tblOretShtese_StafiShkollesId",
                schema: "design",
                table: "tblOretShtese",
                column: "StafiShkollesId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPagesat_PorositeId",
                schema: "design",
                table: "tblPagesat",
                column: "PorositeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPersons_AdresaId",
                schema: "design",
                table: "tblPersons",
                column: "AdresaId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPorosite_ProduktiId",
                schema: "design",
                table: "tblPorosite",
                column: "ProduktiId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPorosite_ShkollaId",
                schema: "design",
                table: "tblPorosite",
                column: "ShkollaId");

            migrationBuilder.CreateIndex(
                name: "IX_tblProdukti_KompaniaId",
                schema: "design",
                table: "tblProdukti",
                column: "KompaniaId");

            migrationBuilder.CreateIndex(
                name: "IX_tblShkolla_AdresaId",
                schema: "design",
                table: "tblShkolla",
                column: "AdresaId");

            migrationBuilder.CreateIndex(
                name: "IX_tblShkolla_drejtori",
                schema: "design",
                table: "tblShkolla",
                column: "drejtori");

            migrationBuilder.CreateIndex(
                name: "IX_tblShkolla_UserId",
                schema: "design",
                table: "tblShkolla",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblShkolla_UserId1",
                schema: "design",
                table: "tblShkolla",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_tblStafiShkolles_numriPersonal",
                schema: "design",
                table: "tblStafiShkolles",
                column: "numriPersonal");

            migrationBuilder.CreateIndex(
                name: "IX_tblStafiShkolles_shkollaId",
                schema: "design",
                table: "tblStafiShkolles",
                column: "shkollaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                schema: "shared",
                table: "AspNetUserClaims",
                column: "UserId",
                principalSchema: "shared",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                schema: "shared",
                table: "AspNetUserLogins",
                column: "UserId",
                principalSchema: "shared",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                schema: "shared",
                table: "AspNetUserRoles",
                column: "UserId",
                principalSchema: "shared",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_tblKomuna_KomunaId",
                schema: "shared",
                table: "AspNetUsers",
                column: "KomunaId",
                principalSchema: "shared",
                principalTable: "tblKomuna",
                principalColumn: "KomunaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblKomuna_AspNetUsers_UserId",
                schema: "shared",
                table: "tblKomuna");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "shared");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "shared");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "shared");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "shared");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "shared");

            migrationBuilder.DropTable(
                name: "tblAccounts",
                schema: "shared");

            migrationBuilder.DropTable(
                name: "tblInventariAktual",
                schema: "design");

            migrationBuilder.DropTable(
                name: "tblMarreveshja",
                schema: "design");

            migrationBuilder.DropTable(
                name: "tblNdalesat",
                schema: "design");

            migrationBuilder.DropTable(
                name: "tblNdarjetBuxhetit",
                schema: "design");

            migrationBuilder.DropTable(
                name: "tblOretShtese",
                schema: "design");

            migrationBuilder.DropTable(
                name: "tblPagesat",
                schema: "design");

            migrationBuilder.DropTable(
                name: "tblRoles",
                schema: "design");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "shared");

            migrationBuilder.DropTable(
                name: "tblTenderi",
                schema: "design");

            migrationBuilder.DropTable(
                name: "tblStafiShkolles",
                schema: "design");

            migrationBuilder.DropTable(
                name: "tblPorosite",
                schema: "design");

            migrationBuilder.DropTable(
                name: "tblProdukti",
                schema: "design");

            migrationBuilder.DropTable(
                name: "tblShkolla",
                schema: "design");

            migrationBuilder.DropTable(
                name: "tblKompania",
                schema: "design");

            migrationBuilder.DropTable(
                name: "tblPersons",
                schema: "design");

            migrationBuilder.DropTable(
                name: "tblAdresat",
                schema: "design");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "shared");

            migrationBuilder.DropTable(
                name: "tblKomuna",
                schema: "shared");
        }
    }
}
