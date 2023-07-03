using FootballClubLibrary.Data;
using FootballClubLibrary.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

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

            await klubRepository.CreateKlub(new Klub() { IdKlub = new Guid(), Nazwa = "Real Madryt", Stadion = "Estadio Santiago Bernabéu", Trofea = "Liga Mistrzów (13 razy), Primera División (34 razy), Puchar Króla (19 razy), Superpuchar Hiszpanii (11 razy)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchwilaniPilkarze = new Collection<Pilkarz> { }, Zarzad = null });
            await klubRepository.CreateKlub(new Klub() { IdKlub = new Guid(), Nazwa = "FC Barcelona", Stadion = "Camp Nou", Trofea = "Liga Mistrzów (5 razy), Primera División (26 razy), Puchar Króla (31 razy), Superpuchar Hiszpanii (13 razy)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchwilaniPilkarze = new Collection<Pilkarz> { }, Zarzad = null });
            await klubRepository.Save();

            var klubs = await klubRepository.GetKluby();
            Assert.NotEmpty(klubs);
            Assert.Equal(2, klubs.Count());
        }
    }
}