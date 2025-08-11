using Hostel.Core.DTOs;
using Hostel.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hostel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RoomResponseDTO>> GetAllRooms()
        {
            var rooms = _roomService.GetAllRooms();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public ActionResult<RoomResponseDTO> GetRoomById(int id)
        {
            var room = _roomService.GetRoomById(id);
            if (room == null)
                return NotFound();
            return Ok(room);
        }

        [HttpPost]
        public ActionResult<RoomResponseDTO> CreateRoom(RoomRequestDTO dto)
        {
            var createdRoom = _roomService.CreateRoom(dto);
            return CreatedAtAction(nameof(GetRoomById), new { id = createdRoom.RoomId }, createdRoom);
        }
    }
}
