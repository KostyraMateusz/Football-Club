using FootballClubLibrary.Data;
using FootballClubLibrary.Intefaces;
using FootballClubLibrary.Interfaces;
using FootballClubLibrary.Models;
using FootballClubLibrary.Repositories;
using FootballClubLibrary.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubLibrary.Unit_of_Work
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IKlubRepository klubRepository;
        private IPilkarzRepository pilkarzRepository;
        private IPracownikRepository pracownikRepository;
        private IStatystykaRepository statystykaRepository;
        private IZarzadRepository zarzadRepository;

        public UnitOfWork(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        public IKlubRepository KlubRepository
        {
            get
            {
                if(this.klubRepository == null)
                {
                    this.klubRepository = new KlubRepository(this._context);
                }
                return this.klubRepository;
            }
        }

        public IPilkarzRepository PilkarzRepository
        {
            get
            {
                if (this.pilkarzRepository == null)
                {
                    this.pilkarzRepository = new PilkarzRepository(this._context);
                }
                return this.pilkarzRepository;
            }
        }

        public IPracownikRepository PracownikRepository
        {
            get
            {
                if (this.pracownikRepository == null)
                {
                    this.pracownikRepository = new PracownikRepository(this._context);
                }
                return this.pracownikRepository;
            }
        }

        public IStatystykaRepository StatystykaRepository
        {
            get
            {
                if (this.statystykaRepository == null)
                {
                    this.statystykaRepository = new StatystykaRepository(this._context);
                }
                return this.statystykaRepository;
            }
        }

        public IZarzadRepository ZarzadRepository
        {
            get
            {
                if (this.zarzadRepository == null)
                {
                    this.zarzadRepository = new ZarzadRepository(this._context);
                }
                return this.zarzadRepository;
            }
        }

        public void Save()
        {
            this._context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this._context.Dispose();
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
