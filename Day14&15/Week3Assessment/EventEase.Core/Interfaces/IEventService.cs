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
        void CreateEvent(EventRequestDTO eventRequestDTO);
        void UpdateEvent(int eventId, EventRequestDTO eventRequestDTO);
        void DeleteEvent(int eventId);
        EventResponseDTO GetEventById(int eventId);
        List<EventResponseDTO> GetAllEvents();
    }
}
