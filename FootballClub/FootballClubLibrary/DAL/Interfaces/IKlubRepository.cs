using FootballClubLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubLibrary.Intefaces
{
    public interface IKlubRepository
    {
        Task<IEnumerable<Klub>>GetKluby();
        Task<Klub> GetKlubById(Guid id);
        Task CreateKlub(Klub klub);
        Task DeleteKlub(Guid id);
        Task UpdateKlub(Klub klub);
        Task Save();
        DbSet<Klub> GetDbSetKluby();
        Task DodajTrofeumKlubu(Guid id, string trofeum);
    }
}
