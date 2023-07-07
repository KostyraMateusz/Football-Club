using FootballClubLibrary.Models;

namespace BusinessLogicLayer.Interfaces
{
    public interface IStatystykaService
    {
        Task DodajStatystyke(Statystyka statystyka);
        Task UsunStatystyke(Guid IdStatystyka);
        Task EdytujStatystyke(Statystyka statystyka);
        Task<Statystyka> DajStatystyke(Guid IdStatystyka);
        Task<IEnumerable<Statystyka>> DajStatystyki();
        Task<Statystyka>DajStatystykeMeczu(string mecz);
        Task<IEnumerable<Statystyka>> DajStatystkiZoltejKartki();
        Task<IEnumerable<Statystyka>> DajStatystykiCzerwonychKartek();
        Task<IEnumerable<Statystyka>> DajStatystykeNajdluzszePrzebiegnieteDystanse();
    }
}