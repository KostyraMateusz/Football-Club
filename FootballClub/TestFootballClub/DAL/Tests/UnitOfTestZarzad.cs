using FootballClubLibrary.Data;
using FootballClubLibrary.Repositories;
using Microsoft.EntityFrameworkCore;

namespace TestsFootballClub.DAL.Tests
{
    public class UnitOfTestZarzad
    {
        [Fact]
        public async void TestCreateZarzad()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Testowa1").Options;
            var zarzadContext = new ApplicationDbContext(options);
            ZarzadRepository zarzadRepository = new ZarzadRepository(zarzadContext);
            Assert.NotNull(zarzadRepository);

            await zarzadRepository.CreateZarzad(new Zarzad() { IdZarzad = Guid.NewGuid(), Pracownicy = new List<Pracownik>(), Budzet = 2500000, Cele = "Liga Mistrzów, Superpuchar Hiszpanii, Naprawa murawy, Renowacja krzesełek, Nowy młody napastnik" });
            await zarzadRepository.CreateZarzad(new Zarzad() { IdZarzad = Guid.NewGuid(), Pracownicy = new List<Pracownik>(), Budzet = 1250000, Cele = "Awans do Segunda División" });
            await zarzadRepository.Save();

            var zarzad = await zarzadRepository.GetZarzady();
            Assert.NotEmpty(zarzad);
            Assert.Equal(2, zarzad.Count());
        }

        [Fact]
        public async void TestDeleteZarzad()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Testowa2").Options;
            var zarzadContext = new ApplicationDbContext(options);
            ZarzadRepository zarzadRepository = new ZarzadRepository(zarzadContext);
            Assert.NotNull(zarzadRepository);

            var idZarzad = Guid.NewGuid();

            await zarzadRepository.CreateZarzad(new Zarzad() { IdZarzad = Guid.NewGuid(), Pracownicy = new List<Pracownik>(), Budzet = 2500000, Cele = "Liga Mistrzów, Superpuchar Hiszpanii, Naprawa murawy, Renowacja krzesełek, Nowy młody napastnik" });
            await zarzadRepository.Save();
            Assert.Equal(1, zarzadRepository?.GetZarzady().Result.Count());

            await zarzadRepository.CreateZarzad(new Zarzad() { IdZarzad = idZarzad, Pracownicy = new List<Pracownik>(), Budzet = 1250000, Cele = "Awans do Segunda División" });
            await zarzadRepository.Save();
            Assert.Equal(2, zarzadRepository?.GetZarzady().Result.Count());

            zarzadRepository.DeleteZarzad(idZarzad);
            await zarzadRepository.Save();
            Assert.Equal(1, zarzadRepository?.GetZarzady().Result.Count());
        }

        [Fact]
        public async void TestUpdateZarzad()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Testowa3").Options;
            var zarzadContext = new ApplicationDbContext(options);
            ZarzadRepository zarzadRepository = new ZarzadRepository(zarzadContext);
            Assert.NotNull(zarzadRepository);

            var idZarzad = Guid.NewGuid();
            Zarzad testowyZarzad = new Zarzad()
            {
                IdZarzad = idZarzad,
                Pracownicy = new List<Pracownik>(),
                Budzet = 250,
                Cele = "Liga Mistrzów",
                IdKlubu = null
            };

            zarzadRepository.CreateZarzad(testowyZarzad);
            await zarzadRepository.Save();

            testowyZarzad.Budzet = 2500000;
            zarzadRepository.UpdateZarzad(testowyZarzad);
            await zarzadRepository.Save();

            Assert.Equal(testowyZarzad, zarzadRepository.GetZarzadById(idZarzad).Result);
        }
    }
}        