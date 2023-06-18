using FootballClubLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballClubLibrary.Interfaces
{
    public interface IZarzadRepository
    {
		DbSet<Zarzad> GetDbSetZarzady();
		Task CreateZarzad(Zarzad zarzad);
		Task DeleteZarzad(Guid id);
		Task UpdateZarzad(Zarzad zarzad);
		Task<IEnumerable<Zarzad>> GetZarzady();
        Task<Zarzad> GetZarzadById(Guid id);
        Task Save();
    }
}