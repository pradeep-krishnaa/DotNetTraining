using EventEase.Core.DTOs;
using EventEase.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventEase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;
        private readonly IUserService _userService;
        private readonly IEventService _eventService;
        public RegistrationController(IRegistrationService registrationService , IUserService userService , IEventService eventService)
        {
            _registrationService = registrationService;
            _userService = userService;
            _eventService = eventService;

        }

        [HttpGet]
        public IActionResult GetAllRegistrations()
        {
            _registrationService.RegisterUserForEvent(new RegistrationRequestDTO{ UserId = 1 , EventId = 1 });
            var registrations = _registrationService.GetAllRegistrations();
            return Ok(registrations);
        }

        [HttpGet("{id}")]
        public IActionResult GetRegistrationById(int id)
        {
            var registration = _registrationService.GetRegistrationById(id);
            return Ok(registration);
        }
        [HttpGet("event/{eventId}")]
        public IActionResult GetRegistrationsByEvent(int eventId)
        {
            var registrations = _registrationService.GetRegistrationsByEventId(eventId);

            if (registrations == null || !registrations.Any())
                return NotFound($"No registrations found for event ID {eventId}");

            return Ok(registrations);
        }
    }
    

}
