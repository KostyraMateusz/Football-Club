﻿// <auto-generated />
using System;
using FootballClubLibrary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FootballClubLibrary.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230327180236_final")]
    partial class final
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FootballClubLibrary.Models.Klub", b =>
                {
                    b.Property<Guid>("IdKlub")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nazwa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Stadion")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Trofea")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdKlub");

                    b.ToTable("Kluby");

                    b.HasData(
                        new
                        {
                            IdKlub = new Guid("f3f899c4-b724-4436-bb01-845eb6df8637"),
                            Nazwa = "Klub1",
                            Stadion = "Stadion1"
                        },
                        new
                        {
                            IdKlub = new Guid("2b9f0aa6-f441-4488-8989-9925f520cacd"),
                            Nazwa = "Klub2",
                            Stadion = "Stadion2"
                        });
                });

            modelBuilder.Entity("FootballClubLibrary.Models.Pilkarz", b =>
                {
                    b.Property<Guid>("IdPilkarz")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdKlubu")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Pozycja")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal>("Wynagrodzenie")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdPilkarz");

                    b.HasIndex("IdKlubu");

                    b.ToTable("Pilkarze");

                    b.HasData(
                        new
                        {
                            IdPilkarz = new Guid("caa23349-53e5-40e2-b0cf-d0b7050b751c"),
                            Pozycja = "Napastnik",
                            Wynagrodzenie = 1000m
                        },
                        new
                        {
                            IdPilkarz = new Guid("5e4648b9-119e-43f5-b086-f5ea56267848"),
                            Pozycja = "Pomocnik",
                            Wynagrodzenie = 2000m
                        });
                });

            modelBuilder.Entity("FootballClubLibrary.Models.Pracownik", b =>
                {
                    b.Property<Guid>("IdPracownik")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdZarzadu")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Imie")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Nazwisko")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PESEL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Wiek")
                        .HasColumnType("int");

                    b.Property<string>("WykonywanaFunkcja")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal>("Wynagrodzenie")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdPracownik");

                    b.HasIndex("IdZarzadu");

                    b.ToTable("Pracownicy");

                    b.HasData(
                        new
                        {
                            IdPracownik = new Guid("fc089e06-d34e-496d-b149-03c18ebe278a"),
                            Imie = "Mateusz",
                            Nazwisko = "Kostyra",
                            PESEL = "00124168751",
                            Wiek = 23,
                            WykonywanaFunkcja = "Prezes",
                            Wynagrodzenie = 50000m
                        },
                        new
                        {
                            IdPracownik = new Guid("bd860188-d4eb-4f94-abba-6df7c0e6d3d7"),
                            Imie = "Stanisław",
                            Nazwisko = "Kluczewski",
                            PESEL = "00864164771",
                            Wiek = 23,
                            WykonywanaFunkcja = "Vc-Prezes",
                            Wynagrodzenie = 50000m
                        });
                });

            modelBuilder.Entity("FootballClubLibrary.Models.Statystyka", b =>
                {
                    b.Property<Guid>("IdStatystyka")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Asysty")
                        .HasColumnType("int");

                    b.Property<int>("CzerwoneKartki")
                        .HasColumnType("int");

                    b.Property<int>("Gole")
                        .HasColumnType("int");

                    b.Property<Guid?>("IdPilkarz")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Mecz")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Ocena")
                        .HasColumnType("float");

                    b.Property<double>("PrzebiegnietyDystans")
                        .HasColumnType("float");

                    b.Property<int>("ZolteKartki")
                        .HasColumnType("int");

                    b.HasKey("IdStatystyka");

                    b.HasIndex("IdPilkarz");

                    b.ToTable("Statystki");

                    b.HasData(
                        new
                        {
                            IdStatystyka = new Guid("484be89a-56f2-4b50-a87b-84786ddfb734"),
                            Asysty = 1,
                            CzerwoneKartki = 1,
                            Gole = 4,
                            Ocena = 8.6999999999999993,
                            PrzebiegnietyDystans = 10.4,
                            ZolteKartki = 0
                        },
                        new
                        {
                            IdStatystyka = new Guid("87c2050c-3b0e-4817-88fe-cb3fa37b6384"),
                            Asysty = 2,
                            CzerwoneKartki = 1,
                            Gole = 0,
                            Ocena = 7.5,
                            PrzebiegnietyDystans = 8.4000000000000004,
                            ZolteKartki = 2
                        });
                });

            modelBuilder.Entity("FootballClubLibrary.Models.Zarzad", b =>
                {
                    b.Property<Guid>("IdZarzad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Budzet")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Cele")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("IdKlubu")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdZarzad");

                    b.HasIndex("IdKlubu")
                        .IsUnique()
                        .HasFilter("[IdKlubu] IS NOT NULL");

                    b.ToTable("Zarzady");

                    b.HasData(
                        new
                        {
                            IdZarzad = new Guid("7c9dddda-9e1e-4bd3-a255-7cfb0fb9064d"),
                            Budzet = 2000m
                        });
                });

            modelBuilder.Entity("KlubPilkarz", b =>
                {
                    b.Property<Guid>("ArchiwalneKlubyIdKlub")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ArchwilaniPilkarzeIdPilkarz")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ArchiwalneKlubyIdKlub", "ArchwilaniPilkarzeIdPilkarz");

                    b.HasIndex("ArchwilaniPilkarzeIdPilkarz");

                    b.ToTable("KlubPilkarz");
                });

            modelBuilder.Entity("FootballClubLibrary.Models.Pilkarz", b =>
                {
                    b.HasOne("FootballClubLibrary.Models.Klub", "Klub")
                        .WithMany("ObecniPilkarze")
                        .HasForeignKey("IdKlubu")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Klub");
                });

            modelBuilder.Entity("FootballClubLibrary.Models.Pracownik", b =>
                {
                    b.HasOne("FootballClubLibrary.Models.Zarzad", "Zarzad")
                        .WithMany("Pracownicy")
                        .HasForeignKey("IdZarzadu")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Zarzad");
                });

            modelBuilder.Entity("FootballClubLibrary.Models.Statystyka", b =>
                {
                    b.HasOne("FootballClubLibrary.Models.Pilkarz", "Pilkarz")
                        .WithMany("Statystyki")
                        .HasForeignKey("IdPilkarz")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Pilkarz");
                });

            modelBuilder.Entity("FootballClubLibrary.Models.Zarzad", b =>
                {
                    b.HasOne("FootballClubLibrary.Models.Klub", "Klub")
                        .WithOne("Zarzad")
                        .HasForeignKey("FootballClubLibrary.Models.Zarzad", "IdKlubu")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Klub");
                });

            modelBuilder.Entity("KlubPilkarz", b =>
                {
                    b.HasOne("FootballClubLibrary.Models.Klub", null)
                        .WithMany()
                        .HasForeignKey("ArchiwalneKlubyIdKlub")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FootballClubLibrary.Models.Pilkarz", null)
                        .WithMany()
                        .HasForeignKey("ArchwilaniPilkarzeIdPilkarz")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FootballClubLibrary.Models.Klub", b =>
                {
                    b.Navigation("ObecniPilkarze");

                    b.Navigation("Zarzad");
                });

            modelBuilder.Entity("FootballClubLibrary.Models.Pilkarz", b =>
                {
                    b.Navigation("Statystyki");
                });

            modelBuilder.Entity("FootballClubLibrary.Models.Zarzad", b =>
                {
                    b.Navigation("Pracownicy");
                });
#pragma warning restore 612, 618
        }
    }
}