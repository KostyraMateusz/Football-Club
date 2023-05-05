using BusinessLogicLayer.Services;
using FootballClubLibrary.Intefaces;
using FootballClubLibrary.Unit_of_Work;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsFootballClub.FakeRepositories;

namespace TestsFootballClub.BLL.Tests
{
    public class TestKlubService
    {
        private readonly Mock<IKlubRepository> _mockKlubRepository = new Mock<IKlubRepository>();

        [Fact]
        public void TestSprawdzIloscKlubow()
        {
            var klubRepo = new FakeKlubRepository();
            var unitOfWork = new UnitOfWork(klubRepo, null);
            var klubService = new KlubService(unitOfWork);

            klubRepo?.CreateKlub(new Klub());
            Assert.Equal(1, klubRepo?.IleJestKlubow());

            klubRepo?.CreateKlub(new Klub());
            Assert.Equal(2, klubRepo?.IleJestKlubow());

            klubRepo?.CreateKlub(new Klub());
            Assert.Equal(3, klubRepo?.IleJestKlubow());
        }

        [Fact]
        public void TestSprawdzTrofeaKlubu()
        {
            var klubRepo = new FakeKlubRepository();
            var unitOfWork = new UnitOfWork(klubRepo, null);
            var klubService = new KlubService(unitOfWork);

            var klub = new Klub();
            klubRepo?.CreateKlub(klub);
            klubRepo?.DodajTrofeumKlubu(klub.IdKlub, "test1");
            Assert.Equal("test1, ", klub.Trofea);

            klubRepo?.DodajTrofeumKlubu(klub.IdKlub, "test2");
            Assert.Equal("test1, test2, ", klub.Trofea);


            var trofea = klubService?.DajTrofeaKlubu(klub.IdKlub);
            Assert.Equal("test1, test2, ", (IEnumerable<char>)trofea); 
        }

        [Fact]
        public void TestSprawdzIloscObecnychPilkarzy()
        {
            var klubRepo = new FakeKlubRepository();
            var unitOfWork = new UnitOfWork(klubRepo, null);
            var klubService = new KlubService(unitOfWork);

            Pilkarz pilkarz = new Pilkarz();
            var klub = new Klub();
            klubRepo?.CreateKlub(klub);
            klubService?.DodajPilkarzaDoObecnych(pilkarz.IdPilkarz, klub.IdKlub);
            var result = klubService?.DajObecnychPilkarzy(klub.IdKlub).Result.Count();
            Assert.Equal(1, result);
        }

        [Fact]
        public void TestSprawdzDodanieObecnychPilkarzy()
        {
            var klubRepo = new FakeKlubRepository();
            var unitOfWork = new UnitOfWork(klubRepo, null);
            var klubService = new KlubService(unitOfWork);

            Pilkarz pilkarz = new Pilkarz();
            Pilkarz pilkarz2 = new Pilkarz();
            Pilkarz pilkarz3 = new Pilkarz();
            var klub = new Klub();
            klubRepo?.CreateKlub(klub);
            klubService?.DodajPilkarzaDoObecnych(pilkarz.IdPilkarz, klub.IdKlub);
            klubService?.DodajPilkarzaDoObecnych(pilkarz2.IdPilkarz, klub.IdKlub);
            klubService?.DodajPilkarzaDoObecnych(pilkarz3.IdPilkarz, klub.IdKlub);
            var result = klubService?.DajObecnychPilkarzy(klub.IdKlub).Result.Count();
            Assert.NotNull(result);
        }
    }
}
