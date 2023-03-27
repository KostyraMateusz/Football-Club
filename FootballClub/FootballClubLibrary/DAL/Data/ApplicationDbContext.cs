using FootballClubLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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


            // Entity Framework does not support collections of primitive types. Converting ICollection to string of max value
            modelBuilder.Entity<Klub>()
                .Property(e => e.Trofea)
                .HasConversion(v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

            modelBuilder.Entity<Zarzad>()
                .Property(e => e.Cele)
                .HasConversion(v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));


            // mock data
            modelBuilder.Entity<Klub>()
                .HasData(
                    new Klub()
                    {
                        IdKlub = Guid.NewGuid(),
                        Nazwa = "Klub1",
                        Stadion = "Stadion1",
                        Trofea = null,
                        ObecniPilkarze = null,
                        ArchwilaniPilkarze = null,
                        Zarzad = null,

                    },
                    new Klub()
                    {
                        IdKlub = Guid.NewGuid(),
                        Nazwa = "Klub2",
                        Stadion = "Stadion2",
                        Trofea = null,
                        ObecniPilkarze = null,
                        ArchwilaniPilkarze = null,
                        Zarzad = null,
                    }
                ); ;

            modelBuilder.Entity<Pilkarz>()
                .HasData(
                new Pilkarz()
                {
                    IdPilkarz = Guid.NewGuid(),
                    Pozycja = "Napastnik",
                    Statystyki = null,
                    ArchiwalneKluby = null,
                    Wynagrodzenie = 1000,
                    IdKlubu = null,
                    Klub = null
                },
                new Pilkarz()
                {
                    IdPilkarz = Guid.NewGuid(),
                    Pozycja = "Pomocnik",
                    Statystyki = null,
                    ArchiwalneKluby = null,
                    Wynagrodzenie = 2000,
                    IdKlubu = null,
                    Klub = null
                }
                );

            modelBuilder.Entity<Pracownik>()
                .HasData(
                    new Pracownik()
                    {
                        IdPracownik = Guid.NewGuid(),
                        Imie = "Mateusz",
                        Nazwisko = "Kostyra",
                        PESEL = "00124168751",
                        Wiek = 23,
                        Wynagrodzenie = 50000,
                        WykonywanaFunkcja = "Prezes",
                        IdZarzadu = null,
                        Zarzad = null
                    },
                    new Pracownik()
                    {
                        IdPracownik = Guid.NewGuid(),
                        Imie = "Stanisław",
                        Nazwisko = "Kluczewski",
                        Wynagrodzenie = 50000,
                        PESEL = "00864164771",
                        Wiek = 23,
                        WykonywanaFunkcja = "Vc-Prezes",
                        IdZarzadu = null,
                        Zarzad = null
                    }
                );

            modelBuilder.Entity<Statystyka>()
                .HasData(
                new Statystyka
                {
                    IdStatystyka = Guid.NewGuid(),
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
                        Cele = null,
                        Klub = null,
                        IdKlubu = null
                    }
                );
        }
    }
}
