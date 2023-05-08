using FootballClubLibrary.Repositories;
using FootballClubLibrary.Unit_of_Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
