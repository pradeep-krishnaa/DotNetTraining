using AutoMapper;
using EmployeeTrackerAutoMapper.Core.DTOs;
using EmployeeTrackerAutoMapper.Core.Interfaces;
using EmployeeTrackerAutoMapper.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTrackerAutoMapper.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public void AddEmployee(EmployeeRequestDTO employeeRequestDTO)
        {
            var Employee = _mapper.Map<Employee>(employeeRequestDTO);
            _employeeRepository.Add(Employee);

        }

        public EmployeeRequestDTO? GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee == null)
            {
                return null;
            }
            return _mapper.Map<EmployeeRequestDTO>(employee);
        }

        public List<EmployeeResponseDTO> GetAllEmployees()
        {
            var employees = _employeeRepository.GetAll();
            return _mapper.Map<List<EmployeeResponseDTO>>(employees);
        }
        public void UpdateEmployee(EmployeeRequestDTO employeeRequestDTO)
        {
            
            var employee = _mapper.Map<Employee>(employeeRequestDTO);
            _employeeRepository.Update(employee);
        }
        public void DeleteEmployee(int id)
        {
            _employeeRepository.Delete(id);


        }
    }
}
