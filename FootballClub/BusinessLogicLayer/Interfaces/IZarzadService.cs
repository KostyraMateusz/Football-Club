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
        Task<decimal> DajBudzetZarzadu(Guid IdZarzadu);
        Task DodajCelZarzadu(Guid IdZarzadu, string cel);
        Task DodajCzlonkaZarzadu(Guid IdZarzadu, Pracownik pracownik);
        Task ZmienBudzetZarzadu(Guid IdZarzadu, decimal budget);
    }
}
