using FootballClubLibrary.Intefaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsFootballClub.DAL.DummyRepositories
{
    public class DummyKlubRepository : IKlubRepository
    {
        public Task CreateKlub(Klub klub)
        {
            throw new NotImplementedException();
        }

        public Task DeleteKlub(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DodajTrofeumKlubu(Guid id, string trofeum)
        {
            throw new NotImplementedException();
        }

        public DbSet<Klub> GetDbSetKluby()
        {
            throw new NotImplementedException();
        }

        public Task<Klub> GetKlubById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Klub>> GetKluby()
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public Task UpdateKlub(Klub klub)
        {
            throw new NotImplementedException();
        }
    }
}
