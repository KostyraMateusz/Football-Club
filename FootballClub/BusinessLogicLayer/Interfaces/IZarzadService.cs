using FootballClubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IZarzadService
    {
        Task DodajCzlonkaZarzadu(Pracownik pracownik, Zarzad zarzad);
        Task<decimal> DajBudzetZarzadu(Zarzad zarzad);
        Task ZmienBudzetZarzadu(Zarzad zarzad, decimal budget);
        Task DodajCelZarzadu(string target, Zarzad zarzad);
    }
}
