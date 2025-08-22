using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EventEase.Core.DTOs;
using EventEase.Core.Entities;

namespace EventEase.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User , UserRequestDTO>().ReverseMap();
            CreateMap<User, UserResponseDTO>();
            CreateMap<Event , EventRequestDTO>().ReverseMap();
            CreateMap<Registration, RegistrationRequestDTO>().ReverseMap();
            CreateMap<Registration, RegistrationResponseDTO>();
            CreateMap<Event, EventResponseDTO>();
        }

    }
}
