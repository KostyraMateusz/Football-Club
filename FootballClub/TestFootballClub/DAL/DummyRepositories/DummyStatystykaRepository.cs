using FootballClubLibrary.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TestsFootballClub.DAL.DummyRepositories
{
    public class DummyStatystykaRepository : IStatystykaRepository
    {
        public Task CreateStatystyka(Statystyka statystyka)
        {
            throw new NotImplementedException();
        }

        public Task DeleteStatystyka(Guid id)
        {
            throw new NotImplementedException();
        }

        public DbSet<Statystyka> GetDbSetStatystyki()
        {
            throw new NotImplementedException();
        }

        public Task<Statystyka> GetStatystykaById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Statystyka>> GetStatystyki()
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public Task UpdateStatystyka(Statystyka statystyka)
        {
            throw new NotImplementedException();
        }
    }
}
