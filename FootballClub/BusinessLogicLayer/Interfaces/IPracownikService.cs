using FootballClubLibrary.Models;

namespace BusinessLogicLayer.Interfaces
{
    public interface IPracownikService
    {
        Task DodajPracownika(Pracownik pracownik);
        Task UsunPracownika(Guid IdPracownika);
        Task EdytujPracownika(Pracownik pracownik);
        Task<Pracownik> DajPracownika(Guid IdPracownika);
        Task<IEnumerable<Pracownik>> DajPracownikow();
        Task ZmienFunkcjePracownika(Guid IdPracownik, string funkcja);
        Task ZmienWynagrodzenie(Guid IdPracownik, decimal wynagrodzenie);
        Task ZmienWiekPracownika(Guid IdPracownika, int wiek);
    }
}