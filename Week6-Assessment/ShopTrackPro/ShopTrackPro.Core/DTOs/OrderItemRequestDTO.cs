using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTrackPro.Core.DTOs
{
    public class OrderItemRequestDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
