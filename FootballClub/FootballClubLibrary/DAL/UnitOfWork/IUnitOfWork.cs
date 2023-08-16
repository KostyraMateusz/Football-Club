using FootballClubLibrary.Interfaces;

namespace FootballClubLibrary.UnitOfWork
{
    public interface IUnitOfWork
    { 
        IKlubRepository KlubRepository{ get;}
        IPilkarzRepository PilkarzRepository { get; }
        IPracownikRepository PracownikRepository { get; }
        IStatystykaRepository StatystykaRepository { get; }
        IZarzadRepository ZarzadRepository { get; }
        Task Save();
    }
}