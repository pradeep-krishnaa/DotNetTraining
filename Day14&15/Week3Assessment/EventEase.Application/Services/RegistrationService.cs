using AutoMapper;
using EventEase.Core.DTOs;
using EventEase.Core.Entities;
using EventEase.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventEase.Application.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepository _registrationRepository;
        private readonly IMapper _mapper;
        //public int _registrationId = 1;
        public RegistrationService(IRegistrationRepository registrationRepository, IMapper mapper)
        {
            _registrationRepository = registrationRepository ?? throw new ArgumentNullException(nameof(registrationRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public void RegisterUserForEvent(RegistrationRequestDTO registrationsRequestDTO)
        {
            if (registrationsRequestDTO == null) throw new ArgumentNullException(nameof(registrationsRequestDTO));
            var registration = _mapper.Map<Registration>(registrationsRequestDTO);
            //registration.Id = _registrationId++; 
            _registrationRepository.Add(registration);
        }
        public void UpdateRegistration(int registrationId, RegistrationRequestDTO registrationsRequestDTO)
        {
            if (registrationsRequestDTO == null) throw new ArgumentNullException(nameof(registrationsRequestDTO));
            var existingRegistration = _registrationRepository.GetById(registrationId);
            if (existingRegistration == null) throw new KeyNotFoundException($"Registration with ID {registrationId} not found");
            var updatedRegistration = _mapper.Map<Registration>(registrationsRequestDTO);
            updatedRegistration.Id = registrationId; // Ensure the ID is set correctly
            _registrationRepository.Update(updatedRegistration);
        }
        public void DeleteRegistration(int registrationId)
        {
            var existingRegistration = _registrationRepository.GetById(registrationId);
            if (existingRegistration == null) throw new KeyNotFoundException($"Registration with ID {registrationId} not found");
            _registrationRepository.Delete(existingRegistration);
        }
        public RegistrationResponseDTO GetRegistrationById(int registrationId)
        {
            var registration = _registrationRepository.GetById(registrationId);
            if (registration == null) throw new KeyNotFoundException($"Registration with ID {registrationId} not found");
            return _mapper.Map<RegistrationResponseDTO>(registration);
        }
        public List<RegistrationResponseDTO> GetAllRegistrations()
        {
            var registrations = _registrationRepository.GetAll();
            return _mapper.Map<List<RegistrationResponseDTO>>(registrations);
        }
        public List<RegistrationResponseDTO> GetRegistrationsByEventId(int id)
        {
            var registrations = _registrationRepository.GetRegistrationsByEventId(id);
            return _mapper.Map<List<RegistrationResponseDTO>>(registrations);
        }


        
    }
}
