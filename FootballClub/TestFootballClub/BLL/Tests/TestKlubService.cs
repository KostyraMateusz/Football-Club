using BusinessLogicLayer.Services;
using FootballClubLibrary.Interfaces;
using FootballClubLibrary.UnitOfWork;
using Moq;
using System.Collections.ObjectModel;
using TestsFootballClub.FakeRepositories;

namespace TestsFootballClub.BLL.Tests
{
    public class TestKlubService
    {
        [Fact]
        public void TestCreateKlubMOQ()
        {
            Mock<IKlubRepository> _mockKlubRepository = new Mock<IKlubRepository>();
            _mockKlubRepository.Setup(x => x.GetKluby())
                .ReturnsAsync(new List<Klub> { new Klub(), new Klub(), new Klub() });

            var unitOfWork = new UnitOfWork(null, _mockKlubRepository.Object, null);
            var klubService = new KlubService(unitOfWork);

            Assert.Equal(3, klubService.DajKluby().Result.Count());
        }

        [Fact]
        public void TestCreateKlub()
        {
            var klubRepo = new FakeKlubRepository();
            var unitOfWork = new UnitOfWork(null ,klubRepo);
            var klubService = new KlubService(unitOfWork);

            klubRepo?.CreateKlub(new Klub());
            Assert.Equal(1, klubRepo?.GetKluby().Result.Count());

            klubRepo?.CreateKlub(new Klub());
            Assert.Equal(2, klubRepo?.GetKluby().Result.Count());

            klubRepo?.CreateKlub(new Klub());
            Assert.Equal(3, klubRepo?.GetKluby().Result.Count());
        }

        [Fact]
        public void TestDeleteKlub()
        {
            var klubRepo = new FakeKlubRepository();
            var unitOfWork = new UnitOfWork(null, klubRepo);
            var klubService = new KlubService(unitOfWork);

            var idKlub = Guid.NewGuid();

            klubRepo?.CreateKlub(new Klub() { IdKlub = idKlub });
            Assert.Equal(1, klubRepo?.GetKluby().Result.Count());

            klubRepo?.CreateKlub(new Klub());
            Assert.Equal(2, klubRepo?.GetKluby().Result.Count());

            klubRepo?.DeleteKlub(idKlub);
            Assert.Equal(1, klubRepo?.GetKluby().Result.Count());
        }

        [Fact]
        public void TestUpdateKlub()
        {
            var klubRepo = new FakeKlubRepository();
            var unitOfWork = new UnitOfWork(null, klubRepo);
            var klubService = new KlubService(unitOfWork);

            var idKlub = Guid.NewGuid();
            Klub RealMadryt = new Klub()
            { 
                IdKlub = idKlub, 
                Nazwa = "Real Madryt", 
                Stadion = "Stadion Śląski", 
                Trofea = "Liga Mistrzów (13 razy), Primera División (34 razy), Puchar Króla (19 razy), Superpuchar Hiszpanii (11 razy)", 
                ObecniPilkarze = new Collection<Pilkarz> { }, 
                ArchiwalniPilkarze = new Collection<Pilkarz> { }, 
                Zarzad = null 
            };

            klubRepo?.CreateKlub(RealMadryt);
            RealMadryt.Stadion = "Estadio Santiago Bernabéu";
            klubRepo?.UpdateKlub(RealMadryt);

            Assert.Equal(RealMadryt, klubRepo?.GetKlubById(idKlub).Result);
        }

        [Fact]
        public void DodajTrofeumKlubu()
        {
            var klubRepo = new FakeKlubRepository();
            var unitOfWork = new UnitOfWork(null, klubRepo);
            var klubService = new KlubService(unitOfWork);

            Klub RealMadryt = new Klub()
            {
                IdKlub = Guid.NewGuid(),
                Nazwa = "Real Madryt",
                Stadion = "Estadio Santiago Bernabéu",
                Trofea = "Liga Mistrzów (13 razy)",
                ObecniPilkarze = new Collection<Pilkarz> { },
                ArchiwalniPilkarze = new Collection<Pilkarz> { },
                Zarzad = null
            };

            klubRepo.CreateKlub(RealMadryt);
            klubRepo?.DodajTrofeumKlubu(RealMadryt.IdKlub, "Primera División (34 razy)");
            klubRepo?.DodajTrofeumKlubu(RealMadryt.IdKlub, "Puchar Króla (19 razy)");
            klubRepo?.DodajTrofeumKlubu(RealMadryt.IdKlub, "Superpuchar Hiszpanii (11 razy)");

            string trofea = "Liga Mistrzów (13 razy), Primera División (34 razy), Puchar Króla (19 razy), Superpuchar Hiszpanii (11 razy)";
            Assert.Equal(trofea, klubRepo?.GetKlubById(RealMadryt.IdKlub).Result.Trofea);
        }

        [Fact]
        public void TestDodajPilkarzaDoObecnych()
        {
            var klubRepo = new FakeKlubRepository();
            var unitOfWork = new UnitOfWork(null, klubRepo);
            var klubService = new KlubService(unitOfWork);

            var idKlub = Guid.NewGuid();
            Klub RealMadryt = new Klub()
            {
                IdKlub = idKlub,
                Nazwa = "Real Madryt",
                Stadion = "Estadio Santiago Bernabéu",
                Trofea = "Liga Mistrzów (13 razy), Primera División (34 razy), Puchar Króla (19 razy), Superpuchar Hiszpanii (11 razy)",
                ObecniPilkarze = new Collection<Pilkarz> { },
                ArchiwalniPilkarze = new Collection<Pilkarz> { },
                Zarzad = null
            };

            Pilkarz ViniciusJunior = new Pilkarz
            {
                IdPilkarz = Guid.NewGuid(),
                Imie = "Vinicius",
                Nazwisko = "Junior",
                Wiek = 21,
                Pozycja = "Lewy skrzydłowy",
                Wynagrodzenie = 420000
            };

            klubRepo?.CreateKlub(RealMadryt);
            klubRepo?.DodajPilkarzaDoObecnych(RealMadryt, ViniciusJunior);
            klubRepo?.DodajPilkarzaDoObecnych(RealMadryt, new Pilkarz());
            klubRepo?.DodajPilkarzaDoObecnych(RealMadryt, ViniciusJunior);

            Assert.Equal(2, klubRepo?.GetKlubById(RealMadryt.IdKlub).Result.ObecniPilkarze.Count);
        }

        [Fact]
        public void TestDodajPilkarzyDoObecnych()
        {
            var klubRepo = new FakeKlubRepository();
            var unitOfWork = new UnitOfWork(null, klubRepo);
            var klubService = new KlubService(unitOfWork);

            var idKlub = Guid.NewGuid();
            Klub RealMadryt = new Klub()
            {
                IdKlub = idKlub,
                Nazwa = "Real Madryt",
                Stadion = "Estadio Santiago Bernabéu",
                Trofea = "Liga Mistrzów (13 razy), Primera División (34 razy), Puchar Króla (19 razy), Superpuchar Hiszpanii (11 razy)",
                ObecniPilkarze = new Collection<Pilkarz> { },
                ArchiwalniPilkarze = new Collection<Pilkarz> { }
            };

            Pilkarz ViniciusJunior = new Pilkarz
            {
                IdPilkarz = Guid.NewGuid(),
                Imie = "Vinicius",
                Nazwisko = "Junior",
                Wiek = 21,
                Pozycja = "Lewy skrzydłowy",
                Wynagrodzenie = 420000
            };

            Pilkarz ToniKroos = new Pilkarz 
            { 
                IdPilkarz = Guid.NewGuid(),
                Imie = "Toni", 
                Nazwisko = "Kroos",
                Wiek = 33, 
                Pozycja = "Środkowy pomocnik", Wynagrodzenie = 250000
            };

            klubRepo?.CreateKlub(RealMadryt);
            klubService?.DodajPilkarzyDoObecnych(new List<Pilkarz>() { ViniciusJunior, ToniKroos, ViniciusJunior }, RealMadryt);

            Assert.Equal(2, klubRepo?.GetKlubById(RealMadryt.IdKlub).Result.ObecniPilkarze.Count);
        }

        [Fact]
        public void TestDodajPilkarzaDoArchiwalnych()
        {
            var klubRepo = new FakeKlubRepository();
            var unitOfWork = new UnitOfWork(null, klubRepo);
            var klubService = new KlubService(unitOfWork);

            Pilkarz ViniciusJunior = new Pilkarz
            {
                IdPilkarz = Guid.NewGuid(),
                Imie = "Vinicius",
                Nazwisko = "Junior",
                Wiek = 21,
                Pozycja = "Lewy skrzydłowy",
                Wynagrodzenie = 420000
            };

            Pilkarz ToniKroos = new Pilkarz
            {
                IdPilkarz = Guid.NewGuid(),
                Imie = "Toni",
                Nazwisko = "Kroos",
                Wiek = 33,
                Pozycja = "Środkowy pomocnik",
                Wynagrodzenie = 250000
            };

            Klub RealMadryt = new Klub()
            {
                IdKlub = Guid.NewGuid(),
                Nazwa = "Real Madryt",
                Stadion = "Estadio Santiago Bernabéu",
                Trofea = "Liga Mistrzów (13 razy), Primera División (34 razy), Puchar Króla (19 razy), Superpuchar Hiszpanii (11 razy)",
                ObecniPilkarze = new Collection<Pilkarz> { ToniKroos, ViniciusJunior },
                ArchiwalniPilkarze = new Collection<Pilkarz> { }
            };

            klubRepo?.CreateKlub(RealMadryt);
            klubService?.DodajPilkarzaDoArchiwalnych(ToniKroos.IdPilkarz, RealMadryt.IdKlub);
            klubService?.DodajPilkarzaDoArchiwalnych(ViniciusJunior.IdPilkarz, RealMadryt.IdKlub);
            klubService?.DodajPilkarzaDoArchiwalnych(ToniKroos.IdPilkarz, RealMadryt.IdKlub);

            Assert.Equal(2, RealMadryt.ArchiwalniPilkarze.Count());
        }
    }
}