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
            if(klub.ArchiwalniPilkarze == null)
            {
                klub.ArchiwalniPilkarze = new List<Pilkarz>() { };
            }

            if(klub.ObecniPilkarze == null)
            {
                klub.ObecniPilkarze = new List<Pilkarz>() { };
            }
            await this.dbContext.Kluby.AddAsync(klub);
            await this.Save();
        }

        public async Task DeleteKlub(Guid id)
        {
            var klub = await this.dbContext.Kluby.FindAsync(id);
            this.dbContext.Kluby.Remove(klub);
            await this.Save();
        }

		public async Task UpdateKlub(Klub klub)
		{
			this.dbContext.Entry(klub).State = EntityState.Modified;
            await this.Save();
        }

        public async Task<Klub> GetKlubById(Guid? id)
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
            klub.Trofea += $", {trofeum}";
            await this.Save();
        }

        public async Task DodajPilkarzaDoObecnych(Klub klub, Pilkarz pilkarz)
        {
            bool czyPilkarzJestWObecnych = klub.ObecniPilkarze == null ? false : (klub.ObecniPilkarze.Contains(pilkarz));
            if (pilkarz == null || klub == null || czyPilkarzJestWObecnych == true)
            {
                return;
            }

            if (klub.ObecniPilkarze == null)
            {
                klub.ObecniPilkarze = new List<Pilkarz>() { };
            }

            klub.ObecniPilkarze.Add(pilkarz);
            pilkarz.IdKlubu = klub.IdKlub;

            if (klub.ArchiwalniPilkarze != null)
            {
                if (klub.ArchiwalniPilkarze.Contains(pilkarz))
                {
                    klub.ArchiwalniPilkarze.Remove(pilkarz);
                }
            }
            await this.Save();
        }

        public async Task DodajPilkarzaDoArchiwalnych(Klub klub, Pilkarz pilkarz)
        {
            if (pilkarz == null || klub == null)
            {
                return;
            }

            if (klub.ObecniPilkarze == null)
            {
                klub.ObecniPilkarze = new List<Pilkarz>() { };
            }

            if (klub.ArchiwalniPilkarze == null)
            {
                klub.ArchiwalniPilkarze = new List<Pilkarz>() { };
            }

            if (!klub.ArchiwalniPilkarze.Contains(pilkarz))
            {
                if (klub.ObecniPilkarze.Contains(pilkarz))
                {
                    klub?.ObecniPilkarze.Remove(pilkarz);
                }
                klub.ArchiwalniPilkarze.Add(pilkarz);
                pilkarz.ArchiwalneKluby?.Add(klub);
                await this.Save();
            }
        }

        public async Task UsunPilkarzaZObecnych(Klub klub, Pilkarz pilkarz)
        {
            bool czyPilkarzJestWObecnych = klub.ObecniPilkarze == null ? false : (klub.ObecniPilkarze.Contains(pilkarz));
            if (pilkarz == null || klub == null || czyPilkarzJestWObecnych == false)
            {
                return;
            }
            klub.ObecniPilkarze?.Remove(pilkarz);
            klub.ArchiwalniPilkarze?.Add(pilkarz);
            await this.Save();
        }

        public async Task DodajPilkarzyDoObecnych(Klub klub, List<Pilkarz> pilkarze)
        {
            if (klub == null || pilkarze == null)
            {
                return;
            }
            foreach (var pilkarz in pilkarze)
            {
                if (pilkarz != null)
                {
                    klub?.ObecniPilkarze.Add(pilkarz);
                }
            }
            await this.Save();
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