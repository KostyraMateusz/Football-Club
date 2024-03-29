﻿using BusinessLogicLayer.Interfaces;
using FootballClubLibrary.Models;
using FootballClubLibrary.UnitOfWork;

namespace BusinessLogicLayer.Services
{
    public class ZarzadService : IZarzadService
    {
        private readonly IUnitOfWork unitOfWork;

        public ZarzadService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task DodajZarzad(Zarzad zarzad)
        {
            var foundZarzad = await this.unitOfWork.ZarzadRepository.GetZarzadById(zarzad.IdZarzad);
            var foundKlub = await this.unitOfWork.KlubRepository.GetKlubById(zarzad.IdKlubu);

            if (foundZarzad == null)
            {
                var zarzad2 = await this.unitOfWork.ZarzadRepository.GetZarzadById(foundKlub.Zarzad.IdZarzad);
                await this.unitOfWork.ZarzadRepository.DeleteZarzad(foundKlub.Zarzad.IdZarzad);
                await this.unitOfWork.ZarzadRepository.CreateZarzad(zarzad);
            }
        }

        public async Task UsunZarzad(Guid IdZarzadu)
        {
            var foundClub = await this.unitOfWork.ZarzadRepository.GetZarzadById(IdZarzadu);
            if (foundClub != null)
            {
                await this.unitOfWork.ZarzadRepository.DeleteZarzad(IdZarzadu);
                await this.unitOfWork.Save();
            }
        }

        public async Task EdytujZarzad(Zarzad zarzad)
        {
            if (zarzad != null)
            {
                await this.unitOfWork.ZarzadRepository.UpdateZarzad(zarzad);
                await this.unitOfWork.Save();
            }
        }

        public async Task<Zarzad> DajZarzad(Guid IdZarzadu)
        {
            var zarzad = await this.unitOfWork.ZarzadRepository.GetZarzadById(IdZarzadu);
            return zarzad;
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
                zarzad.Cele = cel;
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
                pracownik.IdZarzadu = zarzad.IdZarzad;
                zarzad.Pracownicy?.Add(pracownik);
            } 
            else
            {
                return;
            }
            await this.unitOfWork.Save();
        }

        public async Task UsunCzlonkaZarzadu(Guid IdZarzadu, Guid PracownikId)
        {
            var zarzad = await this.unitOfWork.ZarzadRepository.GetZarzadById(IdZarzadu);
            var pracownik = await this.unitOfWork.PracownikRepository.GetPracownikById(PracownikId);
            if (pracownik != null)
            {
                pracownik.IdZarzadu = null;
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