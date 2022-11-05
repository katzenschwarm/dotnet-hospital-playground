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

        public RoomController(IRoomService roomService)
        {
            this.roomService = roomService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoomCreateInput input)
        {
            var room = new RoomDto { RoomNumber = input.RoomNumber };
            var created = await roomService.Create(room);

            // this can be covered by dedicated response types
            return StatusCode(201, created);
        }
    }
}
