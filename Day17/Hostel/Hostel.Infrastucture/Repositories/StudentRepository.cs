using Hostel.Core.Entities;
using Hostel.Core.Interfaces;
using Hostel.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
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

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public Task UpdateAsync(Student student)
        {
            _context.Update(student);
            return _context.SaveChangesAsync();
        }

        public Task AddAsync(Student student)
        {
            _context.Students.Add(student);
            return _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            _context.Remove(id);
            return _context.SaveChangesAsync();
        }
    }
}
