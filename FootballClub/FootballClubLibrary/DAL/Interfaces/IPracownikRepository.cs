using FootballClubLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballClubLibrary.Interfaces
{
    public interface IPracownikRepository
    {
		DbSet<Pracownik> GetDbSetPracownicy();
		Task CreatePracownik(Pracownik pracownik);
		Task DeletePracownik(Guid id);
		Task UpdatePracownik(Pracownik pracownik);
		Task<IEnumerable<Pracownik>> GetPracownicy();
        Task<Pracownik> GetPracownikById(Guid id);
        Task Save();
    }
}