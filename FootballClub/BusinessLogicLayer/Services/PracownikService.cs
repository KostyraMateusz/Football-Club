using BusinessLogicLayer.Interfaces;
using FootballClubLibrary.Unit_of_Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class PracownikService : IPracownikService
    {
        private readonly IUnitOfWork unitOfWork;

        public PracownikService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task ZmienFunkcjePracownika(Guid IdPracownik, string funkcja)
        {
            throw new NotImplementedException();
        }

        public Task ZmienWiekPracownika(Guid IdPracownika, int wiek)
        {
            throw new NotImplementedException();
        }

        public Task ZmienWynagrodzenie(Guid IdPracownik, decimal wynagrodzenie)
        {
            throw new NotImplementedException();
        }
    }
}
