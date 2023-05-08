using FootballClubLibrary.Data;
using FootballClubLibrary.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsFootballClub.DAL.Tests
{
    public class UnitOfTestKlubRepo
    {
        [Fact]
        public void TestKlubow()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Testowa").Options;
            var klubContext = new ApplicationDbContext(options);
            KlubRepository klubRepository = new KlubRepository(klubContext);

            Assert.NotNull(klubRepository);

            Klub klub = new Klub() { IdKlub = Guid.NewGuid(), ObecniPilkarze = new List<Pilkarz>() };
            Klub klub2 = new Klub() { IdKlub = Guid.NewGuid(), ObecniPilkarze = new List<Pilkarz>() };

            klub.ObecniPilkarze.Add(new Pilkarz());
            klub.ObecniPilkarze.Add(new Pilkarz());
            klub2.ObecniPilkarze.Add(new Pilkarz());
            klub.Trofea = "CL";
            klub2.Trofea = "UKL";
            klubRepository.Save();

            Assert.NotSame(klub, klub2);
            Assert.NotEqual(klub.Trofea, klub2.Trofea);
            Assert.Equal(2, klub.ObecniPilkarze.Count);
            Assert.Equal(1, klub2.ObecniPilkarze.Count);
        }
    }
}
