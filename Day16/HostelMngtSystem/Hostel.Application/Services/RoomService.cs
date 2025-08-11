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
    public class RoomService : IRoomService 
    {
        private readonly IRoomRepository _roomRepo;
        private readonly IStaffRepository _staffRepo;

        public RoomService(IRoomRepository roomRepo, IStaffRepository staffRepo)
        {
            _roomRepo = roomRepo;
            _staffRepo = staffRepo;
        }

        public List<RoomResponseDTO> GetAllRooms()
        {
            var rooms = _roomRepo.GetAll();
            var staffList = _staffRepo.GetAll();

            return rooms.Select(room => new RoomResponseDTO
            {
                RoomId = room.RoomId,
                Capacity = room.Capacity,
                AssignedStaff = staffList.FirstOrDefault(s => s.StaffId == room.StaffId)?.Name ?? "Unassigned"
            }).ToList();
        }

        public RoomResponseDTO GetRoomById(int id)
        {
            var room = _roomRepo.GetById(id);
            if (room == null) return null;

            var staff = _staffRepo.GetById(room.StaffId);

            return new RoomResponseDTO
            {
                RoomId = room.RoomId,
                Capacity = room.Capacity,
                AssignedStaff = staff?.Name ?? "Unassigned"
            };
        }

        public Room CreateRoom(RoomRequestDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            // Find staff who manages less than 2 rooms
            var staff = _staffRepo.GetAll()
                        .FirstOrDefault(s => s.RoomsAllocated < 2);

            if (staff == null)
                throw new InvalidOperationException("No staff available to allocate this room.");

            // Create the room and assign the staff
            var room = new Room
            {
                Capacity = dto.Capacity,
                StaffId = staff.StaffId,  // Assign staff by Id
                Staff = staff
            };

            // Add room to repository
            _roomRepo.Add(room);

            // Increment staff rooms allocated count
            staff.RoomsAllocated++;

            // Update staff record in repository
            _staffRepo.Update(staff);
        }
    }
}
