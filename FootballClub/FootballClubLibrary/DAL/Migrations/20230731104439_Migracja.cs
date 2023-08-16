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
                    Nazwa = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
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
                values: new object[,]
                {
                    { new Guid("06118cdc-d28d-4e9a-86ad-1fa14418505a"), "Real Madryt", "Estadio Santiago Bernabéu", "Liga Mistrzów (13 razy), Primera División (34 razy), Puchar Króla (19 razy), Superpuchar Hiszpanii (11 razy)" },
                    { new Guid("fa5f539a-fa36-4a2d-9acd-bf571bf79431"), "Real Madrid Castilla CF", "Estadio Alfredo Di Stéfano", "Segunda División (1 raz), Segunda División B (5 razy), Tercera División (6 razy), Trofeo Teide (3 razy), Torneo de San Ginés (2 razy)" }
                });

            migrationBuilder.InsertData(
                table: "Pilkarze",
                columns: new[] { "IdPilkarz", "IdKlubu", "Imie", "Nazwisko", "Pozycja", "Wiek", "Wynagrodzenie" },
                values: new object[,]
                {
                    { new Guid("08a94f13-1330-4572-a8de-70b5baba5ee1"), new Guid("06118cdc-d28d-4e9a-86ad-1fa14418505a"), "Antonio", "Rüdiger", "Środkowy obrońca", 30, 195000m },
                    { new Guid("0ae1a8c5-effa-45a8-a871-cb93f0f3b558"), new Guid("06118cdc-d28d-4e9a-86ad-1fa14418505a"), "Aurélien", "Tchouaméni", "Środkowy pomocnik", 23, 236000m },
                    { new Guid("12531077-74b6-4b6c-9e3d-dd5aa0105b6a"), new Guid("06118cdc-d28d-4e9a-86ad-1fa14418505a"), "Vinicius", "Junior", "Lewy skrzydłowy", 21, 420000m },
                    { new Guid("12828e66-4716-4003-9bd2-61160f39341f"), new Guid("fa5f539a-fa36-4a2d-9acd-bf571bf79431"), "Mario", "Martín", "Środkowy pomocnik", 19, 200000m },
                    { new Guid("21e93bb3-35fd-4749-b756-bf2c62a0aeab"), new Guid("fa5f539a-fa36-4a2d-9acd-bf571bf79431"), "Mario", "De Luis", "Bramkarz", 21, 200000m },
                    { new Guid("234966ff-d6c7-4bee-bef2-44c2ef59ed55"), new Guid("fa5f539a-fa36-4a2d-9acd-bf571bf79431"), "Theo", "Fernández", "Środkowy pomocnik", 21, 200000m },
                    { new Guid("369137df-ec0c-40f4-9de9-9bbb5ee1266b"), new Guid("fa5f539a-fa36-4a2d-9acd-bf571bf79431"), "Lucas", "Alcázar", "Środkowy obrońca", 21, 200000m },
                    { new Guid("373ba1e1-4d2d-46f9-b676-c68a7b2328b2"), new Guid("06118cdc-d28d-4e9a-86ad-1fa14418505a"), "Dani", "Carvajal", "Prawy obrońca", 29, 250000m },
                    { new Guid("3bca1526-848e-45bc-b015-ebe3c224a046"), new Guid("06118cdc-d28d-4e9a-86ad-1fa14418505a"), "Brahim", "Díaz", "Prawy skrzydłowy", 23, 200000m },
                    { new Guid("448d3808-308b-4cd3-9a3c-d9b890343cdb"), new Guid("06118cdc-d28d-4e9a-86ad-1fa14418505a"), "Eder", "Militao", "Środkowy obrońca", 23, 230000m },
                    { new Guid("45384d63-037c-4dcb-b2cb-58ac49ee372e"), new Guid("06118cdc-d28d-4e9a-86ad-1fa14418505a"), "Nacho", "Fernández", "Środkowy obrońca", 33, 240000m },
                    { new Guid("479a6a94-899e-4642-899d-d52882c9167b"), new Guid("fa5f539a-fa36-4a2d-9acd-bf571bf79431"), "Vinicius", "Tobias", "Prawy obrońca", 19, 200000m },
                    { new Guid("4f3d8210-c7a0-428d-924e-68b9bda84889"), new Guid("06118cdc-d28d-4e9a-86ad-1fa14418505a"), "Arda", "Güler", "Ofensywny pomocnik", 18, 140000m },
                    { new Guid("528d6659-d033-4493-8a54-19cab8c8b495"), new Guid("06118cdc-d28d-4e9a-86ad-1fa14418505a"), "Eduardo", "Camavinga", "Środkowy pomocnik", 20, 235000m },
                    { new Guid("52e52b9b-9e3a-49e2-8bda-0fa603b433f6"), new Guid("fa5f539a-fa36-4a2d-9acd-bf571bf79431"), "Álvaro", "Carrillo", "Środkowy obrońca", 21, 200000m },
                    { new Guid("5ea30d5c-fe56-4870-a29f-f07a4d129704"), new Guid("fa5f539a-fa36-4a2d-9acd-bf571bf79431"), "Javier", "Villar", "Środkowy pomocnik", 20, 200000m },
                    { new Guid("6b43c9b9-4319-4eef-afed-b51cdddf704d"), new Guid("06118cdc-d28d-4e9a-86ad-1fa14418505a"), "David", "Alaba", "Środkowy obrońca", 31, 200000m },
                    { new Guid("7137ea48-1eaf-4694-a05e-d2f44db8d86b"), new Guid("06118cdc-d28d-4e9a-86ad-1fa14418505a"), "Luka", "Modrić", "Środkowy pomocnik", 37, 270000m },
                    { new Guid("7d8f4687-b94e-41c8-8f56-1223a842b059"), new Guid("06118cdc-d28d-4e9a-86ad-1fa14418505a"), "Federico", "Valverde", "Środkowy pomocnik", 25, 255000m },
                    { new Guid("80fb75e7-e8e7-454f-83b2-565332810614"), new Guid("fa5f539a-fa36-4a2d-9acd-bf571bf79431"), "Lucas", "Cañizares", "Bramkarz", 21, 200000m },
                    { new Guid("8ce35861-751a-4e3f-a291-c7107806c6e7"), new Guid("fa5f539a-fa36-4a2d-9acd-bf571bf79431"), "Noel", "López", "Środkowy napastnik", 20, 200000m },
                    { new Guid("9ab4c31d-93bf-41a1-b4cc-89affe90047d"), new Guid("06118cdc-d28d-4e9a-86ad-1fa14418505a"), "Joselu", "Luís Sanmartín Mato", "Środkowy napastnik", 33, 150000m },
                    { new Guid("9abee86c-869d-48e9-9e38-b9e9416ad399"), new Guid("06118cdc-d28d-4e9a-86ad-1fa14418505a"), "Jude", "Bellingham", "Środkowy pomocnik", 20, 360000m },
                    { new Guid("9c58220f-1996-48d7-aa65-7ac122c19ee8"), new Guid("fa5f539a-fa36-4a2d-9acd-bf571bf79431"), "Marvelous", "Garzón", "Środkowy obrońca", 20, 200000m },
                    { new Guid("a6fec0c2-5db8-4977-b8c9-b1068306c8a7"), new Guid("fa5f539a-fa36-4a2d-9acd-bf571bf79431"), "Takuhiro", "Nakai", "Środkowy pomocnik", 19, 200000m },
                    { new Guid("a93c40c3-c098-4fa9-80ee-5d034df07ce1"), new Guid("fa5f539a-fa36-4a2d-9acd-bf571bf79431"), "Álvaro", "Martín", "Środkowy pomocnik", 22, 200000m },
                    { new Guid("a9e8b71c-4890-4abf-a4fe-74aa5b993c1f"), new Guid("06118cdc-d28d-4e9a-86ad-1fa14418505a"), "Lucas", "Vázquez", "Prawy obrońca", 32, 265000m },
                    { new Guid("b059a572-6467-4697-abc7-07ca625ad0ad"), new Guid("fa5f539a-fa36-4a2d-9acd-bf571bf79431"), "Peter", "González", "Środkowy pomocnik", 21, 200000m },
                    { new Guid("b1157463-d91d-4ee5-be62-3ba0338e179c"), new Guid("06118cdc-d28d-4e9a-86ad-1fa14418505a"), "Toni", "Kroos", "Środkowy pomocnik", 33, 250000m },
                    { new Guid("b6853ab3-8d00-4e31-8a71-575151b0a245"), new Guid("06118cdc-d28d-4e9a-86ad-1fa14418505a"), "Álvaro", "Odriozola", "Prawy obrońca", 27, 160000m },
                    { new Guid("c3a3bd84-21e2-4dd0-b042-291f6ba42bd8"), new Guid("fa5f539a-fa36-4a2d-9acd-bf571bf79431"), "Pablo", "Ramón", "Środkowy obrońca", 22, 200000m },
                    { new Guid("ca98ab15-66ec-4899-b736-38a7868ac98e"), new Guid("06118cdc-d28d-4e9a-86ad-1fa14418505a"), "Fran", "García", "Lewy obrońca", 23, 170000m },
                    { new Guid("cdd9b537-56e6-4434-9f4d-f4c347c6b9c7"), new Guid("06118cdc-d28d-4e9a-86ad-1fa14418505a"), "Rodrygo", "Goes", "Prawy krzydłowy", 22, 195000m },
                    { new Guid("cf0c7602-19d0-4bfa-b96b-4c9312804550"), new Guid("06118cdc-d28d-4e9a-86ad-1fa14418505a"), "Daniel", "Ceballos", "Środkowy pomocnik", 26, 175000m },
                    { new Guid("d0fecd05-3bdc-4288-80b5-c6df1c9ece4d"), new Guid("06118cdc-d28d-4e9a-86ad-1fa14418505a"), "Thibaut", "Courtois", "Bramkarz", 29, 350000m },
                    { new Guid("d413b5e5-46a9-4465-aa12-2dafc9833a5c"), new Guid("fa5f539a-fa36-4a2d-9acd-bf571bf79431"), "Carlos", "Dotor", "Środkowy pomocnik", 22, 200000m },
                    { new Guid("d6bac47b-fb29-4e0d-a3bd-eda79a3248a2"), new Guid("06118cdc-d28d-4e9a-86ad-1fa14418505a"), "Ferland", "Mendy", "Lewy obrońca", 26, 245000m },
                    { new Guid("d87dd3fe-dab3-40f9-bc3e-c946016b50e0"), new Guid("fa5f539a-fa36-4a2d-9acd-bf571bf79431"), "Rafael", "Llorente", "Środkowy pomocnik", 20, 200000m },
                    { new Guid("dc57befc-1bdb-4a9f-a83e-b1f5cdadf060"), new Guid("fa5f539a-fa36-4a2d-9acd-bf571bf79431"), "Iker", "Bravo", "Środkowy napastnik", 18, 200000m },
                    { new Guid("dcb78893-ffa9-4edd-a8b7-d7d3d3ce03dc"), new Guid("06118cdc-d28d-4e9a-86ad-1fa14418505a"), "Andrij", "Łunin", "Bramkarz", 24, 150000m },
                    { new Guid("ec1214f0-b7cf-4de7-b454-942167fa24e5"), new Guid("fa5f539a-fa36-4a2d-9acd-bf571bf79431"), "Álvaro", "Leiva", "Środkowy pomocnik", 18, 200000m },
                    { new Guid("ef1d8aff-a581-4438-a01b-83ba29ce27dd"), new Guid("fa5f539a-fa36-4a2d-9acd-bf571bf79431"), "Sergio", "Arribas", "Środkowy pomocnik", 21, 200000m },
                    { new Guid("f7c43299-8814-407d-8c8a-5742f91c180a"), new Guid("fa5f539a-fa36-4a2d-9acd-bf571bf79431"), "Óscar", "Aranda", "Środkowy pomocnik", 21, 200000m }
                });

            migrationBuilder.InsertData(
                table: "Zarzady",
                columns: new[] { "IdZarzad", "Budzet", "Cele", "IdKlubu" },
                values: new object[,]
                {
                    { new Guid("3d5b4638-64f5-487e-8e2a-96605beca028"), 1250000m, "Awans do Segunda División", new Guid("fa5f539a-fa36-4a2d-9acd-bf571bf79431") },
                    { new Guid("d8d6c710-69ae-4693-b117-26ce0655a5d4"), 2500000m, "Liga Mistrzów, Superpuchar Hiszpanii, Naprawa murawy, Renowacja krzesełek, Nowy młody napastnik", new Guid("06118cdc-d28d-4e9a-86ad-1fa14418505a") }
                });

            migrationBuilder.InsertData(
                table: "Pracownicy",
                columns: new[] { "IdPracownik", "IdZarzadu", "Imie", "Nazwisko", "PESEL", "Wiek", "WykonywanaFunkcja", "Wynagrodzenie" },
                values: new object[,]
                {
                    { new Guid("006e8e2d-caec-4fdc-9d30-ac989f1af296"), new Guid("3d5b4638-64f5-487e-8e2a-96605beca028"), "Alberto", "Garrido", "45098763201", 47, "Asystent trenera", 140000m },
                    { new Guid("0fc84b64-5d4e-40df-b6e7-588e211402c6"), new Guid("d8d6c710-69ae-4693-b117-26ce0655a5d4"), "Antonio", "Pintus", "67890100606", 60, "Szef od przygotowania fizycznego", 125000m },
                    { new Guid("10f86f2d-a19e-4fc4-a743-08a74f10e910"), new Guid("d8d6c710-69ae-4693-b117-26ce0655a5d4"), "Mino", "Fulco", "88501220767", 51, "Dietetyk", 140000m },
                    { new Guid("4527f08f-da5b-4e0c-ab04-563520ba3e57"), new Guid("3d5b4638-64f5-487e-8e2a-96605beca028"), "Javier", "de Tomás Maroto", "84501230769", 46, "Fizjoterapeuta", 75000m },
                    { new Guid("6bcbe20c-d0b6-4b9f-8880-7020b545cc9d"), new Guid("d8d6c710-69ae-4693-b117-26ce0655a5d4"), "Francesco", "Mauri", "87890400406", 34, "Fizjoterapeuta", 125000m },
                    { new Guid("6bfb6f89-0c81-40a1-b679-17514e6e5db3"), new Guid("d8d6c710-69ae-4693-b117-26ce0655a5d4"), "Carlo", "Ancelotti", "23456700202", 64, "Trener", 350000m },
                    { new Guid("6c655272-c116-4481-a969-14b2c9cd9eb3"), new Guid("d8d6c710-69ae-4693-b117-26ce0655a5d4"), "Simone", "Montanaro", "78901200707", 51, "Trener analityk", 140000m },
                    { new Guid("6fd39058-e486-4872-b435-51378a32bb7c"), new Guid("3d5b4638-64f5-487e-8e2a-96605beca028"), "Nacho", "S. García", "83456789021", 46, "Trener przygotowania fizycznego", 90000m },
                    { new Guid("7f59c79b-a1b5-4e58-954b-4a7e48632c5d"), new Guid("3d5b4638-64f5-487e-8e2a-96605beca028"), "Víctor", "P. Hernández", "79806543210", 45, "Trener przygotowania fizycznego", 90000m },
                    { new Guid("8e61238a-fadf-4867-a129-d5aee07a2de8"), new Guid("d8d6c710-69ae-4693-b117-26ce0655a5d4"), "Davide", "Ancelotti", "34567800303", 33, "Asystent trenera", 300000m },
                    { new Guid("b58e90bd-d68a-4b55-b57a-257d3e28d181"), new Guid("3d5b4638-64f5-487e-8e2a-96605beca028"), "Álvaro", "Tavira", "71234567890", 35, "Fizjoterapeuta", 75000m },
                    { new Guid("c971ed33-9ffc-4f6c-9ca7-a9e61c4be2fc"), new Guid("3d5b4638-64f5-487e-8e2a-96605beca028"), "Raúl", "González", "70631490286", 46, "Trener", 200000m },
                    { new Guid("d05ef1f3-45fb-469d-b618-ccccea7b0d10"), new Guid("3d5b4638-64f5-487e-8e2a-96605beca028"), "Tirso", "Álvarez", "89765432109", 40, "Fizjoterapeuta", 75000m },
                    { new Guid("dd7fd399-303f-460e-bf8f-a77464e8ac5a"), new Guid("d8d6c710-69ae-4693-b117-26ce0655a5d4"), "Fiorentino", "Perez", "12345600101", 77, "Prezes", 420000m },
                    { new Guid("fdd0b169-57b7-4dbe-92c1-4c5dc90a19c0"), new Guid("3d5b4638-64f5-487e-8e2a-96605beca028"), "Mario", "Soria Amor", "70123450789", 53, "Trener bramkarzy", 100000m }
                });

            migrationBuilder.InsertData(
                table: "Statystki",
                columns: new[] { "IdStatystyka", "Asysty", "CzerwoneKartki", "Gole", "IdPilkarz", "Mecz", "Ocena", "PrzebiegnietyDystans", "ZolteKartki" },
                values: new object[,]
                {
                    { new Guid("00b92a85-fe82-401f-bbe3-e83aab9d4b01"), 2, 0, 0, new Guid("6b43c9b9-4319-4eef-afed-b51cdddf704d"), "Real Madrid vs Paris Saint-Germain", 9.0999999999999996, 10.1, 0 },
                    { new Guid("2163889d-1253-413b-8ece-35be30daca55"), 0, 0, 1, new Guid("9ab4c31d-93bf-41a1-b4cc-89affe90047d"), "Real Madrid vs Napoli", 7.5999999999999996, 8.1999999999999993, 0 },
                    { new Guid("22ebc38a-4e8e-45e2-b67f-612a997e1d13"), 1, 0, 1, new Guid("b059a572-6467-4697-abc7-07ca625ad0ad"), "Real Madrid Castilla vs CD Badajoz", 8.5999999999999996, 8.1999999999999993, 1 },
                    { new Guid("269ecb10-4782-4fc2-8153-4b20eed2bb2b"), 1, 0, 0, new Guid("3bca1526-848e-45bc-b015-ebe3c224a046"), "Real Madrid vs Ajax", 8.4000000000000004, 9.3000000000000007, 0 },
                    { new Guid("2a0b018b-cc1a-4919-a5d4-ef1c0d21b6c2"), 1, 0, 0, new Guid("d6bac47b-fb29-4e0d-a3bd-eda79a3248a2"), "Real Madrid vs Chelsea", 7.7999999999999998, 8.9000000000000004, 2 },
                    { new Guid("2bedbc0f-1966-48ab-825b-e4c5cf0ca9fd"), 1, 0, 0, new Guid("7137ea48-1eaf-4694-a05e-d2f44db8d86b"), "Real Madrid vs FC Barcelona", 7.5, 8.4000000000000004, 1 },
                    { new Guid("2e3a75c5-6f1b-4499-8ae5-88f9ba36fe0e"), 0, 0, 0, new Guid("9c58220f-1996-48d7-aa65-7ac122c19ee8"), "Real Madrid Castilla vs Rayo Vallecano B", 7.7000000000000002, 7.4000000000000004, 1 },
                    { new Guid("340817fe-e202-4e17-bacc-491f4dc43f3e"), 0, 1, 0, new Guid("4f3d8210-c7a0-428d-924e-68b9bda84889"), "Real Madrid vs Galatasaray", 6.5, 7.7999999999999998, 2 },
                    { new Guid("39297dad-5f17-455a-bee6-a7ce570bc34c"), 0, 0, 0, new Guid("d0fecd05-3bdc-4288-80b5-c6df1c9ece4d"), "Real Madrid vs Liverpool", 8.8000000000000007, 0.80000000000000004, 0 },
                    { new Guid("40b1f5ac-15da-4879-b663-bfb704010af0"), 1, 0, 1, new Guid("9abee86c-869d-48e9-9e38-b9e9416ad399"), "Real Madrid vs RB Leipzig", 8.9000000000000004, 9.9000000000000004, 1 },
                    { new Guid("40e3c95b-ff57-45e5-85a5-d5f81100add7"), 0, 0, 0, new Guid("c3a3bd84-21e2-4dd0-b042-291f6ba42bd8"), "Real Madrid Castilla vs Real Betis B", 8.0999999999999996, 7.7999999999999998, 0 },
                    { new Guid("6685a1c4-66cd-466b-a80b-add1cc7aeb8c"), 0, 0, 1, new Guid("479a6a94-899e-4642-899d-d52882c9167b"), "Real Madrid Castilla vs Atletico Madrid B", 8.4000000000000004, 8.0999999999999996, 0 },
                    { new Guid("715df8b3-8b63-46b5-8a7f-ffb1d265731c"), 2, 0, 0, new Guid("369137df-ec0c-40f4-9de9-9bbb5ee1266b"), "Real Madrid Castilla vs Getafe B", 8.5, 8.5, 0 },
                    { new Guid("773b4e5a-f207-471e-be5c-d5094c22fcb4"), 0, 0, 0, new Guid("dcb78893-ffa9-4edd-a8b7-d7d3d3ce03dc"), "Real Madrid vs Juventus", 8.1999999999999993, 0.40000000000000002, 0 },
                    { new Guid("8321714e-4805-46e2-aa1b-c681c1c5babf"), 1, 0, 0, new Guid("d6bac47b-fb29-4e0d-a3bd-eda79a3248a2"), "Real Madrid vs Tottenham", 7.7000000000000002, 8.8000000000000007, 2 },
                    { new Guid("857a7c5e-3778-4501-b8f7-0ef0cdf3bb80"), 1, 0, 0, new Guid("373ba1e1-4d2d-46f9-b676-c68a7b2328b2"), "Real Madrid vs Atletico Madrid", 8.5, 10.5, 1 },
                    { new Guid("85bb3d31-3560-43ef-baf1-eddf080dd02d"), 0, 0, 1, new Guid("234966ff-d6c7-4bee-bef2-44c2ef59ed55"), "Real Madrid Castilla vs Alcorcón B", 8.3000000000000007, 7.9000000000000004, 0 },
                    { new Guid("9b376466-0fdc-4656-9dff-a4a0972dc94d"), 3, 0, 0, new Guid("b1157463-d91d-4ee5-be62-3ba0338e179c"), "Real Madrid vs Sevilla", 9.0999999999999996, 10.699999999999999, 0 },
                    { new Guid("a85d1bf5-d0e3-44b6-89a0-afd29170e014"), 0, 0, 1, new Guid("448d3808-308b-4cd3-9a3c-d9b890343cdb"), "Real Madrid vs Bayern Munich", 8.9000000000000004, 9.6999999999999993, 0 },
                    { new Guid("b1c0c7c6-2a32-42db-b9cb-6b23873a2a9b"), 0, 0, 2, new Guid("7137ea48-1eaf-4694-a05e-d2f44db8d86b"), "Real Madrid vs Valencia", 8.1999999999999993, 8.5, 1 },
                    { new Guid("c02fd773-9d11-4fa0-898b-9aa8868ee4da"), 1, 0, 0, new Guid("52e52b9b-9e3a-49e2-8bda-0fa603b433f6"), "Real Madrid Castilla vs Sevilla Atletico", 7.9000000000000004, 7.5, 1 },
                    { new Guid("cdd4a260-0e21-4299-ac2c-d2a628556297"), 2, 0, 0, new Guid("7137ea48-1eaf-4694-a05e-d2f44db8d86b"), "Real Madrid vs Manchester City", 8.5999999999999996, 9.5999999999999996, 1 },
                    { new Guid("de3e80cc-b5c7-467f-9a5f-e474e9a2e07e"), 1, 0, 0, new Guid("d6bac47b-fb29-4e0d-a3bd-eda79a3248a2"), "Real Madrid vs Liverpool", 7.9000000000000004, 8.5999999999999996, 2 },
                    { new Guid("e832bd2f-757a-4b2f-ad35-b8568bbc09a7"), 1, 0, 0, new Guid("d413b5e5-46a9-4465-aa12-2dafc9833a5c"), "Real Madrid Castilla vs Huesca B", 8.0, 7.5999999999999996, 0 }
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
