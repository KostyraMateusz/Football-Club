﻿using FootballClubLibrary.Data;
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

        public async Task CreateZarzad(Zarzad zarzad)
        {
            await this.dbContext.Zarzady.AddAsync(zarzad);
        }

        public async Task DeleteZarzad(Guid id)
        {
            var zarzad = await this.dbContext.Zarzady.FindAsync(id);
            this.dbContext.Zarzady.Remove(zarzad);
        }

        public async Task<Zarzad> GetZarzadById(Guid id)
        {
            return await this.dbContext.Zarzady.FindAsync(id);
        }

        public async Task<IEnumerable<Zarzad>> GetZarzady()
        {
            return await this.dbContext.Zarzady.ToListAsync();
        }

        public async Task UpdateZarzad(Zarzad zarzad)
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

        public async Task Save()
        {
            this.dbContext.SaveChangesAsync();
        }

        public DbSet<Zarzad> GetDbSetZarzady()
        {
            var result = this.dbContext.Zarzady;
            return result;
        }
    }
}