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
    public class StaffRepository : IStaffRepository
    {
        private readonly AppDbContext _context;
        public int _id = 1;

        public StaffRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Staff> GetAll()
        {
            return _context.Staffs.ToList();
        }

        public Staff GetById(int id)
        {
            return _context.Staffs.FirstOrDefault(s => s.StaffId == id);
        }

        public void Add(Staff staff)
        {
            //staff.StaffId = _id++;
            _context.Staffs.Add(staff);
            _context.SaveChanges();
        }
        public void Update(Staff staff)
        {
            // Attach the staff entity if not already tracked
            var trackedEntity = _context.Staffs.Local.FirstOrDefault(s => s.StaffId == staff.StaffId);
            if (trackedEntity == null)
            {
                _context.Staffs.Attach(staff);
                _context.Entry(staff).State = EntityState.Modified;
            }
            else
            {
                // If already tracked, update the properties manually if needed
                _context.Entry(trackedEntity).CurrentValues.SetValues(staff);
            }

            _context.SaveChanges();
        }
    }
}
