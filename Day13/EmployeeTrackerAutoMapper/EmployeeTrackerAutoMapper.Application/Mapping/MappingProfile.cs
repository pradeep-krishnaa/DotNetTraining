using AutoMapper;
using EmployeeTrackerAutoMapper.Core.DTOs;
using EmployeeTrackerAutoMapper.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackerAutoMapper.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() { 
            CreateMap<Employee , EmployeeRequestDTO>().ReverseMap();


            CreateMap<Employee, EmployeeResponseDTO>();
            CreateMap<Department , DepartmentRequestDTO>().ReverseMap();
            CreateMap<Department, DepartmentResponseDTO>();
        }
    }
}
