using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FootballClubLibrary.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMigration13072023 : Migration
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
                    ArchiwalniPilkarzeIdPilkarz = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KlubPilkarz", x => new { x.ArchiwalneKlubyIdKlub, x.ArchiwalniPilkarzeIdPilkarz });
                    table.ForeignKey(
                        name: "FK_KlubPilkarz_Kluby_ArchiwalneKlubyIdKlub",
                        column: x => x.ArchiwalneKlubyIdKlub,
                        principalTable: "Kluby",
                        principalColumn: "IdKlub",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KlubPilkarz_Pilkarze_ArchiwalniPilkarzeIdPilkarz",
                        column: x => x.ArchiwalniPilkarzeIdPilkarz,
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
                values: new object[] { new Guid("69e5b988-64a8-463e-a79f-a887186e7133"), "Real Madryt", "Estadio Santiago Bernabéu", "Liga Mistrzów (13 razy), Primera División (34 razy), Puchar Króla (19 razy), Superpuchar Hiszpanii (11 razy)" });

            migrationBuilder.InsertData(
                table: "Pracownicy",
                columns: new[] { "IdPracownik", "IdZarzadu", "Imie", "Nazwisko", "PESEL", "Wiek", "WykonywanaFunkcja", "Wynagrodzenie" },
                values: new object[,]
                {
                    { new Guid("21dc9cf5-97a2-4c13-be18-905c70fd9249"), null, "Stanisław", "Kluczewski", "45423402949", 23, "", 5000000m },
                    { new Guid("f9a87cd8-b08e-4208-a01b-aab2737f2d21"), null, "Mateusz", "Kostyra", "780124500909", 23, "", 10000000m }
                });

            migrationBuilder.InsertData(
                table: "Pilkarze",
                columns: new[] { "IdPilkarz", "IdKlubu", "Imie", "Nazwisko", "Pozycja", "Wiek", "Wynagrodzenie" },
                values: new object[,]
                {
                    { new Guid("118390b9-cd9d-4ffe-9c2e-6b746016eb4f"), new Guid("69e5b988-64a8-463e-a79f-a887186e7133"), "Karim", "Benzema", "Napastnik", 33, 450000m },
                    { new Guid("1a74fc12-a7b4-4b83-bd74-6af2a1991bbd"), new Guid("69e5b988-64a8-463e-a79f-a887186e7133"), "Toni", "Kroos", "Pomocnik", 31, 320000m },
                    { new Guid("2d868922-95b0-4b37-8cf2-852a036f7dd3"), new Guid("69e5b988-64a8-463e-a79f-a887186e7133"), "Vinicius", "Junior", "Napastnik", 21, 180000m },
                    { new Guid("2da34696-0b0c-40bf-8297-0ee2c237b171"), new Guid("69e5b988-64a8-463e-a79f-a887186e7133"), "Thibaut", "Courtois", "Bramkarz", 29, 350000m },
                    { new Guid("876922e3-f0c1-4955-b61a-683614df94d9"), new Guid("69e5b988-64a8-463e-a79f-a887186e7133"), "Raphael", "Varane", "Obrońca", 28, 300000m },
                    { new Guid("8bc7eed6-3989-421b-b3d3-2ba1c726abe7"), new Guid("69e5b988-64a8-463e-a79f-a887186e7133"), "Carlos Henrique", "Casimiro", "Pomocnik", 29, 280000m },
                    { new Guid("a0bfb11d-de5a-415b-b997-0f475aef3410"), new Guid("69e5b988-64a8-463e-a79f-a887186e7133"), "Luka", "Modrić", "Pomocnik", 35, 350000m },
                    { new Guid("dbc2a5b4-502f-4432-884c-d5eefd2215ea"), new Guid("69e5b988-64a8-463e-a79f-a887186e7133"), "Dani", "Carvajal", "Obrońca", 29, 250000m },
                    { new Guid("e8aab1ed-4154-4d80-8508-30938b0d0ac7"), new Guid("69e5b988-64a8-463e-a79f-a887186e7133"), "Marco", "Asensio", "Pomocnik", 25, 240000m },
                    { new Guid("e937a556-bb5d-451c-a7da-6892d6689fde"), new Guid("69e5b988-64a8-463e-a79f-a887186e7133"), "Ferland", "Mendy", "Obrońca", 26, 220000m },
                    { new Guid("ebbaa349-d2db-4974-a746-8bbd0cbfa72c"), new Guid("69e5b988-64a8-463e-a79f-a887186e7133"), "Eder", "Militao", "Obrońca", 23, 200000m }
                });

            migrationBuilder.InsertData(
                table: "Zarzady",
                columns: new[] { "IdZarzad", "Budzet", "Cele", "IdKlubu" },
                values: new object[] { new Guid("e8932636-9a42-4a88-a723-91d22a143688"), 2500000m, "Liga Mistrzów, Superpuchar Hiszpanii, Naprawa murawy, Renowacja krzesełek, Nowy młody napastnik", new Guid("69e5b988-64a8-463e-a79f-a887186e7133") });

            migrationBuilder.InsertData(
                table: "Pracownicy",
                columns: new[] { "IdPracownik", "IdZarzadu", "Imie", "Nazwisko", "PESEL", "Wiek", "WykonywanaFunkcja", "Wynagrodzenie" },
                values: new object[,]
                {
                    { new Guid("3537f55c-5364-4755-bdd7-63414616e1e6"), new Guid("e8932636-9a42-4a88-a723-91d22a143688"), "Juni", "Calafat", "90123400909", 50, "Szef skautingu", 200000m },
                    { new Guid("5a2e7acb-87d9-49ed-8106-154dadeaa880"), new Guid("e8932636-9a42-4a88-a723-91d22a143688"), "Iker", "Casillas", "89012300808", 42, "Wice-prezes zarządu", 200000m },
                    { new Guid("7d341121-ca99-4279-af65-d0cb6bb0087b"), new Guid("e8932636-9a42-4a88-a723-91d22a143688"), "Davide", "Ancelotti", "34567800303", 33, "Asystent trenera", 300000m },
                    { new Guid("a095a065-753e-4fc7-8920-3f501d0c5541"), new Guid("e8932636-9a42-4a88-a723-91d22a143688"), "Antonio", "Pintus", "67890100606", 60, "Trener przygotowania fizycznego", 125000m },
                    { new Guid("a62be811-a336-42d3-b765-0fe66854ec19"), new Guid("e8932636-9a42-4a88-a723-91d22a143688"), "Simone", "Montanaro", "78901200707", 51, "Trener analityk", 140000m },
                    { new Guid("ba24b49b-23ab-4d5a-9b34-1384ca464055"), new Guid("e8932636-9a42-4a88-a723-91d22a143688"), "Fiorentino", "Perez", "12345600101", 77, "Prezes", 420000m },
                    { new Guid("bc940a4c-4246-47ab-b8b1-68a8258134ce"), new Guid("e8932636-9a42-4a88-a723-91d22a143688"), "Javier", "Mallo", "56789000505", 46, "Trener przygotowania fizycznego", 1250000m },
                    { new Guid("d21c4a5e-fde8-43f7-93ca-31dc4c1d4e7b"), new Guid("e8932636-9a42-4a88-a723-91d22a143688"), "Luis", "Llopis", "45678900404", 58, "Trener Bramkarzy", 150000m },
                    { new Guid("e9483534-398d-445e-9864-76eeb496e3c5"), new Guid("e8932636-9a42-4a88-a723-91d22a143688"), "Carlo", "Ancelotti", "23456700202", 64, "Trener", 350000m }
                });

            migrationBuilder.InsertData(
                table: "Statystki",
                columns: new[] { "IdStatystyka", "Asysty", "CzerwoneKartki", "Gole", "IdPilkarz", "Mecz", "Ocena", "PrzebiegnietyDystans", "ZolteKartki" },
                values: new object[,]
                {
                    { new Guid("2c8d31c3-2247-4cd0-ad75-e1b0a1d5304c"), 1, 0, 1, new Guid("118390b9-cd9d-4ffe-9c2e-6b746016eb4f"), "Real Madrid vs AC Milan", 8.3000000000000007, 9.4000000000000004, 0 },
                    { new Guid("358c2012-3793-40d0-8a2f-055091b49269"), 1, 0, 0, new Guid("e937a556-bb5d-451c-a7da-6892d6689fde"), "Real Madrid vs Tottenham", 7.7000000000000002, 8.8000000000000007, 2 },
                    { new Guid("36fd27ab-a9d4-467c-b3c4-ddbeca8f5e4f"), 0, 0, 1, new Guid("8bc7eed6-3989-421b-b3d3-2ba1c726abe7"), "Real Madrid vs Juventus", 7.5999999999999996, 8.3000000000000007, 1 },
                    { new Guid("38346b2a-697d-4bad-8642-3f4601fad59a"), 1, 0, 0, new Guid("e937a556-bb5d-451c-a7da-6892d6689fde"), "Real Madrid vs Liverpool", 7.9000000000000004, 8.5999999999999996, 2 },
                    { new Guid("41608104-3c88-4e4a-acc8-426dde65c245"), 1, 0, 0, new Guid("e937a556-bb5d-451c-a7da-6892d6689fde"), "Real Madrid vs Chelsea", 7.7999999999999998, 8.9000000000000004, 2 },
                    { new Guid("48920484-c8e2-4b90-8e1f-f1deab7ebc5a"), 1, 0, 0, new Guid("a0bfb11d-de5a-415b-b997-0f475aef3410"), "Real Madrid vs FC Barcelona", 7.5, 8.4000000000000004, 1 },
                    { new Guid("8810851a-c1e6-44c3-a2cc-c0e704b8cb4e"), 0, 0, 1, new Guid("e8aab1ed-4154-4d80-8508-30938b0d0ac7"), "Real Madrid vs Arsenal", 7.9000000000000004, 8.6999999999999993, 0 },
                    { new Guid("9c59f9e0-51cd-4735-aeca-69240a615e18"), 0, 0, 0, new Guid("8bc7eed6-3989-421b-b3d3-2ba1c726abe7"), "Real Madrid vs Bayern Monachium", 7.2999999999999998, 8.1999999999999993, 1 },
                    { new Guid("c1e61d8e-cc17-4dfa-aacd-ac8b4125c2e8"), 1, 0, 1, new Guid("118390b9-cd9d-4ffe-9c2e-6b746016eb4f"), "Real Madrid vs Sevilla", 8.0, 9.0999999999999996, 0 },
                    { new Guid("cd0946b3-cd2c-4ccc-986a-d7b79d7bb418"), 0, 0, 1, new Guid("8bc7eed6-3989-421b-b3d3-2ba1c726abe7"), "Real Madrid vs Inter Milan", 7.7999999999999998, 8.5, 1 },
                    { new Guid("d2158caa-2a28-4771-b435-b076296bcef2"), 0, 0, 1, new Guid("118390b9-cd9d-4ffe-9c2e-6b746016eb4f"), "Real Madrid vs Atletico Madrid", 8.0999999999999996, 9.1999999999999993, 0 },
                    { new Guid("d83b6e83-c96a-4a52-993d-30e41ae4ebfe"), 0, 0, 2, new Guid("a0bfb11d-de5a-415b-b997-0f475aef3410"), "Real Madrid vs Valencia", 8.1999999999999993, 8.5, 1 },
                    { new Guid("ead3b68d-8278-4a10-94a0-28d92eac1ea3"), 2, 0, 1, new Guid("e8aab1ed-4154-4d80-8508-30938b0d0ac7"), "Real Madrid vs PSG", 8.6999999999999993, 9.8000000000000007, 0 },
                    { new Guid("f3b603e2-6e4a-4d57-bce8-3394985b3b28"), 2, 0, 0, new Guid("a0bfb11d-de5a-415b-b997-0f475aef3410"), "Real Madrid vs Manchester City", 8.5999999999999996, 9.5999999999999996, 1 },
                    { new Guid("f5558643-195b-4e51-9739-8dbabbc74c6f"), 2, 0, 1, new Guid("e8aab1ed-4154-4d80-8508-30938b0d0ac7"), "Real Madrid vs Atalanta", 8.5, 9.6999999999999993, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_KlubPilkarz_ArchiwalniPilkarzeIdPilkarz",
                table: "KlubPilkarz",
                column: "ArchiwalniPilkarzeIdPilkarz");

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
