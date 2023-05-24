using BusinessLogicLayer.Interfaces;
using FootballClubLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsFootballClub.ControllerTests.Pilkarze
{
    public class PilkarzServiceMock : IPilkarzService
    {
        List<Pilkarz> pilkarze = new List<Pilkarz>()
        {
            new Pilkarz(){ IdPilkarz = Guid.NewGuid(), Imie = "Karim", Nazwisko = "Benzema", Wiek = 35, Pozycja = "Napastnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 440000, IdKlubu = null },
            new Pilkarz(){ IdPilkarz = Guid.NewGuid(), Imie = "Luka", Nazwisko = "Modrić", Wiek = 37, Pozycja = "Pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 250000, IdKlubu = null },
            new Pilkarz(){ IdPilkarz = Guid.NewGuid(), Imie = "Daniel", Nazwisko = "Carvajal", Wiek = 31, Pozycja = "Obrońca", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 190000, IdKlubu = null },
            new Pilkarz(){ IdPilkarz = Guid.NewGuid(), Imie = "Kylian", Nazwisko = "Mbappé", Wiek = 24, Pozycja = "Napastnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 350000, IdKlubu = null}
        };

        public async Task<IEnumerable<Klub>> DajArchiwalneKlubyPilkarza(Guid IdPilkarz)
        {
            var pilkarz = await Task.FromResult(this.pilkarze.First(p => p.IdPilkarz == IdPilkarz));
            return pilkarz.ArchiwalneKluby;
        }

        public async Task<IEnumerable<Statystyka>> DajNajlepszeStatystykiPilkarza(Guid IdPilkarz)
        {
            var pilkarz = await Task.FromResult(this.pilkarze.First(p => p.IdPilkarz == IdPilkarz));
            var statystyki = pilkarz.Statystyki.OrderByDescending(s => s.Ocena);
            return statystyki;
        }

        public async Task<IEnumerable<Pilkarz>> DajPilkarzy()
        {
            return await Task.FromResult(this.pilkarze);
        }

        public async Task<IEnumerable<Pilkarz>> DajPilkarzyBezKlubu()
        {
            var piłkarzeBezKlubu = await Task.FromResult(this.pilkarze.Where(p => p.IdKlubu == null).ToList());
            return piłkarzeBezKlubu;
        }

        public async Task<Statystyka> DajStatystykePilkarza(Guid IdStatystyka, Guid IdPilkarza)
        {
            var pilkarz = await Task.FromResult(this.pilkarze.First(p => p.IdPilkarz == IdPilkarza));
            var statystyka = await Task.FromResult(pilkarz.Statystyki.First(s => s.IdStatystyka == IdStatystyka));
            return statystyka;
        }

        public async Task<IEnumerable<Statystyka>> DajStatystykiPilkarza(Guid IdPilkarz)
        {
            var pilkarz = await Task.FromResult(this.pilkarze.First(p => p.IdPilkarz == IdPilkarz));
            return pilkarz.Statystyki;
        }

        public async Task ZmienPozycjePilkarza(Guid IdPilkarza, string pozycja)
        {
            var pilkarz = await Task.FromResult(this.pilkarze.First(p => p.IdPilkarz == IdPilkarza));
            pilkarz.Pozycja = pozycja;
        }
    }
}