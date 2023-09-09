using FootballClubLibrary.Interfaces;
using FootballClubLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace TestsFootballClub.FakeRepositories
{
    public class FakeKlubRepository : IKlubRepository
    {
        private List<Klub> kluby = new List<Klub>();

        public DbSet<Klub> GetDbSetKluby()
        {
            throw new NotImplementedException();
        }

        public async Task CreateKlub(Klub klub)
        {
            if(klub != null)
            {
                kluby.Add(klub);
            }
        }

        public async Task DeleteKlub(Guid id)
        {
            if(id != Guid.Empty)
            {
                var klub = await Task.FromResult(kluby.Find(k => k.IdKlub == id));
                kluby.Remove(klub);
            }
        }

        public async Task UpdateKlub(Klub klub)
        {
            if( klub != null)
            {
                var index = await Task.FromResult(kluby.FindIndex(p => p.IdKlub == klub.IdKlub));
                if (index != -1)
                {
                    kluby[index] = klub;
                }
            }
        }

        public async Task<Klub> GetKlubById(Guid? id)
        {
            var klub = await Task.FromResult(kluby.Find(k => k.IdKlub == id));
            return klub;
        }

        public async Task<IEnumerable<Klub>> GetKluby()
        {
            var kluby = await Task.FromResult(this.kluby);
            return kluby;
        }

        public async Task DodajTrofeumKlubu(Guid id, string trofeum)
        {
            if (id != Guid.Empty && trofeum != null)
            {
                var klub = await Task.FromResult(kluby.Find(k => k.IdKlub == id));
                if (klub != null)
                {
                    klub.Trofea += $", {trofeum}";
                }
            }
        }

        public async Task DodajPilkarzaDoObecnych(Klub klub, Pilkarz pilkarz)
        {
            if (klub != null && pilkarz != null)
            {
                if (klub.ObecniPilkarze.ToList().Find(p => p.IdPilkarz == pilkarz.IdPilkarz) == null)
                {
                    klub.ObecniPilkarze.Add(pilkarz);
                }
            }
        }

        public async Task DodajPilkarzyDoObecnych(Klub klub, List<Pilkarz> pilkarze)
        {
            if (klub != null && pilkarze != null)
            {
                for (int i = 0; i < pilkarze.Count; i++)
                {
                    if (klub.ObecniPilkarze.ToList().Find(p => p.IdPilkarz == pilkarze[i].IdPilkarz) == null)
                    {
                        klub.ObecniPilkarze.Add(pilkarze[i]);
                    }
                }
            }
        }

        public async Task UsunPilkarzaZObecnych(Klub klub, Pilkarz pilkarz)
        {
            if(klub != null && pilkarz != null)
            {
                klub.ObecniPilkarze.Remove(pilkarz);
            }
        }

        public async Task DodajPilkarzaDoArchiwalnych(Klub klub, Pilkarz pilkarz)
        {
            if(klub != null && pilkarz != null)
            {
                if(klub.ObecniPilkarze.ToList().Find(p => p.IdPilkarz == pilkarz.IdPilkarz) != null)
                {
                    klub.ObecniPilkarze.Remove(pilkarz);
                    if(klub.ArchiwalniPilkarze.ToList().Find(p => p.IdPilkarz == pilkarz.IdPilkarz) != null)
                    {
                        klub.ArchiwalniPilkarze.Add(pilkarz);
                    }
                }
            }
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }
    }
}