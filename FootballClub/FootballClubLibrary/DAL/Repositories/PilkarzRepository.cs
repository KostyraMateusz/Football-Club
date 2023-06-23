using FootballClubLibrary.Data;
using FootballClubLibrary.Interfaces;
using FootballClubLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballClubLibrary.Repositories
{
    public class PilkarzRepository : IPilkarzRepository, IDisposable
    {
		private bool disposed = false;
		private readonly ApplicationDbContext dbContext;

        public PilkarzRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

		public DbSet<Pilkarz> GetDbSetPilkarze()
		{
			var result = this.dbContext.Pilkarze;
			return result;
		}

		public async Task CreatePilkarz(Pilkarz pilkarz)
        {
            await this.dbContext.Pilkarze.AddAsync(pilkarz);
        }

        public async Task DeletePilkarz(Guid id)
        {
            var pilkarz = await this.dbContext.Pilkarze.FindAsync(id);
            this.dbContext.Pilkarze.Remove(pilkarz);
        }

		public async Task UpdatePilkarz(Pilkarz pilkarz)
		{
			this.dbContext.Entry(pilkarz).State = EntityState.Modified;
		}

		public async Task<IEnumerable<Pilkarz>> GetPilkarze()
		{
			var pilkarze = await this.dbContext.Pilkarze.Include(z => z.Klub).ToListAsync();
            return pilkarze;
		}

		public async Task<Pilkarz> GetPilkarzById(Guid id)
        {
            var pilkarz = await this.dbContext.Pilkarze.FindAsync(id);
            return pilkarz;
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