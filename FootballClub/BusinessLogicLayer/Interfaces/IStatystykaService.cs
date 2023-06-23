using FootballClubLibrary.Models;

namespace BusinessLogicLayer.Interfaces
{
    public interface IStatystykaService
    {
        Task<IEnumerable<Statystyka>> DajStatystyki();
        Task<Statystyka>DajStatystykeMeczu(string mecz);
        Task<IEnumerable<Statystyka>> DajStatystkiZoltejKartki();
        Task<IEnumerable<Statystyka>> DajStatystykiCzerwonychKartek();
        Task<IEnumerable<Statystyka>> DajStatystykeNajdluzszePrzebiegnieteDystanse();
    }
}