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

		public async Task UpdatePracownik(Pracownik pracownik, Guid id)
		{
            var prac = await this.dbContext.Pracownicy.FirstAsync(p => p.IdPracownik == id);
            prac.Imie = pracownik.Imie;
            prac.Nazwisko = pracownik.Nazwisko;
            prac.PESEL = pracownik.PESEL;
            prac.Wiek = pracownik.Wiek;
            prac.WykonywanaFunkcja = pracownik.WykonywanaFunkcja;
            prac.Wynagrodzenie = pracownik.Wynagrodzenie;
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<Pracownik> GetPracownikById(Guid id)
        {
            var pracownik = await this.dbContext.Pracownicy.FindAsync(id);
            return pracownik;
        }

        public async Task<IEnumerable<Pracownik>> GetPracownicy()
        {
            var pracownicy = await dbContext.Pracownicy.Include(p => p.Zarzad).ThenInclude(z => z.Klub).ToListAsync();
            return pracownicy;
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