using Hostel.Core.DTOs;
using Hostel.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel.Core.Interfaces
{
    public interface IStudentService
    {
        Student CreateStudent(StudentRequestDTO studentRequestDTO);
        StudentResponseDTO GetStudentById(int id);
        List<StudentResponseDTO> GetAllStudents();
    }
}
