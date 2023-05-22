using BusinessLogicLayer.Interfaces;
using FootballClubLibrary.Models;
using FootballClubLibrary.Unit_of_Work;
using NuGet.Versioning;
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

        public async Task<IEnumerable<Klub>> DajKluby()
        {
            return await this.unitOfWork.KlubRepository.GetKluby();
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
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }

        }

        public async Task<Pilkarz> DajObecnegoPilkarza(Guid IdKlubu, Guid IdPilkarza)
        {
            var klub = await this.unitOfWork.KlubRepository.GetKlubById(IdKlubu);
            var result = klub.ObecniPilkarze.First(p => p.IdPilkarz == IdPilkarza);
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        public async Task<IEnumerable<Pilkarz>> DajObecnychPilkarzy(Guid IdKlubu)
        {
            var klub = await this.unitOfWork.KlubRepository.GetKlubById(IdKlubu);
            var result = klub.ObecniPilkarze?.ToList();
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<string> DajStadionKlubu(Guid IdKlubu)
        {
            var klub = await this.unitOfWork.KlubRepository.GetKlubById(IdKlubu);
            return klub?.Stadion;
        }

        public async Task<string> DajTrofeaKlubu(Guid IdKlubu)
        {
            var klub = await this.unitOfWork.KlubRepository.GetKlubById(IdKlubu);
            return klub.Trofea;
        }

        public async Task DodajPilkarzaDoObecnych(Pilkarz pilkarz, Guid IdKlubu)
        {
            var klub = await this.unitOfWork.KlubRepository.GetKlubById(IdKlubu);
            bool czyPilkarzJestWObecnych = klub.ObecniPilkarze == null ? false : (klub.ObecniPilkarze.Contains(pilkarz));
            if (pilkarz == null || klub == null || czyPilkarzJestWObecnych == true)
            {
                return;
            }
            klub.ObecniPilkarze?.Add(pilkarz);
            await this.unitOfWork.Save();
        }

        public async Task UsunPilkarzaZObecnych(Guid PilkarzId, Guid IdKlubu)
        {
            var klub = await this.unitOfWork.KlubRepository.GetKlubById(IdKlubu);
            var _pilkarz = await this.unitOfWork.PilkarzRepository.GetPilkarzById(PilkarzId);
            bool czyPilkarzJestWObecnych = klub.ObecniPilkarze == null ? false : (klub.ObecniPilkarze.Contains(_pilkarz));
            if (_pilkarz == null || klub == null || czyPilkarzJestWObecnych == false)
            {
                return;
            }
            klub.ObecniPilkarze?.Remove(_pilkarz);
            klub.ArchwilaniPilkarze?.Add(_pilkarz);
            await this.unitOfWork.Save();
        }

        public async Task DodajPilkarzyDoObecnych(List<Pilkarz> pilkarze, Klub klub)
        {
            if (klub == null || pilkarze == null)
            {
                return;
            }
            foreach(var pilkarz in pilkarze)
            {
                if(pilkarz != null)
                {
                    klub?.ObecniPilkarze?.Add(pilkarz);
                }
            }
        }
    }
}
