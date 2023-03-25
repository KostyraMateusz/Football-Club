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
    public class ZarzadRepository : IZarzadRepository, IDisposable
    {
        private readonly ApplicationDbContext dbContext;
        private bool disposed = false;

        public ZarzadRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateZarzad(Zarzad zarzad)
        {
            this.dbContext.Zarzady.Add(zarzad);
        }

        public void DeleteZarzad(Guid id)
        {
            var zarzad = this.dbContext.Zarzady.Find(id);
            this.dbContext.Zarzady.Remove(zarzad);
        }

        public Zarzad GetZarzadById(Guid id)
        {
            return this.dbContext.Zarzady.Find(id);
        }

        public IEnumerable<Zarzad> GetZarzady()
        {
            return this.dbContext.Zarzady.ToList();
        }

        public void UpdateZarzad(Zarzad zarzad)
        {
            this.dbContext.Entry(zarzad).State = EntityState.Modified;
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
