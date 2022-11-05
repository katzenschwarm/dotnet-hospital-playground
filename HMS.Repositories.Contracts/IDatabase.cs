namespace HMS.Repositories.Contracts
{
    /// <summary>
    /// The interface for all repositories to handle the UnitOfWork pattern.
    /// </summary>
    public interface IDatabase: IDisposable
    {
        IRoomRepository RoomRepository { get; }

        public Task SaveAsync();
    }
}
