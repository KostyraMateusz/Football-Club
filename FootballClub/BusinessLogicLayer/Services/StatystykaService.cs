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
    public class StatystykaService : IStatystykaService
    {
        private readonly IUnitOfWork unitOfWork;

        public StatystykaService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Statystyka> DajStatystykeMeczu(string mecz)
        {
            var statystyki = await this.unitOfWork.StatystykaRepository.GetStatystyki();
            var result = statystyki.First(s => s.Mecz == mecz);
            return result;
        }
    }
}
