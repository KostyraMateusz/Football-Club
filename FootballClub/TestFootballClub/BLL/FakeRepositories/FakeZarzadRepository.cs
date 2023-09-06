using FootballClubLibrary.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TestsFootballClub.FakeRepositories
{
    public class FakeZarzadRepository : IZarzadRepository
    {
        private List<Zarzad> zarzady = new List<Zarzad>();

        public DbSet<Zarzad> GetDbSetZarzady()
        {
            throw new NotImplementedException();
        }

        public async Task CreateZarzad(Zarzad zarzad)
        {
            zarzady.Add(zarzad);
            return;
        }

        public async Task UpdateZarzad(Zarzad zarzad)
        {
            var index = await Task.FromResult(zarzady.FindIndex(z => z.IdZarzad == zarzad.IdZarzad));
            if (index != -1)
            {
                zarzady[index] = zarzad;
            }
            return;
        }

        public async Task DeleteZarzad(Guid id)
        {
            var zarzad = await Task.FromResult(zarzady.Find(z => z.IdZarzad == id));
            zarzady.Remove(zarzad);
            return;
        }

        public async Task<Zarzad> GetZarzadById(Guid id)
        {
            var result = await Task.FromResult(zarzady.Find(z => z.IdZarzad == id));
            return result;
        }

        public async Task<IEnumerable<Zarzad>> GetZarzady()
        {
            var result = await Task.FromResult(zarzady);
            return result;
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }
    }
}