using BusinessLogicLayer.Interfaces;
using FootballClubLibrary.Models;
using FootballClubPresentationLayer.ControllersMVC;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
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
    }
}
