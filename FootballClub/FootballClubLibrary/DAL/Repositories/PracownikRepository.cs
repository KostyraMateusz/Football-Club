using FootballClubLibrary.Data;
using FootballClubLibrary.Interfaces;
using FootballClubLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballClubLibrary.Repositories
{
    public class PracownikRepository : IPracownikRepository, IDisposable
    {
		private bool disposed = false;
		private readonly ApplicationDbContext dbContext;

        public PracownikRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

		public DbSet<Pracownik> GetDbSetPracownicy()
		{
			var result = this.dbContext.Pracownicy;
			return result;
		}

		public async Task CreatePracownik(Pracownik pracownik)
        {
            await this.dbContext.Pracownicy.AddAsync(pracownik);
        }

        public async Task DeletePracownik(Guid id)
        {
            var pracownik = await this.dbContext.Pracownicy.FindAsync(id);
            this.dbContext.Pracownicy.Remove(pracownik);
        }

		public async Task UpdatePracownik(Pracownik pracownik)
		{
			this.dbContext.Entry(pracownik).State = EntityState.Modified;
		}

		public async Task<IEnumerable<Pracownik>> GetPracownicy()
        {
            var pracownicy = await this.dbContext.Pracownicy.ToListAsync();
            return pracownicy;
        }

        public async Task<Pracownik> GetPracownikById(Guid id)
        {
           var pracownik = await this.dbContext.Pracownicy.FindAsync(id);
           return pracownik;
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