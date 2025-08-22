
using AutoMapper;
using EventEase.Core.DTOs;
using EventEase.Core.Entities;
using EventEase.Core.Interfaces;

namespace EventEase.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventService(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task CreateEventAsync(EventRequestDTO eventRequestDTO)
        {
            if (eventRequestDTO == null)
                throw new ArgumentNullException(nameof(eventRequestDTO));

            var eventEntity = _mapper.Map<Event>(eventRequestDTO);
            await _eventRepository.AddAsync(eventEntity);
        }

        public async Task UpdateEventAsync(int eventId, EventRequestDTO eventRequestDTO)
        {
            if (eventRequestDTO == null)
                throw new ArgumentNullException(nameof(eventRequestDTO));

            var existingEvent = await _eventRepository.GetByIdAsync(eventId);
            if (existingEvent == null)
                throw new KeyNotFoundException($"Event with ID {eventId} not found");

            _mapper.Map(eventRequestDTO, existingEvent);
            await _eventRepository.UpdateAsync(existingEvent);
        }

        public async Task DeleteEventAsync(int eventId)
        {
            var existingEvent = await _eventRepository.GetByIdAsync(eventId);
            if (existingEvent == null)
                throw new KeyNotFoundException($"Event with ID {eventId} not found");

            await _eventRepository.DeleteAsync(eventId);
        }

        public async Task<EventResponseDTO> GetEventByIdAsync(int eventId)
        {
            var existingEvent = await _eventRepository.GetByIdAsync(eventId);
            if (existingEvent == null)
                throw new KeyNotFoundException($"Event with ID {eventId} not found");

            return _mapper.Map<EventResponseDTO>(existingEvent);
        }

        public async Task<List<EventResponseDTO>> GetAllEventsAsync()
        {
            var events = await _eventRepository.GetAllAsync();
            return _mapper.Map<List<EventResponseDTO>>(events);
        }
    }
}

