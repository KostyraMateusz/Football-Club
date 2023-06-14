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
        Task DodajKlub(Klub klub);
        Task EdytujKlub(Klub klub);
        Task UsunKlub(Guid IdKlubu);
        Task<IEnumerable<Klub>> DajKluby();
        Task<Klub> DajKlub(Guid IdKlubu);
        Task<IEnumerable<Pilkarz>> DajArchiwalnychPilkarzy(Guid IdKlubu);
        Task<Pilkarz> DajArchiwalnegoPilkarza(Guid IdKlubu, Guid IdPilkarza);
        Task <IEnumerable<Pilkarz>> DajObecnychPilkarzy(Klub klub);
        Task<Pilkarz> DajObecnegoPilkarza(Guid IdKlubu, Guid IdPilkarza);
        Task<string> DajStadionKlubu(Klub klub);
        Task<string> DajTrofeaKlubu(Klub klub);
        Task DodajPilkarzaDoObecnych(Pilkarz pilkarz, Klub klub);
        Task UsunPilkarzaZObecnych(Guid PilkarzId, Guid IdKlubu);
        Task DodajPilkarzyDoObecnych(List<Pilkarz> pilkarze, Klub klub);
    }
}
