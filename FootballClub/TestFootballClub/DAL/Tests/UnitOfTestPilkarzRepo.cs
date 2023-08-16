using FootballClubLibrary.Data;
using FootballClubLibrary.Repositories;
using Microsoft.EntityFrameworkCore;

namespace TestsFootballClub.DAL.Tests
{
    public class UnitOfTestPilkarzRepo
    {
        [Fact]
        public async void TestPilkarzy()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Testowa").Options;
            var pilkarzContext = new ApplicationDbContext(options);
            PilkarzRepository pilkarzRepository = new PilkarzRepository(pilkarzContext);
            Assert.NotNull(pilkarzRepository);

            await pilkarzRepository.CreatePilkarz(new Pilkarz() { IdPilkarz = Guid.NewGuid(), Imie = "Karim", Nazwisko = "Benzema", Wiek = 35, Pozycja = "Napastnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 240000, IdKlubu = null });
            await pilkarzRepository.CreatePilkarz(new Pilkarz { IdPilkarz = Guid.NewGuid(), Imie = "Kylian", Nazwisko = "Mekambe ", Wiek = 24, Pozycja = "Napastnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 350000, IdKlubu = null });
            await pilkarzRepository.CreatePilkarz(new Pilkarz { IdPilkarz = Guid.NewGuid(), Imie = "Vinicius", Nazwisko = "Junior", Wiek = 21, Pozycja = "Napastnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 180000, IdKlubu = null });
            await pilkarzRepository.Save();

            var pilkarze = await pilkarzRepository.GetPilkarze();
            Assert.NotEmpty(pilkarze);
            Assert.Equal(3, pilkarze.Count());
        }
    }
}
