using EventEase.Core.DTOs;
using EventEase.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistrationEase.Core.Interfaces;

namespace EventEase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService ?? throw new ArgumentNullException(nameof(registrationService));
        }

        // ✅ Register User for Event
        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegistrationRequestDTO registrationRequestDTO)
        {
            await _registrationService.RegisterUserForEventAsync(registrationRequestDTO);
            return Ok("User registered successfully");
        }

        // ✅ Get All Registrations
        [HttpGet]
        public async Task<IActionResult> GetAllRegistrations()
        {
            var regs = await _registrationService.GetAllRegistrationsAsync();
            return Ok(regs);
        }

        // ✅ Get Registration by Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegistration(int id)
        {
            var reg = await _registrationService.GetRegistrationByIdAsync(id);
            if (reg == null)
                return NotFound($"Registration with ID {id} not found.");

            return Ok(reg);
        }

        // ✅ Get Registrations by Event Id
        [HttpGet("event/{eventId}")]
        public async Task<IActionResult> GetRegistrationsByEvent(int eventId)
        {
            var regs = await _registrationService.GetRegistrationsByEventIdAsync(eventId);
            return Ok(regs);
        }

        // ✅ Update Registration
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRegistration(int id, RegistrationRequestDTO registrationRequestDTO)
        {
            try
            {
                await _registrationService.UpdateRegistrationAsync(id, registrationRequestDTO);
                return Ok("Registration updated successfully");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // ✅ Delete Registration
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistration(int id)
        {
            try
            {
                await _registrationService.DeleteRegistrationAsync(id);
                return Ok("Registration deleted successfully");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


    }
}
