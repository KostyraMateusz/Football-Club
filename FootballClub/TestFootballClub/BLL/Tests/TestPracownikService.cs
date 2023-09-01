using BusinessLogicLayer.Services;
using FootballClubLibrary.UnitOfWork;
using TestsFootballClub.BLL.FakeRepositories;

namespace TestsFootballClub.BLL.Tests
{
    public class TestPracownikService
    {
        [Fact]
        public void TestCreatePracownik()
        {
            var pracownikRepo = new FakePracownikRepository();
            var unitOfWork = new UnitOfWork(null, null, null, pracownikRepo);
            var PracownikService = new PracownikService(unitOfWork);

            pracownikRepo?.CreatePracownik(new Pracownik());
            Assert.Equal(1, pracownikRepo?.GetPracownicy().Result.Count());

            pracownikRepo?.CreatePracownik(new Pracownik());
            Assert.Equal(2, pracownikRepo?.GetPracownicy().Result.Count());

            pracownikRepo?.CreatePracownik(new Pracownik());
            Assert.Equal(3, pracownikRepo?.GetPracownicy().Result.Count());
        }

        [Fact]
        public void TestDeletePracownik()
        {
            var pracownikRepo = new FakePracownikRepository();
            var unitOfWork = new UnitOfWork(null, null, null, pracownikRepo);
            var PracownikService = new PracownikService(unitOfWork);

            var idPracownik = Guid.NewGuid();

            pracownikRepo?.CreatePracownik(new Pracownik() { IdPracownik = idPracownik });
            Assert.Equal(1, pracownikRepo?.GetPracownicy().Result.Count());

            pracownikRepo?.CreatePracownik(new Pracownik());
            Assert.Equal(2, pracownikRepo?.GetPracownicy().Result.Count());

            pracownikRepo?.DeletePracownik(idPracownik);
            Assert.Equal(1, pracownikRepo?.GetPracownicy().Result.Count());
        }

        [Fact]
        public void TestUpdatePracownik()
        {
            var pracownikRepo = new FakePracownikRepository();
            var unitOfWork = new UnitOfWork(null, null, null, pracownikRepo);
            var PracownikService = new PracownikService(unitOfWork);

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

            pracownikRepo?.CreatePracownik(testowyPracownik);

            testowyPracownik.WykonywanaFunkcja = "Trener";
            pracownikRepo?.UpdatePracownik(testowyPracownik);

            Assert.Equal(testowyPracownik, pracownikRepo?.GetPracownikById(idPracownik).Result);
        }
    }
}
