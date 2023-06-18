using FootballClubLibrary.Models;

namespace BusinessLogicLayer.Interfaces
{
    public interface IZarzadService
    {
        Task<IEnumerable<Zarzad>> DajZarzady();
        Task<decimal> DajWynikFinansowyZarzadu(Guid IdZarzadu);
        Task DodajCelZarzadu(Guid IdZarzadu, string cel);
        Task DodajCzlonkaZarzadu(Guid IdZarzadu, Guid PracownikId);
        Task ZmienBudzetZarzadu(Guid IdZarzadu, decimal budget);
    }
}