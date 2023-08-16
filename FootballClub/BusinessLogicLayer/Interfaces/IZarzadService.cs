using FootballClubLibrary.Models;

namespace BusinessLogicLayer.Interfaces
{
    public interface IZarzadService
    {
        Task DodajZarzad(Zarzad zarzad);
        Task UsunZarzad(Guid IdZarzadu);
        Task EdytujZarzad(Zarzad zarzad);
        Task<Zarzad> DajZarzad(Guid IdZarzadu);
        Task<IEnumerable<Zarzad>> DajZarzady();
        Task<decimal> DajWynikFinansowyZarzadu(Guid IdZarzadu);
        Task DodajCelZarzadu(Guid IdZarzadu, string cel);
        Task DodajCzlonkaZarzadu(Guid IdZarzadu, Guid PracownikId);
        Task UsunCzlonkaZarzadu(Guid IdZarzadu, Guid PracownikId);
        Task ZmienBudzetZarzadu(Guid IdZarzadu, decimal budget);
    }
}