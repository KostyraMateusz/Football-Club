using FootballClubLibrary.Models;

namespace BusinessLogicLayer.Interfaces
{
    public interface IKlubService
    {
		Task<IEnumerable<Klub>> DajKluby();
		Task DodajKlub(Klub klub);
		Task UsunKlub(Guid IdKlubu);
		Task EdytujKlub(Klub klub);
		Task<Klub> DajKlub(Guid IdKlubu);
		Task<IEnumerable<Pilkarz>> DajArchiwalnychPilkarzy(Guid IdKlubu);
        Task<Pilkarz> DajArchiwalnegoPilkarza(Guid IdKlubu, Guid IdPilkarza);
        Task <IEnumerable<Pilkarz>> DajObecnychPilkarzy(Klub klub);
        Task<Pilkarz> DajObecnegoPilkarza(Guid IdKlubu, Guid IdPilkarza);
		Task DodajPilkarzaDoObecnych(Pilkarz pilkarz, Klub klub);
		Task DodajPilkarzyDoObecnych(List<Pilkarz> pilkarze, Klub klub);
		Task UsunPilkarzaZObecnych(Guid PilkarzId, Guid IdKlubu);
		Task<string> DajStadionKlubu(Klub klub);
        Task<string> DajTrofeaKlubu(Klub klub);
    }
}