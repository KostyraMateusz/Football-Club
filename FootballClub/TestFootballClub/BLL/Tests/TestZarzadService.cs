using BusinessLogicLayer.Services;
using FootballClubLibrary.UnitOfWork;
using TestsFootballClub.FakeRepositories;

namespace TestsFootballClub.BLL.Tests
{
    public class TestZarzadService
    {
        [Fact]
        public void TestCreateZarzad()
        {
            var zarzadRepo = new FakeZarzadRepository();
            var unitOfWork = new UnitOfWork(null, null, null, null, null, zarzadRepo);
            var ZarzadService = new ZarzadService(unitOfWork);

            zarzadRepo?.CreateZarzad(new Zarzad());
            Assert.Equal(1, zarzadRepo?.GetZarzady().Result.Count());

            zarzadRepo?.CreateZarzad(new Zarzad());
            Assert.Equal(2, zarzadRepo?.GetZarzady().Result.Count());

            zarzadRepo?.CreateZarzad(new Zarzad());
            Assert.Equal(3, zarzadRepo?.GetZarzady().Result.Count());
        }

        [Fact]
        public void TestDeleteZarzad()
        {
            var zarzadRepo = new FakeZarzadRepository();
            var unitOfWork = new UnitOfWork(null, null, null, null, null, zarzadRepo);
            var ZarzadService = new ZarzadService(unitOfWork);

            var idZarzad = Guid.NewGuid();

            zarzadRepo?.CreateZarzad(new Zarzad() { IdZarzad = idZarzad });
            Assert.Equal(1, zarzadRepo?.GetZarzady().Result.Count());

            zarzadRepo?.CreateZarzad(new Zarzad());
            Assert.Equal(2, zarzadRepo?.GetZarzady().Result.Count());

            zarzadRepo?.DeleteZarzad(idZarzad);
            Assert.Equal(1, zarzadRepo?.GetZarzady().Result.Count());
        }

        [Fact]
        public void TestUpdateZarzad()
        {
            var zarzadRepo = new FakeZarzadRepository();
            var unitOfWork = new UnitOfWork(null, null, null, null, null, zarzadRepo);
            var ZarzadService = new ZarzadService(unitOfWork);

            var idZarzad = Guid.NewGuid();
            Zarzad testowyZarzad = new Zarzad()
            {
                IdZarzad = idZarzad,
                Pracownicy = new List<Pracownik>(),
                Budzet = 250,
                Cele = "Liga Mistrzów",
                IdKlubu = null
            };

            zarzadRepo?.CreateZarzad(testowyZarzad);

            testowyZarzad.Budzet = 2500000;
            zarzadRepo?.UpdateZarzad(testowyZarzad);

            Assert.Equal(testowyZarzad, zarzadRepo?.GetZarzadById(idZarzad).Result);
        }
    }
}
