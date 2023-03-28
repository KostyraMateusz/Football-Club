using FootballClubLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubLibrary.Interfaces
{
    public interface IStatystykaRepository
    {
        Task<IEnumerable<Statystyka>> GetStatystyki();
        Task<Statystyka> GetStatystykaById(Guid id);
        Task CreateStatystyka(Statystyka statystyka);
        Task DeleteStatystyka(Guid id);
        Task UpdateStatystyka(Statystyka statystyka);
        Task Save();
        DbSet<Statystyka> GetDbSetStatystyki();
    }
}
