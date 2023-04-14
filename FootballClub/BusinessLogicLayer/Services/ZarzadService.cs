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
    public class ZarzadService : IZarzadService
    {
        private readonly IUnitOfWork unitOfWork;

        public ZarzadService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<decimal> DajBudzetZarzadu(Zarzad zarzad)
        {
            throw new NotImplementedException();
        }

        public Task DodajCelZarzadu(string target, Zarzad zarzad)
        {
            throw new NotImplementedException();
        }

        public Task DodajCzlonkaZarzadu(Pracownik pracownik, Zarzad zarzad)
        {
            throw new NotImplementedException();
        }

        public Task ZmienBudzetZarzadu(Zarzad zarzad, decimal budget)
        {
            throw new NotImplementedException();
        }
    }
}
