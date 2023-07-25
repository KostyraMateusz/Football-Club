using BusinessLogicLayer.Interfaces;
using FootballClubLibrary.Models;
using FootballClubLibrary.UnitOfWork;

namespace BusinessLogicLayer.Services
{
    public class KlubService : IKlubService
    {
        private readonly IUnitOfWork unitOfWork;

        public KlubService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task DodajKlub(Klub klub)
        {
            var foundClub = await this.unitOfWork.KlubRepository.GetKlubById(klub.IdKlub);
            if (foundClub == null)
            {
                await this.unitOfWork.KlubRepository.CreateKlub(klub);
                await this.unitOfWork.Save();
            }
        }

        public async Task UsunKlub(Guid IdKlubu)
        {
            var foundClub = await this.unitOfWork.KlubRepository.GetKlubById(IdKlubu);
            if (foundClub != null)
            {
                await this.unitOfWork.KlubRepository.DeleteKlub(IdKlubu);
            }
        }

        public async Task EdytujKlub(Klub klub)
        {
            if (klub != null)
            {
                await this.unitOfWork.KlubRepository.UpdateKlub(klub);
            }
        }

        public async Task<Klub> DajKlub(Guid IdKlubu)
        {
            var klub = await this.unitOfWork.KlubRepository.GetKlubById(IdKlubu);
            return klub;
        }

        public async Task<IEnumerable<Klub>> DajKluby()
		{
			return await this.unitOfWork.KlubRepository.GetKluby();
		}

        public async Task DodajPilkarzaDoObecnych(Pilkarz pilkarz, Klub _klub)
        {
            var klub = await this.unitOfWork.KlubRepository.GetKlubById(_klub.IdKlub);
            bool czyPilkarzJestWObecnych = klub.ObecniPilkarze == null ? false : (klub.ObecniPilkarze.Contains(pilkarz));
            if (pilkarz == null || klub == null || czyPilkarzJestWObecnych == true)
            {
                return;
            }
            klub.ObecniPilkarze?.Add(pilkarz);
            await this.unitOfWork.Save();
        }

        public async Task DodajPilkarzyDoObecnych(List<Pilkarz> pilkarze, Klub klub)
        {
            if (klub == null || pilkarze == null)
            {
                return;
            }
            foreach (var pilkarz in pilkarze)
            {
                if (pilkarz != null)
                {
                    klub?.ObecniPilkarze?.Add(pilkarz);
                }
            }
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
            klub.ArchiwalniPilkarze?.Add(_pilkarz);
            await this.unitOfWork.Save();
        }

        public async Task<Pilkarz> DajObecnegoPilkarza(Guid IdKlubu, Guid IdPilkarza)
        {
            var klub = await this.unitOfWork.KlubRepository.GetKlubById(IdKlubu);
            var result = klub.ObecniPilkarze.First(p => p.IdPilkarz == IdPilkarza);
            return result;
        }

        public async Task<IEnumerable<Pilkarz>> DajObecnychPilkarzy(Klub _klub)
        {
            var klub = await this.unitOfWork.KlubRepository.GetKlubById(_klub.IdKlub);
            var result = klub.ObecniPilkarze?.ToList();
            return result;
        }

        public async Task<Pilkarz> DajArchiwalnegoPilkarza(Guid IdKlubu, Guid IdPilkarza)
        {
            var klub = await this.unitOfWork.KlubRepository.GetKlubById(IdKlubu);
            var pilkarz = klub.ArchiwalniPilkarze.First(p => p.IdPilkarz == IdPilkarza);
            return pilkarz;
        }

        public async Task<IEnumerable<Pilkarz>> DajArchiwalnychPilkarzy(Guid IdKlubu)
		{
			var klub = await this.unitOfWork.KlubRepository.GetKlubById(IdKlubu);
			var result = klub.ArchiwalniPilkarze.ToList();
			return result;
		}

		public async Task<string> DajStadionKlubu(Klub _klub)
        {
            var klub = await this.unitOfWork.KlubRepository.GetKlubById(_klub.IdKlub);
            return klub.Stadion;
        }

        public async Task<string> DajTrofeaKlubu(Klub _klub)
        {
            var klub = await this.unitOfWork.KlubRepository.GetKlubById(_klub.IdKlub);
            return klub.Trofea;
        }
    }
}