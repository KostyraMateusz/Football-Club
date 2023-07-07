using FootballClubLibrary.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TestsFootballClub.FakeRepositories
{
    public class FakeKlubRepository : IKlubRepository
    {
        private List<Klub> kluby = new List<Klub>();

        public DbSet<Klub> GetDbSetKluby()
        {
            throw new NotImplementedException();
        }

        public async Task CreateKlub(Klub klub)
        {
            kluby.Add(klub);
            return;
        }

        public async Task DeleteKlub(Guid id)
        {
            var klub = await Task.FromResult(kluby.Find(k => k.IdKlub == id));
            kluby.Remove(klub);
            return;
        }

        public async Task UpdateKlub(Klub klub)
        {
            var index = await Task.FromResult(kluby.FindIndex(p => p.IdKlub == klub.IdKlub));
            if (index != -1)
            {
                kluby[index] = klub;
            }
            return;
        }

        public async Task<Klub> GetKlubById(Guid id)
        {
            var klub = await Task.FromResult(kluby.Find(k => k.IdKlub == id));
            return klub;
        }

        public async Task<IEnumerable<Klub>> GetKluby()
        {
            var kluby = await Task.FromResult(this.kluby);
            return kluby;
        }

        public async Task DodajTrofeumKlubu(Guid id, string trofeum)
        {
            var klub = await Task.FromResult(this.kluby.Find(k=>k.IdKlub == id));
            if (klub != null)
            {
                klub.Trofea += $"{trofeum}, ";
            }
            return;
        }

        public int IleJestKlubow()
        {
            return kluby.Count();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }
    }
}