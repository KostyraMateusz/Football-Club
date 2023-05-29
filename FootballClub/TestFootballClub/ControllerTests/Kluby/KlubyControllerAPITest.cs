﻿using BusinessLogicLayer.Interfaces;
using FootballClubLibrary.Models;
using FootballClubPresentationLayer.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var klub = new Klub() { IdKlub = Guid.NewGuid(), Nazwa = "Reprezentacja Polski", ArchwilaniPilkarze = pilkarze };
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
            Assert.Same(klub.ArchwilaniPilkarze, resultValue);
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
            var mockKlubService = new KlubServiceMock();
            var pilkarz = new Pilkarz() { IdPilkarz = Guid.NewGuid(), Imie = "Antoine", Nazwisko = "Griezmann" };
            var klub = new Klub() { IdKlub = Guid.NewGuid(), Nazwa = "Atletico Madryt", Stadion = "Wanda Metropolitano", ObecniPilkarze = new List<Pilkarz> { } };
            
            // Act
            var klubyController = new KlubyController(mockKlubService);
            await klubyController.DodajPilkarzaDoObecnych(pilkarz, klub.IdKlub);

            // Assert
            Assert.Equal(klub?.ObecniPilkarze.Count(), 1);
            Assert.Equal(klub?.ObecniPilkarze.Contains(pilkarz), true);
        }

        [Fact]
        public async Task TestDajTrofaKlubu()
        {
            // Arrange
            var mockKlubService = new KlubServiceMock();
            var klub = new Klub() { IdKlub = Guid.NewGuid(), Nazwa = "Atletico Madryt", Trofea = "La Liga" };

            // Act
            var klubyController = new KlubyController(mockKlubService);
            var result  = await klubyController.DajTrofeaKlubu(klub.IdKlub);
            var okObjectResult = result.Result as OkObjectResult;

            // Assert
            Assert.NotNull(okObjectResult);
            var resultValue = okObjectResult.Value;
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Same(klub.Trofea, resultValue);
        }
    }
}