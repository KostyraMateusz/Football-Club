using BusinessLogicLayer.Interfaces;

namespace TestsFootballClub.ControllerTests.Pilkarze
{
    public class PilkarzServiceMock : IPilkarzService
    {
        List<Pilkarz> pilkarze = new List<Pilkarz>();

        public PilkarzServiceMock(List<Pilkarz> pilkarze)
        {
            this.pilkarze = pilkarze;
        }

        public async Task<IEnumerable<Pilkarz>> DajPilkarzy()
        {
            return await Task.FromResult(this.pilkarze.ToList());
        }

        public async Task<IEnumerable<Klub>> DajArchiwalneKlubyPilkarza(Pilkarz pilkarz)
        {
            return await Task.FromResult(pilkarz.ArchiwalneKluby);
        }

        public async Task<Statystyka> DajStatystykePilkarza(Pilkarz pilkarz, Guid IdStatystyka)
        {
            var statystyka = await Task.FromResult(pilkarz.Statystyki?.First(s => s.IdStatystyka == IdStatystyka));
            return await Task.FromResult(statystyka);
        }

        public async Task<IEnumerable<Statystyka>> DajStatystykiPilkarza(Pilkarz pilkarz)
        {
            return await Task.FromResult(pilkarz.Statystyki?.ToList());
        }

        public async Task ZmienPozycjePilkarza(Pilkarz pilkarz, string pozycja)
        {
            if (pilkarz != null)
            {
                pilkarz.Pozycja = pozycja;
            }
        }

        public async Task<IEnumerable<Statystyka>> DajNajlepszeStatystykiPilkarza(Pilkarz pilkarz)
        {
            var statystyki = pilkarz.Statystyki?.OrderByDescending(s => s.Ocena);
            return await Task.FromResult(statystyki?.ToList());
        }

        public async Task<IEnumerable<Pilkarz>> DajPilkarzyBezKlubu()
        {
            var piłkarzeBezKlubu = await Task.FromResult(this.pilkarze.Where(p => p.IdKlubu == null).ToList());
            return await Task.FromResult(piłkarzeBezKlubu.ToList());
        }
    }
}