using FootballClubLibrary.Data;
using Microsoft.EntityFrameworkCore;

namespace FootballClubLibrary.Repositories.Generic
{
    public class GenericRepository<TEntity> where TEntity: class
    {
		internal DbSet<TEntity> dbSet;
		internal ApplicationDbContext dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = this.dbContext.Set<TEntity>();
        }

		public virtual void Add(TEntity entity)
		{
			dbSet.Add(entity);
		}

		public virtual void Delete(object id)
		{
			TEntity entity = this.dbSet.Find(id);
			this.dbSet.Remove(entity);
		}

		public virtual void Update(TEntity entity)
		{
			dbSet.Attach(entity);
			this.dbContext.Entry(entity).State = EntityState.Modified;
		}

        public virtual TEntity GetById(object id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = this.dbSet;
            return query.ToList();
        }
    }
}