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
        DummyKlubRepository klubRepository = new DummyKlubRepository();
        DummyPilkarzRepository pilkarzRepository = new DummyPilkarzRepository();
        //var unitOfWork = new UnitOfWork(klubRepository, pilkarzRepository);

        KlubRepository klub = new KlubRepository(null);
        public void test()
        {
            Assert.NotSame(klubRepository, klub);
        }
    }
}
