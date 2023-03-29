using FootballClubLibrary.Intefaces;
using FootballClubLibrary.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubLibrary.Unit_of_Work
{
    public interface IUnitOfWork
    { 
        IKlubRepository KlubRepository{ get;}
        IPilkarzRepository PilkarzRepository { get; }
        IPracownikRepository PracownikRepository { get; }
        IStatystykaRepository StatystykaRepository { get; }
        IZarzadRepository ZarzadRepository { get; }

    }
}
