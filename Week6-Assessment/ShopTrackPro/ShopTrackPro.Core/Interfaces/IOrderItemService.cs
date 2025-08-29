using ShopTrackPro.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTrackPro.Core.Interfaces
{
    public interface IOrderItemService
    {
        Task<List<OrderItemResponseDTO>> GetAllOrderItemsAsync();
        Task<OrderItemResponseDTO?> GetOrderItemByIdAsync(int id);
        Task AddOrderItemAsync(OrderItemRequestDTO OrderItem);
        Task UpdateOrderItemAsync(int id, OrderItemRequestDTO OrderItem);
        Task DeleteOrderItemAsync(int id);
    }
}
