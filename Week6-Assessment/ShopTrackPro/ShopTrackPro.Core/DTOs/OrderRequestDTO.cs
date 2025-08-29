using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTrackPro.Core.DTOs
{
    public class OrderRequestDTO
    {
        public int UserId { get; set; }
        public List<OrderItemRequestDTO> Items { get; set; } = new();
    }
}
