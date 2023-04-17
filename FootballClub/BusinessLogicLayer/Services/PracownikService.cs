using BusinessLogicLayer.Interfaces;
using FootballClubLibrary.Models;
using FootballClubLibrary.Unit_of_Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class PracownikService : IPracownikService
    {
        private readonly IUnitOfWork unitOfWork;

        public PracownikService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
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
    }
}