using BusinessLogicLayer.Interfaces;
using FootballClubLibrary.Models;
using FootballClubLibrary.UnitOfWork;

namespace BusinessLogicLayer.Services
{
    public class PracownikService : IPracownikService
    {
        private readonly IUnitOfWork unitOfWork;

        public PracownikService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task DodajPracownika(Pracownik pracownik)
        {
            var foundPracownik = await this.unitOfWork.PracownikRepository.GetPracownikById(pracownik.IdPracownik);
            if (foundPracownik == null)
            {
                await this.unitOfWork.PracownikRepository.CreatePracownik(pracownik);
                await this.unitOfWork.Save();
            }
        }

        public async Task UsunPracownika(Guid IdPracownika)
        {
            var foundPracownik = await this.unitOfWork.PracownikRepository.GetPracownikById(IdPracownika);
            if (foundPracownik != null)
            {
                await this.unitOfWork.PracownikRepository.DeletePracownik(IdPracownika);
                await this.unitOfWork.Save();
            }
        }

        public async Task EdytujPracownika(Pracownik pracownik)
        {
            if (pracownik != null)
            {
                await this.unitOfWork.PracownikRepository.UpdatePracownik(pracownik);
            }
        }

        public async Task<Pracownik> DajPracownika(Guid IdPracownika)
        {
            var pracownik = await this.unitOfWork.PracownikRepository.GetPracownikById(IdPracownika);
            return pracownik;
        }

        public async Task<IEnumerable<Pracownik>> DajPracownikow()
        {
            return await this.unitOfWork.PracownikRepository.GetPracownicy();
        }

        public async Task ZmienFunkcjePracownika(Guid IdPracownika, string funkcja)
        {
            var pracownik = await this.unitOfWork.PracownikRepository.GetPracownikById(IdPracownika);
            if (funkcja != "")
            {
                pracownik.WykonywanaFunkcja = funkcja;
            }
            else
            {
                return;
            }
            await this.unitOfWork.Save();
        }

		public async Task ZmienWynagrodzenie(Guid IdPracownika, decimal wynagrodzenie)
		{
			var pracownik = await this.unitOfWork.PracownikRepository.GetPracownikById(IdPracownika);
			if (wynagrodzenie > 0)
			{
				pracownik.Wynagrodzenie = wynagrodzenie;
			}
			else
			{
				return;
			}
			await this.unitOfWork.Save();
		}

		public async Task ZmienWiekPracownika(Guid IdPracownika, int wiek)
        {
            var pracownik = await this.unitOfWork.PracownikRepository.GetPracownikById(IdPracownika);
            if (wiek >= 16 && wiek <= 99)
            {
                pracownik.Wiek = wiek;
            }
            else
            {
                return;
            }
            await this.unitOfWork.Save();
        }
    }
}