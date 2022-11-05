using HMS.Database;
using HMS.Repositories.Contracts;

namespace HMS.Repositories
{
    public class Database : IDatabase
    {
        private HospitalDbContext Context { get; }

        public IRoomRepository RoomRepository { get; }

        public Database(
            HospitalDbContext context,
            IRoomRepository roomRepository)
        {
            this.Context = context;
            this.RoomRepository = roomRepository;
        }

        public async Task SaveAsync()
        {
            await this.Context.SaveChangesAsync();
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
