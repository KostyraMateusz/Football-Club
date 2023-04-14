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
    public class KlubService : IKlubService
    {
        private readonly IUnitOfWork unitOfWork;

        public KlubService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Pilkarz> DajArchiwalnegoPilkarza(Guid IdKlubu, Guid IdPilkarza)
        {
            var klub = await this.unitOfWork.KlubRepository.GetKlubById(IdKlubu);
            var pilkarz = klub.ArchwilaniPilkarze.First(p => p.IdPilkarz == IdPilkarza);
            return pilkarz;
        }

        public async Task<IEnumerable<Pilkarz>> DajArchiwalnychPilkarzy(Guid IdKlubu)
        {
            var klub = await this.unitOfWork.KlubRepository.GetKlubById(IdKlubu);
            var result = klub.ArchwilaniPilkarze.ToList();
            return result;
        }

        public async Task<Pilkarz> DajObecnegoPilkarza(Guid IdKlubu, Guid IdPilkarza)
        {
            var klub = await this.unitOfWork.KlubRepository.GetKlubById(IdKlubu);
            var result = klub.ObecniPilkarze.First(p => p.IdPilkarz == IdPilkarza);
            return result;
        }

        public async Task<IEnumerable<Pilkarz>> DodajObecnychPilkarzy(Guid IdKlubu)
        {
            var klub = await this.unitOfWork.KlubRepository.GetKlubById(IdKlubu);
            var result = klub.ObecniPilkarze.ToList();
            return result;
        }

        public async Task<string> DajStadionKlubu(Guid IdKlubu)
        {
            var klub = await this.unitOfWork.KlubRepository.GetKlubById(IdKlubu);
            return klub.Stadion;
        }

        public async Task<IEnumerable<string>> DajTrofeaKlubu(Guid IdKlubu)
        {
            var klub = await this.unitOfWork.KlubRepository.GetKlubById(IdKlubu);
            return klub.Trofea;
        }
    }
}
