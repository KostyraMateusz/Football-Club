using FootballClubLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubLibrary.Interfaces
{
    public interface IZarzadRepository
    {
        Task<IEnumerable<Zarzad>> GetZarzady();
        Task<Zarzad> GetZarzadById(Guid id);
        Task CreateZarzad(Zarzad zarzad);
        Task DeleteZarzad(Guid id);
        Task UpdateZarzad(Zarzad zarzad);
        Task Save();
        DbSet<Zarzad> GetDbSetZarzady();
    }
}
