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
    public class ZarzadService : IZarzadService
    {
        private readonly IUnitOfWork unitOfWork;

        public ZarzadService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<decimal> DajBudzetZarzadu(Guid IdZarzadu)
        {
            var zarzad = await this.unitOfWork.ZarzadRepository.GetZarzadById(IdZarzadu);
            var result = zarzad.Budzet;
            return result;
        }

        public async Task DodajCelZarzadu(Guid IdZarzadu, string cel)
        {
            var zarzad = await this.unitOfWork.ZarzadRepository.GetZarzadById(IdZarzadu);
            if (cel != "")
            {
                zarzad.Cele.Add(cel);
            }
            return;
        }

        public async Task DodajCzlonkaZarzadu(Guid IdZarzadu, Pracownik pracownik)
        {
            var zarzad = await this.unitOfWork.ZarzadRepository.GetZarzadById(IdZarzadu);
            if (pracownik != null)
            {
                zarzad.Pracownicy.Add(pracownik);
            }
            return;
        }

        public async Task ZmienBudzetZarzadu(Guid IdZarzadu, decimal budzet)
        {
            var zarzad = await this.unitOfWork.ZarzadRepository.GetZarzadById(IdZarzadu);
            if (budzet > 0)
            {
                zarzad.Budzet = budzet;
            }
            return;
        }
    }
}