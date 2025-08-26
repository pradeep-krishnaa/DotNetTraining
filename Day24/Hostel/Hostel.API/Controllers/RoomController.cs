using Hostel.Core.DTOs;
using Hostel.Core.Entities;
using Hostel.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        [Authorize(Roles = "Admin , Staff")]
        public async Task<IActionResult> GetAllRooms()
        {
            var rooms = await _roomService.GetAllRoomsAsync();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin , Staff")]
        public async Task<IActionResult> GetRoomById(int id)
        {
            var room = await _roomService.GetRoomByIdAsync(id);
            if (room == null)
                return NotFound();

            return Ok(room);
        }

        [HttpPost]
        [Authorize(Policy = "RequireAdmin")]
        public async Task<IActionResult> AddRoom([FromBody] RoomRequestDTO roomDto)
        {
            await _roomService.AddRoomAsync(roomDto);
            return StatusCode(200, new { Message = "ROom Created Successfully" });
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "RequireAdmin")]
        public async Task<IActionResult> UpdateRoom(int id, [FromBody] RoomRequestDTO roomDto)
        {
            await _roomService.UpdateRoomAsync(id, roomDto);
            return StatusCode(200, new { Message = "Room Updated Sucessfully" });
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "RequireAdmin")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            await _roomService.DeleteRoomAsync(id);
            return StatusCode(200, new { Message = "Room Deleted Sucessfully" });
        }

        [HttpGet("me")]
        [Authorize]
        public IActionResult GetMyClaims()
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "Unknown";
            var role = User.FindFirst(ClaimTypes.Role)?.Value ?? "No Role";

            // You can also grab all claims if you want
            var claims = User.Claims.Select(c => new { c.Type, c.Value });

            return Ok(new
            {
                Username = username,
                Role = role,
                Claims = claims
            });
        }
    }
}

