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

        public async Task<IEnumerable<Pilkarz>> DajPilkarzy()
        {
            return await this.unitOfWork.PilkarzRepository.GetPilkarze();
        }

        public async Task<IEnumerable<Klub>> DajArchiwalneKlubyPilkarza(Pilkarz pilkarz)
        {
            var result = pilkarz.ArchiwalneKluby?.ToList();
            return result;
        }

        public async Task<Statystyka> DajStatystykePilkarza(Pilkarz pilkarz, Guid IdStatystyka)
        {
            var result = pilkarz.Statystyki?.First(s => s.IdStatystyka == IdStatystyka);
            return result;
        }

        public async Task<IEnumerable<Statystyka>> DajStatystykiPilkarza(Pilkarz pilkarz)
        {
            var result = pilkarz.Statystyki;
            return result;
        }

        public async Task ZmienPozycjePilkarza(Pilkarz pilkarz, string pozycja)
        {
            if (pozycja != "")
            {
                pilkarz.Pozycja = pozycja;
            }
            else
            {
                return;
            }
            await this.unitOfWork.Save();
        }

        public async Task<IEnumerable<Statystyka>> DajNajlepszeStatystykiPilkarza(Pilkarz pilkarz)
        {
            var result = pilkarz.Statystyki?.OrderByDescending(p => p.Ocena).Take(5).ToList();
            return result;
        }

        public async Task<IEnumerable<Pilkarz>> DajPilkarzyBezKlubu()
        {
            var pilkarze = await this.unitOfWork.PilkarzRepository.GetPilkarze();
            var result = pilkarze.Where(p => p.IdKlubu == null && p.Klub == null);
            return result;
        }
    }
}
