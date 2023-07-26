using FootballClubLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballClubLibrary.Interfaces
{
    public interface IKlubRepository
    {
		DbSet<Klub> GetDbSetKluby();
		Task CreateKlub(Klub klub);
		Task DeleteKlub(Guid id);
		Task UpdateKlub(Klub klub);
        Task<Klub> GetKlubById(Guid? id);
        Task<IEnumerable<Klub>>GetKluby();
		Task DodajTrofeumKlubu(Guid id, string trofeum);
		Task Save();
    }
}