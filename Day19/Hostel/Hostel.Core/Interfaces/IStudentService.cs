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
        Task<List<StudentResponseDTO>> GetAllStudentsAsync();
        Task<StudentResponseDTO?> GetStudentByIdAsync(int id);
        Task AddStudentAsync(StudentRequestDTO student);
        Task UpdateStudentAsync(int id , StudentRequestDTO student);
        Task DeleteStudentAsync(int id);
    }
}
