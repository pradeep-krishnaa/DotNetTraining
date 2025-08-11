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
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _staffRepo;
        private readonly IRoomRepository _roomRepo;

        public StaffService(IStaffRepository staffRepo, IRoomRepository roomRepo)
        {
            _staffRepo = staffRepo;
            _roomRepo = roomRepo;
        }

        public List<StaffResponseDTO> GetAllStaffs()
        {
            var staffList = _staffRepo.GetAll();

            return staffList.Select(staff => new StaffResponseDTO
            {
                StaffId = staff.StaffId,
                Name = staff.Name,
                ManagedRoomCount = _roomRepo.GetAll().Count(r => r.StaffId == staff.StaffId)
            }).ToList();
        }

        public StaffResponseDTO GetStaffById(int id)
        {
            var staff = _staffRepo.GetById(id);
            if (staff == null) return null;

            var managedRoomCount = _roomRepo.GetAll().Count(r => r.StaffId == id);

            return new StaffResponseDTO
            {
                StaffId = staff.StaffId,
                Name = staff.Name,
                ManagedRoomCount = managedRoomCount
            };
        }

        public Staff CreateStaff(StaffRequestDTO dto)
        {
            var newStaff = new Staff
            {
                Name = dto.Name
            };

            _staffRepo.Add(newStaff);
            return newStaff;
        }
    }
}
