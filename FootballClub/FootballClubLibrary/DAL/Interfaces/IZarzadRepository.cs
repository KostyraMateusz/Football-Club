using FootballClubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubLibrary.Interfaces
{
    public interface IZarzadRepository
    {
        IEnumerable<Zarzad> GetZarzady();
        Zarzad GetZarzadById(Guid id);
        void CreateZarzad(Zarzad zarzad);
        void DeleteZarzad(Guid id);
        void UpdateZarzad(Zarzad zarzad);
        void Save();
    }
}
