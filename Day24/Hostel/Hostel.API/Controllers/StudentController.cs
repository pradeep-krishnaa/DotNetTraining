using Hostel.Core.DTOs;
using Hostel.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Hostel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin , Staff")]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin , Staff")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);

        }

        [HttpPost]
        [Authorize(Roles = "Admin , Staff")]
        public async Task<IActionResult> CreateStudent([FromBody] StudentRequestDTO studentRequestDTO)
        {
            await _studentService.AddStudentAsync(studentRequestDTO);
            return StatusCode(200, new { Message = "Student Created Successfully" });

        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin , Staff")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] StudentRequestDTO studentRequestDTO)
        {
            await _studentService.UpdateStudentAsync(id, studentRequestDTO);
            return StatusCode(200, new { Message = "Student Updated Sucessfully" });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin , Staff")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _studentService.DeleteStudentAsync(id);
            return Ok(new { Message = "Student Deleted Successfully" });
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
