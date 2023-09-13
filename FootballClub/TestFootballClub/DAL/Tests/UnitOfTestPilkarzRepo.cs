using FootballClubLibrary.Data;
using FootballClubLibrary.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace TestsFootballClub.DAL.Tests
{
    public class UnitOfTestPilkarzRepo
    {
        [Fact]
        public async void TestCreatePilkarzy()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Testowa1").Options;
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

        [Fact]
        public async void TestDeletePilkarz()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Testowa2").Options;
            var pilkarzContext = new ApplicationDbContext(options);
            PilkarzRepository pilkarzRepository = new PilkarzRepository(pilkarzContext);
            Assert.NotNull(pilkarzRepository);

            var idPilkarz = Guid.NewGuid();

            await pilkarzRepository.CreatePilkarz(new Pilkarz() { IdPilkarz = idPilkarz, Imie = "Karim", Nazwisko = "Benzema", Wiek = 35, Pozycja = "Napastnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 240000, IdKlubu = null });
            pilkarzRepository.Save();
            Assert.Equal(1, pilkarzRepository?.GetPilkarze().Result.Count());

            await pilkarzRepository.CreatePilkarz(new Pilkarz { IdPilkarz = Guid.NewGuid(), Imie = "Kylian", Nazwisko = "Mekambe ", Wiek = 24, Pozycja = "Napastnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 350000, IdKlubu = null });
            pilkarzRepository.Save();
            Assert.Equal(2, pilkarzRepository?.GetPilkarze().Result.Count());

            pilkarzRepository?.DeletePilkarz(idPilkarz);
            pilkarzRepository.Save();
            Assert.Equal(1, pilkarzRepository?.GetPilkarze().Result.Count());
        }

        [Fact]
        public void TestUpdatePilkarz()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Testowa3").Options;
            var pilkarzContext = new ApplicationDbContext(options);
            PilkarzRepository pilkarzRepository = new PilkarzRepository(pilkarzContext);
            Assert.NotNull(pilkarzRepository);

            var idPilkarz = Guid.NewGuid();
            Pilkarz testowyPilkarz = new Pilkarz
            {
                IdPilkarz = idPilkarz,
                Imie = "Vinicius",
                Nazwisko = "Junior",
                Wiek = 21,
                Pozycja = "Obronca",
                Wynagrodzenie = 420000
            };

            pilkarzRepository?.CreatePilkarz(testowyPilkarz);
            pilkarzRepository.Save();

            testowyPilkarz.Pozycja = "Lewy skrzydłowy";
            pilkarzRepository?.UpdatePilkarz(testowyPilkarz);
            pilkarzRepository.Save();

            Assert.Equal(testowyPilkarz, pilkarzRepository?.GetPilkarzById(idPilkarz).Result);
        }

        [Fact]
        public async void TestArchiwalneKlubyPilkarza()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Testowa4").Options;
            var pilkarzContext = new ApplicationDbContext(options);
            PilkarzRepository pilkarzRepository = new PilkarzRepository(pilkarzContext);
            Assert.NotNull(pilkarzRepository);

            var idPilkarz = Guid.NewGuid();
            Klub OlympiqueLyon = new Klub() { IdKlub = Guid.NewGuid(), ArchiwalniPilkarze = null, ObecniPilkarze = new List<Pilkarz>(), Stadion = "Groupama Arena", Trofea = "Mistrzostwo Francji", Nazwa = "Olympique Lyon", Zarzad = new Zarzad() };
            pilkarzRepository.CreatePilkarz(new Pilkarz { IdPilkarz = idPilkarz, Imie = "Karim", Nazwisko = "Benzema", Wiek = 35, Pozycja = "Pomocnik", Statystyki = null, ArchiwalneKluby = new Collection<Klub> { OlympiqueLyon }, Wynagrodzenie = 440000, IdKlubu = null });
            Collection<Klub> listaArchiwalnych = new Collection<Klub>() { OlympiqueLyon };
            pilkarzRepository.Save();

            Assert.Same(pilkarzRepository.GetPilkarzById(idPilkarz).Result.ArchiwalneKluby.ToString(), listaArchiwalnych.ToString());
        }

        [Fact]
        public async void TestPorownajDwochPilkarzy()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Testowa5").Options;
            var pilkarzContext = new ApplicationDbContext(options);
            PilkarzRepository pilkarzRepository = new PilkarzRepository(pilkarzContext);
            Assert.NotNull(pilkarzRepository);

            Guid idBenzema = Guid.NewGuid();
            pilkarzRepository.CreatePilkarz(new Pilkarz { IdPilkarz = idBenzema, Imie = "Karim", Nazwisko = "Benzema", Wiek = 35, Pozycja = "Napastnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 440000, IdKlubu = null });

            Guid idMbappé = Guid.NewGuid();
            pilkarzRepository.CreatePilkarz(new Pilkarz { IdPilkarz = idMbappé, Imie = "Kylian", Nazwisko = "Mbappé", Wiek = 24, Pozycja = "Napastnik", Statystyki = null, ArchiwalneKluby = null, Wynagrodzenie = 350000, IdKlubu = null });
            pilkarzRepository.Save();

            Assert.NotSame(pilkarzRepository.GetPilkarzById(idBenzema), pilkarzRepository.GetPilkarzById(idMbappé));
            Assert.Same(pilkarzRepository.GetPilkarzById(idBenzema).Result.Pozycja, pilkarzRepository.GetPilkarzById(idMbappé).Result.Pozycja);
        }
    }
}
