using FootballClubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubLibrary.Intefaces
{
    public interface IKlubRepository
    {
        IEnumerable<Klub>GetKluby();
        Klub GetKlubById(Guid id);
        void CreateKlub(Klub klub);
        void DeleteKlub(Guid id);
        void UpdateKlub(Klub klub);
        void Save();
    }
}
