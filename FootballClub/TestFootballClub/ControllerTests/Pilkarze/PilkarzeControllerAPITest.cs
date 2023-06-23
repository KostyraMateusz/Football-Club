using BusinessLogicLayer.Interfaces;
using FootballClubPresentationLayer.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace TestsFootballClub.ControllerTests.Pilkarze
{
    public class PilkarzeControllerAPITest
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

            // Act
            var PilkarzeController = new PilkarzeController(mockPilkarzService.Object);
            var result = await PilkarzeController.DajPilkarzy();
            var okObjectResult = result.Result as OkObjectResult;

            //Assert
            Assert.NotNull(okObjectResult);
            var resultValue = okObjectResult.Value;
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Same(pilkarze, resultValue);
        }

        [Fact]
        public async Task TestDajPilkarzyBezKlubu()
        {
            // Arrange
            Mock<IPilkarzService> mockPilkarzService = new Mock<IPilkarzService>();
            List<Pilkarz> pilkarze = new List<Pilkarz>()
            {
                new Pilkarz(){ IdPilkarz = Guid.NewGuid(), Imie = "Karim", Nazwisko = "Benzema", Wiek = 35, Pozycja = "Napastnik", Statystyki = new List<Statystyka>{ }, ArchiwalneKluby = new List<Klub>{ }, Wynagrodzenie = 440000, IdKlubu = Guid.NewGuid() },
                new Pilkarz(){ IdPilkarz = Guid.NewGuid(), Imie = "Luka", Nazwisko = "Modrić", Wiek = 37, Pozycja = "Pomocnik", Statystyki = new List<Statystyka>{ }, ArchiwalneKluby = new List<Klub>{ }, Wynagrodzenie = 250000, IdKlubu = Guid.NewGuid() },
                new Pilkarz(){ IdPilkarz = Guid.NewGuid(), Imie = "Daniel", Nazwisko = "Carvajal", Wiek = 31, Pozycja = "Obrońca", Statystyki = new List<Statystyka>{ }, ArchiwalneKluby = new List<Klub>{ }, Wynagrodzenie = 190000, IdKlubu = Guid.NewGuid() },
                new Pilkarz(){ IdPilkarz = Guid.NewGuid(), Imie = "Kylian", Nazwisko = "Mbappé", Wiek = 24, Pozycja = "Napastnik", Statystyki = new List<Statystyka>{ }, ArchiwalneKluby = new List<Klub>{ }, Wynagrodzenie = 350000, IdKlubu = null }
            };
            mockPilkarzService.Setup(x => x.DajPilkarzyBezKlubu()).ReturnsAsync(pilkarze);

            // Act
            var PilkarzeController = new PilkarzeController(mockPilkarzService.Object);
            var result = await PilkarzeController.DajPilkarzyBezKlubu();
            var okObjectResult = result.Result as OkObjectResult;

            //Assert
            Assert.NotNull(okObjectResult);
            var resultValue = okObjectResult.Value;
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Same(pilkarze, resultValue);
        }

        [Fact]
        public async Task TestDajArchiwalneKlubyPilkarza()
        {
            // Arrange
            Klub ManchesterUnited = new Klub { IdKlub = Guid.NewGuid(), Nazwa = "Manchester United", Stadion = "Old Trafford" };
            Klub RealMadryt = new Klub { IdKlub = Guid.NewGuid(), Nazwa = "Real Madryt", Stadion = "Estadio Santiago Bernabéu" };
            Klub Juventus = new Klub { IdKlub = Guid.NewGuid(), Nazwa = "Juventus", Stadion = "Allianz Stadium" };
            Pilkarz CristianoRonaldo = new Pilkarz() { IdPilkarz = Guid.NewGuid(), Imie = "Cristiano", Nazwisko = "Ronaldo", Wiek = 38, Pozycja = "Napastnik", ArchiwalneKluby = new List<Klub> { ManchesterUnited, RealMadryt, Juventus } };
            List<Pilkarz> pilkarze = new List<Pilkarz> { CristianoRonaldo };

            // Act
            var pilkarzMockService = new PilkarzServiceMock(pilkarze);
            var PilkarzeController = new PilkarzeController(pilkarzMockService);
            var result = await PilkarzeController.DajArchiwalneKlubyPilkarza(CristianoRonaldo.IdPilkarz);
            var okObjectResult = result.Result as OkObjectResult;

            // Assert
            Assert.NotNull(okObjectResult);
            var resultValue = okObjectResult.Value;
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(3, pilkarzMockService.DajArchiwalneKlubyPilkarza(CristianoRonaldo).Result.Count());
            Assert.Equal(CristianoRonaldo.ArchiwalneKluby, resultValue);
        }

        [Fact]
        public async Task TestDajStatystykiPilkarza()
        {
            // Arrange
            List<Statystyka> statystyki = new List<Statystyka>()
            {
                new Statystyka(){ IdStatystyka = Guid.NewGuid(), Mecz = "Bayern vs PSG", Gole = 0, ZolteKartki = 1, CzerwoneKartki = 0, Asysty = 0, PrzebiegnietyDystans = 8.4, Ocena = 5.5, IdPilkarz = null, Pilkarz = null },
                new Statystyka(){ IdStatystyka = Guid.NewGuid(), Mecz = "PSG vs Ajaccio", Gole = 3, ZolteKartki = 0, CzerwoneKartki = 0, Asysty = 1, PrzebiegnietyDystans = 10.7, Ocena = 8.8, IdPilkarz = null, Pilkarz = null }
            };
            Pilkarz KylianMbappé = new Pilkarz() { IdPilkarz = Guid.NewGuid(), Imie = "Kylian", Nazwisko = "Mbappé", Wiek = 24, Pozycja = "Napastnik", Statystyki = statystyki, ArchiwalneKluby = null, Wynagrodzenie = 350000, IdKlubu = null };
            List<Pilkarz> pilkarze = new List<Pilkarz> { KylianMbappé };

            // Act
            var pilkarzMockService = new PilkarzServiceMock(pilkarze);
            var PilkarzeController = new PilkarzeController(pilkarzMockService);
            var result = await PilkarzeController.DajStatystykiPilkarza(KylianMbappé.IdPilkarz);
            var okObjectResult = result.Result as OkObjectResult;

            // Assert
            Assert.NotNull(okObjectResult);
            var resultValue = okObjectResult.Value;
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(statystyki, resultValue);
        }
    }
}