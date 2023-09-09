using BusinessLogicLayer.Interfaces;
using FootballClubLibrary.Models;
using FootballClubLibrary.UnitOfWork;

namespace BusinessLogicLayer.Services
{
    public class PilkarzService : IPilkarzService
    {
        private readonly IUnitOfWork unitOfWork;

        public PilkarzService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task DodajPilkarza(Pilkarz pilkarz)
        {
            var foundPilkarz = await this.unitOfWork.PilkarzRepository.GetPilkarzById(pilkarz.IdPilkarz);
            if (foundPilkarz == null)
            {
                await this.unitOfWork.PilkarzRepository.CreatePilkarz(pilkarz);
                await this.unitOfWork.Save();
            }
        }

        public async Task UsunPilkarza(Guid IdPilkarz)
        {
            var foundPilkarz = await this.unitOfWork.PilkarzRepository.GetPilkarzById(IdPilkarz);
            if (foundPilkarz != null)
            {
                await this.unitOfWork.PilkarzRepository.DeletePilkarz(IdPilkarz);
            }
        }

        public async Task EdytujPilkarza(Pilkarz pilkarz, Guid IdPilkarz)
        {
            if (pilkarz != null)
            {
                await this.unitOfWork.PilkarzRepository.UpdatePilkarz(pilkarz, IdPilkarz);
            }
        }

        public async Task<Pilkarz> DajPilkarza(Guid IdPilkarz)
        {
            var pilkarz = await this.unitOfWork.PilkarzRepository.GetPilkarzById(IdPilkarz);
            return pilkarz;
        }

        public async Task<IEnumerable<Pilkarz>> DajPilkarzy()
        {
            return await this.unitOfWork.PilkarzRepository.GetPilkarze();
        }

        public async Task<IEnumerable<Pilkarz>> DajPilkarzyBezKlubu()
        {
            var pilkarze = await this.unitOfWork.PilkarzRepository.GetPilkarze();
            var result = pilkarze.Where(p => p.IdKlubu == null && p.Klub == null);
            return result;
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

        public async Task<IEnumerable<Statystyka>> DajNajlepszeStatystykiPilkarza(Pilkarz pilkarz)
        {
            var statystyki = await this.unitOfWork.StatystykaRepository.GetStatystyki();
            if (pilkarz.Statystyki == null)
            {
                pilkarz.Statystyki = new List<Statystyka>();
                pilkarz.Statystyki = statystyki.Where(s => s.Pilkarz == pilkarz).ToList();
                await this.unitOfWork.PilkarzRepository.Save();
            }
            var result = pilkarz.Statystyki.OrderByDescending(p => p.Ocena).Take(3);
            if (result.Count() < 3)
            {
                return pilkarz.Statystyki;
            }
            return result;
        }

        public async Task<IEnumerable<Statystyka>> DajStatystykiPilkarza(Pilkarz pilkarz)
        {
            var statystyki = await this.unitOfWork.StatystykaRepository.GetStatystyki();
            if (pilkarz.Statystyki == null)
            {
                pilkarz.Statystyki = new List<Statystyka>();
                pilkarz.Statystyki = statystyki.Where(s => s.Pilkarz == pilkarz).ToList();
            }

            var result = pilkarz.Statystyki;

            if (result == null)
            {
                return pilkarz.Statystyki;
            }
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
    }
}