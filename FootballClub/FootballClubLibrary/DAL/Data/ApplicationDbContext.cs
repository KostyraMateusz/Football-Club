using FootballClubLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubLibrary.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Klub> Kluby { get; set; }
        public DbSet<Pilkarz> Pilkarze { get; set; }
        public DbSet<Pracownik> Pracownicy { get; set; }
        public DbSet<Statystyka> Statystyki { get; set; }
        public DbSet<Zarzad> Zarzady { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FootballClub;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            optionsBuilder.UseSqlServer(connectionString);
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


            // mock data
            modelBuilder.Entity<Klub>()
                .HasData(
                    new Klub()
                    {
                        IdKlub = Guid.NewGuid(),
                        Nazwa = "Real Madryt",
                        Stadion = "Estadio Santiago Bernabéu",
                        Trofea = "Liga Mistrzów",
                        ObecniPilkarze = new Collection<Pilkarz> { },
                        ArchwilaniPilkarze = new Collection<Pilkarz> { },
                        Zarzad = null

                    },
                    new Klub()
                    {
                        IdKlub = Guid.NewGuid(),
                        Nazwa = "FC Barcelona",
                        Stadion = "Camp Nou",
                        Trofea = "La Liga",
                        ObecniPilkarze = new Collection<Pilkarz> { },
                        ArchwilaniPilkarze = new Collection<Pilkarz> { },
                        Zarzad = null
                    }
                ); ;

            modelBuilder.Entity<Pilkarz>()
                .HasData(
                new Pilkarz { IdPilkarz = Guid.NewGuid(), Imie = "Robert", Nazwisko = "Lewandowski", Wiek = 35, Pozycja = "Napastnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 440000, IdKlubu = null },
                new Pilkarz { IdPilkarz = Guid.NewGuid(), Imie = "Sergio", Nazwisko = "Busquets", Wiek = 34, Pozycja = "Pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 350000, IdKlubu = null }
                );

            modelBuilder.Entity<Pracownik>()
                .HasData(
                   new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Fiorentino", Nazwisko = "Perez", PESEL = "12345678901", Wiek = 77, WykonywanaFunkcja = "Prezes", IdZarzadu = null, Wynagrodzenie = 340000 },
                   new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Carlo", Nazwisko = "Carlo Ancelotti", PESEL = "12345600101", Wiek = 63, WykonywanaFunkcja = "Trener", IdZarzadu = null, Wynagrodzenie = 340000, },
                   new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Joan", Nazwisko = "Laporta", PESEL = "12345338901", Wiek = 60, WykonywanaFunkcja = "Prezes", IdZarzadu = null, Wynagrodzenie = 340000 },
                   new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Xavi", Nazwisko = "Hernandez", PESEL = "12345600101", Wiek = 43, WykonywanaFunkcja = "Trener", IdZarzadu = null, Wynagrodzenie = 340000 }
                );

            modelBuilder.Entity<Statystyka>()
                .HasData(
                new Statystyka
                {
                    IdStatystyka = Guid.NewGuid(),
                    Mecz = "Real Madrid vs FC Barcelona",
                    Gole = 4,
                    Asysty = 1,
                    ZolteKartki = 0,
                    CzerwoneKartki = 1,
                    PrzebiegnietyDystans = 10.4,
                    Ocena = 8.7,
                    IdPilkarz = null,
                    Pilkarz = null
                },
                new Statystyka
                {
                    IdStatystyka = Guid.NewGuid(),
                    Mecz = "FC Barcelona vs Real Madrid",
                    Gole = 0,
                    ZolteKartki = 2,
                    CzerwoneKartki = 1,
                    Asysty = 2,
                    PrzebiegnietyDystans = 8.4,
                    Ocena = 7.5,
                    IdPilkarz = null,
                    Pilkarz = null
                }
                );;

            modelBuilder.Entity<Zarzad>()
                .HasData(
                    new Zarzad()
                    {
                        IdZarzad = Guid.NewGuid(),
                        Pracownicy = null,
                        Budzet = 2000,
                        Cele = "Cel 1",
                        Klub = null,
                        IdKlubu = null
                    }
                );
        }
    }
}
