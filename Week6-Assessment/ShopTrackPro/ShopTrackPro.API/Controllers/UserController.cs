using Microsoft.AspNetCore.Mvc;
using ShopTrackPro.Core.DTOs;
using ShopTrackPro.Application.Services;
using ShopTrackPro.Core.DTOs;
using ShopTrackPro.Core.Interfaces;

namespace ShopTrackPro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserResponseDTO>>> GetAll()
        {
            var users = await _service.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponseDTO>> GetById(int id)
        {
            var user = await _service.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserRequestDTO dto)
        {
            await _service.AddUserAsync(dto);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UserRequestDTO dto)
        {
            var existing = await _service.GetUserByIdAsync(id);
            if (existing == null) return NotFound();

            await _service.UpdateUserAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existing = await _service.GetUserByIdAsync(id);
            if (existing == null) return NotFound();

            await _service.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
