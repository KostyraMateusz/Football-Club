using FootballClubLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballClubLibrary.Interfaces
{
    public interface IPracownikRepository
    {
		DbSet<Pracownik> GetDbSetPracownicy();
		Task CreatePracownik(Pracownik pracownik);
		Task DeletePracownik(Guid id);
		Task UpdatePracownik(Pracownik pracownik, Guid id);
        Task<Pracownik> GetPracownikById(Guid id);
        Task<IEnumerable<Pracownik>> GetPracownicy();
        Task Save();
    }
}