using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using FootballClubLibrary.Interfaces;
using FootballClubLibrary.Models;
using FootballClubLibrary.UnitOfWork;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsFootballClub.FakeRepositories;

namespace TestsFootballClub.Tests
{
    public class TestPilkarzService
    {
        [Fact]
        public void TestSprawdzIluJestPilkarzy()
        {
        //    var pilkarzRepo = new FakePilkarzRepository();
        //    var unitOfWork = new UnitOfWork(null, pilkarzRepo);
        //    var pilkarzService = new PilkarzService(unitOfWork);

        //    pilkarzRepo?.CreatePilkarz(new Pilkarz { IdPilkarz = Guid.NewGuid(), Imie = "Karim", Nazwisko = "Benzema", Wiek = 35, Pozycja = "Napastnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 440000, IdKlubu = null });
        //    Assert.Equal(1, pilkarzRepo?.IleJestPilkarzy());

        //    pilkarzRepo?.CreatePilkarz(new Pilkarz { IdPilkarz = Guid.NewGuid(), Imie = "Luka", Nazwisko = "Modrić", Wiek = 37, Pozycja = "Pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 250000, IdKlubu = null });
        //    Assert.Equal(2, pilkarzRepo?.IleJestPilkarzy());

        //    pilkarzRepo?.CreatePilkarz(new Pilkarz { IdPilkarz = Guid.NewGuid(), Imie = "Daniel", Nazwisko = "Carvajal", Wiek = 31, Pozycja = "Obrońca", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 190000, IdKlubu = null });
        //    Assert.Equal(3, pilkarzRepo?.IleJestPilkarzy());
        }

        [Fact]
        public void TestArchiwalneKlubyPilkarza()
        {
            //var pilkarzRepo = new FakePilkarzRepository();
            //var unitOfWork = new UnitOfWork(null, pilkarzRepo);
            //var pilkarzService = new PilkarzService(unitOfWork);

            //Klub OlympiqueLyon = new Klub()
            //{
            //    IdKlub = Guid.NewGuid(),
            //    ArchwilaniPilkarze = null,
            //    ObecniPilkarze = new List<Pilkarz>(),
            //    Stadion = "Groupama Arena",
            //    Trofea = "Mistrzostwo Francji",
            //    Nazwa = "Olympique Lyon",
            //    Zarzad = new Zarzad()
            //};

            //Pilkarz Benzema = new Pilkarz
            //{
            //    IdPilkarz = Guid.NewGuid(),
            //    Imie = "Karim",
            //    Nazwisko = "Benzema",
            //    Wiek = 35,
            //    Pozycja = "Pomocnik",
            //    Statystyki = null,
            //    ArchiwalneKluby = new Collection<Klub> { OlympiqueLyon },
            //    Wynagrodzenie = 440000,
            //    IdKlubu = null
            //};

            //Collection<Klub> listaArchiwalnych = new Collection<Klub>();
            //listaArchiwalnych.Add(OlympiqueLyon);

            //Assert.Same(Benzema.ArchiwalneKluby.ToString(), listaArchiwalnych.ToString());
        }


        [Fact]
        public void TestSprawdzIluJestPilkarzyMOQ()
        {
            //Mock<IPilkarzRepository> _mockPilkarzeRepository = new Mock<IPilkarzRepository>();
            //_mockPilkarzeRepository.Setup(x => x.GetPilkarze())
            //    .ReturnsAsync(new List<Pilkarz> {
            //        new Pilkarz { IdPilkarz = Guid.NewGuid(), Imie = "Karim", Nazwisko = "Benzema", Wiek = 35, Pozycja = "Napastnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 440000, IdKlubu = null },
            //        new Pilkarz { IdPilkarz = Guid.NewGuid(), Imie = "Luka", Nazwisko = "Modrić", Wiek = 37, Pozycja = "Pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 250000, IdKlubu = null },
            //        new Pilkarz { IdPilkarz = Guid.NewGuid(), Imie = "Daniel", Nazwisko = "Carvajal", Wiek = 31, Pozycja = "Obrońca", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 190000, IdKlubu = null }
            //    });

            //var unitOfWork = new UnitOfWork(null, _mockPilkarzeRepository.Object);
            //var pilkarzService = new PilkarzService(unitOfWork);

            //Assert.Equal(3, pilkarzService.DajPilkarzy().Result.Count());
        }

        [Fact]
        public void TestPorownajDwochPilkarzy()
        {
            //Pilkarz Benzema = new Pilkarz
            //{
            //    IdPilkarz = Guid.NewGuid(),
            //    Imie = "Karim",
            //    Nazwisko = "Benzema",
            //    Wiek = 35,
            //    Pozycja = "Napastnik",
            //    Statystyki = null,
            //    ArchiwalneKluby = null,
            //    Wynagrodzenie = 440000,
            //    IdKlubu = null
            //};

            //Pilkarz Mbappé = new Pilkarz
            //{
            //    IdPilkarz = Guid.NewGuid(),
            //    Imie = "Kylian",
            //    Nazwisko = "Mbappé",
            //    Wiek = 24,
            //    Pozycja = "Napastnik",
            //    Statystyki = null,
            //    ArchiwalneKluby = null,
            //    Wynagrodzenie = 350000,
            //    IdKlubu = null
            //};

            //Mock<IPilkarzRepository> _mockPilkarzeRepository = new Mock<IPilkarzRepository>();
            //_mockPilkarzeRepository.Setup(x => x.GetPilkarze())
            //    .ReturnsAsync(new List<Pilkarz> { Benzema, Mbappé });

            //var unitOfWork = new UnitOfWork(null, _mockPilkarzeRepository.Object);
            //var pilkarzService = new PilkarzService(unitOfWork);

            //Assert.NotEqual(Benzema.IdPilkarz, Mbappé.IdPilkarz);
            //Assert.NotSame(Benzema, Mbappé);
            //Assert.Same(Benzema.Pozycja, Mbappé.Pozycja);
        }
    }
}
