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
            var t = await _transactionRepo.GetByIdAsync(id);
            if (t == null) return null;

            return new TransactionResponseDTO
            {
                TransactionId = t.TransactionId,
                AccountId = t.AccountId,
                Amount = t.Amount,
                Type = t.Type,
                Date = t.Date
            };
        }

        public async Task<List<TransactionResponseDTO>> GetByAccountIdAsync(int accountId)
        {
            var transactions = await _transactionRepo.GetAllAsync();
            return transactions
                .Where(t => t.AccountId == accountId)
                .Select(t => new TransactionResponseDTO
                {
                    TransactionId = t.TransactionId,
                    AccountId = t.AccountId,
                    Amount = t.Amount,
                    Type = t.Type,
                    Date = t.Date
                }).ToList();
        }
    }
}
