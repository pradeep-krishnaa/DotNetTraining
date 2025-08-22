using EventEase.Core.DTOs;
using EventEase.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventEase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        

        // ✅ Create User
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserRequestDTO userRequestDTO)
        {
            await _userService.CreateUserAsync(userRequestDTO);
            return Ok("User created successfully");
        }

        // ✅ Seed and Get All Users
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            
            

            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        // ✅ Get User by Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }
            return Ok(user);
        }

        // ✅ Update User
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserRequestDTO userRequestDTO)
        {
            try
            {
                await _userService.UpdateUserAsync(id, userRequestDTO);
                return Ok("User updated successfully");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // ✅ Delete User
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await _userService.DeleteUserAsync(id);
                return Ok("User deleted successfully");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


    }
}
