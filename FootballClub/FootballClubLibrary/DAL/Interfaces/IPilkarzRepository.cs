using FootballClubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubLibrary.Interfaces
{
    public interface IPilkarzRepository
    {
        IEnumerable<Pilkarz> GetPilkarze();
        Pilkarz GetPilkarzById(Guid id);
        void CreatePilkarz(Pilkarz pilkarz);
        void DeletePilkarz(Guid id);
        void UpdatePilkarz(Pilkarz pilkarz);
        void Save();
    }
}
