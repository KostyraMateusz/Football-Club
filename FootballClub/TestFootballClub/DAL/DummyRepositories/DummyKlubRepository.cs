using FootballClubLibrary.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TestsFootballClub.DAL.DummyRepositories
{
    public class DummyKlubRepository : IKlubRepository
    {
        public DbSet<Klub> GetDbSetKluby()
        {
            throw new NotImplementedException();
        }

        public Task CreateKlub(Klub klub)
        {
            throw new NotImplementedException();
        }

        public Task DeleteKlub(Guid id)
        {
            throw new NotImplementedException();
        }
        public Task UpdateKlub(Klub klub)
        {
            throw new NotImplementedException();
        }

        public Task<Klub> GetKlubById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Klub>> GetKluby()
        {
            throw new NotImplementedException();
        }

        public Task DodajTrofeumKlubu(Guid id, string trofeum)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }
    }
}