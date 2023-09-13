using FootballClubLibrary.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TestsFootballClub.FakeRepositories
{
    public class FakePilkarzRepository : IPilkarzRepository
    {
        private List<Pilkarz> pilkarze = new List<Pilkarz>();

        public DbSet<Pilkarz> GetDbSetPilkarze()
        {
            throw new NotImplementedException();
        }

        public async Task CreatePilkarz(Pilkarz pilkarz)
        {
            pilkarze.Add(pilkarz);
            return;
        }

        public async Task DeletePilkarz(Guid id)
        {
            var pilkarz = await Task.FromResult(pilkarze.Find(p => p.IdPilkarz == id));
            pilkarze.Remove(pilkarz);
            return;
        }

        public async Task UpdatePilkarz(Pilkarz pilkarz)
        {
            var index = await Task.FromResult(pilkarze.FindIndex(p => p.IdPilkarz == pilkarz.IdPilkarz));
            if (index != -1)
            {
                pilkarze[index] = pilkarz;
            }
            return;
        }

        public async Task<Pilkarz> GetPilkarzById(Guid id)
        {
            var result = await Task.FromResult(pilkarze.Find(p => p.IdPilkarz == id));
            return result;
        }

        public async Task<IEnumerable<Pilkarz>> GetPilkarze()
        {
            var result = await Task.FromResult(pilkarze);
            return result;
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }
    }
}