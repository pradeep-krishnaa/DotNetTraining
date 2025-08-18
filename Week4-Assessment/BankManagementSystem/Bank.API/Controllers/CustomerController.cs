using Bank.Core.DTOs;
using Bank.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _service.GetAllCustomersAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _service.GetCustomerByIdAsync(id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CustomerRequestDTO dto)
        {
            await _service.AddCustomerAsync(dto);
            return Ok("Customer created successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CustomerRequestDTO dto)
        {
            await _service.UpdateCustomerAsync(id, dto);
            return Ok("Customer updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteCustomerAsync(id);
            return Ok("Customer deleted successfully");
        }
    }
}
