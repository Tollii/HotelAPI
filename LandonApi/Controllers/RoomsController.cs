using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using LandonApi.Models;
using LandonApi.Services;

namespace LandonApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {

        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet(Name = nameof(GetRooms))]
        public IActionResult GetRooms()
        {
            throw new NotImplementedException();
        }
   
        // GET/rooms/{roomId}
        [HttpGet("{roomId}", Name = nameof(GetRoomById))]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Room>> GetRoomById(Guid roomId)
        {
            Room room = await _roomService.GetRoomAsync(roomId);
            if (room == null) return NotFound();
            return room;
        }
    }
}
