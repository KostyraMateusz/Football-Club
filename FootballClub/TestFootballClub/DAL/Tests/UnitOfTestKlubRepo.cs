using FootballClubLibrary.Data;
using FootballClubLibrary.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace TestsFootballClub.DAL.Tests
{
    public class UnitOfTestKlubRepo
    {
        [Fact]
        public async Task TestKlubowAsync()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Testowa1").Options;
            var klubContext = new ApplicationDbContext(options);
            KlubRepository klubRepository = new KlubRepository(klubContext);
            Assert.NotNull(klubRepository);

            await klubRepository.CreateKlub(new Klub() { IdKlub = new Guid(), Nazwa = "Real Madryt", Stadion = "Estadio Santiago Bernabéu", Trofea = "Liga Mistrzów (13 razy), Primera División (34 razy), Puchar Króla (19 razy), Superpuchar Hiszpanii (11 razy)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null });
            await klubRepository.CreateKlub(new Klub() { IdKlub = new Guid(), Nazwa = "FC Barcelona", Stadion = "Camp Nou", Trofea = "Liga Mistrzów (5 razy), Primera División (26 razy), Puchar Króla (31 razy), Superpuchar Hiszpanii (13 razy)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null });
            await klubRepository.Save();

            var klubs = await klubRepository.GetKluby();
            Assert.NotEmpty(klubs);
            Assert.Equal(2, klubs.Count());
        }

        [Fact]
        public async void TestDeleteKlub()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Testowa2").Options;
            var klubContext = new ApplicationDbContext(options);
            KlubRepository klubRepository = new KlubRepository(klubContext);
            Assert.NotNull(klubRepository);

            var idKlub = Guid.NewGuid();
            await klubRepository.CreateKlub(new Klub() { IdKlub = idKlub, Nazwa = "Real Madryt", Stadion = "Estadio Santiago Bernabéu", Trofea = "Liga Mistrzów (13 razy), Primera División (34 razy), Puchar Króla (19 razy), Superpuchar Hiszpanii (11 razy)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null });
            await klubRepository.Save();
            Assert.Equal(1, klubRepository.GetKluby().Result.Count());

            await klubRepository.CreateKlub(new Klub() { IdKlub = new Guid(), Nazwa = "FC Barcelona", Stadion = "Camp Nou", Trofea = "Liga Mistrzów (5 razy), Primera División (26 razy), Puchar Króla (31 razy), Superpuchar Hiszpanii (13 razy)", ObecniPilkarze = new Collection<Pilkarz> { }, ArchiwalniPilkarze = new Collection<Pilkarz> { }, Zarzad = null });
            await klubRepository.Save();
            Assert.Equal(2, klubRepository.GetKluby().Result.Count());

            klubRepository?.DeleteKlub(idKlub);
            await klubRepository.Save();
            Assert.Equal(1, klubRepository.GetKluby().Result.Count());
        }

        [Fact]
        public async void TestUpdateKlub()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Testowa3").Options;
            var klubContext = new ApplicationDbContext(options);
            KlubRepository klubRepository = new KlubRepository(klubContext);
            Assert.NotNull(klubRepository);

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

            klubRepository.CreateKlub(RealMadryt);
            await klubRepository.Save();

            RealMadryt.Stadion = "Estadio Santiago Bernabéu";
            klubRepository.UpdateKlub(RealMadryt);
            await klubRepository.Save();

            Assert.Equal(RealMadryt, klubRepository.GetKlubById(idKlub).Result);
        }

        [Fact]
        public async void DodajTrofeumKlubu()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Testowa4").Options;
            var klubContext = new ApplicationDbContext(options);
            KlubRepository klubRepository = new KlubRepository(klubContext);
            Assert.NotNull(klubRepository);

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

            klubRepository.CreateKlub(RealMadryt);
            klubRepository.DodajTrofeumKlubu(RealMadryt.IdKlub, "Primera División (34 razy)");
            klubRepository.DodajTrofeumKlubu(RealMadryt.IdKlub, "Puchar Króla (19 razy)");
            klubRepository.DodajTrofeumKlubu(RealMadryt.IdKlub, "Superpuchar Hiszpanii (11 razy)");
            await klubRepository.Save();

            string trofea = "Liga Mistrzów (13 razy), Primera División (34 razy), Puchar Króla (19 razy), Superpuchar Hiszpanii (11 razy)";
            Assert.Equal(trofea, klubRepository.GetKlubById(RealMadryt.IdKlub).Result.Trofea);
        }

        [Fact]
        public async void TestDodajPilkarzaDoObecnych()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Testowa5").Options;
            var klubContext = new ApplicationDbContext(options);
            KlubRepository klubRepository = new KlubRepository(klubContext);
            Assert.NotNull(klubRepository);

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

            klubRepository.CreateKlub(RealMadryt);
            klubRepository.DodajPilkarzaDoObecnych(RealMadryt, ViniciusJunior);
            klubRepository.DodajPilkarzaDoObecnych(RealMadryt, new Pilkarz());
            klubRepository.DodajPilkarzaDoObecnych(RealMadryt, ViniciusJunior);
            await klubRepository.Save();

            Assert.Equal(2, klubRepository?.GetKlubById(RealMadryt.IdKlub).Result.ObecniPilkarze.Count);
        }

        [Fact]
        public async void TestDodajPilkarzyDoObecnych()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Testowa6").Options;
            var klubContext = new ApplicationDbContext(options);
            KlubRepository klubRepository = new KlubRepository(klubContext);
            Assert.NotNull(klubRepository);

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
                Pozycja = "Środkowy pomocnik",
                Wynagrodzenie = 250000
            };

            klubRepository.CreateKlub(RealMadryt);
            klubRepository.DodajPilkarzyDoObecnych(RealMadryt, new List<Pilkarz>() { ViniciusJunior, ToniKroos, ViniciusJunior });
            await klubRepository.Save();

            Assert.Equal(2, klubRepository.GetKlubById(idKlub).Result.ObecniPilkarze.Count);
        }

        [Fact]
        public async void TestDodajPilkarzaDoArchiwalnych()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Testowa7").Options;
            var klubContext = new ApplicationDbContext(options);
            KlubRepository klubRepository = new KlubRepository(klubContext);
            Assert.NotNull(klubRepository);

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
                Pozycja = "Środkowy pomocnik",
                Wynagrodzenie = 250000
            };

            klubRepository.CreateKlub(RealMadryt);
            klubRepository.DodajPilkarzaDoArchiwalnych(RealMadryt, ToniKroos);
            klubRepository.DodajPilkarzaDoArchiwalnych(RealMadryt, ViniciusJunior);
            klubRepository.DodajPilkarzaDoArchiwalnych(RealMadryt, ToniKroos);
            await klubRepository.Save();

            Assert.Equal(2, klubRepository.GetKlubById(idKlub).Result.ArchiwalniPilkarze.Count);
        }
    }
}