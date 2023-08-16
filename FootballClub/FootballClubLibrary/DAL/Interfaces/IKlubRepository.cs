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

		Task DodajPilkarzaDoObecnych(Klub klub, Pilkarz pilkarz);

		Task DodajPilkarzaDoArchiwalnych(Klub klub, Pilkarz pilkarz);

		Task UsunPilkarzaZObecnych(Klub klub, Pilkarz pilkarz);
		Task DodajPilkarzyDoObecnych(Klub klub, List<Pilkarz> pilkarze);
		Task Save();
    }
}