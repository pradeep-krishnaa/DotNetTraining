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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<OrderResponseDTO>> GetAllOrdersAsync()
        {
            var orders = await _repository.GetAllAsync();
            return _mapper.Map<List<OrderResponseDTO>>(orders);
        }

        public async Task<OrderResponseDTO?> GetOrderByIdAsync(int id)
        {
            var order = await _repository.GetByIdAsync(id);
            return _mapper.Map<OrderResponseDTO?>(order);
        }

        public async Task AddOrderAsync(OrderRequestDTO dto)
        {
            var order = new Order
            {
                UserId = dto.UserId,
                OrderDate = DateTime.UtcNow,
                Status = "Pending",
                OrderItems = dto.Items.Select(i => new OrderItem
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity
                }).ToList()
            };

            await _repository.AddAsync(order);
        }

        public async Task UpdateOrderAsync(int id, OrderRequestDTO dto)
        {
            var order = await _repository.GetByIdAsync(id);
            if (order == null) return;

            // reset items
            order.OrderItems.Clear();
            foreach (var i in dto.Items)
            {
                order.OrderItems.Add(new OrderItem
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity
                });
            }
            order.Status = "Updated";

            await _repository.UpdateAsync(order);
        }

        public async Task DeleteOrderAsync(int id) =>
            await _repository.DeleteAsync(id);
    }
}
