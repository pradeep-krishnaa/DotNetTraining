using EventEase.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationEase.Core.Interfaces
{
    public interface IRegistrationService
    {
        Task RegisterUserForEventAsync(RegistrationRequestDTO RegistrationRequestDTO);
        Task UpdateRegistrationAsync(int RegistrationId, RegistrationRequestDTO RegistrationRequestDTO);
        Task DeleteRegistrationAsync(int RegistrationId);
        Task<RegistrationResponseDTO> GetRegistrationByIdAsync(int RegistrationId);
        Task<List<RegistrationResponseDTO>> GetAllRegistrationsAsync();
        Task<List<RegistrationResponseDTO>> GetRegistrationsByEventIdAsync(int id);
    }
}
