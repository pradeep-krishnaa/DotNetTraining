using AutoMapper;
using Hostel.Core.DTOs;
using Hostel.Core.Entities;
using Hostel.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentrepo;
        private readonly IRoomRepository _roomRepo;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentrepo, IMapper mapper, IRoomRepository roomrepo)
        {
            _studentrepo = studentrepo;
            _mapper = mapper;
            _roomRepo = roomrepo;
        }

        public async Task<List<StudentResponseDTO>> GetAllStudentsAsync()
        {
            var students = await _studentrepo.GetAllAsync();
            return _mapper.Map<List<StudentResponseDTO>>(students);
        }
        public async Task<StudentResponseDTO> GetStudentByIdAsync(int id)
        {
            var student = await _studentrepo.GetByIdAsync(id);
            return _mapper.Map<StudentResponseDTO>(student);
        } 

        public async Task AddStudentAsync(StudentRequestDTO studentRequestDTO)
        {
            var availableRoom = await _roomRepo.GetFirstRoomWithSpaceAsync();
            if (availableRoom == null)
                throw new Exception("No available rooms.");

            // Create student entity
            var student = new Student
            {
                StudentName = studentRequestDTO.StudentName,
                StudentDepartment = studentRequestDTO.StudentDepartment,
                RoomId = availableRoom.RoomId
            };

            await _studentrepo.AddAsync(student);
        }

        public async Task UpdateStudentAsync(int id , StudentRequestDTO studentRequestDTO)
        {
            var student = _mapper.Map<Student>(studentRequestDTO);
            student.StudentId = id;
            await _studentrepo.UpdateAsync(student);


        }
        public async Task DeleteStudentAsync(int id)
        {
            await _studentrepo.DeleteAsync(id);
        }

    }
}
