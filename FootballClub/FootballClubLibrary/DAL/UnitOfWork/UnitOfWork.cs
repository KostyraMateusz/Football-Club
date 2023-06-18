using FootballClubLibrary.Data;
using FootballClubLibrary.Interfaces;
using FootballClubLibrary.Repositories;

namespace FootballClubLibrary.UnitOfWork
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
		private bool disposed = false;
		private readonly ApplicationDbContext _context;

        private IKlubRepository klubRepository;
        private IPilkarzRepository pilkarzRepository;
        private IPracownikRepository pracownikRepository;
        private IStatystykaRepository statystykaRepository;
        private IZarzadRepository zarzadRepository;

        public UnitOfWork(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        public UnitOfWork(IKlubRepository klubRepository, IPilkarzRepository pilkarzRepository)
        {
            this.klubRepository = klubRepository;
            this.pilkarzRepository = pilkarzRepository;
        }

        public IKlubRepository KlubRepository
        {
            get
            {
                if(this.klubRepository == null)
                {
                    this.klubRepository = new KlubRepository(this._context);
                }
                return this.klubRepository;
            }
        }

        public IPilkarzRepository PilkarzRepository
        {
            get
            {
                if (this.pilkarzRepository == null)
                {
                    this.pilkarzRepository = new PilkarzRepository(this._context);
                }
                return this.pilkarzRepository;
            }
        }

        public IPracownikRepository PracownikRepository
        {
            get
            {
                if (this.pracownikRepository == null)
                {
                    this.pracownikRepository = new PracownikRepository(this._context);
                }
                return this.pracownikRepository;
            }
        }

        public IStatystykaRepository StatystykaRepository
        {
            get
            {
                if (this.statystykaRepository == null)
                {
                    this.statystykaRepository = new StatystykaRepository(this._context);
                }
                return this.statystykaRepository;
            }
        }

        public IZarzadRepository ZarzadRepository
        {
            get
            {
                if (this.zarzadRepository == null)
                {
                    this.zarzadRepository = new ZarzadRepository(this._context);
                }
                return this.zarzadRepository;
            }
        }

        public async Task Save()
        {
            await this._context.SaveChangesAsync();
        }

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this._context.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}