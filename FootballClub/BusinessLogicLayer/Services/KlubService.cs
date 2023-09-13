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
            await this.unitOfWork.KlubRepository.DodajPilkarzaDoObecnych(_klub, pilkarz);
            await this.unitOfWork.KlubRepository.Save();
            await this.unitOfWork.PilkarzRepository.Save();
        }

        public async Task DodajPilkarzyDoObecnych(List<Pilkarz> pilkarze, Klub klub)
        {
            if (pilkarze.Count() > 0 && klub != null)
            {
                await this.unitOfWork.KlubRepository.DodajPilkarzyDoObecnych(klub, pilkarze);
                await this.unitOfWork.KlubRepository.Save();
            }
            else
            {
                return;
            }
        }

        public async Task UsunPilkarzaZObecnych(Guid PilkarzId, Guid IdKlubu)
        {
            var klub = await this.unitOfWork.KlubRepository.GetKlubById(IdKlubu);
            var _pilkarz = await this.unitOfWork.PilkarzRepository.GetPilkarzById(PilkarzId);
            await this.unitOfWork.KlubRepository.UsunPilkarzaZObecnych(klub, _pilkarz);
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

        public async Task DodajPilkarzaDoArchiwalnych(Guid IdPilkarza, Guid IdKlubu)
        {
            var pilkarz = await this.unitOfWork.PilkarzRepository.GetPilkarzById(IdPilkarza);
            var klub = await this.unitOfWork.KlubRepository.GetKlubById(IdKlubu);
            await this.unitOfWork.KlubRepository.DodajPilkarzaDoArchiwalnych(klub, pilkarz);
        }
    }
}