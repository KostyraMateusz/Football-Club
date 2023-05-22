using BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsFootballClub.ControllerTests.Kluby
{
    public class KlubServiceMock : IKlubService
    {
        List<Klub> kluby = new List<Klub>()
        {
            new Klub(){IdKlub = Guid.NewGuid(), Nazwa = "Klub1"},
            new Klub(){IdKlub = Guid.NewGuid(), Nazwa = "Klub2"},
            new Klub(){IdKlub = Guid.NewGuid(), Nazwa = "Klub3"},
            new Klub(){IdKlub = Guid.NewGuid(), Nazwa = "Klub4"}

        };
        public async Task<IEnumerable<Klub>> DajKluby()
        {
            return await Task.FromResult(this.kluby);
        }

        public async Task<string> DajTrofeaKlubu(Guid IdKlubu)
        {
            var klub = await Task.FromResult(this.kluby.First(k => k.IdKlub == IdKlubu));
            return klub.Trofea;
        }

        public async Task DodajPilkarzaDoObecnych(Pilkarz pilkarz, Guid IdKlubu)
        {
            var klub = await Task.FromResult(this.kluby.First(k => k.IdKlub == IdKlubu));
            klub.ObecniPilkarze?.Add(pilkarz);
        }

        public async Task<IEnumerable<Pilkarz>> DajObecnychPilkarzy(Guid IdKlubu)
        {
            var klub = await Task.FromResult(this.kluby.First(k=> k.IdKlub == IdKlubu));
            return klub.ObecniPilkarze?.ToList();
        }

        public Task<Pilkarz> DajArchiwalnegoPilkarza(Guid IdKlubu, Guid IdPilkarza)
        {
            throw new NotImplementedException();
        }

        public Task<string> DajStadionKlubu(Guid IdKlubu)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Pilkarz>> DajArchiwalnychPilkarzy(Guid IdKlubu)
        {
            throw new NotImplementedException();
        }

        public Task<Pilkarz> DajObecnegoPilkarza(Guid IdKlubu, Guid IdPilkarza)
        {
            throw new NotImplementedException();
        }

        public Task DodajPilkarzyDoObecnych(List<Pilkarz> pilkarze, Klub klub)
        {
            throw new NotImplementedException();
        }

        public Task UsunPilkarzaZObecnych(Guid PilkarzId, Guid IdKlubu)
        {
            throw new NotImplementedException();
        }
    }
}
