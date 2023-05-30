using BusinessLogicLayer.Interfaces;
using FootballClubLibrary.Models;
using FootballClubPresentationLayer.ControllersMVC;
using FootballClubWeb.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsFootballClub.ControllerTests.Kluby
{
    public class KlubyControllerMVCTest
    {
        [Fact]
        public async Task TestDajKlubyTest()
        {
            // Arrange
            Mock<IKlubService> mockKlubyService = new Mock<IKlubService>();
            List<Klub> kluby = new List<Klub>()
            {
                new Klub() { IdKlub = Guid.NewGuid(), Nazwa = "Klub1"},
                new Klub() { IdKlub = Guid.NewGuid(), Nazwa = "Klub2"},
                new Klub() { IdKlub = Guid.NewGuid(), Nazwa = "Klub3"},
            };
            mockKlubyService.Setup(k => k.DajKluby())
                .ReturnsAsync(kluby);
            var klubyController = new KlubyControllerMVC(mockKlubyService.Object);

            // Act
            var result = await Task.FromResult(klubyController.DajKluby());
            var viewResult = (ViewResult)result;

            // Assert
            Assert.IsType<ViewResult>(result);
            Assert.Equal(kluby, viewResult.ViewData["Kluby"]);
        }

        [Fact]
        public async Task TestDajObecnychPilkarzyKlubu()
        {
            // Arrange
            Mock<IKlubService> mockKlubyService = new Mock<IKlubService>();
            var klub = new Klub()
            {
                IdKlub = Guid.NewGuid(),
                Nazwa = "Klub1",
                ObecniPilkarze = new List<Pilkarz> {
                    new Pilkarz() { IdPilkarz = Guid.NewGuid(), Imie = "Jan", Nazwisko = "Nowak" },
                    new Pilkarz() { IdPilkarz = Guid.NewGuid(), Imie = "Tomek", Nazwisko = "Januszek" }
                }
            };
            mockKlubyService.Setup(x => x.DajObecnychPilkarzy(klub))
                .ReturnsAsync(klub.ObecniPilkarze);
            var klubyController = new KlubyControllerMVC(mockKlubyService.Object);

            // Act
            var result = await Task.FromResult(klubyController.DajObecnychPilkarzyKlubu(klub));
            var viewResult = (ViewResult)result;

            // Assert
            Assert.IsType<ViewResult>(viewResult);
            Assert.Equal(klub.ObecniPilkarze, viewResult.ViewData["Pilkarze"]);
        }

        [Fact]
        public async Task TestDodajPilkarzaDoObecnych()
        {
            // Arrange
            var klubMockService = new KlubServiceMock();
            var klubController = new KlubyControllerMVC(klubMockService);
            var pilkarz = new Pilkarz() { IdPilkarz = Guid.NewGuid(), Imie = "Piotr", Nazwisko = "Nowak" };
            var klub = new Klub() { IdKlub = Guid.NewGuid(), Nazwa = "Klub1", ObecniPilkarze = new List<Pilkarz> { } };

            // Act
            var result = klubController.DodajPilkarzaDoObecnych(klub, pilkarz);
            var resultView = (ViewResult)result;

            // Assert
            Assert.IsType<ViewResult>(resultView);
            Assert.Equal(1, klubMockService.DajObecnychPilkarzy(klub).Result.Count());
        }

        [Fact]
        public async Task TestDajStadionKlubu()
        {
            // Arrange
            var klubMockService = new KlubServiceMock();
            var klubController = new KlubyControllerMVC(klubMockService);
            var klub = new Klub() { IdKlub = Guid.NewGuid(), Nazwa = "Atletico Madryt", Stadion = "Wanda Metropolitano" };

            // Act
            var result = await Task.FromResult(klubController.DajStadion(klub));
            var resultView = (ViewResult)result;

            // Assert
            Assert.IsType<ViewResult>(resultView);
            Assert.Equal(klub.Stadion, resultView.ViewData["Stadion"]);

        }
    }
}
