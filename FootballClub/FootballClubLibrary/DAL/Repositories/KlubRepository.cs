
using FootballClubLibrary.Data;
using FootballClubLibrary.Intefaces;
using FootballClubLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace FootballClubLibrary.Repositories
{
    public class KlubRepository : IKlubRepository, IDisposable
    {
        private readonly ApplicationDbContext dbContext;
        private bool disposed = false;

        public KlubRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateKlub(Klub? klub)
        {
            await this.dbContext.Kluby.AddAsync(klub);
        }

        public async Task DeleteKlub(Guid id)
        {
            var klub = await this.dbContext.Kluby.FindAsync(id);
            this.dbContext.Kluby.Remove(klub);
        }

        public async Task<Klub> GetKlubById(Guid id)
        {
            return await this.dbContext.Kluby.FindAsync(id);
        }

        public async Task<IEnumerable<Klub>> GetKluby()
        {
            return await this.dbContext.Kluby.ToListAsync();
        }

        public async Task UpdateKlub(Klub klub)
        {
            this.dbContext.Entry(klub).State = EntityState.Modified;
        }

        public async Task DodajTrofeumKlubu(Guid id, string trofeum)
        {
            var klub = await this.dbContext.Kluby.FindAsync(id);
            klub.Trofea += $"{trofeum}, ";
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public DbSet<Klub> GetDbSetKluby()
        {
            var result = this.dbContext.Kluby;
            return result;
        }

        public async Task Save()
        {
            await this.dbContext.SaveChangesAsync();
        }
    }
}
