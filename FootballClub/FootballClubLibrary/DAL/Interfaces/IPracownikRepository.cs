using FootballClubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubLibrary.Interfaces
{
    public interface IPracownikRepository
    {
        IEnumerable<Pracownik> GetPracownicy();
        Pracownik GetPracownikById(Guid id);
        void CreatePracownik(Pracownik pracownik);
        void DeletePracownik(Guid id);
        void UpdatePracownik(Pracownik pracownik);
        void Save();
    }
}
