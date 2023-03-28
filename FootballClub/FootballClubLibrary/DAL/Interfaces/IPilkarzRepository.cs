using FootballClubLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubLibrary.Interfaces
{
    public interface IPilkarzRepository
    {
        Task<IEnumerable<Pilkarz>> GetPilkarze();
        Task<Pilkarz> GetPilkarzById(Guid id);
        Task CreatePilkarz(Pilkarz pilkarz);
        Task DeletePilkarz(Guid id);
        Task UpdatePilkarz(Pilkarz pilkarz);
        Task Save();

        DbSet<Pilkarz> GetDbSetPilkarze();
    }
}
