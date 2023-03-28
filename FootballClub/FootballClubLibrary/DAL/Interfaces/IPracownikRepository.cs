using FootballClubLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubLibrary.Interfaces
{
    public interface IPracownikRepository
    {
        Task<IEnumerable<Pracownik>> GetPracownicy();
        Task<Pracownik> GetPracownikById(Guid id);
        Task CreatePracownik(Pracownik pracownik);
        Task DeletePracownik(Guid id);
        Task UpdatePracownik(Pracownik pracownik);
        Task Save();
        DbSet<Pracownik> GetDbSetPracownicy();
    }
}
