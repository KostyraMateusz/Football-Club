using FootballClubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IPilkarzService
    {
        Task<IEnumerable<Pilkarz>> DajPilkarzy();
        Task<IEnumerable<Klub>> DajArchiwalneKlubyPilkarza(Pilkarz pilkarz);
        Task<Statystyka> DajStatystykePilkarza(Pilkarz pilkarz, Guid IdStatystyka);
        Task<IEnumerable<Statystyka>> DajStatystykiPilkarza(Pilkarz pilkarz);
        Task ZmienPozycjePilkarza(Pilkarz pilkarz, string pozycja);
        Task<IEnumerable<Statystyka>> DajNajlepszeStatystykiPilkarza(Pilkarz pilkarz);
        Task<IEnumerable<Pilkarz>> DajPilkarzyBezKlubu();
    }
}
