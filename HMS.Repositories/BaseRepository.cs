using HMS.Database;
using HMS.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace HMS.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class
        where TKey : struct
    {
        protected HospitalDbContext Context { get; }

        protected DbSet<TEntity> EntityDbSet { get; }

        protected BaseRepository([NotNull] HospitalDbContext context)
        {
            Context = context;
            EntityDbSet = context.Set<TEntity>();
        }

        public virtual async Task DeleteAsync(TKey id)
        {
            var entity = await EntityDbSet.FindAsync(id);

            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        public virtual void Delete(TEntity entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                EntityDbSet.Attach(entity);
            }
            EntityDbSet.Remove(entity);
        }

        public async virtual Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await EntityDbSet.ToListAsync();
        }

        public async virtual Task<TEntity?> GetByIdAsync(TKey id)
        {
            return await EntityDbSet.FindAsync(id);
        }

        public virtual void Insert(TEntity entity)
        {
            EntityDbSet.Add(entity);
        }

        public async virtual Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }

        public virtual void Update(TEntity entity)
        {
            EntityDbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        #region GC

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
