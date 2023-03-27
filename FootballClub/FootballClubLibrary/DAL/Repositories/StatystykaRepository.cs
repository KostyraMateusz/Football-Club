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

        public void CreateStatystyka(Statystyka statystyka)
        {
            this.dbContext.Statystyki.Add(statystyka);
        }

        public void DeleteStatystyka(Guid id)
        {
            var statystyka = this.dbContext.Statystyki.Find(id);
            this.dbContext.Statystyki.Remove(statystyka);
        }

        public Statystyka GetStatystykaById(Guid id)
        {
            var statystyka = this.dbContext.Statystyki.Find(id);
            return statystyka;
        }

        public IEnumerable<Statystyka> GetStatystyki()
        {
            var statystyki = this.dbContext.Statystyki.ToList();
            return statystyki;
        }

        public void UpdateStatystyka(Statystyka statystyka)
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

        public void Save()
        {
            this.dbContext.SaveChanges();
        }
    }
}
