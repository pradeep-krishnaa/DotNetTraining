using Bank.Core.DTOs;
using Bank.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var accounts = await _service.GetAllAccountsAsync();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var account = await _service.GetAccountByIdAsync(id);
            if (account == null) return NotFound();
            return Ok(account);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(AccountRequestDTO dto)
        {
            await _service.CreateAccountAsync(dto);
            return Ok("Account created successfully");
        }

        [HttpPost("deposit/{id}")]
        public async Task<IActionResult> Deposit(int id, [FromQuery] decimal amount)
        {
            await _service.DepositAsync(id, amount);
            return Ok("Deposit successful");
        }

        [HttpPost("withdraw/{id}")]
        public async Task<IActionResult> Withdraw(int id, [FromQuery] decimal amount)
        {
            await _service.WithdrawAsync(id, amount);
            return Ok("Withdrawal successful");
        }

        [HttpPost("transfer")]
        public async Task<IActionResult> Transfer([FromQuery] int fromId, [FromQuery] int toId, [FromQuery] decimal amount)
        {
            await _service.TransferAsync(fromId, toId, amount);
            return Ok("Transfer successful");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok("Account deleted successfully");
        }
    }
}
