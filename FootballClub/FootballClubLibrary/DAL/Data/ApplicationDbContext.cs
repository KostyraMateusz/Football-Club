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
            var RealMadrytId = Guid.NewGuid();
            var ZarzadRealMadrytId = Guid.NewGuid();

            var RealMadrytCastillaId = Guid.NewGuid();
            var ZarzadRealMadrytCastillaId = Guid.NewGuid();

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


            // mock data
            modelBuilder.Entity<Klub>().HasData(
                new Klub() { IdKlub = RealMadrytId, Nazwa = "Real Madryt", Stadion = "Estadio Santiago Bernabéu", Trofea = "Liga Mistrzów (13 razy), Primera División (34 razy), Puchar Króla (19 razy), Superpuchar Hiszpanii (11 razy)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null },
                new Klub() { IdKlub = RealMadrytCastillaId, Nazwa = "Real Madrid Castilla CF", Stadion = "Estadio Alfredo Di Stéfano", Trofea = "Segunda División (1 raz), Segunda División B (5 razy), Tercera División (6 razy), Trofeo Teide (3 razy), Torneo de San Ginés (2 razy)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null }
            );

            modelBuilder.Entity<Pilkarz>().HasData(
                new Pilkarz { IdPilkarz = ThibautCourtois, Imie = "Thibaut", Nazwisko = "Courtois", Wiek = 29, Pozycja = "Bramkarz", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 350000, IdKlubu = RealMadrytId },
                new Pilkarz { IdPilkarz = AndrijLunin, Imie = "Andrij", Nazwisko = "Łunin", Wiek = 24, Pozycja = "Bramkarz", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 150000, IdKlubu = RealMadrytId },
                new Pilkarz { IdPilkarz = DaniCarvajal, Imie = "Dani", Nazwisko = "Carvajal", Wiek = 29, Pozycja = "Prawy obrońca", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 250000, IdKlubu = RealMadrytId },
                new Pilkarz { IdPilkarz = EderMilitao, Imie = "Eder", Nazwisko = "Militao", Wiek = 23, Pozycja = "Środkowy obrońca", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 230000, IdKlubu = RealMadrytId },
                new Pilkarz { IdPilkarz = DavidAlaba, Imie = "David", Nazwisko = "Alaba", Wiek = 31, Pozycja = "Środkowy obrońca", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytId },
                new Pilkarz { IdPilkarz = NachoFernandez, Imie = "Nacho", Nazwisko = "Fernández", Wiek = 33, Pozycja = "Środkowy obrońca", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 240000, IdKlubu = RealMadrytId },
                new Pilkarz { IdPilkarz = AlvaroOdriozola, Imie = "Álvaro", Nazwisko = "Odriozola", Wiek = 27, Pozycja = "Prawy obrońca", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 160000, IdKlubu = RealMadrytId },
                new Pilkarz { IdPilkarz = LucasVazquez, Imie = "Lucas", Nazwisko = "Vázquez", Wiek = 32, Pozycja = "Prawy obrońca", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 265000, IdKlubu = RealMadrytId },
                new Pilkarz { IdPilkarz = FranGarcia, Imie = "Fran", Nazwisko = "García", Wiek = 23, Pozycja = "Lewy obrońca", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 170000, IdKlubu = RealMadrytId },
                new Pilkarz { IdPilkarz = AntonioRudiger, Imie = "Antonio", Nazwisko = "Rüdiger", Wiek = 30, Pozycja = "Środkowy obrońca", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 195000, IdKlubu = RealMadrytId },
                new Pilkarz { IdPilkarz = FerlandMendy, Imie = "Ferland", Nazwisko = "Mendy", Wiek = 26, Pozycja = "Lewy obrońca", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 245000, IdKlubu = RealMadrytId },
                new Pilkarz { IdPilkarz = JudeBellingham, Imie = "Jude", Nazwisko = "Bellingham", Wiek = 20, Pozycja = "Środkowy pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 360000, IdKlubu = RealMadrytId },
                new Pilkarz { IdPilkarz = ToniKroos, Imie = "Toni", Nazwisko = "Kroos", Wiek = 33, Pozycja = "Środkowy pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 250000, IdKlubu = RealMadrytId },
                new Pilkarz { IdPilkarz = LukaModric, Imie = "Luka", Nazwisko = "Modrić", Wiek = 37, Pozycja = "Środkowy pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 270000, IdKlubu = RealMadrytId },
                new Pilkarz { IdPilkarz = EduardoCamavinga, Imie = "Eduardo", Nazwisko = "Camavinga", Wiek = 20, Pozycja = "Środkowy pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 235000, IdKlubu = RealMadrytId },
                new Pilkarz { IdPilkarz = FedericoValverde, Imie = "Federico", Nazwisko = "Valverde", Wiek = 25, Pozycja = "Środkowy pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 255000, IdKlubu = RealMadrytId },
                new Pilkarz { IdPilkarz = AurelienTchouameni, Imie = "Aurélien", Nazwisko = "Tchouaméni", Wiek = 23, Pozycja = "Środkowy pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 236000, IdKlubu = RealMadrytId },
                new Pilkarz { IdPilkarz = DanielCeballos, Imie = "Daniel", Nazwisko = "Ceballos", Wiek = 26, Pozycja = "Środkowy pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 175000, IdKlubu = RealMadrytId },
                new Pilkarz { IdPilkarz = ArdaGuler, Imie = "Arda", Nazwisko = "Güler", Wiek = 18, Pozycja = "Ofensywny pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 140000, IdKlubu = RealMadrytId },
                new Pilkarz { IdPilkarz = ViniciusJunior, Imie = "Vinicius", Nazwisko = "Junior", Wiek = 21, Pozycja = "Lewy skrzydłowy", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 420000, IdKlubu = RealMadrytId },
                new Pilkarz { IdPilkarz = RodrygoGoes, Imie = "Rodrygo", Nazwisko = "Goes", Wiek = 22, Pozycja = "Prawy krzydłowy", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 195000, IdKlubu = RealMadrytId },
                new Pilkarz { IdPilkarz = Joselu, Imie = "Joselu", Nazwisko = "Luís Sanmartín Mato", Wiek = 33, Pozycja = "Środkowy napastnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 150000, IdKlubu = RealMadrytId },
                new Pilkarz { IdPilkarz = BrahimDiaz, Imie = "Brahim", Nazwisko = "Díaz", Wiek = 23, Pozycja = "Prawy skrzydłowy", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytId },
                
                new Pilkarz { IdPilkarz = LucasCanizares, Imie = "Lucas", Nazwisko = "Cañizares", Wiek = 21, Pozycja = "Bramkarz", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytCastillaId },
                new Pilkarz { IdPilkarz = MarioDeLuis, Imie = "Mario", Nazwisko = "De Luis", Wiek = 21, Pozycja = "Bramkarz", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytCastillaId },
                new Pilkarz { IdPilkarz = ViniciusTobias, Imie = "Vinicius", Nazwisko = "Tobias", Wiek = 19, Pozycja = "Prawy obrońca", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytCastillaId },
                new Pilkarz { IdPilkarz = AlvaroCarrillo, Imie = "Álvaro", Nazwisko = "Carrillo", Wiek = 21, Pozycja = "Środkowy obrońca", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytCastillaId },
                new Pilkarz { IdPilkarz = PabloRamon, Imie = "Pablo", Nazwisko = "Ramón", Wiek = 22, Pozycja = "Środkowy obrońca", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytCastillaId },
                new Pilkarz { IdPilkarz = LucasAlcazar, Imie = "Lucas", Nazwisko = "Alcázar", Wiek = 21, Pozycja = "Środkowy obrońca", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytCastillaId },
                new Pilkarz { IdPilkarz = MarvelousGarzon, Imie = "Marvelous", Nazwisko = "Garzón", Wiek = 20, Pozycja = "Środkowy obrońca", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytCastillaId },
                new Pilkarz { IdPilkarz = TheoFernandez, Imie = "Theo", Nazwisko = "Fernández", Wiek = 21, Pozycja = "Środkowy pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytCastillaId },
                new Pilkarz { IdPilkarz = CarlosDotor, Imie = "Carlos", Nazwisko = "Dotor", Wiek = 22, Pozycja = "Środkowy pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytCastillaId },
                new Pilkarz { IdPilkarz = PeterGonzalez, Imie = "Peter", Nazwisko = "González", Wiek = 21, Pozycja = "Środkowy pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytCastillaId },
                new Pilkarz { IdPilkarz = AlvaroMartin, Imie = "Álvaro", Nazwisko = "Martín", Wiek = 22, Pozycja = "Środkowy pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytCastillaId },
                new Pilkarz { IdPilkarz = TakuhiroNakai, Imie = "Takuhiro", Nazwisko = "Nakai", Wiek = 19, Pozycja = "Środkowy pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytCastillaId },
                new Pilkarz { IdPilkarz = AlvaroLeiva, Imie = "Álvaro", Nazwisko = "Leiva", Wiek = 18, Pozycja = "Środkowy pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytCastillaId },
                new Pilkarz { IdPilkarz = JavierVillar, Imie = "Javier", Nazwisko = "Villar", Wiek = 20, Pozycja = "Środkowy pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytCastillaId },
                new Pilkarz { IdPilkarz = OscarAranda, Imie = "Óscar", Nazwisko = "Aranda", Wiek = 21, Pozycja = "Środkowy pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytCastillaId },
                new Pilkarz { IdPilkarz = RafaelLlorente, Imie = "Rafael", Nazwisko = "Llorente", Wiek = 20, Pozycja = "Środkowy pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytCastillaId },
                new Pilkarz { IdPilkarz = MarioMartin, Imie = "Mario", Nazwisko = "Martín", Wiek = 19, Pozycja = "Środkowy pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytCastillaId },
                new Pilkarz { IdPilkarz = SergioArribas, Imie = "Sergio", Nazwisko = "Arribas", Wiek = 21, Pozycja = "Środkowy pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytCastillaId },
                new Pilkarz { IdPilkarz = NoelLopez, Imie = "Noel", Nazwisko = "López", Wiek = 20, Pozycja = "Środkowy napastnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytCastillaId },
                new Pilkarz { IdPilkarz = IkerBravo, Imie = "Iker", Nazwisko = "Bravo", Wiek = 18, Pozycja = "Środkowy napastnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 200000, IdKlubu = RealMadrytCastillaId }
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
                new Zarzad() { IdZarzad = ZarzadRealMadrytId, Pracownicy = new List<Pracownik>(), Budzet = 2500000, Cele = "Liga Mistrzów, Superpuchar Hiszpanii, Naprawa murawy, Renowacja krzesełek, Nowy młody napastnik", IdKlubu = RealMadrytId },
                new Zarzad() { IdZarzad = ZarzadRealMadrytCastillaId, Pracownicy = new List<Pracownik>(), Budzet = 1250000, Cele = "Awans do Segunda División", IdKlubu = RealMadrytCastillaId }
            );

            modelBuilder.Entity<Pracownik>().HasData(
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Fiorentino", Nazwisko = "Perez", PESEL = "12345600101", Wiek = 77, WykonywanaFunkcja = "Prezes", IdZarzadu = ZarzadRealMadrytId, Wynagrodzenie = 420000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Carlo", Nazwisko = "Ancelotti", PESEL = "23456700202", Wiek = 64, WykonywanaFunkcja = "Trener", IdZarzadu = ZarzadRealMadrytId, Wynagrodzenie = 350000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Davide", Nazwisko = "Ancelotti", PESEL = "34567800303", Wiek = 33, WykonywanaFunkcja = "Asystent trenera", IdZarzadu = ZarzadRealMadrytId, Wynagrodzenie = 300000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Antonio", Nazwisko = "Pintus", PESEL = "67890100606", Wiek = 60, WykonywanaFunkcja = "Szef od przygotowania fizycznego", IdZarzadu = ZarzadRealMadrytId, Wynagrodzenie = 125000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Francesco", Nazwisko = "Mauri", PESEL = "87890400406", Wiek = 34, WykonywanaFunkcja = "Fizjoterapeuta", IdZarzadu = ZarzadRealMadrytId, Wynagrodzenie = 125000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Simone", Nazwisko = "Montanaro", PESEL = "78901200707", Wiek = 51, WykonywanaFunkcja = "Trener analityk", IdZarzadu = ZarzadRealMadrytId, Wynagrodzenie = 140000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Mino", Nazwisko = "Fulco", PESEL = "88501220767", Wiek = 51, WykonywanaFunkcja = "Dietetyk", IdZarzadu = ZarzadRealMadrytId, Wynagrodzenie = 140000 },
                
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Raúl", Nazwisko = "González", PESEL = "70631490286", Wiek = 46, WykonywanaFunkcja = "Trener", IdZarzadu = ZarzadRealMadrytCastillaId, Wynagrodzenie = 200000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Alberto", Nazwisko = "Garrido", PESEL = "45098763201", Wiek = 47, WykonywanaFunkcja = "Asystent trenera", IdZarzadu = ZarzadRealMadrytCastillaId, Wynagrodzenie = 140000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Nacho", Nazwisko = "S. García", PESEL = "83456789021", Wiek = 46, WykonywanaFunkcja = "Trener przygotowania fizycznego", IdZarzadu = ZarzadRealMadrytCastillaId, Wynagrodzenie = 90000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Víctor", Nazwisko = "P. Hernández", PESEL = "79806543210", Wiek = 45, WykonywanaFunkcja = "Trener przygotowania fizycznego", IdZarzadu = ZarzadRealMadrytCastillaId, Wynagrodzenie = 90000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Mario", Nazwisko = "Soria Amor", PESEL = "70123450789", Wiek = 53, WykonywanaFunkcja = "Trener bramkarzy", IdZarzadu = ZarzadRealMadrytCastillaId, Wynagrodzenie = 100000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Javier", Nazwisko = "de Tomás Maroto", PESEL = "84501230769", Wiek = 46, WykonywanaFunkcja = "Fizjoterapeuta", IdZarzadu = ZarzadRealMadrytCastillaId, Wynagrodzenie = 75000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Tirso", Nazwisko = "Álvarez", PESEL = "89765432109", Wiek = 40, WykonywanaFunkcja = "Fizjoterapeuta", IdZarzadu = ZarzadRealMadrytCastillaId, Wynagrodzenie = 75000 },
                new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Álvaro", Nazwisko = "Tavira", PESEL = "71234567890", Wiek = 35, WykonywanaFunkcja = "Fizjoterapeuta", IdZarzadu = ZarzadRealMadrytCastillaId, Wynagrodzenie = 75000 }
            );
        }
    }
}