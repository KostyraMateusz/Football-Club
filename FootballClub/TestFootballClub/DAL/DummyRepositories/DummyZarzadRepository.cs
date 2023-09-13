using FootballClubLibrary.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TestsFootballClub.DAL.DummyRepositories
{
    public class DummyZarzadRepository : IZarzadRepository
    {
        public Task CreateZarzad(Zarzad zarzad)
        {
            throw new NotImplementedException();
        }

        public Task DeleteZarzad(Guid id)
        {
            throw new NotImplementedException();
        }

        public DbSet<Zarzad> GetDbSetZarzady()
        {
            throw new NotImplementedException();
        }

        public Task<Zarzad> GetZarzadById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Zarzad>> GetZarzady()
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public Task UpdateZarzad(Zarzad zarzad)
        {
            throw new NotImplementedException();
        }
    }
}
