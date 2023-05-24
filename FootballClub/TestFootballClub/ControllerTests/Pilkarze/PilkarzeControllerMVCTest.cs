using BusinessLogicLayer.Interfaces;
using FootballClubLibrary.Models;
using FootballClubPresentationLayer.Controllers;
using FootballClubPresentationLayer.ControllersMVC;
using FootballClubWeb.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsFootballClub.ControllerTests.Kluby;

namespace TestsFootballClub.ControllerTests.Pilkarze
{
    public class PilkarzeControllerMVCTest
    {
        [Fact]
        public async Task TestDajPilkarzy()
        {
            var pilkarzeMockService = new PilkarzServiceMock();
            var pilkarzeController = new PilkarzeControllerMVC(pilkarzeMockService);
            List<Pilkarz> pilkarze = new List<Pilkarz>()
            {
                new Pilkarz(){ IdPilkarz = Guid.NewGuid(), Imie = "Karim", Nazwisko = "Benzema", Wiek = 35, Pozycja = "Napastnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 440000, IdKlubu = null },
                new Pilkarz(){ IdPilkarz = Guid.NewGuid(), Imie = "Luka", Nazwisko = "Modrić", Wiek = 37, Pozycja = "Pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 250000, IdKlubu = null },
                new Pilkarz(){ IdPilkarz = Guid.NewGuid(), Imie = "Daniel", Nazwisko = "Carvajal", Wiek = 31, Pozycja = "Obrońca", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 190000, IdKlubu = null },
                new Pilkarz(){ IdPilkarz = Guid.NewGuid(), Imie = "Kylian", Nazwisko = "Mbappé", Wiek = 24, Pozycja = "Napastnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 350000, IdKlubu = null}
            };

            var result = pilkarzeController.DajPilkarzy();

            Assert.IsType<ViewResult>(result);
            Assert.Equal(4, pilkarzeMockService.DajPilkarzy().Result.Count());
        }


        [Fact]
        public async Task TestDajStatystykiPilkarza()
        {
            Mock<IPilkarzService> mockPilkarzService = new Mock<IPilkarzService>();

            List<Statystyka> statystyki = new List<Statystyka>()
            {
                new Statystyka(){ IdStatystyka = Guid.NewGuid(), Mecz = "Bayern vs PSG", Gole = 0, ZolteKartki = 1, CzerwoneKartki = 0, Asysty = 0, PrzebiegnietyDystans = 8.4, Ocena = 5.5, IdPilkarz = null, Pilkarz = null },
                new Statystyka(){ IdStatystyka = Guid.NewGuid(), Mecz = "PSG vs Ajaccio", Gole = 3, ZolteKartki = 0, CzerwoneKartki = 0, Asysty = 1, PrzebiegnietyDystans = 10.7, Ocena = 8.8, IdPilkarz = null, Pilkarz = null }
            };
            Pilkarz KylianMbappé = new Pilkarz() { IdPilkarz = Guid.NewGuid(), Imie = "Kylian", Nazwisko = "Mbappé", Wiek = 24, Pozycja = "Napastnik", Statystyki = statystyki, ArchiwalneKluby = null, Wynagrodzenie = 350000, IdKlubu = null };

            mockPilkarzService.Setup(p => p.DajStatystykiPilkarza(KylianMbappé.IdPilkarz));
            var pilkarzController = new PilkarzeControllerMVC(mockPilkarzService.Object);

            // Act
            var result = await Task.FromResult(pilkarzController.DajStatystykiPilkarza(KylianMbappé.IdPilkarz));
            var viewResult = (ViewResult)result;

            // Assert
            Assert.IsType<ViewResult>(result);
            Assert.Equal(result, viewResult);
        }


        [Fact]
        public async Task TestDajPilkarzyBezKlubu()
        {
            Mock<IPilkarzService> mockPilkarzService = new Mock<IPilkarzService>();
            Klub RealMadryt = new Klub { IdKlub = Guid.NewGuid(), Nazwa = "Real Madryt", Stadion = "Estadio Santiago Bernabéu", Trofea = "Liga Mistrzów", ObecniPilkarze = new Collection<Pilkarz> { }, ArchwilaniPilkarze = new Collection<Pilkarz> { }, Zarzad = null };
            List<Pilkarz> pilkarze = new List<Pilkarz>()
            {
                new Pilkarz(){ IdPilkarz = Guid.NewGuid(), Imie = "Karim", Nazwisko = "Benzema", Wiek = 35, Pozycja = "Napastnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 440000, IdKlubu = RealMadryt.IdKlub },
                new Pilkarz(){ IdPilkarz = Guid.NewGuid(), Imie = "Luka", Nazwisko = "Modrić", Wiek = 37, Pozycja = "Pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 250000, IdKlubu = RealMadryt.IdKlub },
                new Pilkarz(){ IdPilkarz = Guid.NewGuid(), Imie = "Daniel", Nazwisko = "Carvajal", Wiek = 31, Pozycja = "Obrońca", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 190000, IdKlubu = RealMadryt.IdKlub },
                new Pilkarz(){ IdPilkarz = Guid.NewGuid(), Imie = "Kylian", Nazwisko = "Mbappé", Wiek = 24, Pozycja = "Napastnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 350000, IdKlubu = null}
            };

            mockPilkarzService.Setup(p => p.DajPilkarzyBezKlubu()).ReturnsAsync(pilkarze);
            var pilkarzController = new PilkarzeControllerMVC(mockPilkarzService.Object);

            // Act
            var result = await Task.FromResult(pilkarzController.DajPilkarzyBezKlubu());
            var viewResult = (ViewResult)result;

            // Assert
            Assert.IsType<ViewResult>(result);
            Assert.Equal(result, viewResult);
        }


        [Fact]
        public async Task TestDajArchiwalneKlubyPilkarza()
        {
            Mock<IPilkarzService> mockPilkarzService = new Mock<IPilkarzService>();

            Klub ManchesterUnited = new Klub { IdKlub = Guid.NewGuid(), Nazwa = "Manchester United", Stadion = "Old Trafford", Trofea = "Liga Mistrzów", ObecniPilkarze = new Collection<Pilkarz> { }, ArchwilaniPilkarze = new Collection<Pilkarz> { }, Zarzad = null };
            Klub RealMadryt = new Klub { IdKlub = Guid.NewGuid(), Nazwa = "Real Madryt", Stadion = "Estadio Santiago Bernabéu", Trofea = "Liga Mistrzów", ObecniPilkarze = new Collection<Pilkarz> { }, ArchwilaniPilkarze = new Collection<Pilkarz> { }, Zarzad = null };
            Klub Juventus = new Klub { IdKlub = Guid.NewGuid(), Nazwa = "Juventus", Stadion = "Allianz Stadium", Trofea = "Liga Europy", ObecniPilkarze = new Collection<Pilkarz> { }, ArchwilaniPilkarze = new Collection<Pilkarz> { }, Zarzad = null };
            Pilkarz CristianoRonaldo = new Pilkarz() { IdPilkarz = Guid.NewGuid(), Imie = "Cristiano", Nazwisko = "Ronaldo", Wiek = 38, Pozycja = "Napastnik", Statystyki = null, ArchiwalneKluby = new Collection<Klub>{ ManchesterUnited, RealMadryt, Juventus }, Wynagrodzenie = 560000, IdKlubu = null };

            mockPilkarzService.Setup(p => p.DajArchiwalneKlubyPilkarza(CristianoRonaldo.IdPilkarz));
            var pilkarzController = new PilkarzeControllerMVC(mockPilkarzService.Object);

            // Act
            var result = await Task.FromResult(pilkarzController.DajArchiwalneKlubyPilkarza(CristianoRonaldo.IdPilkarz));
            var viewResult = (ViewResult)result;

            // Assert
            Assert.IsType<ViewResult>(result);
            Assert.Equal(result, viewResult);
        }
    }
}
