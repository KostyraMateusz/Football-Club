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
        public async Task TestKlubowAsync()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Testowa").Options;
            var klubContext = new ApplicationDbContext(options);
            KlubRepository klubRepository = new KlubRepository(klubContext);

            Assert.NotNull(klubRepository);
            
            await klubRepository.CreateKlub(new Klub() { IdKlub = Guid.NewGuid(), ObecniPilkarze = new List<Pilkarz>() });
            await klubRepository.CreateKlub(new Klub() { IdKlub = Guid.NewGuid(), ObecniPilkarze = new List<Pilkarz>() });
            await klubRepository.Save();

            var klubs = await klubRepository.GetKluby();
            Assert.NotEmpty(klubs);
            Assert.Equal(2, klubs.Count());

        }
    }
}
