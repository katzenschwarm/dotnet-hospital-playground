namespace HMS.Repositories.Contracts
{
    public interface IRepository<TEntity, in TKey> : IDisposable
        where TEntity : class
        where TKey : struct
    {
        Task DeleteAsync(TKey id);

        void Delete(TEntity entity);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity?> GetByIdAsync(TKey id);

        void Insert(TEntity entity);

        Task SaveAsync();

        void Update(TEntity entity);
    }
}
