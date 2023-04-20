using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FootballClubLibrary.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMigration2 : Migration
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
                    Trofea = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Imie = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Wiek = table.Column<int>(type: "int", nullable: false),
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
                    Cele = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    { new Guid("23da5e72-4b42-47ad-965e-5511cc772eae"), "Real Madryt", "Estadio Santiago Bernabéu", "Liga Mistrzów" },
                    { new Guid("90fe8fab-b90e-4cd1-aa7c-12ab3b6040ad"), "FC Barcelona", "Camp Nou", "La Liga" }
                });

            migrationBuilder.InsertData(
                table: "Pilkarze",
                columns: new[] { "IdPilkarz", "IdKlubu", "Imie", "Nazwisko", "Pozycja", "Wiek", "Wynagrodzenie" },
                values: new object[,]
                {
                    { new Guid("5ed7ba86-5116-4da1-badb-61592d26ce74"), null, "Robert", "Lewandowski", "Napastnik", 35, 440000m },
                    { new Guid("eda062ba-e7b1-4e41-8c91-9b166880a497"), null, "Sergio", "Busquets", "Pomocnik", 34, 350000m }
                });

            migrationBuilder.InsertData(
                table: "Pracownicy",
                columns: new[] { "IdPracownik", "IdZarzadu", "Imie", "Nazwisko", "PESEL", "Wiek", "WykonywanaFunkcja", "Wynagrodzenie" },
                values: new object[,]
                {
                    { new Guid("265c9b83-b7ba-4b18-8cf2-2b02973c1467"), null, "Carlo", "Carlo Ancelotti", "12345600101", 63, "Trener", 340000m },
                    { new Guid("3a0e73ac-053b-4c05-a1fe-04e15d9d4ebb"), null, "Xavi", "Hernandez", "12345600101", 43, "Trener", 340000m },
                    { new Guid("7a303c5a-b9f9-42b6-9a03-f51c6e2ad182"), null, "Fiorentino", "Perez", "12345678901", 77, "Prezes", 340000m },
                    { new Guid("b3cc1806-b9a5-465b-8b51-d73dd2f70a76"), null, "Joan", "Laporta", "12345338901", 60, "Prezes", 340000m }
                });

            migrationBuilder.InsertData(
                table: "Statystki",
                columns: new[] { "IdStatystyka", "Asysty", "CzerwoneKartki", "Gole", "IdPilkarz", "Mecz", "Ocena", "PrzebiegnietyDystans", "ZolteKartki" },
                values: new object[,]
                {
                    { new Guid("4dc1af77-4d52-4a55-bd71-2dcc3e8a6252"), 2, 1, 0, null, "FC Barcelona vs Real Madrid", 7.5, 8.4000000000000004, 2 },
                    { new Guid("facef62e-d543-4593-bc68-ee153e121920"), 1, 1, 4, null, "Real Madrid vs FC Barcelona", 8.6999999999999993, 10.4, 0 }
                });

            migrationBuilder.InsertData(
                table: "Zarzady",
                columns: new[] { "IdZarzad", "Budzet", "Cele", "IdKlubu" },
                values: new object[] { new Guid("e47db833-127c-4b8c-8965-a2d35dd760db"), 2000m, "Cel 1", null });

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
