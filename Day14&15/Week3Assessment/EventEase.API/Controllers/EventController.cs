using EventEase.Core.DTOs;
using EventEase.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventEase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        public EventController(IEventService eventService)
        {

            _eventService = eventService;
        }

        [HttpGet]
        public IActionResult GetAllEvents()
        {
            _eventService.CreateEvent(new EventRequestDTO { Title = "Event A", Description = "Event A Descrioption", Location = "Sample Location" });
            _eventService.CreateEvent(new EventRequestDTO { Title = "Event B", Description = "Event B Descrioption", Location = "Sample Location" });
            var events = _eventService.GetAllEvents();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public IActionResult GetEventById(int id)
        {
            var eventResponse = _eventService.GetEventById(id);
            if (eventResponse == null)
            {
                return NotFound($"Event with ID {id} not found.");
            }
            return Ok(eventResponse);
        }

    }
}
