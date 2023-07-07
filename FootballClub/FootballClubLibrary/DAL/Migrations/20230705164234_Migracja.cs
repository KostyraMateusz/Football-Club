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
                    { new Guid("5128b21a-e6b9-4aef-8c1e-307a6fe57980"), "Juventus", "Allianz Stadium", "Liga Mistrzów (2 razy), Serie A (36 razy), Puchar Włoch (14 razy), Superpuchar Włoch (9 razy)" },
                    { new Guid("60b76cbe-81e7-49a9-b0d0-7032296a7e69"), "FC Barcelona", "Camp Nou", "Liga Mistrzów (5 razy), Primera División (26 razy), Puchar Króla (31 razy), Superpuchar Hiszpanii (13 razy)" },
                    { new Guid("92e4cb05-cce9-449d-8e39-fba252c47ba1"), "Real Madryt", "Estadio Santiago Bernabéu", "Liga Mistrzów (13 razy), Primera División (34 razy), Puchar Króla (19 razy), Superpuchar Hiszpanii (11 razy)" }
                });

            migrationBuilder.InsertData(
                table: "Pracownicy",
                columns: new[] { "IdPracownik", "IdZarzadu", "Imie", "Nazwisko", "PESEL", "Wiek", "WykonywanaFunkcja", "Wynagrodzenie" },
                values: new object[,]
                {
                    { new Guid("11ba2f3f-b9d6-4229-aab2-4897f495fdc8"), null, "Mateusz", "Kostyra", "780124500909", 23, "", 10000000m },
                    { new Guid("29103e4b-c8ef-478b-bd5f-724707b4add2"), null, "Stanisław", "Kluczewski", "45423402949", 23, "", 5000000m }
                });

            migrationBuilder.InsertData(
                table: "Pilkarze",
                columns: new[] { "IdPilkarz", "IdKlubu", "Imie", "Nazwisko", "Pozycja", "Wiek", "Wynagrodzenie" },
                values: new object[,]
                {
                    { new Guid("18abe966-c138-442d-af8a-066f8ed8ff82"), new Guid("92e4cb05-cce9-449d-8e39-fba252c47ba1"), "Carlos Henrique", "Casimiro", "Pomocnik", 29, 280000m },
                    { new Guid("2bfc2dab-fa67-464b-9a67-2accef09a8e6"), new Guid("92e4cb05-cce9-449d-8e39-fba252c47ba1"), "Raphael", "Varane", "Obrońca", 28, 300000m },
                    { new Guid("2dc9b501-b8e8-406d-b1dd-a2d75c09bb6c"), new Guid("92e4cb05-cce9-449d-8e39-fba252c47ba1"), "Thibaut", "Courtois", "Bramkarz", 29, 350000m },
                    { new Guid("43eb151c-6670-4c49-b7a4-c6fa596f9672"), new Guid("92e4cb05-cce9-449d-8e39-fba252c47ba1"), "Marco", "Asensio", "Pomocnik", 25, 240000m },
                    { new Guid("4b4c693d-0d59-4095-88a4-d5e90b9edb94"), new Guid("92e4cb05-cce9-449d-8e39-fba252c47ba1"), "Dani", "Carvajal", "Obrońca", 29, 250000m },
                    { new Guid("5480053a-38f1-416b-9e5d-3cca81a3ec3e"), new Guid("92e4cb05-cce9-449d-8e39-fba252c47ba1"), "Eder", "Militao", "Obrońca", 23, 200000m },
                    { new Guid("913390be-a78f-4359-b86e-fcadf9e04f4b"), new Guid("92e4cb05-cce9-449d-8e39-fba252c47ba1"), "Luka", "Modrić", "Pomocnik", 35, 350000m },
                    { new Guid("92078c5b-86f8-462a-8e44-17e394929fd0"), new Guid("92e4cb05-cce9-449d-8e39-fba252c47ba1"), "Vinicius", "Junior", "Napastnik", 21, 180000m },
                    { new Guid("a38cbad7-8cce-472e-8501-4c56197461dd"), new Guid("92e4cb05-cce9-449d-8e39-fba252c47ba1"), "Ferland", "Mendy", "Obrońca", 26, 220000m },
                    { new Guid("dacee609-350b-4063-9ab0-3b45e5d7f56c"), new Guid("92e4cb05-cce9-449d-8e39-fba252c47ba1"), "Karim", "Benzema", "Napastnik", 33, 450000m },
                    { new Guid("dcc261ab-9650-484f-b246-68185e9b1fec"), new Guid("92e4cb05-cce9-449d-8e39-fba252c47ba1"), "Toni", "Kroos", "Pomocnik", 31, 320000m }
                });

            migrationBuilder.InsertData(
                table: "Zarzady",
                columns: new[] { "IdZarzad", "Budzet", "Cele", "IdKlubu" },
                values: new object[,]
                {
                    { new Guid("08713cb3-6e15-4b34-b0cd-8a7a95060a00"), 1800000m, "Liga Mistrzów, Serie A, Puchar Włoch, Akademia młodzieżowa, Rozwój infrastruktury", new Guid("5128b21a-e6b9-4aef-8c1e-307a6fe57980") },
                    { new Guid("77b3ccb5-4c02-4725-bb10-43872e315398"), 2000000m, "Liga Mistrzów, Primera División, Puchar Króla, Odnowienie akademii młodzieżowej, Wzmocnienie składu", new Guid("60b76cbe-81e7-49a9-b0d0-7032296a7e69") },
                    { new Guid("99a3bae0-86f7-4a8d-ae5d-cb890d86e41b"), 2500000m, "Liga Mistrzów, Superpuchar Hiszpanii, Naprawa murawy, Renowacja krzesełek, Nowy młody napastnik", new Guid("92e4cb05-cce9-449d-8e39-fba252c47ba1") }
                });

            migrationBuilder.InsertData(
                table: "Pracownicy",
                columns: new[] { "IdPracownik", "IdZarzadu", "Imie", "Nazwisko", "PESEL", "Wiek", "WykonywanaFunkcja", "Wynagrodzenie" },
                values: new object[,]
                {
                    { new Guid("3362e435-2147-4e11-a0a7-2031a40c72ea"), new Guid("99a3bae0-86f7-4a8d-ae5d-cb890d86e41b"), "Juni", "Calafat", "90123400909", 50, "Szef skautingu", 200000m },
                    { new Guid("720d475b-d529-4159-b218-7ed97f479cf8"), new Guid("99a3bae0-86f7-4a8d-ae5d-cb890d86e41b"), "Luis", "Llopis", "45678900404", 58, "Trener Bramkarzy", 150000m },
                    { new Guid("7d6a550a-583e-4a18-a1bf-14422268dc18"), new Guid("99a3bae0-86f7-4a8d-ae5d-cb890d86e41b"), "Fiorentino", "Perez", "12345600101", 77, "Prezes", 420000m },
                    { new Guid("a07af027-d1ec-41ac-a25f-8776df952f1b"), new Guid("99a3bae0-86f7-4a8d-ae5d-cb890d86e41b"), "Davide", "Ancelotti", "34567800303", 33, "Asystent trenera", 300000m },
                    { new Guid("b079260d-4783-4a45-814a-091523e3dc06"), new Guid("99a3bae0-86f7-4a8d-ae5d-cb890d86e41b"), "Carlo", "Ancelotti", "23456700202", 64, "Trener", 350000m },
                    { new Guid("bf4e794b-5997-43a3-8b20-5b2517305bd5"), new Guid("99a3bae0-86f7-4a8d-ae5d-cb890d86e41b"), "Antonio", "Pintus", "67890100606", 60, "Trener przygotowania fizycznego", 125000m },
                    { new Guid("c49f0b4f-8a6b-4bd5-b3c8-97987e40a6dc"), new Guid("99a3bae0-86f7-4a8d-ae5d-cb890d86e41b"), "Iker", "Casillas", "89012300808", 42, "Wice-prezes zarządu", 200000m },
                    { new Guid("c575ff03-5339-486e-b94e-f2a20df4ccb1"), new Guid("99a3bae0-86f7-4a8d-ae5d-cb890d86e41b"), "Simone", "Montanaro", "78901200707", 51, "Trener analityk", 140000m },
                    { new Guid("cc2f7e66-f2c1-4724-8bb9-3e6ffa67681a"), new Guid("99a3bae0-86f7-4a8d-ae5d-cb890d86e41b"), "Javier", "Mallo", "56789000505", 46, "Trener przygotowania fizycznego", 1250000m }
                });

            migrationBuilder.InsertData(
                table: "Statystki",
                columns: new[] { "IdStatystyka", "Asysty", "CzerwoneKartki", "Gole", "IdPilkarz", "Mecz", "Ocena", "PrzebiegnietyDystans", "ZolteKartki" },
                values: new object[,]
                {
                    { new Guid("0e29c631-890d-4386-b83a-a2201c34c4e3"), 2, 0, 0, new Guid("913390be-a78f-4359-b86e-fcadf9e04f4b"), "Real Madrid vs Manchester City", 8.5999999999999996, 9.5999999999999996, 1 },
                    { new Guid("1f5d6e69-68de-401a-93b5-45482061c5c3"), 2, 0, 1, new Guid("43eb151c-6670-4c49-b7a4-c6fa596f9672"), "Real Madrid vs Atalanta", 8.5, 9.6999999999999993, 0 },
                    { new Guid("2a104f8c-7ded-4f48-8b7d-d591d0169349"), 0, 0, 2, new Guid("913390be-a78f-4359-b86e-fcadf9e04f4b"), "Real Madrid vs Valencia", 8.1999999999999993, 8.5, 1 },
                    { new Guid("2b7fcb6d-730a-44ec-8090-3c2fe14bb3f7"), 1, 0, 0, new Guid("a38cbad7-8cce-472e-8501-4c56197461dd"), "Real Madrid vs Tottenham", 7.7000000000000002, 8.8000000000000007, 2 },
                    { new Guid("3bb929e5-ade1-421d-8d43-0f970bd3c34b"), 0, 0, 1, new Guid("43eb151c-6670-4c49-b7a4-c6fa596f9672"), "Real Madrid vs Arsenal", 7.9000000000000004, 8.6999999999999993, 0 },
                    { new Guid("6021c88f-7ba4-4c93-b73b-7fbf4385bead"), 0, 0, 1, new Guid("dacee609-350b-4063-9ab0-3b45e5d7f56c"), "Real Madrid vs Atletico Madrid", 8.0999999999999996, 9.1999999999999993, 0 },
                    { new Guid("62e3c6c2-2e58-48ae-a00c-5ae840e1a2eb"), 0, 0, 1, new Guid("18abe966-c138-442d-af8a-066f8ed8ff82"), "Real Madrid vs Juventus", 7.5999999999999996, 8.3000000000000007, 1 },
                    { new Guid("900e4775-ca1f-4716-8ea2-8dad5f291324"), 1, 0, 0, new Guid("a38cbad7-8cce-472e-8501-4c56197461dd"), "Real Madrid vs Liverpool", 7.9000000000000004, 8.5999999999999996, 2 },
                    { new Guid("91aa9200-21ba-4716-a7a5-1c393e28c044"), 1, 0, 1, new Guid("dacee609-350b-4063-9ab0-3b45e5d7f56c"), "Real Madrid vs AC Milan", 8.3000000000000007, 9.4000000000000004, 0 },
                    { new Guid("946475d5-6713-4f0f-b2e9-57b0cac3b3ef"), 1, 0, 0, new Guid("a38cbad7-8cce-472e-8501-4c56197461dd"), "Real Madrid vs Chelsea", 7.7999999999999998, 8.9000000000000004, 2 },
                    { new Guid("9705e34a-38ac-44fa-9a04-3ad5bbc585d0"), 0, 0, 1, new Guid("18abe966-c138-442d-af8a-066f8ed8ff82"), "Real Madrid vs Inter Milan", 7.7999999999999998, 8.5, 1 },
                    { new Guid("99af6f3c-e95b-47d4-9e6d-b4311a6e2068"), 1, 0, 0, new Guid("913390be-a78f-4359-b86e-fcadf9e04f4b"), "Real Madrid vs FC Barcelona", 7.5, 8.4000000000000004, 1 },
                    { new Guid("9eb65a17-d04f-42c7-88f9-390f9570333e"), 2, 0, 1, new Guid("43eb151c-6670-4c49-b7a4-c6fa596f9672"), "Real Madrid vs PSG", 8.6999999999999993, 9.8000000000000007, 0 },
                    { new Guid("c76437a8-ec60-499f-979f-b40d4b5548c4"), 0, 0, 0, new Guid("18abe966-c138-442d-af8a-066f8ed8ff82"), "Real Madrid vs Bayern Monachium", 7.2999999999999998, 8.1999999999999993, 1 },
                    { new Guid("f77f4547-aa4f-411e-95ce-19c8978dec5c"), 1, 0, 1, new Guid("dacee609-350b-4063-9ab0-3b45e5d7f56c"), "Real Madrid vs Sevilla", 8.0, 9.0999999999999996, 0 }
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
