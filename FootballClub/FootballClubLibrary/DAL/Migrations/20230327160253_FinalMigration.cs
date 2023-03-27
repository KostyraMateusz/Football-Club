using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FootballClubLibrary.Migrations
{
    /// <inheritdoc />
    public partial class FinalMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kluby",
                columns: table => new
                {
                    IdKlub = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stadion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Trofea = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kluby", x => x.IdKlub);
                });

            migrationBuilder.CreateTable(
                name: "Pilkarze",
                columns: table => new
                {
                    IdPilkarz = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Pozycja = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Wynagrodzenie = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdKlubu = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilkarze", x => x.IdPilkarz);
                    table.ForeignKey(
                        name: "FK_Pilkarze_Kluby_IdKlubu",
                        column: x => x.IdKlubu,
                        principalTable: "Kluby",
                        principalColumn: "IdKlub");
                });

            migrationBuilder.CreateTable(
                name: "Zarzady",
                columns: table => new
                {
                    IdZarzad = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Budzet = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cele = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdKlubu = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zarzady", x => x.IdZarzad);
                    table.ForeignKey(
                        name: "FK_Zarzady_Kluby_IdKlubu",
                        column: x => x.IdKlubu,
                        principalTable: "Kluby",
                        principalColumn: "IdKlub",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KlubPilkarz",
                columns: table => new
                {
                    ArchiwalneKlubyIdKlub = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArchwilaniPilkarzeIdPilkarz = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KlubPilkarz", x => new { x.ArchiwalneKlubyIdKlub, x.ArchwilaniPilkarzeIdPilkarz });
                    table.ForeignKey(
                        name: "FK_KlubPilkarz_Kluby_ArchiwalneKlubyIdKlub",
                        column: x => x.ArchiwalneKlubyIdKlub,
                        principalTable: "Kluby",
                        principalColumn: "IdKlub",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KlubPilkarz_Pilkarze_ArchwilaniPilkarzeIdPilkarz",
                        column: x => x.ArchwilaniPilkarzeIdPilkarz,
                        principalTable: "Pilkarze",
                        principalColumn: "IdPilkarz",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Statystki",
                columns: table => new
                {
                    IdStatystyka = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mecz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gole = table.Column<int>(type: "int", nullable: false),
                    Asysty = table.Column<int>(type: "int", nullable: false),
                    ZolteKartki = table.Column<int>(type: "int", nullable: false),
                    CzerwoneKartki = table.Column<int>(type: "int", nullable: false),
                    PrzebiegnietyDystans = table.Column<double>(type: "float", nullable: false),
                    Ocena = table.Column<double>(type: "float", nullable: false),
                    IdPilkarz = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statystki", x => x.IdStatystyka);
                    table.ForeignKey(
                        name: "FK_Statystki_Pilkarze_IdPilkarz",
                        column: x => x.IdPilkarz,
                        principalTable: "Pilkarze",
                        principalColumn: "IdPilkarz",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pracownicy",
                columns: table => new
                {
                    IdPracownik = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Imie = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Nazwisko = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PESEL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wiek = table.Column<int>(type: "int", nullable: false),
                    WykonywanaFunkcja = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IdZarzadu = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Wynagrodzenie = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracownicy", x => x.IdPracownik);
                    table.ForeignKey(
                        name: "FK_Pracownicy_Zarzady_IdZarzadu",
                        column: x => x.IdZarzadu,
                        principalTable: "Zarzady",
                        principalColumn: "IdZarzad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kluby",
                columns: new[] { "IdKlub", "Nazwa", "Stadion", "Trofea" },
                values: new object[,]
                {
                    { new Guid("97639ccf-13a1-4f8a-b405-5f1a4482191f"), "Klub2", "Stadion2", null },
                    { new Guid("d8846ec1-c8ce-43fd-87e0-f6ca49f0d10e"), "Klub1", "Stadion1", null }
                });

            migrationBuilder.InsertData(
                table: "Pilkarze",
                columns: new[] { "IdPilkarz", "IdKlubu", "Pozycja", "Wynagrodzenie" },
                values: new object[,]
                {
                    { new Guid("aa2811a8-fb02-4841-bc83-84ec98114a60"), null, "Napastnik", 1000m },
                    { new Guid("b6e0ad33-c448-4c7d-bea0-7a4643943ea4"), null, "Pomocnik", 2000m }
                });

            migrationBuilder.InsertData(
                table: "Pracownicy",
                columns: new[] { "IdPracownik", "IdZarzadu", "Imie", "Nazwisko", "PESEL", "Wiek", "WykonywanaFunkcja", "Wynagrodzenie" },
                values: new object[,]
                {
                    { new Guid("026a7c74-82ae-4b24-8ae9-ff948adcba90"), null, "Mateusz", "Kostyra", "00124168751", 23, "Prezes", 50000m },
                    { new Guid("ea7c1f63-805e-451d-9686-b469f31e7c06"), null, "Stanisław", "Kluczewski", "00864164771", 23, "Vc-Prezes", 50000m }
                });

            migrationBuilder.InsertData(
                table: "Statystki",
                columns: new[] { "IdStatystyka", "Asysty", "CzerwoneKartki", "Gole", "IdPilkarz", "Mecz", "Ocena", "PrzebiegnietyDystans", "ZolteKartki" },
                values: new object[,]
                {
                    { new Guid("21e6caf1-1184-4802-82c6-ecd02b5fc985"), 1, 1, 4, null, null, 8.6999999999999993, 10.4, 0 },
                    { new Guid("77afdb37-3517-4db1-9e33-82b1d2164f27"), 2, 1, 0, null, null, 7.5, 8.4000000000000004, 2 }
                });

            migrationBuilder.InsertData(
                table: "Zarzady",
                columns: new[] { "IdZarzad", "Budzet", "Cele", "IdKlubu" },
                values: new object[] { new Guid("4cb42210-e7ab-4ca1-87b2-ae6b3db9e3a2"), 2000m, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_KlubPilkarz_ArchwilaniPilkarzeIdPilkarz",
                table: "KlubPilkarz",
                column: "ArchwilaniPilkarzeIdPilkarz");

            migrationBuilder.CreateIndex(
                name: "IX_Pilkarze_IdKlubu",
                table: "Pilkarze",
                column: "IdKlubu");

            migrationBuilder.CreateIndex(
                name: "IX_Pracownicy_IdZarzadu",
                table: "Pracownicy",
                column: "IdZarzadu");

            migrationBuilder.CreateIndex(
                name: "IX_Statystki_IdPilkarz",
                table: "Statystki",
                column: "IdPilkarz");

            migrationBuilder.CreateIndex(
                name: "IX_Zarzady_IdKlubu",
                table: "Zarzady",
                column: "IdKlubu",
                unique: true,
                filter: "[IdKlubu] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KlubPilkarz");

            migrationBuilder.DropTable(
                name: "Pracownicy");

            migrationBuilder.DropTable(
                name: "Statystki");

            migrationBuilder.DropTable(
                name: "Zarzady");

            migrationBuilder.DropTable(
                name: "Pilkarze");

            migrationBuilder.DropTable(
                name: "Kluby");
        }
    }
}
