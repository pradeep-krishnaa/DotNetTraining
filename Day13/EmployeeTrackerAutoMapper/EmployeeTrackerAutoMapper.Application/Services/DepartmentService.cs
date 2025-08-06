using AutoMapper;
using EmployeeTrackerAutoMapper.Core.DTOs;
using EmployeeTrackerAutoMapper.Core.Entities;
using EmployeeTrackerAutoMapper.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackerAutoMapper.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }
        public void AddDepartment(DepartmentRequestDTO departmentRequestDTO)
        {
            var department = _mapper.Map<Department>(departmentRequestDTO);
            _departmentRepository.Add(department);
        }
        public DepartmentRequestDTO? GetDepartmentById(int id)
        {
            var department = _departmentRepository.GetById(id);
            if (department == null)
            {
                return null;
            }
            return _mapper.Map<DepartmentRequestDTO>(department);
        }
        public List<DepartmentResponseDTO> GetAllDepartments()
        {
            var departments = _departmentRepository.GetAll();
            return _mapper.Map<List<DepartmentResponseDTO>>(departments);
        }
        public void UpdateDepartment(DepartmentRequestDTO departmentRequestDTO)
        {
            var department = _mapper.Map<Department>(departmentRequestDTO);
            _departmentRepository.Update(department);
        }
        public void DeleteDepartment(int id)
        {
            _departmentRepository.Delete(id);

        }
    }
}
