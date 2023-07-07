using BusinessLogicLayer.Interfaces;
using FootballClubPresentationLayer.ControllersMVC;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.ObjectModel;

namespace TestsFootballClub.ControllerTests.Pilkarze
{
    public class PilkarzeControllerMVCTest
    {
        [Fact]
        public async Task TestDajPilkarzy()
        {
            // Arrange
            Mock<IPilkarzService> mockPilkarzService = new Mock<IPilkarzService>();
            List<Pilkarz> pilkarze = new List<Pilkarz>()
            {
                new Pilkarz(){ IdPilkarz = Guid.NewGuid(), Imie = "Karim", Nazwisko = "Benzema", Wiek = 35, Pozycja = "Napastnik", Statystyki = new List<Statystyka>{ }, ArchiwalneKluby = new List<Klub>{ }, Wynagrodzenie = 440000, IdKlubu = Guid.NewGuid() },
                new Pilkarz(){ IdPilkarz = Guid.NewGuid(), Imie = "Luka", Nazwisko = "Modrić", Wiek = 37, Pozycja = "Pomocnik", Statystyki = new List<Statystyka>{ }, ArchiwalneKluby = new List<Klub>{ }, Wynagrodzenie = 250000, IdKlubu = Guid.NewGuid() },
                new Pilkarz(){ IdPilkarz = Guid.NewGuid(), Imie = "Daniel", Nazwisko = "Carvajal", Wiek = 31, Pozycja = "Obrońca", Statystyki = new List<Statystyka>{ }, ArchiwalneKluby = new List<Klub>{ }, Wynagrodzenie = 190000, IdKlubu = Guid.NewGuid() },
                new Pilkarz(){ IdPilkarz = Guid.NewGuid(), Imie = "Kylian", Nazwisko = "Mbappé", Wiek = 24, Pozycja = "Napastnik", Statystyki = new List<Statystyka>{ }, ArchiwalneKluby = new List<Klub>{ }, Wynagrodzenie = 350000, IdKlubu = Guid.NewGuid() }
            };
            mockPilkarzService.Setup(x => x.DajPilkarzy()).ReturnsAsync(pilkarze);
            var pilkarzController = new PilkarzeControllerMVC(mockPilkarzService.Object);

            // Act
            var result = await Task.FromResult(pilkarzController.DajPilkarzy());
            var viewResult = (ViewResult)result;

            //Assert
            Assert.IsType<ViewResult>(viewResult);
            Assert.Equal(pilkarze, viewResult.ViewData["Pilkarze"]);
        }

        [Fact]
        public async Task TestDajPilkarzyBezKlubu()
        {
            // Arrange
            Mock<IPilkarzService> mockPilkarzService = new Mock<IPilkarzService>();
            Klub RealMadryt = new Klub { IdKlub = Guid.NewGuid(), Nazwa = "Real Madryt", Stadion = "Estadio Santiago Bernabéu", Trofea = "Liga Mistrzów", ObecniPilkarze = new List<Pilkarz> { }, ArchwilaniPilkarze = new Collection<Pilkarz> { }, Zarzad = null };
            List<Pilkarz> pilkarze = new List<Pilkarz>()
            {
                new Pilkarz(){ IdPilkarz = Guid.NewGuid(), Imie = "Karim", Nazwisko = "Benzema", Wiek = 35, Pozycja = "Napastnik", Statystyki = new List<Statystyka>{ }, ArchiwalneKluby = new List<Klub>{ }, Wynagrodzenie = 440000, IdKlubu = RealMadryt.IdKlub },
                new Pilkarz(){ IdPilkarz = Guid.NewGuid(), Imie = "Luka", Nazwisko = "Modrić", Wiek = 37, Pozycja = "Pomocnik", Statystyki = new List<Statystyka>{ }, ArchiwalneKluby = new List<Klub>{ }, Wynagrodzenie = 250000, IdKlubu = RealMadryt.IdKlub },
                new Pilkarz(){ IdPilkarz = Guid.NewGuid(), Imie = "Daniel", Nazwisko = "Carvajal", Wiek = 31, Pozycja = "Obrońca", Statystyki = new List<Statystyka>{ }, ArchiwalneKluby = new List<Klub>{ }, Wynagrodzenie = 190000, IdKlubu = RealMadryt.IdKlub },
                new Pilkarz(){ IdPilkarz = Guid.NewGuid(), Imie = "Kylian", Nazwisko = "Mbappé", Wiek = 24, Pozycja = "Napastnik", Statystyki = new List<Statystyka>{ }, ArchiwalneKluby = new List<Klub>{ }, Wynagrodzenie = 350000, IdKlubu = null }
            };

            mockPilkarzService.Setup(p => p.DajPilkarzyBezKlubu()).ReturnsAsync(pilkarze);
            var pilkarzController = new PilkarzeControllerMVC(mockPilkarzService.Object);

            // Act
            var result = await Task.FromResult(pilkarzController.DajPilkarzyBezKlubu());
            var viewResult = (ViewResult)result;

            // Assert
            Assert.IsType<ViewResult>(result);
            Assert.Equal(pilkarze, viewResult.ViewData["Pilkarze"]);
        }


        [Fact]
        public async Task TestDajArchiwalneKlubyPilkarza()
        {
            // Arrange
            var pilkarzMockService = new PilkarzServiceMock(null);
            var PilkarzController = new PilkarzeControllerMVC(pilkarzMockService);
            Klub ManchesterUnited = new Klub { IdKlub = Guid.NewGuid(), Nazwa = "Manchester United", Stadion = "Old Trafford" };
            Klub RealMadryt = new Klub { IdKlub = Guid.NewGuid(), Nazwa = "Real Madryt", Stadion = "Estadio Santiago Bernabéu" };
            Klub Juventus = new Klub { IdKlub = Guid.NewGuid(), Nazwa = "Juventus", Stadion = "Allianz Stadium" };
            Pilkarz CristianoRonaldo = new Pilkarz() { IdPilkarz = Guid.NewGuid(), Imie = "Cristiano", Nazwisko = "Ronaldo", Wiek = 38, Pozycja = "Napastnik", ArchiwalneKluby = new List<Klub> { ManchesterUnited, RealMadryt, Juventus } };

            // Act
            var result = PilkarzController.DajArchiwalneKlubyPilkarza(CristianoRonaldo);
            var resultView = (ViewResult)result;

            // Assert
            Assert.IsType<ViewResult>(resultView);
            Assert.Equal(3, pilkarzMockService.DajArchiwalneKlubyPilkarza(CristianoRonaldo).Result.Count());
            Assert.Equal(CristianoRonaldo.ArchiwalneKluby, resultView.ViewData["Pilkarze"]);
        }


        [Fact]
        public async Task TestDajStatystykiPilkarza()
        {
            // Arrange
            var pilkarzMockService = new PilkarzServiceMock(null);
            var PilkarzController = new PilkarzeControllerMVC(pilkarzMockService);
            List<Statystyka> statystyki = new List<Statystyka>()
            {
                new Statystyka(){ IdStatystyka = Guid.NewGuid(), Mecz = "Bayern vs PSG", Gole = 0, ZolteKartki = 1, CzerwoneKartki = 0, Asysty = 0, PrzebiegnietyDystans = 8.4, Ocena = 5.5, IdPilkarz = null, Pilkarz = null },
                new Statystyka(){ IdStatystyka = Guid.NewGuid(), Mecz = "PSG vs Ajaccio", Gole = 3, ZolteKartki = 0, CzerwoneKartki = 0, Asysty = 1, PrzebiegnietyDystans = 10.7, Ocena = 8.8, IdPilkarz = null, Pilkarz = null }
            };
            Pilkarz KylianMbappé = new Pilkarz() { IdPilkarz = Guid.NewGuid(), Imie = "Kylian", Nazwisko = "Mbappé", Wiek = 24, Pozycja = "Napastnik", Statystyki = statystyki, ArchiwalneKluby = null, Wynagrodzenie = 350000, IdKlubu = null };

            // Act
            var result = PilkarzController.DajStatystykiPilkarza(KylianMbappé);
            var resultView = (ViewResult)result;

            // Assert
            Assert.IsType<ViewResult>(resultView);
            Assert.Equal(2, pilkarzMockService.DajStatystykiPilkarza(KylianMbappé).Result.Count());
            Assert.Equal(statystyki, resultView.ViewData["Pilkarze"]);
        }
    }
}