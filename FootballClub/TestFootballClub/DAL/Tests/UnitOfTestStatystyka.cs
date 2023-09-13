using FootballClubLibrary.Data;
using FootballClubLibrary.Repositories;
using Microsoft.EntityFrameworkCore;

namespace TestsFootballClub.DAL.Tests
{
    public class UnitOfTestStatystyka
    {
        [Fact]
        public async void TestCreatePracownik()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Testowa1").Options;
            var statystykaContext = new ApplicationDbContext(options);
            StatystykaRepository statystykaRepository = new StatystykaRepository(statystykaContext);
            Assert.NotNull(statystykaRepository);

            await statystykaRepository.CreateStatystyka(new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs Ajax", Gole = 0, ZolteKartki = 0, CzerwoneKartki = 0, Asysty = 1, PrzebiegnietyDystans = 9.3, Ocena = 8.4 });
            await statystykaRepository.CreateStatystyka(new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs RB Leipzig", Gole = 1, ZolteKartki = 1, CzerwoneKartki = 0, Asysty = 1, PrzebiegnietyDystans = 9.9, Ocena = 8.9 });
            await statystykaRepository.CreateStatystyka(new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs Sevilla", Gole = 0, ZolteKartki = 0, CzerwoneKartki = 0, Asysty = 3, PrzebiegnietyDystans = 10.7, Ocena = 9.1 });
            await statystykaRepository.Save();

            var statystyki = await statystykaRepository.GetStatystyki();
            Assert.NotEmpty(statystyki);
            Assert.Equal(3, statystyki.Count());
        }

        [Fact]
        public async void TestDeleteStatystykak()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Testowa2").Options;
            var statystykaContext = new ApplicationDbContext(options);
            StatystykaRepository statystykaRepository = new StatystykaRepository(statystykaContext);
            Assert.NotNull(statystykaRepository);

            var idStatystyka = Guid.NewGuid();

            await statystykaRepository.CreateStatystyka(new Statystyka { IdStatystyka = idStatystyka, Mecz = "Real Madrid vs Ajax", Gole = 0, ZolteKartki = 0, CzerwoneKartki = 0, Asysty = 1, PrzebiegnietyDystans = 9.3, Ocena = 8.4 });
            statystykaRepository.Save();
            Assert.Equal(1, statystykaRepository.GetStatystyki().Result.Count());

            await statystykaRepository.CreateStatystyka(new Statystyka { IdStatystyka = Guid.NewGuid(), Mecz = "Real Madrid vs RB Leipzig", Gole = 1, ZolteKartki = 1, CzerwoneKartki = 0, Asysty = 1, PrzebiegnietyDystans = 9.9, Ocena = 8.9 });
            statystykaRepository.Save();
            Assert.Equal(2, statystykaRepository.GetStatystyki().Result.Count());

            statystykaRepository?.DeleteStatystyka(idStatystyka);
            statystykaRepository.Save();
            Assert.Equal(1, statystykaRepository?.GetStatystyki().Result.Count());
        }

        [Fact]
        public void TestUpdateStatystyka()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Testowa3").Options;
            var statystykaContext = new ApplicationDbContext(options);
            StatystykaRepository statystykaRepository = new StatystykaRepository(statystykaContext);
            Assert.NotNull(statystykaRepository);

            var idStatystyka = Guid.NewGuid();
            Statystyka testowaStatystyka = new Statystyka
            {
                IdStatystyka = idStatystyka,
                Mecz = "Real Madrid vs Liverpool",
                Gole = 0,
                ZolteKartki = 0,
                CzerwoneKartki = 0,
                Asysty = 0,
                PrzebiegnietyDystans = 0.8,
                Ocena = 8.8,
            };

            statystykaRepository?.CreateStatystyka(testowaStatystyka);
            statystykaRepository.Save();

            testowaStatystyka.Asysty = 1;
            statystykaRepository?.UpdateStatystyka(testowaStatystyka);
            statystykaRepository.Save();

            Assert.Equal(testowaStatystyka, statystykaRepository?.GetStatystykaById(idStatystyka).Result);
        }
    }
}