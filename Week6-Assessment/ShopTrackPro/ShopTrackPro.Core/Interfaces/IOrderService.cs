using ShopTrackPro.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTrackPro.Core.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderResponseDTO>> GetAllOrdersAsync();
        Task<OrderResponseDTO?> GetOrderByIdAsync(int id);
        Task AddOrderAsync(OrderRequestDTO Order);
        Task UpdateOrderAsync(int id, OrderRequestDTO Order);
        Task DeleteOrderAsync(int id);
    }
}
