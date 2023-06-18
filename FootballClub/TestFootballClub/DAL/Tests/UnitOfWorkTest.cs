using FootballClubLibrary.UnitOfWork;
using TestsFootballClub.DAL.DummyRepositories;

namespace TestsFootballClub.DAL.Tests
{
    public class UnitOfWorkTest
    {
        [Fact]
        public void TestUnitOfWork()
        {
            var klubRepository = new DummyKlubRepository();
            var pilkarzRepository = new DummyPilkarzRepository();
            var unitOfWork = new UnitOfWork(klubRepository, pilkarzRepository);

            Assert.Same(klubRepository, unitOfWork.KlubRepository);
            Assert.Same(pilkarzRepository, unitOfWork.PilkarzRepository);
        }
    }
}