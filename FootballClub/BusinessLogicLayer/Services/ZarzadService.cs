using BusinessLogicLayer.Interfaces;
using FootballClubLibrary.Models;
using FootballClubLibrary.UnitOfWork;
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
        public async Task<IEnumerable<Zarzad>> DajZarzady()
        {
            return await this.unitOfWork.ZarzadRepository.GetZarzady();
        }

        public async Task<decimal> DajWynikFinansowyZarzadu(Guid IdZarzadu)
        {
            var zarzad = await this.unitOfWork.ZarzadRepository.GetZarzadById(IdZarzadu);
            if (zarzad == null)
            {
                return 0;
            }
            var klub = await this.unitOfWork.KlubRepository.GetKlubById((Guid)zarzad.IdKlubu);
            var pensjePilkarze = klub.ObecniPilkarze.Sum(p => p.Wynagrodzenie);
            var pensjePracownikow = zarzad.Pracownicy.Sum(p => p.Wynagrodzenie);
            return zarzad.Budzet - pensjePilkarze - pensjePracownikow;
        }

        public async Task DodajCelZarzadu(Guid IdZarzadu, string cel)
        {
            var zarzad = await this.unitOfWork.ZarzadRepository.GetZarzadById(IdZarzadu);
            if (cel != "")
            {
                zarzad.Cele += ", " + cel;
            }
            else
            {
                return;
            }
            await this.unitOfWork.Save();
        }

        public async Task DodajCzlonkaZarzadu(Guid IdZarzadu, Guid PracownikId)
        {
            var zarzad = await this.unitOfWork.ZarzadRepository.GetZarzadById(IdZarzadu);
            var pracownik = await this.unitOfWork.PracownikRepository.GetPracownikById(PracownikId);
            if (pracownik != null)
            {
                zarzad.Pracownicy?.Add(pracownik);
            } 
            else
            {
                return;
            }
            await this.unitOfWork.Save();
        }

        public async Task ZmienBudzetZarzadu(Guid IdZarzadu, decimal budzet)
        {
            var zarzad = await this.unitOfWork.ZarzadRepository.GetZarzadById(IdZarzadu);
            if (budzet > 0)
            {
                zarzad.Budzet = budzet;
            }
            else
            {
                return;
            }
            await this.unitOfWork.Save();
        }
    }
}