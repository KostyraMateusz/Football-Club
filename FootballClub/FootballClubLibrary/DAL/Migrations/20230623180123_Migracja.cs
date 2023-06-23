using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FootballClubLibrary.Migrations
{
    /// <inheritdoc />
    public partial class Migracja : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kluby",
                columns: table => new
                {
                    IdKlub = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Stadion = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
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
                    Imie = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Wiek = table.Column<int>(type: "int", nullable: false),
                    Pozycja = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
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
                    IdKlubu = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Budzet = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cele = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    IdPilkarz = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Mecz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gole = table.Column<int>(type: "int", nullable: false),
                    Asysty = table.Column<int>(type: "int", nullable: false),
                    ZolteKartki = table.Column<int>(type: "int", nullable: false),
                    CzerwoneKartki = table.Column<int>(type: "int", nullable: false),
                    PrzebiegnietyDystans = table.Column<double>(type: "float", nullable: false),
                    Ocena = table.Column<double>(type: "float", nullable: false)
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
                    Imie = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Nazwisko = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PESEL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wiek = table.Column<int>(type: "int", nullable: false),
                    WykonywanaFunkcja = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Wynagrodzenie = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdZarzadu = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    { new Guid("5b76ebdf-12a5-45b9-9412-d8044fbbccab"), "Real Madryt", "Estadio Santiago Bernabéu", "Liga Mistrzów (13 razy), Primera División (34 razy), Puchar Króla (19 razy), Superpuchar Hiszpanii (11 razy)" },
                    { new Guid("646dce1f-325b-4561-80d9-80babbd0eefe"), "FC Barcelona", "Camp Nou", "Liga Mistrzów (5 razy), Primera División (26 razy), Puchar Króla (31 razy), Superpuchar Hiszpanii (13 razy)" },
                    { new Guid("f9334e88-98aa-469c-92b8-aec5fc192dde"), "Juventus", "Allianz Stadium", "Liga Mistrzów (2 razy), Serie A (36 razy), Puchar Włoch (14 razy), Superpuchar Włoch (9 razy)" }
                });

            migrationBuilder.InsertData(
                table: "Pilkarze",
                columns: new[] { "IdPilkarz", "IdKlubu", "Imie", "Nazwisko", "Pozycja", "Wiek", "Wynagrodzenie" },
                values: new object[,]
                {
                    { new Guid("275310a0-8b4e-404c-8c1b-c843910de78d"), new Guid("5b76ebdf-12a5-45b9-9412-d8044fbbccab"), "Ferland", "Mendy", "Obrońca", 26, 220000m },
                    { new Guid("57fc888f-31e2-4b2d-a977-1097e2ba8d08"), new Guid("5b76ebdf-12a5-45b9-9412-d8044fbbccab"), "Carlos Henrique", "Casimiro", "Pomocnik", 29, 280000m },
                    { new Guid("62a77b69-8739-4a14-a898-8d1de84ccb24"), new Guid("5b76ebdf-12a5-45b9-9412-d8044fbbccab"), "Thibaut", "Courtois", "Bramkarz", 29, 350000m },
                    { new Guid("63544162-323b-4417-ba17-45636c0f8b92"), new Guid("5b76ebdf-12a5-45b9-9412-d8044fbbccab"), "Eder", "Militao", "Obrońca", 23, 200000m },
                    { new Guid("698cc8cc-caad-4515-ba3b-9aa383896940"), new Guid("5b76ebdf-12a5-45b9-9412-d8044fbbccab"), "Dani", "Carvajal", "Obrońca", 29, 250000m },
                    { new Guid("7b35fc65-2935-4cd0-9487-2ee84cf9d107"), new Guid("5b76ebdf-12a5-45b9-9412-d8044fbbccab"), "Toni", "Kroos", "Pomocnik", 31, 320000m },
                    { new Guid("85294532-4fc8-4985-ad83-f6cb9e3b3ffc"), new Guid("5b76ebdf-12a5-45b9-9412-d8044fbbccab"), "Raphael", "Varane", "Obrońca", 28, 300000m },
                    { new Guid("85527111-dc5e-4fd2-8cfd-9253e860d954"), new Guid("5b76ebdf-12a5-45b9-9412-d8044fbbccab"), "Vinicius", "Junior", "Napastnik", 21, 180000m },
                    { new Guid("a283f0b2-1547-4d10-8b78-943ef3771eb8"), new Guid("5b76ebdf-12a5-45b9-9412-d8044fbbccab"), "Luka", "Modrić", "Pomocnik", 35, 350000m },
                    { new Guid("be454e0b-f322-442c-86f0-bcb1829ffe6f"), new Guid("5b76ebdf-12a5-45b9-9412-d8044fbbccab"), "Karim", "Benzema", "Napastnik", 33, 450000m },
                    { new Guid("eaf2f672-0ece-4935-9222-b0f5a2adbd34"), new Guid("5b76ebdf-12a5-45b9-9412-d8044fbbccab"), "Marco", "Asensio", "Pomocnik", 25, 240000m }
                });

            migrationBuilder.InsertData(
                table: "Zarzady",
                columns: new[] { "IdZarzad", "Budzet", "Cele", "IdKlubu" },
                values: new object[,]
                {
                    { new Guid("244124f6-bcbe-4196-8598-d9b14cadde5b"), 1800000m, "Liga Mistrzów, Serie A, Puchar Włoch, Akademia młodzieżowa, Rozwój infrastruktury", new Guid("f9334e88-98aa-469c-92b8-aec5fc192dde") },
                    { new Guid("c5e4e7c6-0a0c-41ad-9a1c-5f718c456dcb"), 2500000m, "Liga Mistrzów, Superpuchar Hiszpanii, Naprawa murawy, Renowacja krzesełek, Nowy młody napastnik", new Guid("5b76ebdf-12a5-45b9-9412-d8044fbbccab") },
                    { new Guid("e3db1031-4b3e-41e7-91f3-c90420ffb1c8"), 2000000m, "Liga Mistrzów, Primera División, Puchar Króla, Odnowienie akademii młodzieżowej, Wzmocnienie składu", new Guid("646dce1f-325b-4561-80d9-80babbd0eefe") }
                });

            migrationBuilder.InsertData(
                table: "Pracownicy",
                columns: new[] { "IdPracownik", "IdZarzadu", "Imie", "Nazwisko", "PESEL", "Wiek", "WykonywanaFunkcja", "Wynagrodzenie" },
                values: new object[,]
                {
                    { new Guid("09015678-73fc-430c-afb8-50738f146010"), new Guid("c5e4e7c6-0a0c-41ad-9a1c-5f718c456dcb"), "Javier", "Mallo", "56789000505", 46, "Trener przygotowania fizycznego", 1250000m },
                    { new Guid("0a1414ce-4804-4b3d-a0aa-c20260209223"), new Guid("c5e4e7c6-0a0c-41ad-9a1c-5f718c456dcb"), "Luis", "Llopis", "45678900404", 58, "Trener Bramkarzy", 150000m },
                    { new Guid("0f9bc5d8-3d00-41fb-b76d-1a5d6584099c"), new Guid("c5e4e7c6-0a0c-41ad-9a1c-5f718c456dcb"), "Carlo", "Ancelotti", "23456700202", 64, "Trener", 350000m },
                    { new Guid("114669e3-dfdd-41ef-afd6-3e15bab7e315"), new Guid("c5e4e7c6-0a0c-41ad-9a1c-5f718c456dcb"), "Antonio", "Pintus", "67890100606", 60, "Trener przygotowania fizycznego", 125000m },
                    { new Guid("76c3bdb3-0f8b-4e79-ae4f-489d4e439917"), new Guid("c5e4e7c6-0a0c-41ad-9a1c-5f718c456dcb"), "Juni", "Calafat", "90123400909", 50, "Szef skautingu", 200000m },
                    { new Guid("76c5bff9-4e79-4432-b5d9-596710b72ade"), new Guid("c5e4e7c6-0a0c-41ad-9a1c-5f718c456dcb"), "Fiorentino", "Perez", "12345600101", 77, "Prezes", 420000m },
                    { new Guid("78f5630b-0028-4874-8adb-e31c8599e486"), new Guid("c5e4e7c6-0a0c-41ad-9a1c-5f718c456dcb"), "Iker", "Casillas", "89012300808", 42, "Wice-prezes zarządu", 200000m },
                    { new Guid("9bf2bf34-ca52-48dd-ab1d-08bdb0dc2da9"), new Guid("c5e4e7c6-0a0c-41ad-9a1c-5f718c456dcb"), "Simone", "Montanaro", "78901200707", 51, "Trener analityk", 140000m },
                    { new Guid("ee0c6375-26ed-4543-855f-ddcab060d092"), new Guid("c5e4e7c6-0a0c-41ad-9a1c-5f718c456dcb"), "Davide", "Ancelotti", "34567800303", 33, "Asystent trenera", 300000m }
                });

            migrationBuilder.InsertData(
                table: "Statystki",
                columns: new[] { "IdStatystyka", "Asysty", "CzerwoneKartki", "Gole", "IdPilkarz", "Mecz", "Ocena", "PrzebiegnietyDystans", "ZolteKartki" },
                values: new object[,]
                {
                    { new Guid("09070374-b8ec-431a-a405-2085cd8e0fdf"), 1, 0, 1, new Guid("be454e0b-f322-442c-86f0-bcb1829ffe6f"), "Real Madrid vs Sevilla", 8.0, 9.0999999999999996, 0 },
                    { new Guid("15ad7e67-170d-4c98-bf10-dc18c35e0027"), 1, 0, 0, new Guid("275310a0-8b4e-404c-8c1b-c843910de78d"), "Real Madrid vs Liverpool", 7.9000000000000004, 8.5999999999999996, 2 },
                    { new Guid("20728071-3b87-44d6-8ba1-1ece97cf5f41"), 1, 0, 0, new Guid("275310a0-8b4e-404c-8c1b-c843910de78d"), "Real Madrid vs Chelsea", 7.7999999999999998, 8.9000000000000004, 2 },
                    { new Guid("257819e5-ae76-4963-a6b6-6cd6b9a18487"), 2, 0, 1, new Guid("eaf2f672-0ece-4935-9222-b0f5a2adbd34"), "Real Madrid vs Atalanta", 8.5, 9.6999999999999993, 0 },
                    { new Guid("326fe5c0-787f-4415-9a06-1d97252255dc"), 2, 0, 0, new Guid("a283f0b2-1547-4d10-8b78-943ef3771eb8"), "Real Madrid vs Manchester City", 8.5999999999999996, 9.5999999999999996, 1 },
                    { new Guid("33c249b2-87b9-4727-8a01-3c2db4164797"), 0, 0, 1, new Guid("57fc888f-31e2-4b2d-a977-1097e2ba8d08"), "Real Madrid vs Inter Milan", 7.7999999999999998, 8.5, 1 },
                    { new Guid("6b0e06e9-bed6-473b-9f69-5ae1b548bc02"), 0, 0, 1, new Guid("eaf2f672-0ece-4935-9222-b0f5a2adbd34"), "Real Madrid vs Arsenal", 7.9000000000000004, 8.6999999999999993, 0 },
                    { new Guid("6e0b6ff0-1be6-405c-a23e-f948bdbef114"), 0, 0, 1, new Guid("be454e0b-f322-442c-86f0-bcb1829ffe6f"), "Real Madrid vs Atletico Madrid", 8.0999999999999996, 9.1999999999999993, 0 },
                    { new Guid("850b45ef-7c21-4242-ac5f-32932ad573d3"), 0, 0, 2, new Guid("a283f0b2-1547-4d10-8b78-943ef3771eb8"), "Real Madrid vs Valencia", 8.1999999999999993, 8.5, 1 },
                    { new Guid("937288c6-e6d1-4fce-9e83-ec787532a6ab"), 2, 0, 1, new Guid("eaf2f672-0ece-4935-9222-b0f5a2adbd34"), "Real Madrid vs PSG", 8.6999999999999993, 9.8000000000000007, 0 },
                    { new Guid("b3a978c8-e3c2-4f46-aa94-b74fab871fb9"), 1, 0, 1, new Guid("be454e0b-f322-442c-86f0-bcb1829ffe6f"), "Real Madrid vs AC Milan", 8.3000000000000007, 9.4000000000000004, 0 },
                    { new Guid("f479321b-a961-4ce9-a51f-344fbb360be4"), 1, 0, 0, new Guid("a283f0b2-1547-4d10-8b78-943ef3771eb8"), "Real Madrid vs FC Barcelona", 7.5, 8.4000000000000004, 1 },
                    { new Guid("fb56cc42-a0db-41db-912c-406acbcf2f59"), 0, 0, 1, new Guid("57fc888f-31e2-4b2d-a977-1097e2ba8d08"), "Real Madrid vs Juventus", 7.5999999999999996, 8.3000000000000007, 1 },
                    { new Guid("fd79226b-183a-4212-a19b-f27c4847a2c4"), 0, 0, 0, new Guid("57fc888f-31e2-4b2d-a977-1097e2ba8d08"), "Real Madrid vs Bayern Monachium", 7.2999999999999998, 8.1999999999999993, 1 },
                    { new Guid("ffb1e724-ecc3-4b3a-8de7-730c0ee56566"), 1, 0, 0, new Guid("275310a0-8b4e-404c-8c1b-c843910de78d"), "Real Madrid vs Tottenham", 7.7000000000000002, 8.8000000000000007, 2 }
                });

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
