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
            _eventService = eventService ?? throw new ArgumentNullException(nameof(eventService));
        }

        // ✅ Create Event
        [HttpPost]
        public async Task<IActionResult> CreateEvent(EventRequestDTO eventRequestDTO)
        {
            await _eventService.CreateEventAsync(eventRequestDTO);
            return Ok("Event created successfully");
        }

        // ✅ Get All Events
        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            var events = await _eventService.GetAllEventsAsync();
            return Ok(events);
        }

        // ✅ Get Event by Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvent(int id)
        {
            var ev = await _eventService.GetEventByIdAsync(id);
            if (ev == null)
                return NotFound($"Event with ID {id} not found.");

            return Ok(ev);
        }

        // ✅ Update Event
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int id, EventRequestDTO eventRequestDTO)
        {
            try
            {
                await _eventService.UpdateEventAsync(id, eventRequestDTO);
                return Ok("Event updated successfully");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // ✅ Delete Event
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            try
            {
                await _eventService.DeleteEventAsync(id);
                return Ok("Event deleted successfully");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
