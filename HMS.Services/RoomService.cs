using HMS.DTO.Room;
using HMS.Entities;
using HMS.Repositories.Contracts;
using HMS.Services.Contracts;

namespace HMS.Services
{
    public class RoomService : IRoomService
    {
        private readonly IDatabase database;

        public RoomService(IDatabase database)
        {
            this.database = database;
        }

        public async Task<RoomDto> Create(RoomDto dto)
        {
            // map dto to entity with auto mapper
            //this._database.RoomRepository.Insert(dto);

            var entity = new Room();
            entity.CreateAt = DateTime.UtcNow;

            this.database.RoomRepository.Insert(entity);
            await database.SaveAsync();

            // map back to dto
            return new RoomDto();
        }
    }
}
