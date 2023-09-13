using FootballClubLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Collections.ObjectModel;

namespace FootballClubLibrary.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Klub> Kluby { get; set; }
        public DbSet<Pilkarz> Pilkarze { get; set; }
        public DbSet<Pracownik> Pracownicy { get; set; }
        public DbSet<Statystyka> Statystyki { get; set; }
        public DbSet<Zarzad> Zarzady { get; set; }

        public ApplicationDbContext() : base() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FootballClub;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                optionsBuilder.UseSqlServer(connectionString);
                optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.NavigationBaseIncludeIgnored));
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // one to one
            modelBuilder.Entity<Klub>()
                .HasOne(k => k.Zarzad)
                .WithOne(k => k.Klub)
                .HasForeignKey<Zarzad>(k => k.IdKlubu)
                .OnDelete(DeleteBehavior.Cascade);


            // one to many
            modelBuilder.Entity<Pracownik>()
                .HasOne(p => p.Zarzad)
                .WithMany(p => p.Pracownicy)
                .HasForeignKey(p => p.IdZarzadu)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Statystyka>()
                .HasOne(s => s.Pilkarz)
                .WithMany(s => s.Statystyki)
                .HasForeignKey(s => s.IdPilkarz)
                .OnDelete(DeleteBehavior.Cascade);


            // football players have one current club
            modelBuilder.Entity<Pilkarz>()
                .HasOne(p => p.Klub)
                .WithMany(p => p.ObecniPilkarze)
                .HasForeignKey(p => p.IdKlubu)
                .OnDelete(DeleteBehavior.NoAction);


            // many to many 
            modelBuilder.Entity<Pilkarz>()
                .HasMany(p => p.ArchiwalneKluby)
                .WithMany(p => p.ArchiwalniPilkarze);


            // Klucze dla klubu
            var RealMadryt = Guid.NewGuid();
            var ZarzadRealMadryt = Guid.NewGuid();
            var RealMadrytCastilla = Guid.NewGuid();
            var ZarzadRealMadrytCastilla = Guid.NewGuid();
            var RealMadrytC = Guid.NewGuid();

            //Archiwalne kluby pilkarzy
            var AtleticoMadryt = Guid.NewGuid();
            var Chelsea = Guid.NewGuid();
            var BayerLeverkusen = Guid.NewGuid();
            var BayernMonachiumII = Guid.NewGuid();
            var BayernMonachium = Guid.NewGuid();
            var KRCGenk = Guid.NewGuid();
            var FKDnipro = Guid.NewGuid();
            var ZoriaŁugańsk = Guid.NewGuid();
            var FCSaoPaulo = Guid.NewGuid();
            var FCPorto = Guid.NewGuid();
            var AustriaWieden = Guid.NewGuid();
            var RealSociedadB = Guid.NewGuid();
            var RealSociedad = Guid.NewGuid();
            var RayoVallecano = Guid.NewGuid();
            var VfBStuttgartII = Guid.NewGuid();
            var VfBStuttgart = Guid.NewGuid();
            var ASRoma = Guid.NewGuid();
            var ACLeHavreB = Guid.NewGuid();
            var LeHavreAC = Guid.NewGuid();
            var BirminghamCity = Guid.NewGuid();
            var BorussiaDortmund = Guid.NewGuid();
            var DinamoZagrzeb = Guid.NewGuid();
            var Tottenham = Guid.NewGuid();
            var StadeRennaisFCB = Guid.NewGuid();
            var StadeRennais = Guid.NewGuid();
            var CAPenarol = Guid.NewGuid();
            var FCGirondinsBordeauxB = Guid.NewGuid();
            var FCGirondinsBordeaux = Guid.NewGuid();
            var ASMonaco = Guid.NewGuid();
            var RealBetis = Guid.NewGuid();
            var CRFlamengo = Guid.NewGuid();
            var SantosFC = Guid.NewGuid();
            var ManchesterCity = Guid.NewGuid();
            var Fenerbahce = Guid.NewGuid();
            var SportingCP = Guid.NewGuid();
            var FCBarcelona = Guid.NewGuid();
            var InterMilan = Guid.NewGuid();
            var ManchesterUnited = Guid.NewGuid();
            var Juventus = Guid.NewGuid();
            var AlNassr = Guid.NewGuid();
            var Liverpool = Guid.NewGuid();
            var FCSchalke = Guid.NewGuid();
            var AlSadd = Guid.NewGuid();
            var NewYorkCosmos = Guid.NewGuid();
            var ASCannes = Guid.NewGuid();
            var Emerytura = Guid.NewGuid();
            var Trener = Guid.NewGuid();


            //Klucze dla piłkarzy RealMadryt
            var ThibautCourtois = Guid.NewGuid();
            var AndrijLunin = Guid.NewGuid();
            var DaniCarvajal = Guid.NewGuid();
            var EderMilitao = Guid.NewGuid();
            var DavidAlaba = Guid.NewGuid();
            var NachoFernandez = Guid.NewGuid();
            var AlvaroOdriozola = Guid.NewGuid();
            var LucasVazquez = Guid.NewGuid();
            var FranGarcia = Guid.NewGuid();
            var AntonioRudiger = Guid.NewGuid();
            var FerlandMendy = Guid.NewGuid();
            var JudeBellingham = Guid.NewGuid();
            var ToniKroos = Guid.NewGuid();
            var LukaModric = Guid.NewGuid();
            var EduardoCamavinga = Guid.NewGuid();
            var FedericoValverde = Guid.NewGuid();
            var AurelienTchouameni = Guid.NewGuid();
            var DanielCeballos = Guid.NewGuid();
            var ArdaGuler = Guid.NewGuid();
            var ViniciusJunior = Guid.NewGuid();
            var RodrygoGoes = Guid.NewGuid();
            var Joselu = Guid.NewGuid();
            var BrahimDiaz = Guid.NewGuid();

            //Klucze dla piłkarzy RealMadrytCastilla
            var LucasCanizares = Guid.NewGuid();
            var MarioDeLuis = Guid.NewGuid();
            var ViniciusTobias = Guid.NewGuid();
            var AlvaroCarrillo = Guid.NewGuid();
            var PabloRamon = Guid.NewGuid();
            var LucasAlcazar = Guid.NewGuid();
            var MarvelousGarzon = Guid.NewGuid();
            var TheoFernandez = Guid.NewGuid();
            var CarlosDotor = Guid.NewGuid();
            var PeterGonzalez = Guid.NewGuid();
            var AlvaroMartin = Guid.NewGuid();
            var TakuhiroNakai = Guid.NewGuid();
            var AlvaroLeiva = Guid.NewGuid();
            var JavierVillar = Guid.NewGuid();
            var OscarAranda = Guid.NewGuid();
            var RafaelLlorente = Guid.NewGuid();
            var MarioMartin = Guid.NewGuid();
            var SergioArribas = Guid.NewGuid();
            var NoelLopez = Guid.NewGuid();
            var IkerBravo = Guid.NewGuid();

            //Klucze archiwalni piłkarze Real Madryt
            var LuísFigo = Guid.NewGuid();
            var IkerCasillas = Guid.NewGuid();
            var CristianoRonaldo = Guid.NewGuid();
            var XabiAlonso = Guid.NewGuid();
            var RaulGonzalez = Guid.NewGuid();
            var ZinedineZidane = Guid.NewGuid();


            // mock data
            modelBuilder.Entity<Klub>().HasData(
                new Klub() { IdKlub = RealMadryt, Nazwa = "Real Madryt", Stadion = "Estadio Santiago Bernabéu", Trofea = "Liga Mistrzów (13 razy), Primera División (34 razy), Puchar Króla (19 razy), Superpuchar Hiszpanii (11 razy)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = RealMadrytCastilla, Nazwa = "Real Madrid Castilla CF", Stadion = "Estadio Alfredo Di Stéfano", Trofea = "Segunda División (1 raz), Segunda División B (5 razy), Tercera División (6 razy), Trofeo Teide (3 razy), Torneo de San Ginés (2 razy)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                
                //Archiwalne kluby piłkarzy
                new Klub() { IdKlub = AtleticoMadryt, Nazwa = "Atlético Madryt", Stadion = "Civitas Metropolitano", Trofea = "Mistrz Hiszpanii (11), Superpuchar UEFA (3), Puchar Europy(3), Superpuchar Hiszpanii (2), Puchar Króla (Copa del Rey) (10), Superpuchar Hiszpanii (2), Puchar Interkontynentalny (1), Mistrz drugiej ligi hiszpańskiej (1), Puchar Ewy Duarte (1)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = Chelsea, Nazwa = "Chelsea Football Club", Stadion = "Stamford Bridge", Trofea = "Liga Mistrzów (2), Klubowy Puchar Świata FIFA (1), Mistrzostwo Anglii (6), Superpuchar UEFA (2), Liga Europy UEFA (2), Puchar Zdobywców Pucharów (2), Puchar Anglii (FA Cup) (8), Puchar Ligi Angielskiej (5), Superpuchar Anglii (4), Mistrzostwo Anglii w 2. Lidze (2)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = BayerLeverkusen, Nazwa = "Bayer 04 Leverkusen", Stadion = "BayArena", Trofea = "Puchar UEFA (1), Puchar Niemiec (DFB-Pokal) (1), Mistrzostwo 2. Bundesligi Niemieckiej (1)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = BayernMonachiumII, Nazwa = "Bayern München II", Stadion = "Grünwalder Stadion", Trofea = "Mistrz 3. Ligi Niemieckiej (1), Mistrz Regionalliga Bavaria Niemieckiej (2), Zwycięzca Landespokal Bayern (1)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = BayernMonachium, Nazwa = "Bayern München", Stadion = "Allianz Arena", Trofea = "Liga Mistrzów (3), Puchar Europy (3), Klubowy Puchar Świata FIFA (2), Mistrz Niemiec (33), Superpuchar UEFA (2), Puchar UEFA (1), Puchar Zdobywców Pucharów (1), Puchar Niemiec (DFB-Pokal) (20), Superpuchar Niemiec (10), Puchar Interkontynentalny (2), Puchar Ligi (6)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = KRCGenk, Nazwa = "KRC Genk", Stadion = "Cegeka Arena", Trofea = "Mistrzostwo Belgii (4), Puchar Belgii (5), Superpuchar Belgii (2)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = FKDnipro, Nazwa = "Dnipro Dniepropetrowsk", Stadion = "Meteor", Trofea = "Mistrzostwo Związku Radzieckiego (2), Puchar Związku Radzieckiego (1), Mistrzostwo Drugiej Dywizji Związku Radzieckiego (1)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = ZoriaŁugańsk, Nazwa = "Zoria Ługańsk", Stadion = "Valeriy Lobanovsky Stadion", Trofea = "Mistrzostwo Związku Radzieckiego (1)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = FCSaoPaulo, Nazwa = "FC Sao Paulo", Stadion = "Cícero Pompeu de Toledo", Trofea = "Klubowe Mistrzostwa Świata FIFA (1), Mistrz Brazylii (6), Copa Sudamericana (1), Copa Libertadores (3), Pucharu Interkontynentalnego (2), Recopa Sudamericana (2), Copa CONMEBOL (1)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = FCPorto, Nazwa = "FC Porto", Stadion = "Estádio do Dragão", Trofea = "Liga Mistrzów (1), Puchar Europy (1), Superpuchar UEFA (1), Puchar UEFA (1), Liga Europy (1), Mistrz Portugalii (30), Pucharu Portugalii (19), Superpuchar Portugalii (24), Puchar Ligi (1), Puchar Interkontynentalny (2)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = AustriaWieden, Nazwa = "FK Austria Wiedeń", Stadion = "Generali Arena", Trofea = "Mistrz Austrii (24), Pucharu Austrii (ÖFB-Cup) (27), Puchar Mitropa (2)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = RealSociedadB, Nazwa = "Real Sociedad B", Stadion = "Instalaciones de Zubieta", Trofea = "Brak", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = RealSociedad, Nazwa = "Real Sociedad", Stadion = "Reale Arena", Trofea = "Mistrz Hiszpanii (2), Puchar Króla (Copa del Rey) (3), Superpuchar Hiszpanii (1), Mistrz Hiszpanii w 2. lidze (6)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = RayoVallecano, Nazwa = "Rayo Vallecano", Stadion = "Campo de Fútbol de Vallecas", Trofea = "Mistrz Hiszpanii w 2. lidze (1)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = VfBStuttgartII, Nazwa = "VfB Stuttgart II", Stadion = "Robert-Schlienz-Stadion", Trofea = "Mistrz Niemiec w Kategorii Amatorów (2), Landespokal Württemberg (4)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = VfBStuttgart, Nazwa = "VfB Stuttgart", Stadion = "Mercedes-Benz Arena", Trofea = "Mistrz Niemiec (5), Puchar Niemiec (DFB-Pokal) (3), Superpuchar Niemiec (1), Mistrz 2. Bundesligi Niemieckiej (2)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = ASRoma, Nazwa = "AS Roma", Stadion = "Olimpico di Roma", Trofea = "Mistrz Włoch (3), Konferencja Ligi (Conference League) (1), Puchar Włoch (Coppa Italia) (9), Superpuchar Włoch (Supercoppa) (2), Mistrz Drugiej Ligi Włoskiej (Italienischer Zweitligameister) (1), Puchar Messe (Messe Cup) (1)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = ACLeHavreB, Nazwa = "AC Le Havre B", Stadion = "Stade Charles Argentin", Trofea = "Brak", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = LeHavreAC, Nazwa = "Le Havre AC", Stadion = "Stade Océane", Trofea = "Puchar Francji (Coupe de France) (1), Mistrz Drugiej Ligi Francuskiej (6)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = BirminghamCity, Nazwa = "Birmingham City", Stadion = "St Andrew's", Trofea = "Puchar Ligi (2), Puchar Ligi Angielskiej (Football League Trophy) (2), Mistrz Anglii w Drugiej Lidze (4), Mistrz Anglii w Trzeciej Lidze (1)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = BorussiaDortmund, Nazwa = "Borussia Dortmund", Stadion = "SIGNAL IDUNA PARK", Trofea = "Ligia Mistrzów (1), Mistrz Niemiec (8), Puchar Zdobywców Pucharów (1), Puchar Niemiec (DFB-Pokal) (5), Superpuchar Niemiec (6), Puchar Interkontynentalny (1), Puchar Zachodnioniemiecki (2)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = DinamoZagrzeb, Nazwa = "GNK Dinamo Zagrzeb", Stadion = "Maksimir", Trofea = "Mistrz Chorwacji (24), Pucharu Messe (1), Mistrz Jugosławii (4), Pucharu Jugosławii (7), Pucharu Chorwacji (16)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = Tottenham, Nazwa = "Tottenham Hotspur", Stadion = "Tottenham Hotspur Stadium", Trofea = "Mistrz Angii (2), Puchar UEFA (2), Puchar Zdobywców Pucharów (1), Puchar Angii (FA Cup) (8), Puchar Ligi Angielskiej (English League Cup) (4), Superpuchar Angii (English Supercup) (7), mistrz Drugiej Ligi Angielskiej (English 2nd Tier) (2)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = StadeRennaisFCB, Nazwa = "Stade Rennais FC B", Stadion = "Centre d'entraînement de la Piverdière - H.Guérin", Trofea = "Brak", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = StadeRennais, Nazwa = "Stade Rennais FC", Stadion = "CRoazhon Park", Trofea = "Puchar Francji (Coupe de France) (3)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = CAPenarol, Nazwa = "CA Peñarol", Stadion = "Campeón del Siglo", Trofea = "Urugwajski mistrz (46), Superpuchar Urugwaju (2), Copa Libertadores (5), Puchar Interkontynentalny (3)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = FCGirondinsBordeauxB, Nazwa = "FC Girondins Bordeaux B", Stadion = " - ", Trofea = "Brak", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = FCGirondinsBordeaux, Nazwa = "FC Girondins Bordeaux", Stadion = "Matmut Atlantique", Trofea = "Mistrz Francji (6), Puchar Francji (Coupe de France) (4), Puchar Ligi Francuskiej (3), Superpuchar Francji (2)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = ASMonaco, Nazwa = "AS Monaco", Stadion = "Stade Louis-II", Trofea = "Mistrz Francji (8), Puchar Francji (Coupe de France) (5), Puchar Ligi Francuskiej (1), Mistrz Drugiej Ligi Francuskiej (1), Superpuchar Francji (2)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = RealBetis, Nazwa = "Real Betis", Stadion = "Benito Villamarín", Trofea = "Mistrz Hiszpanii (1), Puchar Hiszpanii (Copa del Rey) (3), mistrz drugiej ligi hiszpańskiej (7)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = CRFlamengo, Nazwa = "CR Flamengo", Stadion = "Jornalista Mário Filho", Trofea = "Mistrz Brazylii (8), Puchar Brazylii (4), Superpuchar Brasil (2), Copa Libertadores (3), Puchar Interkontynentalny (1), Recopa Sudamericana (1)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = SantosFC, Nazwa = "Santos FC", Stadion = "Urbano Caldeira", Trofea = "Mistrz Brazylii (8), Puchar Brazylii (1), Copa Libertadores (3), Puchar Interkontynentalny (2), Recopa Sudamericana (1), Copa CONMEBOL (1", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = ManchesterCity, Nazwa = "Manchester City", Stadion = "Etihad Stadium", Trofea = "Liga Mistrzów (1), Mistrz Anglii (9), Superpuchar UEFA (1), Puchar Zdobywców (1), Puchar Anglii (7), Puchar Ligi (8), Superpuchar Angii (6), mistrz Drugiej Ligi Anglii (7)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = Fenerbahce, Nazwa = "Fenerbahce", Stadion = "Şükrü Saracoğlu Stadyumu", Trofea = "Mistrz Turcji (19), Puchar Turcji (7), Superpuchar Turcji (9)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = SportingCP, Nazwa = "Sporting CP", Stadion = "José Alvalade XXI", Trofea = "Puchar Zdobywców Pucharów (1), Mistrz Portugalii (19), Puchar Portugalii (17), Puchar Ligi (4), Superpuchar Portugalii (9)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = FCBarcelona, Nazwa = "FC Barcelona", Stadion = "Spotify Camp Nou", Trofea = "Liga Mistrzów (4), Puchar Europy (1), Klubowy Puchar Świata FIFA (3), Mistrz Hiszpanii (27), Superpuchar UEFA (5), Puchar Zdobywców Pucharów (4), Puchar Hiszpanii (Copa del Rey) (31), Superpuchar Hiszpanii (14), Puchar Messe (3), Copa Catalunya (9), Copa Eva Duarte (3)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = InterMilan, Nazwa = "Inter Milan", Stadion = "Giuseppe Meazza", Trofea = "Liga mistrzów (1), puchar europy (2), klubowy puchar świata fifa (1), mistrz włoch (19), puchar uefa (3), puchar włoch (Coppa Italia) (9), superpuchar włoch (Supercoppa) (7), puchar międzykontynentalny (2)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = ManchesterUnited, Nazwa = "Manchester United", Stadion = "Old Trafford", Trofea = "Ligi Mistrzów (2), Pucharu Europy (1), Klubowego Pucharu Świata FIFA (1), Mistrz Anglii (20), Superpucharu UEFA (1), Ligi Europy UEFA (1), Pucharu Zdobywców Pucharów (1), Pucharu Anglii (FA Cup) (12), Pucharu Ligi Angielskiej (6), Superpucharu Anglii (21), Pucharu Interkontynentalnego (1), Mistrz Drugiej Ligi Angielskiej (2)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = Juventus, Nazwa = "Juventus Turyn", Stadion = "Allianz Stadium", Trofea = "Liga Mistrzów (1), Puchar Europy (1), Mistrz Włoch (36), Superpuchar UEFA (2), Puchar UEFA (3), Puchar Zdobywców Pucharów (1), Puchar Włoch (Coppa Italia) (14), Superpuchar Włoch (Supercoppa) (9), Mistrz Drugiej Ligi Włoskiej (1), Puchar Interkontynentalny (2)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = AlNassr, Nazwa = "Al-Nassr", Stadion = "Al-Awwal Park", Trofea = "Mistrz Arabii Saudyjskiej (9), Puchar Arabii Saudyjskiej (6), Puchar Księcia Korony Arabii Saudyjskiej (2), Superpuchar Arabii Saudyjskiej (2), Azjatycki Superpuchar (1), Puchar Zdobywców Pucharów Azji (1), Dwukrotny Zwycięzca Ligi Mistrzów Zatoki Perskiej (GCC Champions League) (2), Puchar Mistrzów Klubów Arabskich (Arab Club Champions Cup) (1)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = Liverpool, Nazwa = "FC Liverpool", Stadion = "Anfield", Trofea = "Liga Mistrzów (2), Puchar Europy (4), Klubowy Puchar Świata FIFA (1), Mistrz Anglii (19), Superpuchar UEFA (4), Puchar UEFA (3), Puchar Anglii (FA Cup) (8), Puchar Ligi Angielskiej (The League Cup) (9), Superpuchar Anglii (16), Mistrz Drugiej Ligi Angielskiej (4)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = FCSchalke, Nazwa = "FC Schalke 04", Stadion = "Veltins-Arena", Trofea = "Mistrz Niemiec (7), Puchar UEFA (1), Puchar Niemiec (DFB-Pokal) (5), Superpuchar Niemiec (1), Mistrz Drugiej Ligi Niemieckiej (2. Bundesliga) (3), Puchar Ligi (1), Landespokal Westfalii (2), Western German Cup (1)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = AlSadd, Nazwa = "Al-Sadd SC", Stadion = "Jassim Bin Hamad", Trofea = "Liga Mistrzów AFC (1), Klubowe Mistrzostwo Azji (1), Mistrz Kataru (16), Puchar Kataru (Emir of Qatar Cup) (18), Puchar Ligi Kataru (8), Superpuchar Kataru (Sheikh Jassim Cup) (15), Puchar Gwiazd Kataru (Ooredoo Cup) (2), Liga Mistrzów Zatoki Perskiej (GCC Champions League) (1), Puchar Mistrzów Klubów Arabskich (1)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = NewYorkCosmos, Nazwa = "New York Cosmos", Stadion = "Mitchel Athletic Complex", Trofea = "8X NASL SOCCER BOWL CHAMPION, 9X NASL REGULAR SEASON CHAMPION", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = ASCannes, Nazwa = "AS Cannes", Stadion = "Stade Pierre-de-Coubertin", Trofea = "Pucharu Francji (Coupe de France) (1)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },

                new Klub() { IdKlub = Emerytura, Nazwa = "Koniec kariery", Stadion = null, Trofea = null, ObecniPilkarze = null, ArchiwalniPilkarze = null, Zarzad = null },
                new Klub() { IdKlub = Trener, Nazwa = "Trener", Stadion = null, Trofea = null, ObecniPilkarze = null, ArchiwalniPilkarze = null, Zarzad = null }
                );


            modelBuilder.Entity<Pilkarz>().HasData(
                new Pilkarz { IdPilkarz = ThibautCourtois, Imie = "Thibaut", Nazwisko = "Courtois", Wiek = 29, Pozycja = "Bramkarz", Statystyki = null, ArchiwalneKluby = new Collection<Klub> { /* KRCGenk, Chelsea, AtleticoMadryt */ }, Wynagrodzenie = 350000, IdKlubu = RealMadryt },
                new Pilkarz { IdPilkarz = AndrijLunin, Imie = "Andrij", Nazwisko = "Łunin", Wiek = 24, Pozycja = "Bramkarz", Statystyki = null, ArchiwalneKluby = new Collection<Klub> { /* FKDnipro, ZoriaŁugańsk */ }, Wynagrodzenie = 150000, IdKlubu = RealMadryt },
                new Pilkarz { IdPilkarz = DaniCarvajal, Imie = "Dani", Nazwisko = "Carvajal", Wiek = 29, Pozycja = "Prawy obrońca", Statystyki = null, ArchiwalneKluby = new Collection<Klub> { /* RealMadrytCastilla, BayerLeverkusen */ }, Wynagrodzenie = 250000, IdKlubu = RealMadryt },
                new Pilkarz { IdPilkarz = EderMilitao, Imie = "Eder", Nazwisko = "Militao", Wiek = 23, Pozycja = "Środkowy obrońca", Statystyki = null, ArchiwalneKluby = new Collection<Klub> { /* FCSaoPaulo, FCPorto */ }, Wynagrodzenie = 230000, IdKlubu = RealMadryt },
                new Pilkarz { IdPilkarz = DavidAlaba, Imie = "David", Nazwisko = "Alaba", Wiek = 31, Pozycja = "Środkowy obrońca", Statystyki = null, ArchiwalneKluby = new Collection<Klub> { /* AustriaWieden, BayernMonachiumII, BayernMonachium */ }, Wynagrodzenie = 200000, IdKlubu = RealMadryt },
                new Pilkarz { IdPilkarz = NachoFernandez, Imie = "Nacho", Nazwisko = "Fernández", Wiek = 33, Pozycja = "Środkowy obrońca", Statystyki = null, ArchiwalneKluby = new Collection<Klub> { /* RealMadrytCastilla */ }, Wynagrodzenie = 240000, IdKlubu = RealMadryt },
                new Pilkarz { IdPilkarz = AlvaroOdriozola, Imie = "Álvaro", Nazwisko = "Odriozola", Wiek = 27, Pozycja = "Prawy obrońca", Statystyki = null, ArchiwalneKluby = new Collection<Klub> { /* RealSociedadB, RealSociedad */ }, Wynagrodzenie = 160000, IdKlubu = RealMadryt },
                new Pilkarz { IdPilkarz = LucasVazquez, Imie = "Lucas", Nazwisko = "Vázquez", Wiek = 32, Pozycja = "Prawy obrońca", Statystyki = null, ArchiwalneKluby = new Collection<Klub> { /* RealMadrytC, RealMadrytCastilla */ }, Wynagrodzenie = 265000, IdKlubu = RealMadryt },
                new Pilkarz { IdPilkarz = FranGarcia, Imie = "Fran", Nazwisko = "García", Wiek = 23, Pozycja = "Lewy obrońca", Statystyki = null, ArchiwalneKluby = new Collection<Klub> { /* RealMadrytCastilla, RayoVallecano */ }, Wynagrodzenie = 170000, IdKlubu = RealMadryt },
                new Pilkarz { IdPilkarz = AntonioRudiger, Imie = "Antonio", Nazwisko = "Rüdiger", Wiek = 30, Pozycja = "Środkowy obrońca", Statystyki = null, ArchiwalneKluby = new Collection<Klub> { /* VfBStuttgartII, VfBStuttgart, ASRoma, Chelsea */ }, Wynagrodzenie = 195000, IdKlubu = RealMadryt },
                new Pilkarz { IdPilkarz = FerlandMendy, Imie = "Ferland", Nazwisko = "Mendy", Wiek = 26, Pozycja = "Lewy obrońca", Statystyki = null, ArchiwalneKluby = new Collection<Klub> { /* ACLeHavreB, LeHavreAC */ }, Wynagrodzenie = 245000, IdKlubu = RealMadryt },
                new Pilkarz { IdPilkarz = JudeBellingham, Imie = "Jude", Nazwisko = "Bellingham", Wiek = 20, Pozycja = "Środkowy pomocnik", Statystyki = null, ArchiwalneKluby = new Collection<Klub> { /* BirminghamCity, BorussiaDortmund */ }, Wynagrodzenie = 360000, IdKlubu = RealMadryt },
                new Pilkarz { IdPilkarz = ToniKroos, Imie = "Toni", Nazwisko = "Kroos", Wiek = 33, Pozycja = "Środkowy pomocnik", Statystyki = null, ArchiwalneKluby = new Collection<Klub> { /* BayernMonachiumII, BayernMonachium */ }, Wynagrodzenie = 250000, IdKlubu = RealMadryt },
                new Pilkarz { IdPilkarz = LukaModric, Imie = "Luka", Nazwisko = "Modrić", Wiek = 37, Pozycja = "Środkowy pomocnik", Statystyki = null, ArchiwalneKluby = new Collection<Klub> { /*  */ }, Wynagrodzenie = 270000, IdKlubu = RealMadryt },
                new Pilkarz { IdPilkarz = EduardoCamavinga, Imie = "Eduardo", Nazwisko = "Camavinga", Wiek = 20, Pozycja = "Środkowy pomocnik", Statystyki = null, ArchiwalneKluby = new Collection<Klub> { /* DinamoZagrzeb, Tottenham */ }, Wynagrodzenie = 235000, IdKlubu = RealMadryt },
                new Pilkarz { IdPilkarz = FedericoValverde, Imie = "Federico", Nazwisko = "Valverde", Wiek = 25, Pozycja = "Środkowy pomocnik", Statystyki = null, ArchiwalneKluby = new Collection<Klub> { /* StadeRennaisFCB, StadeRennais */ }, Wynagrodzenie = 255000, IdKlubu = RealMadryt },
                new Pilkarz { IdPilkarz = AurelienTchouameni, Imie = "Aurélien", Nazwisko = "Tchouaméni", Wiek = 23, Pozycja = "Środkowy pomocnik", Statystyki = null, ArchiwalneKluby = new Collection<Klub> { /* CAPenarol, RealMadrytCastilla */ }, Wynagrodzenie = 236000, IdKlubu = RealMadryt },
                new Pilkarz { IdPilkarz = DanielCeballos, Imie = "Daniel", Nazwisko = "Ceballos", Wiek = 26, Pozycja = "Środkowy pomocnik", Statystyki = null, ArchiwalneKluby = new Collection<Klub> { /* FCGirondinsBordeauxB, FCGirondinsBordeaux, ASMonaco */ }, Wynagrodzenie = 175000, IdKlubu = RealMadryt },
                new Pilkarz { IdPilkarz = ArdaGuler, Imie = "Arda", Nazwisko = "Güler", Wiek = 18, Pozycja = "Ofensywny pomocnik", Statystyki = null, ArchiwalneKluby = new Collection<Klub> { /* RealBetis */ }, Wynagrodzenie = 140000, IdKlubu = RealMadryt },
                new Pilkarz { IdPilkarz = ViniciusJunior, Imie = "Vinicius", Nazwisko = "Junior", Wiek = 21, Pozycja = "Lewy skrzydłowy", Statystyki = null, ArchiwalneKluby = new Collection<Klub> { /* Fenerbahce */ }, Wynagrodzenie = 420000, IdKlubu = RealMadryt },
                new Pilkarz { IdPilkarz = RodrygoGoes, Imie = "Rodrygo", Nazwisko = "Goes", Wiek = 22, Pozycja = "Prawy krzydłowy", Statystyki = null, ArchiwalneKluby = new Collection<Klub> { /* CRFlamengo, RealMadrytCastilla */ }, Wynagrodzenie = 195000, IdKlubu = RealMadryt },
                new Pilkarz { IdPilkarz = Joselu, Imie = "Joselu", Nazwisko = "Luís Sanmartín Mato", Wiek = 33, Pozycja = "Środkowy napastnik", Statystyki = null, ArchiwalneKluby = new Collection<Klub> { /* SantosFC, RealMadrytCastilla */ }, Wynagrodzenie = 150000, IdKlubu = RealMadryt },
                new Pilkarz { IdPilkarz = BrahimDiaz, Imie = "Brahim", Nazwisko = "Díaz", Wiek = 23, Pozycja = "Prawy skrzydłowy", Statystyki = null, ArchiwalneKluby = new Collection<Klub> { /* ManchesterCity */ }, Wynagrodzenie = 200000, IdKlubu = RealMadryt },
                
                new Pilkarz { IdPilkarz = LucasCanizares, Imie = "Lucas", Nazwisko = "Cañizares", Wiek = 21, Pozycja = "Bramkarz", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytCastilla },
                new Pilkarz { IdPilkarz = MarioDeLuis, Imie = "Mario", Nazwisko = "De Luis", Wiek = 21, Pozycja = "Bramkarz", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytCastilla },
                new Pilkarz { IdPilkarz = ViniciusTobias, Imie = "Vinicius", Nazwisko = "Tobias", Wiek = 19, Pozycja = "Prawy obrońca", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytCastilla },
                new Pilkarz { IdPilkarz = AlvaroCarrillo, Imie = "Álvaro", Nazwisko = "Carrillo", Wiek = 21, Pozycja = "Środkowy obrońca", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytCastilla },
                new Pilkarz { IdPilkarz = PabloRamon, Imie = "Pablo", Nazwisko = "Ramón", Wiek = 22, Pozycja = "Środkowy obrońca", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytCastilla },
                new Pilkarz { IdPilkarz = LucasAlcazar, Imie = "Lucas", Nazwisko = "Alcázar", Wiek = 21, Pozycja = "Środkowy obrońca", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytCastilla },
                new Pilkarz { IdPilkarz = MarvelousGarzon, Imie = "Marvelous", Nazwisko = "Garzón", Wiek = 20, Pozycja = "Środkowy obrońca", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytCastilla },
                new Pilkarz { IdPilkarz = TheoFernandez, Imie = "Theo", Nazwisko = "Fernández", Wiek = 21, Pozycja = "Środkowy pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytCastilla },
                new Pilkarz { IdPilkarz = CarlosDotor, Imie = "Carlos", Nazwisko = "Dotor", Wiek = 22, Pozycja = "Środkowy pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytCastilla },
                new Pilkarz { IdPilkarz = PeterGonzalez, Imie = "Peter", Nazwisko = "González", Wiek = 21, Pozycja = "Środkowy pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytCastilla },
                new Pilkarz { IdPilkarz = AlvaroMartin, Imie = "Álvaro", Nazwisko = "Martín", Wiek = 22, Pozycja = "Środkowy pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytCastilla },
                new Pilkarz { IdPilkarz = TakuhiroNakai, Imie = "Takuhiro", Nazwisko = "Nakai", Wiek = 19, Pozycja = "Środkowy pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytCastilla },
                new Pilkarz { IdPilkarz = AlvaroLeiva, Imie = "Álvaro", Nazwisko = "Leiva", Wiek = 18, Pozycja = "Środkowy pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytCastilla },
                new Pilkarz { IdPilkarz = JavierVillar, Imie = "Javier", Nazwisko = "Villar", Wiek = 20, Pozycja = "Środkowy pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytCastilla },
                new Pilkarz { IdPilkarz = OscarAranda, Imie = "Óscar", Nazwisko = "Aranda", Wiek = 21, Pozycja = "Środkowy pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytCastilla },
                new Pilkarz { IdPilkarz = RafaelLlorente, Imie = "Rafael", Nazwisko = "Llorente", Wiek = 20, Pozycja = "Środkowy pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytCastilla },
                new Pilkarz { IdPilkarz = MarioMartin, Imie = "Mario", Nazwisko = "Martín", Wiek = 19, Pozycja = "Środkowy pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytCastilla },
                new Pilkarz { IdPilkarz = SergioArribas, Imie = "Sergio", Nazwisko = "Arribas", Wiek = 21, Pozycja = "Środkowy pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytCastilla },
                new Pilkarz { IdPilkarz = NoelLopez, Imie = "Noel", Nazwisko = "López", Wiek = 20, Pozycja = "Środkowy napastnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytCastilla },
                new Pilkarz { IdPilkarz = IkerBravo, Imie = "Iker", Nazwisko = "Bravo", Wiek = 18, Pozycja = "Środkowy napastnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytCastilla },

                //Archiwalni piłkarze
                new Pilkarz { IdPilkarz = LuísFigo, Imie = "Luís", Nazwisko = "Figo", Wiek = 50, Pozycja = "Prawy napastnik", Statystyki = null, ArchiwalneKluby = new Collection<Klub> { /* SportingCP, FCBarcelona, RealMadryt, InterMilan */ }, Wynagrodzenie = 210000, IdKlubu = Emerytura },
                new Pilkarz { IdPilkarz = IkerCasillas, Imie = "Iker", Nazwisko = "Casillas", Wiek = 42, Pozycja = "Bramkarz", Statystyki = null, ArchiwalneKluby = new Collection<Klub> { /* RealMadrytCastilla, RealMadryt, FCPorto */ }, Wynagrodzenie = 180000, IdKlubu = Emerytura },
                new Pilkarz { IdPilkarz = CristianoRonaldo, Imie = "Cristiano", Nazwisko = "Ronaldo", Wiek = 38, Pozycja = "Napastnik", Statystyki = null, ArchiwalneKluby = new Collection<Klub> { /* SportingCP, ManchesterUnited, RealMadryt, Juventus, ManchesterUnited */ }, Wynagrodzenie = 300000, IdKlubu = AlNassr },
                new Pilkarz { IdPilkarz = XabiAlonso, Imie = "Xabi", Nazwisko = "Alonso", Wiek = 41, Pozycja = "Środkowy pomocnik", Statystyki = null, ArchiwalneKluby = new Collection<Klub> { /* RealSociedad, Liverpool, RealMadryt, BayernMonachium */ }, Wynagrodzenie = 140000, IdKlubu = Trener },
                new Pilkarz { IdPilkarz = RaulGonzalez, Imie = "Raúl", Nazwisko = "González", Wiek = 46, Pozycja = "Napastnik", Statystyki = null, ArchiwalneKluby = new Collection<Klub> { /* RealMadrytC, RealMadrytCastilla, RealMadryt, FCSchalke, AlSadd, NewYorkCosmos */ }, Wynagrodzenie = 190000, IdKlubu = Emerytura },
                new Pilkarz { IdPilkarz = ZinedineZidane, Imie = "Zinédine", Nazwisko = "Zidane", Wiek = 51, Pozycja = "Pomocnik", Statystyki = null, ArchiwalneKluby = new Collection<Klub> { /* ASCannes, FCGirondinsBordeaux, Juventus, RealMadryt */ }, Wynagrodzenie = 250000, IdKlubu = Emerytura }
            );


            modelBuilder.Entity<Statystyka>().HasData(
                new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs Liverpool", Gole = 0, ZolteKartki = 0, CzerwoneKartki = 0, Asysty = 0, PrzebiegnietyDystans = 0.8, Ocena = 8.8, IdPilkarz = ThibautCourtois },
                new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs Juventus", Gole = 0, ZolteKartki = 0, CzerwoneKartki = 0, Asysty = 0, PrzebiegnietyDystans = 0.4,  Ocena = 8.2, IdPilkarz = AndrijLunin },
                new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs Atletico Madrid", Gole = 0, ZolteKartki = 1, CzerwoneKartki = 0, Asysty = 1, PrzebiegnietyDystans = 10.5, Ocena = 8.5, IdPilkarz = DaniCarvajal },
                new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs Bayern Munich", Gole = 1, ZolteKartki = 0, CzerwoneKartki = 0, Asysty = 0, PrzebiegnietyDystans = 9.7,  Ocena = 8.9, IdPilkarz = EderMilitao },
                new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs Paris Saint-Germain", Gole = 0, ZolteKartki = 0, CzerwoneKartki = 0,  Asysty = 2, PrzebiegnietyDystans = 10.1, Ocena = 9.1, IdPilkarz = DavidAlaba },
                new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs FC Barcelona", Gole = 0, ZolteKartki = 1, CzerwoneKartki = 0, Asysty = 1, PrzebiegnietyDystans = 8.4, Ocena = 7.5, IdPilkarz = LukaModric },
                new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs Liverpool", Gole = 0, ZolteKartki = 2, CzerwoneKartki = 0, Asysty = 1, PrzebiegnietyDystans = 8.6, Ocena = 7.9, IdPilkarz = FerlandMendy },
                new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs Valencia", Gole = 2, ZolteKartki = 1, CzerwoneKartki = 0, Asysty = 0, PrzebiegnietyDystans = 8.5, Ocena = 8.2, IdPilkarz = LukaModric },
                new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs Chelsea", Gole = 0, ZolteKartki = 2, CzerwoneKartki = 0, Asysty = 1, PrzebiegnietyDystans = 8.9, Ocena = 7.8, IdPilkarz = FerlandMendy },
                new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs Manchester City", Gole = 0, ZolteKartki = 1, CzerwoneKartki = 0, Asysty = 2, PrzebiegnietyDystans = 9.6, Ocena = 8.6, IdPilkarz = LukaModric },
                new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs Tottenham", Gole = 0, ZolteKartki = 2, CzerwoneKartki = 0, Asysty = 1, PrzebiegnietyDystans = 8.8, Ocena = 7.7, IdPilkarz = FerlandMendy },
                new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs Napoli", Gole = 1, ZolteKartki = 0, CzerwoneKartki = 0, Asysty = 0, PrzebiegnietyDystans = 8.2, Ocena = 7.6, IdPilkarz = Joselu }, 
                new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs Ajax", Gole = 0, ZolteKartki = 0, CzerwoneKartki = 0, Asysty = 1, PrzebiegnietyDystans = 9.3, Ocena = 8.4, IdPilkarz = BrahimDiaz }, 
                new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs RB Leipzig", Gole = 1, ZolteKartki = 1, CzerwoneKartki = 0, Asysty = 1, PrzebiegnietyDystans = 9.9, Ocena = 8.9, IdPilkarz = JudeBellingham }, 
                new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs Sevilla", Gole = 0, ZolteKartki = 0, CzerwoneKartki = 0, Asysty = 3, PrzebiegnietyDystans = 10.7, Ocena = 9.1, IdPilkarz = ToniKroos }, 
                new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs Galatasaray", Gole = 0, ZolteKartki = 2, CzerwoneKartki = 1, Asysty = 0, PrzebiegnietyDystans = 7.8, Ocena = 6.5, IdPilkarz = ArdaGuler },

                new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid Castilla vs Atletico Madrid B", Gole = 1, ZolteKartki = 0, CzerwoneKartki = 0, Asysty = 0, PrzebiegnietyDystans = 8.1, Ocena = 8.4, IdPilkarz = ViniciusTobias },
                new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid Castilla vs Sevilla Atletico", Gole = 0, ZolteKartki = 1, CzerwoneKartki = 0, Asysty = 1, PrzebiegnietyDystans = 7.5, Ocena = 7.9, IdPilkarz = AlvaroCarrillo },
                new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid Castilla vs Real Betis B", Gole = 0, ZolteKartki = 0, CzerwoneKartki = 0, Asysty = 0, PrzebiegnietyDystans = 7.8, Ocena = 8.1, IdPilkarz = PabloRamon },
                new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid Castilla vs Getafe B", Gole = 0, ZolteKartki = 0, CzerwoneKartki = 0, Asysty = 2, PrzebiegnietyDystans = 8.5, Ocena = 8.5, IdPilkarz = LucasAlcazar },
                new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid Castilla vs Rayo Vallecano B", Gole = 0, ZolteKartki = 1, CzerwoneKartki = 0, Asysty = 0, PrzebiegnietyDystans = 7.4, Ocena = 7.7, IdPilkarz = MarvelousGarzon },
                new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid Castilla vs Alcorcón B", Gole = 1, ZolteKartki = 0, CzerwoneKartki = 0, Asysty = 0, PrzebiegnietyDystans = 7.9, Ocena = 8.3, IdPilkarz = TheoFernandez },
                new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid Castilla vs Huesca B", Gole = 0, ZolteKartki = 0, CzerwoneKartki = 0, Asysty = 1, PrzebiegnietyDystans = 7.6, Ocena = 8.0, IdPilkarz = CarlosDotor },
                new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid Castilla vs CD Badajoz", Gole = 1, ZolteKartki = 1, CzerwoneKartki = 0, Asysty = 1, PrzebiegnietyDystans = 8.2, Ocena = 8.6, IdPilkarz = PeterGonzalez }
            );


            modelBuilder.Entity<Zarzad>().HasData(
                new Zarzad() { IdZarzad = ZarzadRealMadryt, Pracownicy = new List<Pracownik>(), Budzet = 2500000, Cele = "Liga Mistrzów, Superpuchar Hiszpanii, Naprawa murawy, Renowacja krzesełek, Nowy młody napastnik", IdKlubu = RealMadryt },
                new Zarzad() { IdZarzad = ZarzadRealMadrytCastilla, Pracownicy = new List<Pracownik>(), Budzet = 1250000, Cele = "Awans do Segunda División", IdKlubu = RealMadrytCastilla }
            );


            modelBuilder.Entity<Pracownik>().HasData(
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Fiorentino", Nazwisko = "Perez", PESEL = "12345600101", Wiek = 77, WykonywanaFunkcja = "Prezes", IdZarzadu = ZarzadRealMadryt, Wynagrodzenie = 420000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Carlo", Nazwisko = "Ancelotti", PESEL = "23456700202", Wiek = 64, WykonywanaFunkcja = "Trener", IdZarzadu = ZarzadRealMadryt, Wynagrodzenie = 350000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Davide", Nazwisko = "Ancelotti", PESEL = "34567800303", Wiek = 33, WykonywanaFunkcja = "Asystent trenera", IdZarzadu = ZarzadRealMadryt, Wynagrodzenie = 300000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Antonio", Nazwisko = "Pintus", PESEL = "67890100606", Wiek = 60, WykonywanaFunkcja = "Szef od przygotowania fizycznego", IdZarzadu = ZarzadRealMadryt, Wynagrodzenie = 125000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Francesco", Nazwisko = "Mauri", PESEL = "87890400406", Wiek = 34, WykonywanaFunkcja = "Fizjoterapeuta", IdZarzadu = ZarzadRealMadryt, Wynagrodzenie = 125000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Simone", Nazwisko = "Montanaro", PESEL = "78901200707", Wiek = 51, WykonywanaFunkcja = "Trener analityk", IdZarzadu = ZarzadRealMadryt, Wynagrodzenie = 140000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Mino", Nazwisko = "Fulco", PESEL = "88501220767", Wiek = 51, WykonywanaFunkcja = "Dietetyk", IdZarzadu = ZarzadRealMadryt, Wynagrodzenie = 140000 },
                
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Raúl", Nazwisko = "González", PESEL = "70631490286", Wiek = 46, WykonywanaFunkcja = "Trener", IdZarzadu = ZarzadRealMadrytCastilla, Wynagrodzenie = 200000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Alberto", Nazwisko = "Garrido", PESEL = "45098763201", Wiek = 47, WykonywanaFunkcja = "Asystent trenera", IdZarzadu = ZarzadRealMadrytCastilla, Wynagrodzenie = 140000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Nacho", Nazwisko = "S. García", PESEL = "83456789021", Wiek = 46, WykonywanaFunkcja = "Trener przygotowania fizycznego", IdZarzadu = ZarzadRealMadrytCastilla, Wynagrodzenie = 90000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Víctor", Nazwisko = "P. Hernández", PESEL = "79806543210", Wiek = 45, WykonywanaFunkcja = "Trener przygotowania fizycznego", IdZarzadu = ZarzadRealMadrytCastilla, Wynagrodzenie = 90000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Mario", Nazwisko = "Soria Amor", PESEL = "70123450789", Wiek = 53, WykonywanaFunkcja = "Trener bramkarzy", IdZarzadu = ZarzadRealMadrytCastilla, Wynagrodzenie = 100000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Javier", Nazwisko = "de Tomás Maroto", PESEL = "84501230769", Wiek = 46, WykonywanaFunkcja = "Fizjoterapeuta", IdZarzadu = ZarzadRealMadrytCastilla, Wynagrodzenie = 75000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Tirso", Nazwisko = "Álvarez", PESEL = "89765432109", Wiek = 40, WykonywanaFunkcja = "Fizjoterapeuta", IdZarzadu = ZarzadRealMadrytCastilla, Wynagrodzenie = 75000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Álvaro", Nazwisko = "Tavira", PESEL = "71234567890", Wiek = 35, WykonywanaFunkcja = "Fizjoterapeuta", IdZarzadu = ZarzadRealMadrytCastilla, Wynagrodzenie = 75000 }
            );
        }
    }
}