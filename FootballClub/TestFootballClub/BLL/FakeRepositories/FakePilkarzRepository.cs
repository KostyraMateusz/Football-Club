using FootballClubLibrary.Interfaces;
using FootballClubLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsFootballClub.FakeRepositories
{
    public class FakePilkarzRepository : IPilkarzRepository
    {
        private List<Pilkarz> pilkarze = new List<Pilkarz>();
        public async Task CreatePilkarz(Pilkarz pilkarz)
        {
            pilkarze.Add(pilkarz);
            return;
        }

        public async Task DeletePilkarz(Guid id)
        {
            var pilkarz = await Task.FromResult(pilkarze.Find(p => p.IdPilkarz == id));
            pilkarze.Remove(pilkarz);
            return;
        }

        public async Task<Pilkarz> GetPilkarzById(Guid id)
        {
            var result = await Task.FromResult(pilkarze.Find(p => p.IdPilkarz == id));
            return result;
        }

        public async Task<IEnumerable<Pilkarz>> GetPilkarze()
        {
            var result = await Task.FromResult(pilkarze);
            return result;
        }

        public async Task UpdatePilkarz(Pilkarz pilkarz)
        {
            var index = await Task.FromResult(pilkarze.FindIndex(p => p.IdPilkarz == pilkarz.IdPilkarz));
            if (index != -1)
            {
                pilkarze[index] = pilkarz;
            }
            return;
        }

        public int IleJestPilkarzy()
        {
            return pilkarze.Count();
        }

        // Niewykorzystywane w FakePilkarzRepository
        public Task Save()
        {
            throw new NotImplementedException();
        }

        public DbSet<Pilkarz> GetDbSetPilkarze()
        {
            throw new NotImplementedException();
        }
    }
}
