using FootballClubLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.ObjectModel;
using System.Drawing;

namespace FootballClubLibrary.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Klub> Kluby { get; set; }
        public DbSet<Pilkarz> Pilkarze { get; set; }
        public DbSet<Pracownik> Pracownicy { get; set; }
        public DbSet<Statystyka> Statystyki { get; set; }
        public DbSet<Zarzad> Zarzady { get; set; }

        public ApplicationDbContext() : base()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FootballClub;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.NavigationBaseIncludeIgnored));
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
                .WithMany(p => p.ArchwilaniPilkarze);


            // Klucze dla klubu
            var klubRealMadrytId = Guid.NewGuid();
            var ZarzadRealMadrytId = Guid.NewGuid();

            var klubFCBarcelonaId = Guid.NewGuid();
            var zarzadFCBarcelonaId = Guid.NewGuid();

            var klubJuventusId = Guid.NewGuid();
            var zarzadJuventusId = Guid.NewGuid();


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
                new Klub() { IdKlub = klubRealMadrytId, Nazwa = "Real Madryt", Stadion = "Estadio Santiago Bernabéu", Trofea = "Liga Mistrzów (13 razy), Primera División (34 razy), Puchar Króla (19 razy), Superpuchar Hiszpanii (11 razy)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchwilaniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = klubFCBarcelonaId, Nazwa = "FC Barcelona", Stadion = "Camp Nou", Trofea = "Liga Mistrzów (5 razy), Primera División (26 razy), Puchar Króla (31 razy), Superpuchar Hiszpanii (13 razy)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchwilaniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = klubJuventusId, Nazwa = "Juventus", Stadion = "Allianz Stadium", Trofea = "Liga Mistrzów (2 razy), Serie A (36 razy), Puchar Włoch (14 razy), Superpuchar Włoch (9 razy)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchwilaniPilkarze = new Collection<Pilkarz> { }, Zarzad = null }
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

            modelBuilder.Entity<Pracownik>().HasData(
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Fiorentino", Nazwisko = "Perez", PESEL = "12345600101", Wiek = 77, WykonywanaFunkcja = "Prezes", IdZarzadu = ZarzadRealMadrytId, Wynagrodzenie = 420000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Carlo", Nazwisko = "Ancelotti", PESEL = "23456700202", Wiek = 64, WykonywanaFunkcja = "Trener", IdZarzadu = ZarzadRealMadrytId, Wynagrodzenie = 350000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Davide", Nazwisko = "Ancelotti", PESEL = "34567800303", Wiek = 33, WykonywanaFunkcja = "Asystent trenera", IdZarzadu = ZarzadRealMadrytId, Wynagrodzenie = 300000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Luis", Nazwisko = "Llopis", PESEL = "45678900404", Wiek = 58, WykonywanaFunkcja = "Trener Bramkarzy", IdZarzadu = ZarzadRealMadrytId, Wynagrodzenie = 150000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Javier", Nazwisko = "Mallo", PESEL = "56789000505", Wiek = 46, WykonywanaFunkcja = "Trener przygotowania fizycznego", IdZarzadu = ZarzadRealMadrytId, Wynagrodzenie = 1250000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Antonio", Nazwisko = "Pintus", PESEL = "67890100606", Wiek = 60, WykonywanaFunkcja = "Trener przygotowania fizycznego", IdZarzadu = ZarzadRealMadrytId, Wynagrodzenie = 125000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Simone", Nazwisko = "Montanaro", PESEL = "78901200707", Wiek = 51, WykonywanaFunkcja = "Trener analityk", IdZarzadu = ZarzadRealMadrytId, Wynagrodzenie = 140000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Iker", Nazwisko = "Casillas", PESEL = "89012300808", Wiek = 42, WykonywanaFunkcja = "Wice-prezes zarządu", IdZarzadu = ZarzadRealMadrytId, Wynagrodzenie = 200000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Juni", Nazwisko = "Calafat", PESEL = "90123400909", Wiek = 50, WykonywanaFunkcja = "Szef skautingu", IdZarzadu = ZarzadRealMadrytId, Wynagrodzenie = 200000 }
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
                new Zarzad() { IdZarzad = ZarzadRealMadrytId, Pracownicy = null, Budzet = 2500000, Cele = "Liga Mistrzów, Superpuchar Hiszpanii, Naprawa murawy, Renowacja krzesełek, Nowy młody napastnik", IdKlubu = klubRealMadrytId },
                new Zarzad() { IdZarzad = zarzadFCBarcelonaId, Pracownicy = null, Budzet = 2000000, Cele = "Liga Mistrzów, Primera División, Puchar Króla, Odnowienie akademii młodzieżowej, Wzmocnienie składu", IdKlubu = klubFCBarcelonaId },
                new Zarzad() { IdZarzad = zarzadJuventusId, Pracownicy = null, Budzet = 1800000, Cele = "Liga Mistrzów, Serie A, Puchar Włoch, Akademia młodzieżowa, Rozwój infrastruktury", IdKlubu = klubJuventusId }
            );
        }
    }
}