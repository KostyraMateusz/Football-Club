using FootballClubLibrary.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TestsFootballClub.DAL.DummyRepositories
{
    public class DummyPilkarzRepository : IPilkarzRepository
    {
        public Task CreatePilkarz(Pilkarz pilkarz)
        {
            throw new NotImplementedException();
        }

        public Task DeletePilkarz(Guid id)
        {
            throw new NotImplementedException();
        }

        public DbSet<Pilkarz> GetDbSetPilkarze()
        {
            throw new NotImplementedException();
        }

        public Task<Pilkarz> GetPilkarzById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Pilkarz>> GetPilkarze()
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public Task UpdatePilkarz(Pilkarz pilkarz)
        {
            throw new NotImplementedException();
        }
    }
}