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
        [HttpGet]
        public IActionResult GetAllUsers()
        {

            //create 2 users
            _userService.CreateUser(new UserRequestDTO { Name = "John Doe", Email = "xx@gmail.com" });
            _userService.CreateUser(new UserRequestDTO { Name = "Jane Smith", Email = "yy@gmail.com" });
            var users = _userService.GetAllUsers();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }
            return Ok(user);
        }

    }
}
