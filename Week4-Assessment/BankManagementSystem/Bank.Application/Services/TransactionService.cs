using Bank.Core.DTOs;
using Bank.Core.Interfaces;
using Bank.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Core.Entities;
namespace Bank.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepo;

        public TransactionService(ITransactionRepository transactionRepo)
        {
            _transactionRepo = transactionRepo;
        }

        public async Task<List<TransactionResponseDTO>> GetAllAsync()
        {
            var transactions = await _transactionRepo.GetAllAsync();
            return transactions.Select(t => new TransactionResponseDTO
            {
                TransactionId = t.TransactionId,
                AccountId = t.AccountId,
                Amount = t.Amount,
                Type = t.Type,
                Date = t.Date
            }).ToList();
        }

        public async Task<TransactionResponseDTO?> GetByIdAsync(int id)
        {
            var transaction = await _transactionRepo.GetByIdAsync(id);
            if (transaction == null) return null;

            return new TransactionResponseDTO
            {
                TransactionId = transaction.TransactionId,
                AccountId = transaction.AccountId,
                Amount = transaction.Amount,
                Type = transaction.Type,
                Date = transaction.Date
            };
        }

        public async Task AddAsync(TransactionRequestDTO dto)
        {
            var transaction = new Transaction
            {
                AccountId = dto.AccountId,
                Amount = dto.Amount,
                Type = dto.Type,
                Date = DateTime.Now
            };

            await _transactionRepo.AddAsync(transaction);
        }

        public async Task DeleteAsync(int id)
        {
            await _transactionRepo.DeleteAsync(id);
        }
    }
}
