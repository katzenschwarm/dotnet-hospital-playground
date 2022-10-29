using HMS.Database;
using HMS.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HMS.WebApi.Controllers
{
    public class RoomCreateInput
    {
        public string RoomNumber { get; set; }
    }

    //public class RoomCreateOutput
    //{
    //    public int RoomId { get; set; }
    //}

    [ApiController]
    [Route("[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly HospitalDbContext hospitalDbContext;

        public RoomController(HospitalDbContext hospitalDbContext)
        {
            this.hospitalDbContext = hospitalDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoomCreateInput input)
        {
            var room = new Room { RoomNumber = input.RoomNumber, CreateAt = DateTime.UtcNow };

            await this.hospitalDbContext.Rooms.AddAsync(room);
            await this.hospitalDbContext.SaveChangesAsync();

            return Ok(new { RoomId = room.Id });
        }
    }
}
