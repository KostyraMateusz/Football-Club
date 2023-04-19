using FootballClubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IPracownikService
    {
        Task<IEnumerable<Pracownik>> DajPracownikow();
        Task ZmienFunkcjePracownika(Guid IdPracownik, string funkcja);
        Task ZmienWynagrodzenie(Guid IdPracownik, decimal wynagrodzenie);
        Task ZmienWiekPracownika(Guid IdPracownika, int wiek);
    }
}
