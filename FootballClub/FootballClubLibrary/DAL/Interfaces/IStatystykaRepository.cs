using FootballClubLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballClubLibrary.Interfaces
{
    public interface IStatystykaRepository
    {
		DbSet<Statystyka> GetDbSetStatystyki();
		Task CreateStatystyka(Statystyka statystyka);
		Task DeleteStatystyka(Guid id);
		Task UpdateStatystyka(Statystyka statystyka);
		Task<IEnumerable<Statystyka>> GetStatystyki();
        Task<Statystyka> GetStatystykaById(Guid id);
        Task Save();
    }
}