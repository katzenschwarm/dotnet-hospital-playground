using HMS.DTO.Room;

namespace HMS.Services.Contracts
{
    public interface IRoomService
    {
        public Task<RoomDto> Create(RoomDto dto);
    }
}
