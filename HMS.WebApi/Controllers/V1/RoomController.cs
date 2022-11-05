using AutoMapper;
using HMS.DTO.Room;
using HMS.Services.Contracts;
using HMS.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HMS.WebApi.Controllers.V1
{
    // we want to introduce a versioning here
    [ApiController]
    [Route("[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService roomService;
        private readonly IMapper mapper;

        public RoomController(IRoomService roomService, IMapper mapper)
        {
            this.roomService = roomService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoomCreateInput input)
        {
            var room = mapper.Map<RoomDto>(input);
            
            var created = await roomService.Create(room);

            // this can be covered by dedicated response types
            return StatusCode(201, created);
        }
    }
}
