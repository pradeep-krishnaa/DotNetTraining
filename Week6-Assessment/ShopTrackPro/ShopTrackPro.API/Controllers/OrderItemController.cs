using Microsoft.AspNetCore.Mvc;
using ShopTrackPro.Core.DTOs;
using ShopTrackPro.Application.Services;
using ShopTrackPro.Core.DTOs;
using ShopTrackPro.Core.Interfaces;

namespace ShopTrackPro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemService _service;

        public OrderItemsController(IOrderItemService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderItemResponseDTO>>> GetAll()
        {
            var items = await _service.GetAllOrderItemsAsync();
            return Ok(items);
        }

        

        
    }
}
