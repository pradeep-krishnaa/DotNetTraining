using EventEase.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventEase.Core.Interfaces
{
    public interface IRegistrationService
    {
        void RegisterUserForEvent(RegistrationRequestDTO registrationsRequestDTO);
        void UpdateRegistration(int registrationId, RegistrationRequestDTO registrationsRequestDTO);
        void DeleteRegistration(int registrationId);
        RegistrationResponseDTO GetRegistrationById(int registrationId);
        List<RegistrationResponseDTO> GetAllRegistrations();
        List<RegistrationResponseDTO> GetRegistrationsByEventId(int eventId);
    }
}
