using BugTracker.Core.DTOs;
using BugTracker.Core.Interfaces;
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
        [HttpGet]
        public IActionResult GetAllBugs()
        {
            var bugs = _service.GetAllBugs();
            return Ok(bugs);
        }
        [HttpGet("{id}")]
        public IActionResult GetBugById(int id)
        {
            var bug = _service.GetBugById(id);
            if (bug == null)
            {
                return NotFound();
            }
            return Ok(bug);
        }
        
    }
}
