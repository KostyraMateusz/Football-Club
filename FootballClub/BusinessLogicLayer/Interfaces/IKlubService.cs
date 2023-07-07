using FootballClubLibrary.Models;

namespace BusinessLogicLayer.Interfaces
{
    public interface IKlubService
    {
        Task DodajKlub(Klub klub);
        Task UsunKlub(Guid IdKlubu);
        Task EdytujKlub(Klub klub);
        Task<Klub> DajKlub(Guid IdKlubu);
        Task<IEnumerable<Klub>> DajKluby();
        Task DodajPilkarzaDoObecnych(Pilkarz pilkarz, Klub klub);
        Task DodajPilkarzyDoObecnych(List<Pilkarz> pilkarze, Klub klub);
        Task UsunPilkarzaZObecnych(Guid PilkarzId, Guid IdKlubu);
        Task<Pilkarz> DajObecnegoPilkarza(Guid IdKlubu, Guid IdPilkarza);
        Task <IEnumerable<Pilkarz>> DajObecnychPilkarzy(Klub klub);
        Task<Pilkarz> DajArchiwalnegoPilkarza(Guid IdKlubu, Guid IdPilkarza);
        Task<IEnumerable<Pilkarz>> DajArchiwalnychPilkarzy(Guid IdKlubu);
        Task<string> DajStadionKlubu(Klub klub);
        Task<string> DajTrofeaKlubu(Klub klub);
    }
}