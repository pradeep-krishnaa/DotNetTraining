using Microsoft.AspNetCore.Mvc;
using ShopTrackPro.Core.DTOs;
using ShopTrackPro.Application.Services;
using ShopTrackPro.Core.DTOs;
using ShopTrackPro.Core.Interfaces;

namespace ShopTrackPro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderResponseDTO>>> GetAll()
        {
            var orders = await _service.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderResponseDTO>> GetById(int id)
        {
            var order = await _service.GetOrderByIdAsync(id);
            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult> Create(OrderRequestDTO dto)
        {
            await _service.AddOrderAsync(dto);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, OrderRequestDTO dto)
        {
            var existing = await _service.GetOrderByIdAsync(id);
            if (existing == null) return NotFound();

            await _service.UpdateOrderAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existing = await _service.GetOrderByIdAsync(id);
            if (existing == null) return NotFound();

            await _service.DeleteOrderAsync(id);
            return NoContent();
        }
    }
}
