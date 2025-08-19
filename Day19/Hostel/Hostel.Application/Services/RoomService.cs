using AutoMapper;
using Hostel.Core.DTOs;
using Hostel.Core.Entities;
using Hostel.Core.Interfaces;
using Hostel.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
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
        private readonly IMapper _mapper;

        public RoomService(IRoomRepository roomRepo, IMapper mapper)
        {
            _roomRepo = roomRepo;
            _mapper = mapper;
        }

        public async Task<List<RoomResponseDTO>> GetAllRoomsAsync()
        {
            var rooms = await _roomRepo.GetAllAsync();
            return _mapper.Map<List<RoomResponseDTO>>(rooms);
        }

        public async Task<RoomResponseDTO?> GetRoomByIdAsync(int id)
        {
            var room = await _roomRepo.GetByIdAsync(id);
            return _mapper.Map<RoomResponseDTO?>(room);
        }

        public async Task AddRoomAsync(RoomRequestDTO roomDto)
        {
            var room = _mapper.Map<Room>(roomDto);
            await _roomRepo.AddAsync(room);
        }

        public async Task UpdateRoomAsync(int id , RoomRequestDTO roomDto)
        {
            var room = _mapper.Map<Room>(roomDto);
            room.RoomId = id;
            await _roomRepo.UpdateAsync(room);
        }

        public async Task DeleteRoomAsync(int id)
        {
            await _roomRepo.DeleteAsync(id);
        }
    }
}
