using BusinessLogicLayer.Services;
using FootballClubLibrary.Intefaces;
using FootballClubLibrary.Unit_of_Work;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using TestsFootballClub.FakeRepositories;

namespace TestsFootballClub.BLL.Tests
{
    public class TestKlubService
    {

        // FAKE TESTS
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
        public void TestSprawdzIloscObecnychPilkarzy()
        {
            var klubRepo = new FakeKlubRepository();
            var unitOfWork = new UnitOfWork(klubRepo, null);
            var klubService = new KlubService(unitOfWork);

            var klub = new Klub() { ObecniPilkarze = new List<Pilkarz>(), IdKlub = Guid.NewGuid() };
            klubRepo?.CreateKlub(klub);

            Pilkarz pilkarz1 = new Pilkarz();
            Pilkarz pilkarz2 = new Pilkarz();
            Pilkarz pilkarz3 = new Pilkarz();
            List<Pilkarz> pilkarze = new List<Pilkarz>() { pilkarz1, pilkarz2, pilkarz3 };
            klubService?.DodajPilkarzyDoObecnych(pilkarze, klub);
            Assert.Equal(3, klub.ObecniPilkarze.Count());

            Pilkarz pilkarz4 = new Pilkarz();
            Pilkarz pilkarz5 = new Pilkarz();
            Pilkarz pilkarz6 = new Pilkarz();
            List<Pilkarz> pilkarze2 = new List<Pilkarz>() { pilkarz4, pilkarz5, pilkarz6 };
            klubService?.DodajPilkarzyDoObecnych(pilkarze2, klub);
            Assert.Equal(6, klub.ObecniPilkarze.Count());

        }

        [Fact]
        public void TestSprawdzDodanieObecnychPilkarzy()
        {
            var klubRepo = new FakeKlubRepository();
            var unitOfWork = new UnitOfWork(klubRepo, null);
            var klubService = new KlubService(unitOfWork);

            Pilkarz pilkarz1 = new Pilkarz();
            Pilkarz pilkarz2 = new Pilkarz();
            Pilkarz pilkarz3 = new Pilkarz();
            List<Pilkarz> pilkarze = new List<Pilkarz>() { pilkarz1, pilkarz2, pilkarz3 };
            var klub = new Klub() { ObecniPilkarze = new List<Pilkarz>(), IdKlub = Guid.NewGuid() };
            klubRepo?.CreateKlub(klub);
            klubService?.DodajPilkarzyDoObecnych(pilkarze, klub);

            Assert.Equal(3, klub.ObecniPilkarze.Count());
        }


        /// MOQ
        [Fact]
        public void TestSprawdzIleKlubow()
        {
            Mock<IKlubRepository> _mockKlubRepository = new Mock<IKlubRepository>();
            _mockKlubRepository.Setup(x => x.GetKluby())
                .ReturnsAsync(new List<Klub> { new Klub(), new Klub(), new Klub() });

            var unitOfWork = new UnitOfWork(_mockKlubRepository.Object, null);
            var klubService = new KlubService(unitOfWork);

            Assert.Equal(3, klubService.DajKluby().Result.Count());
        }


        [Fact]
        public void TestSprawdzDwaKluby()
        {
            Klub klub = new Klub()
            {
                IdKlub = Guid.NewGuid(),
                ArchwilaniPilkarze = null,
                ObecniPilkarze = new List<Pilkarz>(),
                Stadion = "Stadion1",
                Trofea = "La Liga",
                Nazwa = "Klub1",
                Zarzad = new Zarzad()
            };

            Klub klub2 = new Klub()
            {
                IdKlub = Guid.NewGuid(),
                ArchwilaniPilkarze = null,
                ObecniPilkarze = new List<Pilkarz>(),
                Stadion = "Stadion2",
                Trofea = "La Liga",
                Nazwa = "Klub2",
                Zarzad = new Zarzad()
            };

            Mock<IKlubRepository> _mockKlubRepository = new Mock<IKlubRepository>();
            _mockKlubRepository.Setup(x => x.GetKluby())
                .ReturnsAsync(new List<Klub> { klub, klub2 });

            Assert.NotEqual(klub.IdKlub, klub2.IdKlub);
            Assert.Equal(klub.Trofea, klub2.Trofea);
            Assert.NotSame(klub, klub2);
        }
    }
}
