using Hostel.Core.DTOs;
using Hostel.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hostel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<StaffResponseDTO>> GetAllStaff()
        {
            var staffList = _staffService.GetAllStaffs();
            return Ok(staffList);
        }

        [HttpGet("{id}")]
        public ActionResult<StaffResponseDTO> GetStaffById(int id)
        {
            var staff = _staffService.GetStaffById(id);
            if (staff == null)
                return NotFound();
            return Ok(staff);
        }

        [HttpPost]
        public ActionResult<StaffResponseDTO> CreateStaff(StaffRequestDTO dto)
        {
            var createdStaff = _staffService.CreateStaff(dto);
            return CreatedAtAction(nameof(GetStaffById), new { id = createdStaff.StaffId }, createdStaff);
        }
    }
}
