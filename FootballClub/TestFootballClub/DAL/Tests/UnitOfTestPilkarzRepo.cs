using FootballClubLibrary.Data;
using FootballClubLibrary.Repositories;
using Microsoft.EntityFrameworkCore;

namespace TestsFootballClub.DAL.Tests
{
    public class UnitOfTestPilkarzRepo
    {
        [Fact]
        public void TestPilkarzy()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Testowa").Options;
            var pilkarzContext = new ApplicationDbContext(options);
            PilkarzRepository pilkarzRepository = new PilkarzRepository(pilkarzContext);

            Assert.NotNull(pilkarzRepository);

            Pilkarz Benzema = new Pilkarz { IdPilkarz = Guid.NewGuid(), Imie = "Karim", Nazwisko = "Benzema", Wiek = 35, Pozycja = "Pomocnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 240000, IdKlubu = null };
            Pilkarz Mbappé = new Pilkarz { IdPilkarz = Guid.NewGuid(), Imie = "Kylian", Nazwisko = "Mekambe ", Wiek = 24, Pozycja = "Napastnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 350000, IdKlubu = null };

            Benzema.Pozycja = "Napastnik";
            Mbappé.Nazwisko = "Mbappé";
            pilkarzRepository.Save();

            Assert.NotSame(Benzema, Mbappé);
            Assert.Same("Napastnik", Benzema.Pozycja);
            Assert.Same("Mbappé", Mbappé.Nazwisko);
        }
    }
}
