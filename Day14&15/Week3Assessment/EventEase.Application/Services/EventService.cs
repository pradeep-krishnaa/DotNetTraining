using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventEase.Core.DTOs;
using EventEase.Core.Entities;
using EventEase.Core.Interfaces;
using AutoMapper;

namespace EventEase.Application.Services
{
    public class EventService  : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        //public int _eventId = 1;
        public EventService(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public void CreateEvent(EventRequestDTO eventRequestDTO)
        {
            if (eventRequestDTO == null) throw new ArgumentNullException(nameof(eventRequestDTO));
            var eventEntity = _mapper.Map<Event>(eventRequestDTO);
            //eventEntity.Id = _eventId++; 
            _eventRepository.Add(eventEntity);
        }
        public void UpdateEvent(int eventId, EventRequestDTO eventRequestDTO)
        {
            if (eventRequestDTO == null) throw new ArgumentNullException(nameof(eventRequestDTO));
            var existingEvent = _eventRepository.GetById(eventId);
            if (existingEvent == null) throw new KeyNotFoundException($"Event with ID {eventId} not found");
            var updatedEvent = _mapper.Map(eventRequestDTO, existingEvent);
            _eventRepository.Update(updatedEvent);
        }
        public void DeleteEvent(int eventId)
        {
            var existingEvent = _eventRepository.GetById(eventId);
            if (existingEvent == null) throw new KeyNotFoundException($"Event with ID {eventId} not found");
            _eventRepository.Delete(existingEvent);
        }
        public EventResponseDTO GetEventById(int eventId)
        {
            var existingEvent = _eventRepository.GetById(eventId);
            if (existingEvent == null) throw new KeyNotFoundException($"Event with ID {eventId} not found");
            return _mapper.Map<EventResponseDTO>(existingEvent);
        }
        public List<EventResponseDTO> GetAllEvents()
        {
            var events = _eventRepository.GetAll();
            return _mapper.Map<List<EventResponseDTO>>(events);
        }
    }
}
