using FootballClubLibrary.Models;

namespace BusinessLogicLayer.Interfaces
{
    public interface IPilkarzService
    {
        Task DodajPilkarza(Pilkarz pilkarz);
		Task UsunPilkarza(Guid IdPilkarz);
		Task EdytujPilkarza(Pilkarz pilkarz, Guid IdPilkarz);
		Task<Pilkarz> DajPilkarza(Guid IdPilkarz);
        Task<IEnumerable<Pilkarz>> DajPilkarzy();
		Task<IEnumerable<Pilkarz>> DajPilkarzyBezKlubu();
		Task<IEnumerable<Klub>> DajArchiwalneKlubyPilkarza(Pilkarz pilkarz);
        Task<Statystyka> DajStatystykePilkarza(Pilkarz pilkarz, Guid IdStatystyka);
        Task<IEnumerable<Statystyka>> DajNajlepszeStatystykiPilkarza(Pilkarz pilkarz);
        Task<IEnumerable<Statystyka>> DajStatystykiPilkarza(Pilkarz pilkarz);
		Task ZmienPozycjePilkarza(Pilkarz pilkarz, string pozycja);
	}
}