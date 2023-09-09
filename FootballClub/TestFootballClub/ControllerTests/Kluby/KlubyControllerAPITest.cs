using BusinessLogicLayer.Interfaces;
using FootballClubPresentationLayer.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace TestsFootballClub.ControllerTests.Kluby
{
    public class KlubyControllerAPITest
    {
        [Fact]
        public async Task TestDajArchiwlanychPilkarzyKlubu()
        {
            // Arrange
            Mock<IKlubService> mockKlubService = new Mock<IKlubService>();
            var pilkarze = new List<Pilkarz>
            {
                new Pilkarz(){IdPilkarz = Guid.NewGuid(), Imie="Jan", Nazwisko = "Tomaszewski"},
                new Pilkarz(){IdPilkarz = Guid.NewGuid(), Imie="Jan", Nazwisko = "Domarski"},
                new Pilkarz(){IdPilkarz = Guid.NewGuid(), Imie="Zbigniew", Nazwisko = "Boniek"},
                new Pilkarz(){IdPilkarz = Guid.NewGuid(), Imie="Grzegorz", Nazwisko = "Lato"}
            };
            var klub = new Klub() { IdKlub = Guid.NewGuid(), Nazwa = "Reprezentacja Polski", ArchiwalniPilkarze = pilkarze };
            mockKlubService.Setup(x => x.DajArchiwalnychPilkarzy(klub.IdKlub))
                           .ReturnsAsync(pilkarze);

            // Act
            var klubyController = new KlubyController(mockKlubService.Object);
            var result = await klubyController.DajArchiwalnychPilkarzy(klub.IdKlub);
            var okObjectResult = result.Result as OkObjectResult;


            ////Assert
            Assert.NotNull(okObjectResult);
            var resultValue = okObjectResult.Value;
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Same(klub.ArchiwalniPilkarze, resultValue);
        }

        [Fact]
        public async Task TestDajObecnychPilkarzyKlubu()
        {
            // Arrange
            Mock<IKlubService> mockKlubService = new Mock<IKlubService>();
            var pilkarz = new Pilkarz() { IdPilkarz = Guid.NewGuid(), Imie = "Robert", Nazwisko = "Lewandowski" };
            var klub = new Klub() { IdKlub = Guid.NewGuid(), Nazwa = "Reprezentacja Polski", ObecniPilkarze = new List<Pilkarz> { pilkarz } };

            mockKlubService.Setup(x => x.DajObecnegoPilkarza(klub.IdKlub, pilkarz.IdPilkarz)).ReturnsAsync(pilkarz);

            // Act
            var klubyController = new KlubyController(mockKlubService.Object);
            var result = await klubyController.DajObecnegoPilkarza(klub.IdKlub, pilkarz.IdPilkarz);
            var okObjectResult = result.Result as OkObjectResult;

            // Assert
            Assert.NotNull(okObjectResult);
            var resultValue = okObjectResult.Value;
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Same(pilkarz, resultValue);

        }

        [Fact]
        public async Task TestDodajPilkarzaDoObecnych()
        {
            // Arrange
            var pilkarz = new Pilkarz() { IdPilkarz = Guid.NewGuid(), Imie = "Antoine", Nazwisko = "Griezmann" };
            var AtleticoMadryt = new Klub() { IdKlub = Guid.NewGuid(), Nazwa = "Atletico Madryt", Stadion = "Wanda Metropolitano", ObecniPilkarze = new List<Pilkarz> { } };
            List<Klub> kluby = new List<Klub> { AtleticoMadryt };

            // Act
            var mockKlubService = new KlubServiceMock(kluby);
            var klubyController = new KlubyController(mockKlubService);
            await klubyController.DodajPilkarzaDoObecnych(AtleticoMadryt.IdKlub, pilkarz);

            // Assert
            Assert.Equal(AtleticoMadryt?.ObecniPilkarze.Count(), 1);
            Assert.Equal(AtleticoMadryt?.ObecniPilkarze.Contains(pilkarz), true);
        }

        [Fact]
        public async Task TestDajTrofaKlubu()
        {
            // Arrange
            var AtleticoMadryt = new Klub() { IdKlub = Guid.NewGuid(), Nazwa = "Atletico Madryt", Trofea = "La Liga" };
            List<Klub> kluby = new List<Klub> { AtleticoMadryt };

            // Act
            var mockKlubService = new KlubServiceMock(kluby);
            var klubyController = new KlubyController(mockKlubService);
            var result  = await klubyController.DajTrofeaKlubu(AtleticoMadryt.IdKlub);
            var okObjectResult = result.Result as OkObjectResult;

            // Assert
            Assert.NotNull(okObjectResult);
            var resultValue = okObjectResult.Value;
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Same(AtleticoMadryt.Trofea, resultValue);
        }
    }
}