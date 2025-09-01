using Microsoft.AspNetCore.Mvc;
using ShopTrackPro.Core.DTOs;
using ShopTrackPro.Application.Services;
using ShopTrackPro.Core.DTOs;
using ShopTrackPro.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace ShopTrackPro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<ProductResponseDTO>>> GetAll()
        {
            var products = await _service.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "RequireAdmin")]
        public async Task<ActionResult<ProductResponseDTO>> GetById(int id)
        {
            var product = await _service.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProductRequestDTO dto)
        {
            await _service.AddProductAsync(dto);
            return StatusCode(201); // Created
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, ProductRequestDTO dto)
        {
            var existing = await _service.GetProductByIdAsync(id);
            if (existing == null) return NotFound();

            await _service.UpdateProductAsync(id, dto);
            return NoContent(); // 204
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existing = await _service.GetProductByIdAsync(id);
            if (existing == null) return NotFound();

            await _service.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
