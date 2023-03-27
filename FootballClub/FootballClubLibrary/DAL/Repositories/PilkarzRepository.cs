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

        public void CreatePilkarz(Pilkarz pilkarz)
        {
            this.dbContext.Pilkarze.Add(pilkarz);
        }

        public void DeletePilkarz(Guid id)
        {
            var pilkarz = this.dbContext.Pilkarze.Find(id);
            this.dbContext.Pilkarze.Remove(pilkarz);
        }

        public Pilkarz GetPilkarzById(Guid id)
        {
            var pilkarz = this.dbContext.Pilkarze.Find(id);
            return pilkarz;
        }

        public IEnumerable<Pilkarz> GetPilkarze()
        {
            var pilkarze = this.dbContext.Pilkarze.ToList();
            return pilkarze;
        }

        public void UpdatePilkarz(Pilkarz pilkarz)
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

        public void Save()
        {
            this.dbContext.SaveChanges();
        }
    }
}
