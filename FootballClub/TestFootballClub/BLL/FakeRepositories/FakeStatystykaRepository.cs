using FootballClubLibrary.Interfaces;
using FootballClubLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace TestsFootballClub.BLL.FakeRepositories
{
    public class FakeStatystykaRepository : IStatystykaRepository
    {
        private List<Statystyka> statystyki = new List<Statystyka>();

        public DbSet<Statystyka> GetDbSetStatystyki()
        {
            throw new NotImplementedException();
        }

        public async Task CreateStatystyka(Statystyka statystyka)
        {
            statystyki.Add(statystyka);
            return;
        }

        public async Task DeleteStatystyka(Guid id)
        {
            var statystyka = await Task.FromResult(statystyki.Find(s => s.IdStatystyka == id));
            statystyki.Remove(statystyka);
            return;
        }

        public async Task UpdateStatystyka(Statystyka statystyka)
        {
            var index = await Task.FromResult(statystyki.FindIndex(s => s.IdStatystyka == statystyka.IdStatystyka));
            if (index != -1)
            {
                statystyki[index] = statystyka;
            }
            return;
        }

        public async Task<Statystyka> GetStatystykaById(Guid id)
        {
            var result = await Task.FromResult(statystyki.Find(s => s.IdStatystyka == id));
            return result;
        }

        public async Task<IEnumerable<Statystyka>> GetStatystyki()
        {
            var result = await Task.FromResult(statystyki);
            return result;
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }
    }
}