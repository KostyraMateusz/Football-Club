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
    public class PilkarzRepository : IPilkarzRepository, IDisposable
    {
        private readonly ApplicationDbContext dbContext;
        private bool disposed = false;

        public PilkarzRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
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

        public async Task<Pilkarz> GetPilkarzById(Guid id)
        {
            var pilkarz = await this.dbContext.Pilkarze.FindAsync(id);
            return pilkarz;
        }

        public async Task<IEnumerable<Pilkarz>> GetPilkarze()
        {
            var pilkarze = await this.dbContext.Pilkarze.ToListAsync();
            return pilkarze;
        }

        public async Task UpdatePilkarz(Pilkarz pilkarz)
        {
            this.dbContext.Entry(pilkarz).State = EntityState.Modified;
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
            this.dbContext.SaveChangesAsync();
        }

        public DbSet<Pilkarz> GetDbSetPilkarze()
        {
            var result = this.dbContext.Pilkarze;
            return result;
        }
    }
}
