using Bank.Application.Services;
using Bank.Core.Interfaces;
using Bank.Application.Services;
using Bank.Core.Entities;
using Bank.Core.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Bank.Tests
{
    public class TransactionServiceTests
    {
        private readonly Mock<ITransactionRepository> _transactionRepo;
        private readonly TransactionService _service;

        public TransactionServiceTests()
        {
            _transactionRepo = new Mock<ITransactionRepository>();
            _service = new TransactionService(_transactionRepo.Object);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnTransactions()
        {
            var transactions = new List<Transaction>
            {
                new Transaction { TransactionId = 1, AccountId = 1, Amount = 100m, Type = "Deposit" },
                new Transaction { TransactionId = 2, AccountId = 2, Amount = 200m, Type = "Withdraw" }
            };

            _transactionRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(transactions);

            var result = await _service.GetAllAsync();

            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnTransaction()
        {
            var transaction = new Transaction { TransactionId = 1, AccountId = 1, Amount = 100m, Type = "Deposit" };
            _transactionRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(transaction);

            var result = await _service.GetByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.TransactionId);
            Assert.Equal(100m, result.Amount);
        }

       
    }
}
