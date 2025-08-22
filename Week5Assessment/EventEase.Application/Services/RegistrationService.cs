using AutoMapper;
using EventEase.Core.DTOs;
using EventEase.Core.Entities;
using EventEase.Core.Interfaces;
using RegistrationEase.Core.Interfaces;

namespace EventEase.Application.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepository _registrationRepository;
        private readonly IMapper _mapper;

        public RegistrationService(IRegistrationRepository registrationRepository, IMapper mapper)
        {
            _registrationRepository = registrationRepository ?? throw new ArgumentNullException(nameof(registrationRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task RegisterUserForEventAsync(RegistrationRequestDTO registrationsRequestDTO)
        {
            
            if (registrationsRequestDTO == null)
                throw new ArgumentNullException(nameof(registrationsRequestDTO));

            var registration = _mapper.Map<Registration>(registrationsRequestDTO);
            await _registrationRepository.AddAsync(registration);
        }

        public async Task UpdateRegistrationAsync(int registrationId, RegistrationRequestDTO registrationsRequestDTO)
        {
            if (registrationsRequestDTO == null)
                throw new ArgumentNullException(nameof(registrationsRequestDTO));

            var existingRegistration = await _registrationRepository.GetByIdAsync(registrationId);
            if (existingRegistration == null)
                throw new KeyNotFoundException($"Registration with ID {registrationId} not found");

            _mapper.Map(registrationsRequestDTO, existingRegistration);
            await _registrationRepository.UpdateAsync(existingRegistration);
        }

        public async Task DeleteRegistrationAsync(int registrationId)
        {
            var existingRegistration = await _registrationRepository.GetByIdAsync(registrationId);
            if (existingRegistration == null)
                throw new KeyNotFoundException($"Registration with ID {registrationId} not found");

            await _registrationRepository.DeleteAsync(registrationId);
        }

        public async Task<RegistrationResponseDTO> GetRegistrationByIdAsync(int registrationId)
        {
            var registration = await _registrationRepository.GetByIdAsync(registrationId);
            if (registration == null)
                throw new KeyNotFoundException($"Registration with ID {registrationId} not found");

            return _mapper.Map<RegistrationResponseDTO>(registration);
        }

        public async Task<List<RegistrationResponseDTO>> GetAllRegistrationsAsync()
        {
            var registrations = await _registrationRepository.GetAllAsync();
            return _mapper.Map<List<RegistrationResponseDTO>>(registrations);
        }

        public async Task<List<RegistrationResponseDTO>> GetRegistrationsByEventIdAsync(int id)
        {
            var registrations = await _registrationRepository.GetRegistrationsByEventIdAsync(id);
            return _mapper.Map<List<RegistrationResponseDTO>>(registrations);
        }
    }
}
