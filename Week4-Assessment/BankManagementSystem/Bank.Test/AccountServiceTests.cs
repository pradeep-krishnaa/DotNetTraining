using Bank.Application.Services;
using Bank.Core.Entities;
using Bank.Core.Interfaces;
using Bank.Application.Services;
using Bank.Core.Entities;
using Bank.Core.Interfaces;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Bank.Tests
{
    public class AccountServiceTests
    {
        private readonly Mock<IAccountRepository> _accountRepo;
        private readonly Mock<ITransactionRepository> _transactionRepo;
        private readonly AccountService _service;

        public AccountServiceTests()
        {
            _accountRepo = new Mock<IAccountRepository>();
            _transactionRepo = new Mock<ITransactionRepository>();
            _service = new AccountService(_accountRepo.Object, _transactionRepo.Object);
        }

        [Fact]
        public async Task Deposit_ShouldIncreaseBalance()
        {
            var account = new Account { AccountId = 1, Balance = 100m };
            _accountRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(account);

            await _service.DepositAsync(1, 50m);

            Assert.Equal(150m, account.Balance);
        }

        [Fact]
        public async Task Withdraw_ShouldDecreaseBalance()
        {
            var account = new Account { AccountId = 1, Balance = 200m };
            _accountRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(account);

            await _service.WithdrawAsync(1, 100m);

            Assert.Equal(100m, account.Balance);
        }

        [Fact]
        public async Task Transfer_ShouldMoveMoneyBetweenAccounts()
        {
            var from = new Account { AccountId = 1, Balance = 500m };
            var to = new Account { AccountId = 2, Balance = 200m };
            _accountRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(from);
            _accountRepo.Setup(r => r.GetByIdAsync(2)).ReturnsAsync(to);

            await _service.TransferAsync(1, 2, 150m);

            Assert.Equal(350m, from.Balance);
            Assert.Equal(350m, to.Balance);
        }

        [Fact]
        public async Task Transfer_ShouldThrow_WhenInsufficientFunds()
        {
            var from = new Account { AccountId = 1, Balance = 50m };
            var to = new Account { AccountId = 2, Balance = 100m };
            _accountRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(from);
            _accountRepo.Setup(r => r.GetByIdAsync(2)).ReturnsAsync(to);

            var ex = await Assert.ThrowsAsync<Exception>(() => _service.TransferAsync(1, 2, 200m));

            Assert.Equal("Insufficient balance", ex.Message);
        }
    }
}
