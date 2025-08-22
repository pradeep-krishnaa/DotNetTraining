using EventEase.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventEase.Core.Interfaces
{
    public interface IEventService
    {
        Task CreateEventAsync(EventRequestDTO eventRequestDTO);
        Task UpdateEventAsync(int eventId, EventRequestDTO eventRequestDTO);
        Task DeleteEventAsync(int eventId);
        Task<EventResponseDTO> GetEventByIdAsync(int eventId);
        Task<List<EventResponseDTO>> GetAllEventsAsync();
    }
}
