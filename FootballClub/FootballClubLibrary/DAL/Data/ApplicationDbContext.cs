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
            var klubRealMadrytId = Guid.NewGuid();
            var ZarzadRealMadrytId = Guid.NewGuid();

            //Klucze dla piłkarzy
            var ThibautCourtois = Guid.NewGuid();
            var DaniCarvajal = Guid.NewGuid();
            var RaphaelVarane = Guid.NewGuid();
            var EderMilitao = Guid.NewGuid();
            var FerlandMendy = Guid.NewGuid();
            var Casemiro = Guid.NewGuid();
            var ToniKroos = Guid.NewGuid();
            var LukaModric = Guid.NewGuid();
            var MarcoAsensio = Guid.NewGuid();
            var KarimBenzema = Guid.NewGuid();
            var ViniciusJunior = Guid.NewGuid();


            // mock data
            modelBuilder.Entity<Klub>().HasData(
                new Klub() { IdKlub = klubRealMadrytId, Nazwa = "Real Madryt", Stadion = "Estadio Santiago Bernabéu", Trofea = "Liga Mistrzów (13 razy), Primera División (34 razy), Puchar Króla (19 razy), Superpuchar Hiszpanii (11 razy)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null }
            );

            modelBuilder.Entity<Pilkarz>().HasData(
                new Pilkarz { IdPilkarz = ThibautCourtois, Imie = "Thibaut", Nazwisko = "Courtois", Wiek = 29, Pozycja = "Bramkarz", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 350000, IdKlubu = klubRealMadrytId },
                new Pilkarz { IdPilkarz = DaniCarvajal, Imie = "Dani", Nazwisko = "Carvajal", Wiek = 29, Pozycja = "Obrońca", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 250000, IdKlubu = klubRealMadrytId },
                new Pilkarz { IdPilkarz = RaphaelVarane, Imie = "Raphael", Nazwisko = "Varane", Wiek = 28, Pozycja = "Obrońca", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 300000, IdKlubu = klubRealMadrytId },
                new Pilkarz { IdPilkarz = EderMilitao, Imie = "Eder", Nazwisko = "Militao", Wiek = 23, Pozycja = "Obrońca", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = klubRealMadrytId },
                new Pilkarz { IdPilkarz = FerlandMendy, Imie = "Ferland", Nazwisko = "Mendy", Wiek = 26, Pozycja = "Obrońca", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 220000, IdKlubu = klubRealMadrytId },
                new Pilkarz { IdPilkarz = Casemiro, Imie = "Carlos Henrique", Nazwisko = "Casimiro", Wiek = 29, Pozycja = "Pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 280000, IdKlubu = klubRealMadrytId },
                new Pilkarz { IdPilkarz = ToniKroos, Imie = "Toni", Nazwisko = "Kroos", Wiek = 31, Pozycja = "Pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 320000, IdKlubu = klubRealMadrytId },
                new Pilkarz { IdPilkarz = LukaModric, Imie = "Luka", Nazwisko = "Modrić", Wiek = 35, Pozycja = "Pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 350000, IdKlubu = klubRealMadrytId },
                new Pilkarz { IdPilkarz = MarcoAsensio, Imie = "Marco", Nazwisko = "Asensio", Wiek = 25, Pozycja = "Pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 240000, IdKlubu = klubRealMadrytId },
                new Pilkarz { IdPilkarz = KarimBenzema, Imie = "Karim", Nazwisko = "Benzema", Wiek = 33, Pozycja = "Napastnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 450000, IdKlubu = klubRealMadrytId },
                new Pilkarz { IdPilkarz = ViniciusJunior, Imie = "Vinicius", Nazwisko = "Junior", Wiek = 21, Pozycja = "Napastnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 180000, IdKlubu = klubRealMadrytId }
            );

            modelBuilder.Entity<Statystyka>().HasData(
                new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs Atletico Madrid", Gole = 1, ZolteKartki = 0, CzerwoneKartki = 0, Asysty = 0, PrzebiegnietyDystans = 9.2, Ocena = 8.1, IdPilkarz = KarimBenzema },
                new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs FC Barcelona", Gole = 0, ZolteKartki = 1, CzerwoneKartki = 0, Asysty = 1, PrzebiegnietyDystans = 8.4, Ocena = 7.5, IdPilkarz = LukaModric },
                new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs PSG", Gole = 1, ZolteKartki = 0, CzerwoneKartki = 0, Asysty = 2, PrzebiegnietyDystans = 9.8, Ocena = 8.7, IdPilkarz = MarcoAsensio },
                new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs Liverpool", Gole = 0, ZolteKartki = 2, CzerwoneKartki = 0, Asysty = 1, PrzebiegnietyDystans = 8.6, Ocena = 7.9, IdPilkarz = FerlandMendy },
                new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs Bayern Monachium", Gole = 0, ZolteKartki = 1, CzerwoneKartki = 0, Asysty = 0, PrzebiegnietyDystans = 8.2, Ocena = 7.3, IdPilkarz = Casemiro },
                new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs Sevilla", Gole = 1, ZolteKartki = 0, CzerwoneKartki = 0, Asysty = 1, PrzebiegnietyDystans = 9.1, Ocena = 8.0, IdPilkarz = KarimBenzema },
                new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs Valencia", Gole = 2, ZolteKartki = 1, CzerwoneKartki = 0, Asysty = 0, PrzebiegnietyDystans = 8.5, Ocena = 8.2, IdPilkarz = LukaModric },
                new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs Atalanta", Gole = 1, ZolteKartki = 0, CzerwoneKartki = 0, Asysty = 2, PrzebiegnietyDystans = 9.7, Ocena = 8.5, IdPilkarz = MarcoAsensio },
                new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs Chelsea", Gole = 0, ZolteKartki = 2, CzerwoneKartki = 0, Asysty = 1, PrzebiegnietyDystans = 8.9, Ocena = 7.8, IdPilkarz = FerlandMendy },
                new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs Juventus", Gole = 1, ZolteKartki = 1, CzerwoneKartki = 0, Asysty = 0, PrzebiegnietyDystans = 8.3, Ocena = 7.6, IdPilkarz = Casemiro },
                new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs AC Milan", Gole = 1, ZolteKartki = 0, CzerwoneKartki = 0, Asysty = 1, PrzebiegnietyDystans = 9.4, Ocena = 8.3, IdPilkarz = KarimBenzema },
                new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs Manchester City", Gole = 0, ZolteKartki = 1, CzerwoneKartki = 0, Asysty = 2, PrzebiegnietyDystans = 9.6, Ocena = 8.6, IdPilkarz = LukaModric },
                new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs Arsenal", Gole = 1, ZolteKartki = 0, CzerwoneKartki = 0, Asysty = 0, PrzebiegnietyDystans = 8.7, Ocena = 7.9, IdPilkarz = MarcoAsensio },
                new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs Tottenham", Gole = 0, ZolteKartki = 2, CzerwoneKartki = 0, Asysty = 1, PrzebiegnietyDystans = 8.8, Ocena = 7.7, IdPilkarz = FerlandMendy },
                new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs Inter Milan", Gole = 1, ZolteKartki = 1, CzerwoneKartki = 0, Asysty = 0, PrzebiegnietyDystans = 8.5, Ocena = 7.8, IdPilkarz = Casemiro }
            );

            modelBuilder.Entity<Zarzad>().HasData(
                new Zarzad() { IdZarzad = ZarzadRealMadrytId, Pracownicy = new List<Pracownik>(), Budzet = 2500000, Cele = "Liga Mistrzów, Superpuchar Hiszpanii, Naprawa murawy, Renowacja krzesełek, Nowy młody napastnik", IdKlubu = klubRealMadrytId }
            );

            modelBuilder.Entity<Pracownik>().HasData(
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Fiorentino", Nazwisko = "Perez", PESEL = "12345600101", Wiek = 77, WykonywanaFunkcja = "Prezes", IdZarzadu = ZarzadRealMadrytId, Wynagrodzenie = 420000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Carlo", Nazwisko = "Ancelotti", PESEL = "23456700202", Wiek = 64, WykonywanaFunkcja = "Trener", IdZarzadu = ZarzadRealMadrytId, Wynagrodzenie = 350000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Davide", Nazwisko = "Ancelotti", PESEL = "34567800303", Wiek = 33, WykonywanaFunkcja = "Asystent trenera", IdZarzadu = ZarzadRealMadrytId, Wynagrodzenie = 300000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Luis", Nazwisko = "Llopis", PESEL = "45678900404", Wiek = 58, WykonywanaFunkcja = "Trener Bramkarzy", IdZarzadu = ZarzadRealMadrytId, Wynagrodzenie = 150000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Javier", Nazwisko = "Mallo", PESEL = "56789000505", Wiek = 46, WykonywanaFunkcja = "Trener przygotowania fizycznego", IdZarzadu = ZarzadRealMadrytId, Wynagrodzenie = 1250000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Antonio", Nazwisko = "Pintus", PESEL = "67890100606", Wiek = 60, WykonywanaFunkcja = "Trener przygotowania fizycznego", IdZarzadu = ZarzadRealMadrytId, Wynagrodzenie = 125000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Simone", Nazwisko = "Montanaro", PESEL = "78901200707", Wiek = 51, WykonywanaFunkcja = "Trener analityk", IdZarzadu = ZarzadRealMadrytId, Wynagrodzenie = 140000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Iker", Nazwisko = "Casillas", PESEL = "89012300808", Wiek = 42, WykonywanaFunkcja = "Wice-prezes zarządu", IdZarzadu = ZarzadRealMadrytId, Wynagrodzenie = 200000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Juni", Nazwisko = "Calafat", PESEL = "90123400909", Wiek = 50, WykonywanaFunkcja = "Szef skautingu", IdZarzadu = ZarzadRealMadrytId, Wynagrodzenie = 200000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Mateusz", Nazwisko = "Kostyra", PESEL = "780124500909", Wiek = 23, WykonywanaFunkcja = "", IdZarzadu = null, Wynagrodzenie = 10000000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Stanisław", Nazwisko = "Kluczewski", PESEL = "45423402949", Wiek = 23, WykonywanaFunkcja = "", IdZarzadu = null, Wynagrodzenie = 5000000 }
            );

            //// mock data
            //var zarzadRealMadryt = new Zarzad() { IdZarzad = ZarzadRealMadrytId, Pracownicy = new List<Pracownik>(), Budzet = 2500000, Cele = "Liga Mistrzów, Superpuchar Hiszpanii, Naprawa murawy, Renowacja krzesełek, Nowy młody napastnik", IdKlubu = null };
            //var RealMadryt = new Klub()
            //{
            //    IdKlub = klubRealMadrytId,
            //    Nazwa = "Real Madryt",
            //    Stadion = "Estadio Santiago Bernabéu",
            //    Trofea = "Liga Mistrzów (13 razy), Primera División (34 razy), Puchar Króla (19 razy), Superpuchar Hiszpanii (11 razy)",
            //    ObecniPilkarze = new Collection<Pilkarz> { },
            //    ArchiwalniPilkarze = new Collection<Pilkarz> { },
            //    Zarzad = null
            //};
            //var RealMadrytCastilla = new Klub() { IdKlub = klubRealMadrytCastillaId, Nazwa = "Real Madryt Castilla", Stadion = "Estadio Alfredo Di Stéfano", Trofea = "Real Madryt Castilla", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = zarzadRealMadryt };

            ////zarzadRealMadryt.Klub = RealMadryt;
            ////RealMadryt.Zarzad = zarzadRealMadryt;


            //var ThibautCourtois = new Pilkarz() { IdPilkarz = ThibautCourtoisId, Imie = "Thibaut", Nazwisko = "Courtois", Wiek = 29, Pozycja = "Bramkarz", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 350000, IdKlubu = null, Klub = null };
            //var DaniCarvajal = new Pilkarz() { IdPilkarz = DaniCarvajalId, Imie = "Dani", Nazwisko = "Carvajal", Wiek = 29, Pozycja = "Obrońca", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 250000, IdKlubu = null, Klub = null };
            //var RaphaelVarane = new Pilkarz() { IdPilkarz = RaphaelVaraneId, Imie = "Raphael", Nazwisko = "Varane", Wiek = 28, Pozycja = "Obrońca", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 300000, IdKlubu = null, Klub = null };
            //var EderMilitao = new Pilkarz() { IdPilkarz = EderMilitaoId, Imie = "Eder", Nazwisko = "Militao", Wiek = 23, Pozycja = "Obrońca", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = null, Klub = null };
            //var FerlandMendy = new Pilkarz() { IdPilkarz = FerlandMendyId, Imie = "Ferland", Nazwisko = "Mendy", Wiek = 26, Pozycja = "Obrońca", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 220000, IdKlubu = null, Klub = null };
            //var Casemiro = new Pilkarz() { IdPilkarz = CasemiroId, Imie = "Carlos Henrique", Nazwisko = "Casimiro", Wiek = 29, Pozycja = "Pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 280000, IdKlubu = null, Klub = null };
            //var ToniKroos = new Pilkarz() { IdPilkarz = ToniKroosId, Imie = "Toni", Nazwisko = "Kroos", Wiek = 31, Pozycja = "Pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 320000, IdKlubu = null, Klub = null };
            //var LukaModric = new Pilkarz() { IdPilkarz = LukaModricId, Imie = "Luka", Nazwisko = "Modrić", Wiek = 35, Pozycja = "Pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 350000, IdKlubu = null, Klub = null };
            //var MarcoAsensio = new Pilkarz() { IdPilkarz = MarcoAsensioId, Imie = "Marco", Nazwisko = "Asensio", Wiek = 25, Pozycja = "Pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 240000, IdKlubu = null, Klub = null };
            //var KarimBenzema = new Pilkarz() { IdPilkarz = KarimBenzemaId, Imie = "Karim", Nazwisko = "Benzema", Wiek = 33, Pozycja = "Napastnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 450000, IdKlubu = null, Klub = null };
            //var ViniciusJunior = new Pilkarz() { IdPilkarz = ViniciusJuniorId, Imie = "Vinicius", Nazwisko = "Junior", Wiek = 21, Pozycja = "Napastnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 180000, IdKlubu = null, Klub = null };


            ////RealMadryt.ObecniPilkarze = new Collection<Pilkarz> {
            ////  ThibautCourtois, DaniCarvajal, EderMilitao, FerlandMendy, ToniKroos, LukaModric, MarcoAsensio, ViniciusJunior
            ////};

            ////RealMadryt.ArchiwalniPilkarze = new Collection<Pilkarz>
            ////{
            ////    RaphaelVarane, Casemiro, KarimBenzema
            ////};

            //modelBuilder.Entity<Zarzad>().HasData(zarzadRealMadryt);

            //modelBuilder.Entity<Pilkarz>().HasData(
            //    ThibautCourtois, DaniCarvajal, RaphaelVarane, EderMilitao, FerlandMendy, Casemiro, ToniKroos, LukaModric, MarcoAsensio, KarimBenzema, ViniciusJunior);


            //modelBuilder.Entity<Klub>().HasData(RealMadryt, RealMadrytCastilla);


            //modelBuilder.Entity<Statystyka>().HasData(
            //    new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs Atletico Madrid", Gole = 1, ZolteKartki = 0, CzerwoneKartki = 0, Asysty = 0, PrzebiegnietyDystans = 9.2, Ocena = 8.1, IdPilkarz = KarimBenzemaId },
            //    new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs FC Barcelona", Gole = 0, ZolteKartki = 1, CzerwoneKartki = 0, Asysty = 1, PrzebiegnietyDystans = 8.4, Ocena = 7.5, IdPilkarz = LukaModricId },
            //    new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs PSG", Gole = 1, ZolteKartki = 0, CzerwoneKartki = 0, Asysty = 2, PrzebiegnietyDystans = 9.8, Ocena = 8.7, IdPilkarz = MarcoAsensioId },
            //    new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs Liverpool", Gole = 0, ZolteKartki = 2, CzerwoneKartki = 0, Asysty = 1, PrzebiegnietyDystans = 8.6, Ocena = 7.9, IdPilkarz = FerlandMendyId },
            //    new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs Bayern Monachium", Gole = 0, ZolteKartki = 1, CzerwoneKartki = 0, Asysty = 0, PrzebiegnietyDystans = 8.2, Ocena = 7.3, IdPilkarz = CasemiroId },
            //    new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs Sevilla", Gole = 1, ZolteKartki = 0, CzerwoneKartki = 0, Asysty = 1, PrzebiegnietyDystans = 9.1, Ocena = 8.0, IdPilkarz = KarimBenzemaId },
            //    new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs Valencia", Gole = 2, ZolteKartki = 1, CzerwoneKartki = 0, Asysty = 0, PrzebiegnietyDystans = 8.5, Ocena = 8.2, IdPilkarz = LukaModricId },
            //    new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs Atalanta", Gole = 1, ZolteKartki = 0, CzerwoneKartki = 0, Asysty = 2, PrzebiegnietyDystans = 9.7, Ocena = 8.5, IdPilkarz = MarcoAsensioId },
            //    new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs Chelsea", Gole = 0, ZolteKartki = 2, CzerwoneKartki = 0, Asysty = 1, PrzebiegnietyDystans = 8.9, Ocena = 7.8, IdPilkarz = FerlandMendyId },
            //    new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs Juventus", Gole = 1, ZolteKartki = 1, CzerwoneKartki = 0, Asysty = 0, PrzebiegnietyDystans = 8.3, Ocena = 7.6, IdPilkarz = CasemiroId },
            //    new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs AC Milan", Gole = 1, ZolteKartki = 0, CzerwoneKartki = 0, Asysty = 1, PrzebiegnietyDystans = 9.4, Ocena = 8.3, IdPilkarz = KarimBenzemaId },
            //    new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs Manchester City", Gole = 0, ZolteKartki = 1, CzerwoneKartki = 0, Asysty = 2, PrzebiegnietyDystans = 9.6, Ocena = 8.6, IdPilkarz = LukaModricId },
            //    new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs Arsenal", Gole = 1, ZolteKartki = 0, CzerwoneKartki = 0, Asysty = 0, PrzebiegnietyDystans = 8.7, Ocena = 7.9, IdPilkarz = MarcoAsensioId },
            //    new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs Tottenham", Gole = 0, ZolteKartki = 2, CzerwoneKartki = 0, Asysty = 1, PrzebiegnietyDystans = 8.8, Ocena = 7.7, IdPilkarz = FerlandMendyId },
            //    new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs Inter Milan", Gole = 1, ZolteKartki = 1, CzerwoneKartki = 0, Asysty = 0, PrzebiegnietyDystans = 8.5, Ocena = 7.8, IdPilkarz = CasemiroId }
            //);


            //modelBuilder.Entity<Pracownik>().HasData(
            //    new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Fiorentino", Nazwisko = "Perez", PESEL = "12345600101", Wiek = 77, WykonywanaFunkcja = "Prezes", IdZarzadu = ZarzadRealMadrytId, Zarzad = zarzadRealMadryt, Wynagrodzenie = 420000 },
            //    new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Carlo", Nazwisko = "Ancelotti", PESEL = "23456700202", Wiek = 64, WykonywanaFunkcja = "Trener", IdZarzadu = ZarzadRealMadrytId, Zarzad = zarzadRealMadryt, Wynagrodzenie = 350000 },
            //    new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Davide", Nazwisko = "Ancelotti", PESEL = "34567800303", Wiek = 33, WykonywanaFunkcja = "Asystent trenera", IdZarzadu = ZarzadRealMadrytId, Zarzad = zarzadRealMadryt, Wynagrodzenie = 300000 },
            //    new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Luis", Nazwisko = "Llopis", PESEL = "45678900404", Wiek = 58, WykonywanaFunkcja = "Trener Bramkarzy", IdZarzadu = ZarzadRealMadrytId, Zarzad = zarzadRealMadryt, Wynagrodzenie = 150000 },
            //    new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Javier", Nazwisko = "Mallo", PESEL = "56789000505", Wiek = 46, WykonywanaFunkcja = "Trener przygotowania fizycznego", IdZarzadu = ZarzadRealMadrytId, Zarzad = zarzadRealMadryt, Wynagrodzenie = 1250000 },
            //    new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Antonio", Nazwisko = "Pintus", PESEL = "67890100606", Wiek = 60, WykonywanaFunkcja = "Trener przygotowania fizycznego", IdZarzadu = ZarzadRealMadrytId, Zarzad = zarzadRealMadryt, Wynagrodzenie = 125000 },
            //    new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Simone", Nazwisko = "Montanaro", PESEL = "78901200707", Wiek = 51, WykonywanaFunkcja = "Trener analityk", IdZarzadu = ZarzadRealMadrytId, Zarzad = zarzadRealMadryt, Wynagrodzenie = 140000 },
            //    new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Iker", Nazwisko = "Casillas", PESEL = "89012300808", Wiek = 42, WykonywanaFunkcja = "Wice-prezes zarządu", IdZarzadu = ZarzadRealMadrytId, Zarzad = zarzadRealMadryt, Wynagrodzenie = 200000 },
            //    new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Juni", Nazwisko = "Calafat", PESEL = "90123400909", Wiek = 50, WykonywanaFunkcja = "Szef skautingu", IdZarzadu = ZarzadRealMadrytId, Zarzad = zarzadRealMadryt, Wynagrodzenie = 200000 },
            //    new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Mateusz", Nazwisko = "Kostyra", PESEL = "780124500909", Wiek = 23, WykonywanaFunkcja = "", IdZarzadu = ZarzadRealMadrytId, Zarzad = zarzadRealMadryt, Wynagrodzenie = 10000000 },
            //    new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Stanisław", Nazwisko = "Kluczewski", PESEL = "45423402949", Wiek = 23, WykonywanaFunkcja = "", IdZarzadu = ZarzadRealMadrytId, Zarzad = zarzadRealMadryt, Wynagrodzenie = 5000000 }
            //);



        }
    }
}