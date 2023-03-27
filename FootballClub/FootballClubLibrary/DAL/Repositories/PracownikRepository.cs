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
    public class PracownikRepository : IPracownikRepository, IDisposable
    {
        private readonly ApplicationDbContext dbContext;
        private bool disposed = false;

        public PracownikRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreatePracownik(Pracownik pracownik)
        {
            this.dbContext.Pracownicy.Add(pracownik);
        }

        public void DeletePracownik(Guid id)
        {
            var pracownik = this.dbContext.Pracownicy.Find(id);
            this.dbContext.Pracownicy.Remove(pracownik);
        }

        public IEnumerable<Pracownik> GetPracownicy()
        {
            var pracownicy = this.dbContext.Pracownicy.ToList();
            return pracownicy;
        }

        public Pracownik GetPracownikById(Guid id)
        {
           var pracownik = this.dbContext.Pracownicy.Find(id);
            return pracownik;
        }

        public void UpdatePracownik(Pracownik pracownik)
        {
            this.dbContext.Entry(pracownik).State = EntityState.Modified;
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
