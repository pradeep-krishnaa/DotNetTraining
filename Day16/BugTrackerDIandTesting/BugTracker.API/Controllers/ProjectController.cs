using BugTracker.Core.DTOs;
using BugTracker.Core.Entities;
using BugTracker.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        [HttpGet]
        public IActionResult GetAllProjects()
        {   
            
            
            var dto = new ProjectRequestDTO
            {
                ProjectName = "AA",
                ProjectDescription = "DD"
            };

            _projectService.CreateProject(dto);

            var projects = _projectService.GetAllProjects();
            return Ok(projects);
        }
        [HttpGet("{id}")]
        public IActionResult GetProject(int id)
        {
            var project = _projectService.GetProjectById(id);
            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpPost]
        public IActionResult AddProject([FromBody] ProjectRequestDTO proj)
        {
            var projectEntity = _projectService.CreateProject(proj);

            return CreatedAtAction(nameof(GetProject), new { id = projectEntity.ProjectId }, proj);
            
        }
    }
}
