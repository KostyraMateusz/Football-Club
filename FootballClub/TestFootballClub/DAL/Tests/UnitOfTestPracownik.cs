using FootballClubLibrary.Data;
using FootballClubLibrary.Repositories;
using Microsoft.EntityFrameworkCore;

namespace TestsFootballClub.DAL.Tests
{
    public class UnitOfTestPracownik
    {
        [Fact]
        public async void TestCreatePracownik()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Testowa1").Options;
            var pracownikContext = new ApplicationDbContext(options);
            PracownikRepository pracownikRepository = new PracownikRepository(pracownikContext);
            Assert.NotNull(pracownikRepository);

            await pracownikRepository.CreatePracownik(new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Fiorentino", Nazwisko = "Perez", PESEL = "12345600101", Wiek = 77, WykonywanaFunkcja = "Prezes", Wynagrodzenie = 420000 });
            await pracownikRepository.CreatePracownik(new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Carlo", Nazwisko = "Ancelotti", PESEL = "23456700202", Wiek = 64, WykonywanaFunkcja = "Trener", Wynagrodzenie = 350000 });
            await pracownikRepository.CreatePracownik(new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Davide", Nazwisko = "Ancelotti", PESEL = "34567800303", Wiek = 33, WykonywanaFunkcja = "Asystent trenera", Wynagrodzenie = 300000 });
            await pracownikRepository.Save();

            var pracownicy = await pracownikRepository.GetPracownicy();
            Assert.NotEmpty(pracownicy);
            Assert.Equal(3, pracownicy.Count());
        }

        [Fact]
        public async void TestDeletePracownik()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Testowa2").Options;
            var pracownikContext = new ApplicationDbContext(options);
            PracownikRepository pracownikRepository = new PracownikRepository(pracownikContext);
            Assert.NotNull(pracownikRepository);

            var idPracownik = Guid.NewGuid();

            await pracownikRepository.CreatePracownik(new Pracownik() { IdPracownik = idPracownik, Imie = "Fiorentino", Nazwisko = "Perez", PESEL = "12345600101", Wiek = 77, WykonywanaFunkcja = "Prezes", Wynagrodzenie = 420000 });
            await pracownikRepository.Save();
            Assert.Equal(1, pracownikRepository.GetPracownicy().Result.Count());

            await pracownikRepository.CreatePracownik(new Pracownik() { IdPracownik = Guid.NewGuid(), Imie = "Carlo", Nazwisko = "Ancelotti", PESEL = "23456700202", Wiek = 64, WykonywanaFunkcja = "Trener", Wynagrodzenie = 350000 });
            await pracownikRepository.Save();
            Assert.Equal(2, pracownikRepository.GetPracownicy().Result.Count());

            pracownikRepository.DeletePracownik(idPracownik);
            await pracownikRepository.Save();
            Assert.Equal(1, pracownikRepository.GetPracownicy().Result.Count());
        }

        [Fact]
        public async void TestUpdatePracownik()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Testowa3").Options;
            var pracownikContext = new ApplicationDbContext(options);
            PracownikRepository pracownikRepository = new PracownikRepository(pracownikContext);
            Assert.NotNull(pracownikRepository);

            var idPracownik = Guid.NewGuid();
            Pracownik testowyPracownik = new Pracownik()
            {
                IdPracownik = idPracownik,
                Imie = "Carlo",
                Nazwisko = "Ancelotti",
                PESEL = "23456700202",
                Wiek = 64,
                WykonywanaFunkcja = "Woźny",
                Wynagrodzenie = 350000
            };

            pracownikRepository.CreatePracownik(testowyPracownik);
            await pracownikRepository.Save();

            testowyPracownik.WykonywanaFunkcja = "Trener";
            pracownikRepository?.UpdatePracownik(testowyPracownik);
            await pracownikRepository.Save();

            Assert.Equal(testowyPracownik, pracownikRepository?.GetPracownikById(idPracownik).Result);
        }
    }
}
