
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

        public void CreateKlub(Klub klub)
        {
            this.dbContext.Kluby.Add(klub);
        }

        public void DeleteKlub(Guid id)
        {
            var klub = this.dbContext.Kluby.Find(id);
            this.dbContext.Kluby.Remove(klub);
        }

        public Klub GetKlubById(Guid id)
        {
            return this.dbContext.Kluby.Find(id);
        }

        public IEnumerable<Klub> GetKlubs()
        {
            return this.dbContext.Kluby.ToList();
        }

        public void UpdateKlub(Klub klub)
        {
            this.dbContext.Entry(klub).State = EntityState.Modified;
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
