using AutoMapper;
using HMS.DTO.Room;
using HMS.Entities;
using HMS.Repositories.Contracts;
using HMS.Services.Contracts;

namespace HMS.Services
{
    public class RoomService : IRoomService
    {
        private readonly IDatabase database;
        private readonly IMapper mapper;

        public RoomService(IDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }

        public async Task<RoomDto> Create(RoomDto dto)
        {
            var entity = mapper.Map<Room>(dto);
            entity.CreateAt = DateTime.UtcNow;

            this.database.RoomRepository.Insert(entity);

            await database.SaveAsync();

            return mapper.Map<RoomDto>(entity);
        }
    }
}
