using BusinessLogicLayer.Interfaces;

namespace TestsFootballClub.ControllerTests.Kluby
{
    public class KlubServiceMock : IKlubService
    {
        List<Klub> kluby = new List<Klub>();

        public KlubServiceMock(List<Klub> kluby)
        {
            this.kluby = kluby;
        }

        public Task DodajKlub(Klub klub)
        {
            throw new NotImplementedException();
        }

        public Task UsunKlub(Guid IdKlubu)
        {
            throw new NotImplementedException();
        }

        public Task EdytujKlub(Klub klub)
        {
            throw new NotImplementedException();
        }

        public Task<Klub> DajKlub(Guid IdKlubu)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Klub>> DajKluby()
        {
            return await Task.FromResult(this.kluby);
        }

        public async Task DodajPilkarzaDoObecnych(Pilkarz pilkarz, Klub _klub)
        {
            _klub.ObecniPilkarze?.Add(pilkarz);
        }

        public Task DodajPilkarzyDoObecnych(List<Pilkarz> pilkarze, Klub klub)
        {
            throw new NotImplementedException();
        }

        public async Task UsunPilkarzaZObecnych(Pilkarz pilkarz, Klub _klub)
        {
            _klub.ObecniPilkarze?.Remove(pilkarz);
        }

        public Task UsunPilkarzaZObecnych(Guid PilkarzId, Guid IdKlubu)
        {
            throw new NotImplementedException();
        }

        public Task<Pilkarz> DajObecnegoPilkarza(Guid IdKlubu, Guid IdPilkarza)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Pilkarz>> DajObecnychPilkarzy(Klub klub)
        {
            return await Task.FromResult(klub.ObecniPilkarze?.ToList());
        }

        public Task<Pilkarz> DajArchiwalnegoPilkarza(Guid IdKlubu, Guid IdPilkarza)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Pilkarz>> DajArchiwalnychPilkarzy(Guid IdKlubu)
        {
            throw new NotImplementedException();
        }

        public async Task<string> DajStadionKlubu(Klub klub)
        {
            return await Task.FromResult(klub.Stadion);
        }

        public async Task<string> DajTrofeaKlubu(Klub klub)
        {
            return await Task.FromResult(klub.Trofea);
        }
    }
}
