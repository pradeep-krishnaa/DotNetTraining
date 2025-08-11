using Hostel.Core.DTOs;
using Hostel.Core.Entities;
using Hostel.Core.Interfaces;
using Hostel.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IStaffRepository _staffRepository;

        public StudentService(IStudentRepository studentRepository, IRoomRepository roomRepository , IStaffRepository staffRepository)
        {
            _studentRepository = studentRepository;
            _roomRepository = roomRepository;
            _staffRepository = staffRepository;
        }

        public List<StudentResponseDTO> GetAllStudents()
        {
            var students = _studentRepository.GetAll();

            return students.Select(s =>
            {
                var room = _roomRepository.GetById(s.RoomId);
                var staff = room != null ? _staffRepository.GetById(room.StaffId) : null;

                return new StudentResponseDTO
                {
                    StudentId = s.StudentId,
                    StudentName = s.Name,
                    Age = s.Age,
                    RoomNumber = room?.RoomId ?? 0,
                    StaffName = staff?.Name ?? "N/A"
                };
            }).ToList();
        }

        public StudentResponseDTO GetStudentById(int id)
        {
            var s = _studentRepository.GetById(id);
            if (s == null) return null;

            var room = _roomRepository.GetById(s.RoomId);
            var staff = room != null ? _staffRepository.GetById(room.StaffId) : null;

            return new StudentResponseDTO
            {
                StudentId = s.StudentId,
                StudentName = s.Name,
                Age = s.Age,
                RoomNumber = room?.RoomId ?? 0,
                StaffName = staff?.Name ?? "N/A"
            };
        }

        public Student CreateStudent(StudentRequestDTO studentRequestDTO)
        {
            //map DTO to domain 
            var student = new Student
            {
                Name = studentRequestDTO.Name,
                Age = studentRequestDTO.Age,
            };
            // Find a room with available capacity
            var room = _roomRepository
                .GetAll()
                .FirstOrDefault(r => _studentRepository.GetAll().Count(s => s.RoomId == r.RoomId) < r.Capacity);

            if (room == null)
                throw new Exception("No available room with free capacity");

            // Assign room automatically
            student.RoomId = room.RoomId;

            _studentRepository.Add(student);
            return student;
        }
    }

}
