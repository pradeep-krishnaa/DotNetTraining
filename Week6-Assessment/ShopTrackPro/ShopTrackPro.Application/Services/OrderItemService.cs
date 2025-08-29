using AutoMapper;
using ShopTrackPro.Core.DTOs;
using ShopTrackPro.Core.Entities;
using ShopTrackPro.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTrackPro.Application.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _repository;
        private readonly IMapper _mapper;

        public OrderItemService(IOrderItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<OrderItemResponseDTO>> GetAllOrderItemsAsync()
        {
            var items = await _repository.GetAllAsync();
            return _mapper.Map<List<OrderItemResponseDTO>>(items);
        }

        public async Task<OrderItemResponseDTO?> GetOrderItemByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            return _mapper.Map<OrderItemResponseDTO?>(item);
        }

        public async Task AddOrderItemAsync(OrderItemRequestDTO dto)
        {
            var item = _mapper.Map<OrderItem>(dto);
            await _repository.AddAsync(item);
        }

        public async Task UpdateOrderItemAsync(int id, OrderItemRequestDTO dto)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null) return;

            _mapper.Map(dto, item);
            await _repository.UpdateAsync(item);
        }

        public async Task DeleteOrderItemAsync(int id) =>
            await _repository.DeleteAsync(id);
    }
}
