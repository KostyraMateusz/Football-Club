using FootballClubLibrary.Data;
using FootballClubLibrary.Interfaces;
using FootballClubLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballClubLibrary.Repositories
{
    public class KlubRepository : IKlubRepository, IDisposable
    {
		private bool disposed = false;
		private readonly ApplicationDbContext dbContext;

        public KlubRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

		public DbSet<Klub> GetDbSetKluby()
		{
			var result = this.dbContext.Kluby;
			return result;
		}

		public async Task CreateKlub(Klub klub)
        {
            await this.dbContext.Kluby.AddAsync(klub);
        }

        public async Task DeleteKlub(Guid id)
        {
            var klub = await this.dbContext.Kluby.FindAsync(id);
            this.dbContext.Kluby.Remove(klub);
        }

		public async Task UpdateKlub(Klub klub)
		{
			this.dbContext.Entry(klub).State = EntityState.Modified;
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<Klub> GetKlubById(Guid id)
        {
            var klub = await this.dbContext.Kluby.FindAsync(id);
            return klub;
        }

        public async Task<IEnumerable<Klub>> GetKluby()
		{
			var kluby = await this.dbContext.Kluby.ToListAsync();
            return kluby;
		}

        public async Task DodajTrofeumKlubu(Guid id, string trofeum)
        {
            var klub = await this.dbContext.Kluby.FindAsync(id);
            klub.Trofea += $"{trofeum}, ";
        }

		public async Task Save()
		{
			await this.dbContext.SaveChangesAsync();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.dbContext.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}