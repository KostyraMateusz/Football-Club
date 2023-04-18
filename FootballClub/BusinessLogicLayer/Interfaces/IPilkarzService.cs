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
        Task<IEnumerable<Klub>> DajArchiwalneKlubyPilkarza(Guid IdPilkarz);
        Task<Statystyka> DajStatystykePilkarza(Guid IdStatystyka, Guid IdPilkarza);
        Task<IEnumerable<Statystyka>> DajStatystykiPilkarza(Guid IdPilkarz);
        Task ZmienPozycjePilkarza(Guid IdPilkarza, string pozycja);
        Task<IEnumerable<Statystyka>> DajNajlepszeStatystykiPilkarza(Guid IdPilkarz);
        Task<IEnumerable<Pilkarz>> DajPilkarzyBezKlubu();
    }
}
