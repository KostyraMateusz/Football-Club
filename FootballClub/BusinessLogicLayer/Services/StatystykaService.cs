using BusinessLogicLayer.Interfaces;
using FootballClubLibrary.Models;
using FootballClubLibrary.UnitOfWork;

namespace BusinessLogicLayer.Services
{
    public class StatystykaService : IStatystykaService
    {
        private readonly IUnitOfWork unitOfWork;

        public StatystykaService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task DodajStatystyke(Statystyka statystyka)
        {
            var foundStatystyka = await this.unitOfWork.StatystykaRepository.GetStatystykaById(statystyka.IdStatystyka);
            if (foundStatystyka == null)
            {
                await this.unitOfWork.StatystykaRepository.CreateStatystyka(statystyka);
                await this.unitOfWork.Save();
            }
        }

        public async Task UsunStatystyke(Guid IdStatystyka)
        {
            var foundStatystyka = await this.unitOfWork.StatystykaRepository.GetStatystykaById(IdStatystyka);
            if (foundStatystyka != null)
            {
                await this.unitOfWork.StatystykaRepository.DeleteStatystyka(IdStatystyka);
            }
        }

        public async Task EdytujStatystyke(Statystyka statystyka)
        {
            if (statystyka != null)
            {
                await this.unitOfWork.StatystykaRepository.UpdateStatystyka(statystyka);
            }
        }

        public async Task<Statystyka> DajStatystyke(Guid IdStatystyka)
        {
            var statystyka = await this.unitOfWork.StatystykaRepository.GetStatystykaById(IdStatystyka);
            return statystyka;
        }

        public async Task<IEnumerable<Statystyka>> DajStatystyki()
        {
            return await this.unitOfWork.StatystykaRepository.GetStatystyki();
        }

		public async Task<Statystyka> DajStatystykeMeczu(string mecz)
		{
			var statystyki = await this.unitOfWork.StatystykaRepository.GetStatystyki();
			var result = statystyki.First(s => s.Mecz == mecz);
			return result;
		}

		public async Task<IEnumerable<Statystyka>> DajStatystkiZoltejKartki()
        {
            var statystyki = await this.unitOfWork.StatystykaRepository.GetStatystyki();
            var result = statystyki.Where(s => s.ZolteKartki == 1);
            return result;
        }

		public async Task<IEnumerable<Statystyka>> DajStatystykiCzerwonychKartek()
		{
			var statystyki = await this.unitOfWork.StatystykaRepository.GetStatystyki();
			var result = statystyki.Where(k => k.CzerwoneKartki == 1 || k.ZolteKartki == 2);
			return result;
		}

		public async Task<IEnumerable<Statystyka>> DajStatystykeNajdluzszePrzebiegnieteDystanse()
        {
            var statystyki = await this.unitOfWork.StatystykaRepository.GetStatystyki();
            var result = statystyki.Where(s => s.PrzebiegnietyDystans >= 10.0).Take(5);
            return result;
        }
    }
}