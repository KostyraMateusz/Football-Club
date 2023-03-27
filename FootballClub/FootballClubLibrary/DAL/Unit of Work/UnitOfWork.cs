﻿using FootballClubLibrary.Data;
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
        private GenericRepository<Pilkarz> pilkarzRepository;
        private GenericRepository<Pracownik> pracownikRepository;
        private GenericRepository<Statystyka> statystykaRepository;
        private GenericRepository<Zarzad> zarzadRepository;


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

        public GenericRepository<Pilkarz> PilkarzRepository
        {
            get
            {
                if (this.pilkarzRepository == null)
                {
                    this.pilkarzRepository = new GenericRepository<Pilkarz>(this.dbContext);
                }
                return this.pilkarzRepository;
            }
        }

        public GenericRepository<Pracownik> PracownikRepository
        {
            get
            {
                if (this.pracownikRepository == null)
                {
                    this.pracownikRepository = new GenericRepository<Pracownik>(this.dbContext);
                }
                return this.pracownikRepository;
            }
        }

        public GenericRepository<Statystyka> StatystykaRepository
        {
            get
            {
                if (this.statystykaRepository == null)
                {
                    this.statystykaRepository = new GenericRepository<Statystyka>(this.dbContext);
                }
                return this.statystykaRepository;
            }
        }

        public GenericRepository<Zarzad> ZarzadRepository
        {
            get
            {
                if (this.zarzadRepository == null)
                {
                    this.zarzadRepository = new GenericRepository<Zarzad>(this.dbContext);
                }
                return this.zarzadRepository;
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
