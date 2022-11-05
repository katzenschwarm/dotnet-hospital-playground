using HMS.Database;
using HMS.Entities;
using HMS.Repositories.Contracts;
using System.Diagnostics.CodeAnalysis;

namespace HMS.Repositories
{
    public class RoomRepository : BaseRepository<Room, int>, IRoomRepository
    {
        public RoomRepository([NotNull] HospitalDbContext context) : base(context)
        {
        }
    }
}
