using BusinessLogicLayer.Services;
using FootballClubLibrary.Models;
using FootballClubLibrary.UnitOfWork;
using TestsFootballClub.BLL.FakeRepositories;

namespace TestsFootballClub.BLL.Tests
{
    public class TestStatystykaService
    {
        [Fact]
        public void TestCreateStatystyka()
        {
            var statystykaRepo = new FakeStatystykaRepository();
            var unitOfWork = new UnitOfWork(null, null, null, null, statystykaRepo);
            var StatystykaService = new StatystykaService(unitOfWork);

            statystykaRepo?.CreateStatystyka(new Statystyka());
            Assert.Equal(1, statystykaRepo?.GetStatystyki().Result.Count());

            statystykaRepo?.CreateStatystyka(new Statystyka());
            Assert.Equal(2, statystykaRepo?.GetStatystyki().Result.Count());

            statystykaRepo?.CreateStatystyka(new Statystyka());
            Assert.Equal(3, statystykaRepo?.GetStatystyki().Result.Count());
        }

        [Fact]
        public void TestDeleteStatystykak()
        {
            var statystykaRepo = new FakeStatystykaRepository();
            var unitOfWork = new UnitOfWork(null, null, null, null, statystykaRepo);
            var StatystykaService = new StatystykaService(unitOfWork);

            var idStatystyka = Guid.NewGuid();

            statystykaRepo?.CreateStatystyka(new Statystyka() { IdStatystyka = idStatystyka });
            Assert.Equal(1, statystykaRepo?.GetStatystyki().Result.Count());

            statystykaRepo?.CreateStatystyka(new Statystyka());
            Assert.Equal(2, statystykaRepo?.GetStatystyki().Result.Count());

            statystykaRepo?.DeleteStatystyka(idStatystyka);
            Assert.Equal(1, statystykaRepo?.GetStatystyki().Result.Count());
        }

        [Fact]
        public void TestUpdateStatystyka()
        {
            var statystykaRepo = new FakeStatystykaRepository();
            var unitOfWork = new UnitOfWork(null, null, null, null, statystykaRepo);
            var StatystykaService = new StatystykaService(unitOfWork);

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

            statystykaRepo?.CreateStatystyka(testowaStatystyka);

            testowaStatystyka.Asysty = 1;
            statystykaRepo?.UpdateStatystyka(testowaStatystyka);

            Assert.Equal(testowaStatystyka, statystykaRepo?.GetStatystykaById(idStatystyka).Result);
        }
    }
}
