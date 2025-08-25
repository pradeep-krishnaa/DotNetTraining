using BugTracker.Core.DTOs;
using BugTracker.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class BugController : ControllerBase
    {
        private readonly IBugService _service;

        public BugController(IBugService service)
        {
            _service = service;
        }

        // ✅ GET: api/bug
        [HttpGet]
        [Authorize(Roles = "Admin , Developer , User")]

        public IActionResult GetAllBugs()
        {
            var bugs = _service.GetAllBugs();
            return Ok(bugs);
        }

        // ✅ GET: api/bug/{id}
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin , Developer , User")]
        public IActionResult GetBugById(int id)
        {
            var bug = _service.GetBugById(id);
            if (bug == null)
                return NotFound();

            return Ok(bug);
        }

        // ✅ POST: api/bug
        [HttpPost]
        [Authorize(Roles = "Admin , Developer , User")]
        public IActionResult CreateBug([FromBody] BugRequestDTO bugDto)
        {
            if (bugDto == null)
                return BadRequest("Bug data is required");

            _service.CreateBug(bugDto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // ✅ PUT: api/bug/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateBug(int id, [FromBody] BugRequestDTO bugDto)
        {
            if (bugDto == null)
                return BadRequest("Bug data is required");

            var existing = _service.GetBugById(id);
            if (existing == null)
                return NotFound();

            _service.UpdateBug(id, bugDto);
            return NoContent(); // ✅ 204 is standard for successful PUT
        }

        // ✅ DELETE: api/bug/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteBug(int id)
        {
            var existing = _service.GetBugById(id);
            if (existing == null)
                return NotFound();

            _service.DeleteBug(id);
            return NoContent();
        }
    }
}
