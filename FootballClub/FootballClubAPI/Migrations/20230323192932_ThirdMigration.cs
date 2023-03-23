using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballClubAPI.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kluby",
                columns: table => new
                {
                    IdKlub = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Stadion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    Pozycja = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Wynagrodzenie = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdKlubu = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilkarze", x => x.IdPilkarz);
                    table.ForeignKey(
                        name: "FK_Pilkarze_Kluby_IdKlubu",
                        column: x => x.IdKlubu,
                        principalTable: "Kluby",
                        principalColumn: "IdKlub",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zarzady",
                columns: table => new
                {
                    IdZarzad = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Budzet = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cele = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdKlubu = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                name: "Statystki",
                columns: table => new
                {
                    IdStatystyka = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Gole = table.Column<int>(type: "int", nullable: false),
                    Asysty = table.Column<int>(type: "int", nullable: false),
                    Kartki = table.Column<int>(type: "int", nullable: false),
                    PrzebiegnietyDystans = table.Column<double>(type: "float", nullable: false),
                    Ocena = table.Column<double>(type: "float", nullable: false),
                    IdPilkarz = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    Imie = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PESEL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wiek = table.Column<int>(type: "int", nullable: false),
                    WykonywanaFunkcja = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IdZarzadu = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

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
