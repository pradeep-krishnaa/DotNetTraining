using Hostel.Core.Entities;
using Hostel.Core.Interfaces;
using Hostel.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostel.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;
        public int _id = 1;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public Student GetById(int id)
        {
            return _context.Students.FirstOrDefault(s => s.StudentId == id);
        }

        public void Add(Student student)
        {
            //student.StudentId = _id++;
            _context.Students.Add(student);
            _context.SaveChanges();
        }
    }
}
