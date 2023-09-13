using FootballClubLibrary.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TestsFootballClub.DAL.DummyRepositories
{
    public class DummyPracownikRepository : IPracownikRepository
    {
        public Task CreatePracownik(Pracownik pracownik)
        {
            throw new NotImplementedException();
        }

        public Task DeletePracownik(Guid id)
        {
            throw new NotImplementedException();
        }

        public DbSet<Pracownik> GetDbSetPracownicy()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Pracownik>> GetPracownicy()
        {
            throw new NotImplementedException();
        }

        public Task<Pracownik> GetPracownikById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public Task UpdatePracownik(Pracownik pracownik)
        {
            throw new NotImplementedException();
        }
    }
}
