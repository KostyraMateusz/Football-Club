using FootballClubLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballClubLibrary.Interfaces
{
    public interface IPilkarzRepository
    {
		DbSet<Pilkarz> GetDbSetPilkarze();
		Task CreatePilkarz(Pilkarz pilkarz);
		Task DeletePilkarz(Guid id);
		Task UpdatePilkarz(Pilkarz pilkarz);
        Task<Pilkarz> GetPilkarzById(Guid id);
        Task<IEnumerable<Pilkarz>> GetPilkarze();
        Task Save();
    }
}