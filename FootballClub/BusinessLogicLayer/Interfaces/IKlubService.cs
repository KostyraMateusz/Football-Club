using FootballClubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IKlubService
    {
        Task<IEnumerable<Klub>> DajKluby();
        Task<IEnumerable<Pilkarz>> DajArchiwalnychPilkarzy(Guid IdKlubu);
        Task<Pilkarz> DajArchiwalnegoPilkarza(Guid IdKlubu, Guid IdPilkarza);
        Task <IEnumerable<Pilkarz>> DajObecnychPilkarzy(Guid IdKlubu);
        Task<Pilkarz> DajObecnegoPilkarza(Guid IdKlubu, Guid IdPilkarza);
        Task<string> DajStadionKlubu(Guid IdKlubu);
        Task<string> DajTrofeaKlubu(Guid IdKlubu);
        Task DodajPilkarzaDoObecnych(Pilkarz pilkarz, Guid IdKlubu);
        Task UsunPilkarzaZObecnych(Guid PilkarzId, Guid IdKlubu);
        Task DodajPilkarzyDoObecnych(List<Pilkarz> pilkarze, Klub klub);
    }
}
