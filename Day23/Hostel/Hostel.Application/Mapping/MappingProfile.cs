using AutoMapper;
using Hostel.Core.DTOs;
using Hostel.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentRequestDTO>().ReverseMap();
            CreateMap<Student, StudentResponseDTO>();
            CreateMap<Room , RoomRequestDTO>().ReverseMap();
            CreateMap<Room, RoomResponseDTO>();

        }
    }
}
