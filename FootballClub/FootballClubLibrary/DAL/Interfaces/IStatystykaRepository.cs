using FootballClubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubLibrary.Interfaces
{
    public interface IStatystykaRepository
    {
        IEnumerable<Statystyka> GetStatystyki();
        Statystyka GetStatystykaById(Guid id);
        void CreateStatystyka(Statystyka statystyka);
        void DeleteStatystyka(Guid id);
        void UpdateStatystyka(Statystyka statystyka);
        void Save();
    }
}
