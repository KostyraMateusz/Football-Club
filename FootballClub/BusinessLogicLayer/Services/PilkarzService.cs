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
    public class PilkarzService : IPilkarzService
    {
        private readonly IUnitOfWork unitOfWork;

        public PilkarzService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Klub>> DajArchiwalneKlubyPilkarza(Guid IdPilkarz)
        {
            var pilkarz = await this.unitOfWork.PilkarzRepository.GetPilkarzById(IdPilkarz);
            var result = pilkarz.ArchiwalneKluby.ToList();
            return result;
        }

        public async Task<Statystyka> DajStatystykePilkarza(Guid IdStatystyka, Guid IdPilkarza)
        {
            var pilkarz = await this.unitOfWork.PilkarzRepository.GetPilkarzById(IdPilkarza);
            var result = pilkarz.Statystyki.First(s => s.IdStatystyka == IdStatystyka);
            return result;
        }

        public async Task<IEnumerable<Statystyka>> DajStatystykiPilkarza(Guid IdPilkarz)
        {
            var pilkarz = await this.unitOfWork.PilkarzRepository.GetPilkarzById(IdPilkarz);
            var result = pilkarz.Statystyki.ToList();
            return result;
        }

        public async Task ZmienPozycjePilkarza(Guid IdPilkarza, string pozycja)
        {
            var pilkarz = await this.unitOfWork.PilkarzRepository.GetPilkarzById(IdPilkarza);
            if(pozycja != "")
            {
                pilkarz.Pozycja = pozycja;
            }
            return;
        }
    }
}
