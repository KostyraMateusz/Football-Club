using FootballClubLibrary.Data;
using FootballClubLibrary.Models;
using FootballClubLibrary.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubLibrary.Unit_of_Work
{
    public class UnitOfWork : IDisposable
    {
        private ApplicationDbContext dbContext = new ApplicationDbContext();
        private GenericRepository<Klub> klubRepository;

        public GenericRepository<Klub> KlubRepository
        {
            get
            {
                if(this.klubRepository == null)
                {
                    this.klubRepository = new GenericRepository<Klub>(this.dbContext);
                }
                return this.klubRepository;
            }
        }

        public void Save()
        {
            this.dbContext.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
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
    }
}
