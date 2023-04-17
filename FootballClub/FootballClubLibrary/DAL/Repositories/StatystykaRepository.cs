using FootballClubLibrary.Data;
using FootballClubLibrary.Interfaces;
using FootballClubLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubLibrary.Repositories
{
    public class StatystykaRepository : IStatystykaRepository, IDisposable
    {
        private bool disposed = false;
        private readonly ApplicationDbContext dbContext;

        public StatystykaRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateStatystyka(Statystyka statystyka)
        {
            await this.dbContext.Statystyki.AddAsync(statystyka);
        }

        public async Task DeleteStatystyka(Guid id)
        {
            var statystyka = await this.dbContext.Statystyki.FindAsync(id);
            this.dbContext.Statystyki.Remove(statystyka);
        }

        public async Task<Statystyka> GetStatystykaById(Guid id)
        {
            var statystyka = await this.dbContext.Statystyki.FindAsync(id);
            return statystyka;
        }

        public async Task<IEnumerable<Statystyka>> GetStatystyki()
        {
            var statystyki = await this.dbContext.Statystyki.ToListAsync();
            return statystyki;
        }

        public async Task UpdateStatystyka(Statystyka statystyka)
        {
            this.dbContext.Entry(statystyka).State = EntityState.Modified;
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

        public async Task Save()
        {
            await this.dbContext.SaveChangesAsync();
        }

        public DbSet<Statystyka> GetDbSetStatystyki()
        {
            var result = this.dbContext.Statystyki;
            return result;
        }
    }
}
