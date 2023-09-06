using FootballClubLibrary.Interfaces;
using FootballClubLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace TestsFootballClub.BLL.FakeRepositories
{
    public class FakePracownikRepository : IPracownikRepository
    {
        private List<Pracownik> pracownicy = new List<Pracownik>();

        public DbSet<Pracownik> GetDbSetPracownicy()
        {
            throw new NotImplementedException();
        }

        public async Task CreatePracownik(Pracownik pracownik)
        {
            pracownicy.Add(pracownik);
            return;
        }

        public async Task DeletePracownik(Guid id)
        {
            var pracownik = await Task.FromResult(pracownicy.Find(p => p.IdPracownik == id));
            pracownicy.Remove(pracownik);
            return;
        }

        public async Task UpdatePracownik(Pracownik pracownik)
        {
            var index = await Task.FromResult(pracownicy.FindIndex(p => p.IdPracownik == pracownik.IdPracownik));
            if (index != -1)
            {
                pracownicy[index] = pracownik;
            }
            return;
        }

        public async Task<Pracownik> GetPracownikById(Guid id)
        {
            var result = await Task.FromResult(pracownicy.Find(p => p.IdPracownik == id));
            return result;
        }

        public async Task<IEnumerable<Pracownik>> GetPracownicy()
        {
            var result = await Task.FromResult(pracownicy);
            return result;
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }
    }
}