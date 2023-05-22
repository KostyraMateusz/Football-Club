using BusinessLogicLayer.Interfaces;
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
        public async Task TestDodajPilkarzaDoObecnych()
        {
            // Arrange
            var klubMockService = new KlubServiceMock();
            var klubController = new KlubyControllerMVC(klubMockService);
            var pilkarz = new Pilkarz() { IdPilkarz = Guid.NewGuid(), Imie = "Piotr", Nazwisko = "Nowak" };
            var klub = new Klub() { IdKlub = Guid.NewGuid(), Nazwa = "Klub1" };

            // Act
            var result = klubController.DodajPilkarzaDoObecnych(klub.IdKlub, pilkarz);
            var resultView = (ViewResult)result;

            // Assert
            Assert.IsType<ViewResult>(result);
            Assert.Equal(1, klubMockService.DajObecnychPilkarzy(klub.IdKlub).Result.Count());
        }

        [Fact]
        public async Task TestDajTrofeaKlubu()
        {
            // Arrange
            Mock<IKlubService> mockKlubyService = new Mock<IKlubService>();
        
            // Act

            // Assert

        }
    }
}
