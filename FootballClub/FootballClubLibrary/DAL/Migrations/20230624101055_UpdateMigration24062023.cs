using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FootballClubLibrary.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMigration24062023 : Migration
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
                    { new Guid("3bad4552-ed17-45ad-b7e1-efdc4bacca9a"), "FC Barcelona", "Camp Nou", "Liga Mistrzów (5 razy), Primera División (26 razy), Puchar Króla (31 razy), Superpuchar Hiszpanii (13 razy)" },
                    { new Guid("5f719cd7-19c9-45cb-b6f0-c78882a81a23"), "Juventus", "Allianz Stadium", "Liga Mistrzów (2 razy), Serie A (36 razy), Puchar Włoch (14 razy), Superpuchar Włoch (9 razy)" },
                    { new Guid("93aef9fc-6263-4bd6-8d03-25f783298d4c"), "Real Madryt", "Estadio Santiago Bernabéu", "Liga Mistrzów (13 razy), Primera División (34 razy), Puchar Króla (19 razy), Superpuchar Hiszpanii (11 razy)" }
                });

            migrationBuilder.InsertData(
                table: "Pilkarze",
                columns: new[] { "IdPilkarz", "IdKlubu", "Imie", "Nazwisko", "Pozycja", "Wiek", "Wynagrodzenie" },
                values: new object[,]
                {
                    { new Guid("23fad9ad-3f30-476d-9385-61beade997e4"), new Guid("93aef9fc-6263-4bd6-8d03-25f783298d4c"), "Luka", "Modrić", "Pomocnik", 35, 350000m },
                    { new Guid("243c318a-ef37-4cc4-922f-32fe35877921"), new Guid("93aef9fc-6263-4bd6-8d03-25f783298d4c"), "Carlos Henrique", "Casimiro", "Pomocnik", 29, 280000m },
                    { new Guid("4b36ff41-13a3-4863-921e-848f68200f93"), new Guid("93aef9fc-6263-4bd6-8d03-25f783298d4c"), "Karim", "Benzema", "Napastnik", 33, 450000m },
                    { new Guid("5e569d43-8919-4133-ba4d-6c809ff257a7"), new Guid("93aef9fc-6263-4bd6-8d03-25f783298d4c"), "Vinicius", "Junior", "Napastnik", 21, 180000m },
                    { new Guid("66dc3b6a-6457-4713-b803-f0c3037570fd"), new Guid("93aef9fc-6263-4bd6-8d03-25f783298d4c"), "Marco", "Asensio", "Pomocnik", 25, 240000m },
                    { new Guid("79d4458a-909d-418b-aa28-c718e39362dd"), new Guid("93aef9fc-6263-4bd6-8d03-25f783298d4c"), "Thibaut", "Courtois", "Bramkarz", 29, 350000m },
                    { new Guid("7df92ca1-32ff-41ad-8de4-5572a16f169b"), new Guid("93aef9fc-6263-4bd6-8d03-25f783298d4c"), "Ferland", "Mendy", "Obrońca", 26, 220000m },
                    { new Guid("94dc432f-2df7-4569-ad14-247149913d3c"), new Guid("93aef9fc-6263-4bd6-8d03-25f783298d4c"), "Raphael", "Varane", "Obrońca", 28, 300000m },
                    { new Guid("c99d07b2-b064-4f99-927e-c75892e89322"), new Guid("93aef9fc-6263-4bd6-8d03-25f783298d4c"), "Dani", "Carvajal", "Obrońca", 29, 250000m },
                    { new Guid("e4d51f0a-bc05-4386-8f80-f7c1ea2cc06c"), new Guid("93aef9fc-6263-4bd6-8d03-25f783298d4c"), "Toni", "Kroos", "Pomocnik", 31, 320000m },
                    { new Guid("ef335694-b7aa-40ce-b9d7-f7450cf03fe7"), new Guid("93aef9fc-6263-4bd6-8d03-25f783298d4c"), "Eder", "Militao", "Obrońca", 23, 200000m }
                });

            migrationBuilder.InsertData(
                table: "Zarzady",
                columns: new[] { "IdZarzad", "Budzet", "Cele", "IdKlubu" },
                values: new object[,]
                {
                    { new Guid("31f70c25-a087-446f-90c3-518b6f72f0cf"), 1800000m, "Liga Mistrzów, Serie A, Puchar Włoch, Akademia młodzieżowa, Rozwój infrastruktury", new Guid("5f719cd7-19c9-45cb-b6f0-c78882a81a23") },
                    { new Guid("937da978-a2a5-481c-9df4-5bc4db79d052"), 2500000m, "Liga Mistrzów, Superpuchar Hiszpanii, Naprawa murawy, Renowacja krzesełek, Nowy młody napastnik", new Guid("93aef9fc-6263-4bd6-8d03-25f783298d4c") },
                    { new Guid("cc967b17-a571-4c4a-82c7-9f279f25409e"), 2000000m, "Liga Mistrzów, Primera División, Puchar Króla, Odnowienie akademii młodzieżowej, Wzmocnienie składu", new Guid("3bad4552-ed17-45ad-b7e1-efdc4bacca9a") }
                });

            migrationBuilder.InsertData(
                table: "Pracownicy",
                columns: new[] { "IdPracownik", "IdZarzadu", "Imie", "Nazwisko", "PESEL", "Wiek", "WykonywanaFunkcja", "Wynagrodzenie" },
                values: new object[,]
                {
                    { new Guid("452b528e-a715-4a96-a174-477234c7644b"), new Guid("937da978-a2a5-481c-9df4-5bc4db79d052"), "Iker", "Casillas", "89012300808", 42, "Wice-prezes zarządu", 200000m },
                    { new Guid("5ee22d1c-0087-413f-a0e3-d041448dda33"), new Guid("937da978-a2a5-481c-9df4-5bc4db79d052"), "Carlo", "Ancelotti", "23456700202", 64, "Trener", 350000m },
                    { new Guid("727c0eba-84b7-486f-8d9d-31dac844f033"), new Guid("937da978-a2a5-481c-9df4-5bc4db79d052"), "Juni", "Calafat", "90123400909", 50, "Szef skautingu", 200000m },
                    { new Guid("9e6ba0fe-5dcb-4337-840b-0b28b42e6ad1"), new Guid("937da978-a2a5-481c-9df4-5bc4db79d052"), "Davide", "Ancelotti", "34567800303", 33, "Asystent trenera", 300000m },
                    { new Guid("be8a9a05-42a9-422b-8b8f-e4f33c664f5e"), new Guid("937da978-a2a5-481c-9df4-5bc4db79d052"), "Simone", "Montanaro", "78901200707", 51, "Trener analityk", 140000m },
                    { new Guid("e75399cf-3349-4a04-b8f4-0b85b82893f5"), new Guid("937da978-a2a5-481c-9df4-5bc4db79d052"), "Antonio", "Pintus", "67890100606", 60, "Trener przygotowania fizycznego", 125000m },
                    { new Guid("ee72c56f-773a-4ec8-a78b-1133cb71f916"), new Guid("937da978-a2a5-481c-9df4-5bc4db79d052"), "Fiorentino", "Perez", "12345600101", 77, "Prezes", 420000m },
                    { new Guid("fc473cd9-54ee-4258-a536-1bcd2ac44375"), new Guid("937da978-a2a5-481c-9df4-5bc4db79d052"), "Luis", "Llopis", "45678900404", 58, "Trener Bramkarzy", 150000m },
                    { new Guid("ffccc730-c6df-4492-8653-3c3f8a1e49d0"), new Guid("937da978-a2a5-481c-9df4-5bc4db79d052"), "Javier", "Mallo", "56789000505", 46, "Trener przygotowania fizycznego", 1250000m }
                });

            migrationBuilder.InsertData(
                table: "Statystki",
                columns: new[] { "IdStatystyka", "Asysty", "CzerwoneKartki", "Gole", "IdPilkarz", "Mecz", "Ocena", "PrzebiegnietyDystans", "ZolteKartki" },
                values: new object[,]
                {
                    { new Guid("0d444821-0b14-48f1-8c44-056696203c13"), 1, 0, 1, new Guid("4b36ff41-13a3-4863-921e-848f68200f93"), "Real Madrid vs AC Milan", 8.3000000000000007, 9.4000000000000004, 0 },
                    { new Guid("30191131-c5d6-4b1b-b3e1-bc26442b9075"), 0, 0, 1, new Guid("66dc3b6a-6457-4713-b803-f0c3037570fd"), "Real Madrid vs Arsenal", 7.9000000000000004, 8.6999999999999993, 0 },
                    { new Guid("4718a420-14a3-4a63-b0e7-ff1395006405"), 1, 0, 0, new Guid("23fad9ad-3f30-476d-9385-61beade997e4"), "Real Madrid vs FC Barcelona", 7.5, 8.4000000000000004, 1 },
                    { new Guid("4c677113-7f0f-4fea-b98b-2fd4ce40c6dc"), 1, 0, 0, new Guid("7df92ca1-32ff-41ad-8de4-5572a16f169b"), "Real Madrid vs Chelsea", 7.7999999999999998, 8.9000000000000004, 2 },
                    { new Guid("894eabde-b0d6-420f-aeea-d30be8c20316"), 2, 0, 1, new Guid("66dc3b6a-6457-4713-b803-f0c3037570fd"), "Real Madrid vs PSG", 8.6999999999999993, 9.8000000000000007, 0 },
                    { new Guid("8a56e3c8-5601-4faa-9a56-dfde8c813539"), 2, 0, 1, new Guid("66dc3b6a-6457-4713-b803-f0c3037570fd"), "Real Madrid vs Atalanta", 8.5, 9.6999999999999993, 0 },
                    { new Guid("8c19a1b6-7802-4e9f-91b5-10be6d847a58"), 0, 0, 1, new Guid("243c318a-ef37-4cc4-922f-32fe35877921"), "Real Madrid vs Inter Milan", 7.7999999999999998, 8.5, 1 },
                    { new Guid("a42299b8-ce76-44c5-bb4c-1450c8b42d03"), 2, 0, 0, new Guid("23fad9ad-3f30-476d-9385-61beade997e4"), "Real Madrid vs Manchester City", 8.5999999999999996, 9.5999999999999996, 1 },
                    { new Guid("adeeb94f-7f37-4f11-9926-c594a2827b86"), 0, 0, 2, new Guid("23fad9ad-3f30-476d-9385-61beade997e4"), "Real Madrid vs Valencia", 8.1999999999999993, 8.5, 1 },
                    { new Guid("b2a581bf-bd39-4686-ae06-3f8ca857a67a"), 1, 0, 0, new Guid("7df92ca1-32ff-41ad-8de4-5572a16f169b"), "Real Madrid vs Liverpool", 7.9000000000000004, 8.5999999999999996, 2 },
                    { new Guid("b94bf4ab-751c-4ea7-8e6e-9f9ce51b4071"), 1, 0, 1, new Guid("4b36ff41-13a3-4863-921e-848f68200f93"), "Real Madrid vs Sevilla", 8.0, 9.0999999999999996, 0 },
                    { new Guid("c6a650e1-e02c-4c32-ba55-bbfd076ce4b6"), 0, 0, 1, new Guid("243c318a-ef37-4cc4-922f-32fe35877921"), "Real Madrid vs Juventus", 7.5999999999999996, 8.3000000000000007, 1 },
                    { new Guid("dbb3ebd0-6cc7-4d55-b581-c42ed90235c9"), 0, 0, 1, new Guid("4b36ff41-13a3-4863-921e-848f68200f93"), "Real Madrid vs Atletico Madrid", 8.0999999999999996, 9.1999999999999993, 0 },
                    { new Guid("eb3a31e0-f319-4058-8fda-5b65904eb439"), 1, 0, 0, new Guid("7df92ca1-32ff-41ad-8de4-5572a16f169b"), "Real Madrid vs Tottenham", 7.7000000000000002, 8.8000000000000007, 2 },
                    { new Guid("fc30d473-1f15-49e1-bffa-649ec1fefdfb"), 0, 0, 0, new Guid("243c318a-ef37-4cc4-922f-32fe35877921"), "Real Madrid vs Bayern Monachium", 7.2999999999999998, 8.1999999999999993, 1 }
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
