using AutoMapper;
using Bank.Core.DTOs;
using Bank.Core.Entities;
using Bank.Core.Interfaces;
using Bank.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepo;
        private readonly ITransactionRepository _transactionRepo;

        public AccountService(IAccountRepository accountRepo, ITransactionRepository transactionRepo)
        {
            _accountRepo = accountRepo;
            _transactionRepo = transactionRepo;
        }

        public async Task<List<AccountResponseDTO>> GetAllAccountsAsync()
        {
            var accounts = await _accountRepo.GetAllAsync();
            return accounts.Select(a => new AccountResponseDTO
            {
                AccountId = a.AccountId,
                CustomerId = a.CustomerId,
                Balance = a.Balance
            }).ToList();
        }

        public async Task<AccountResponseDTO?> GetAccountByIdAsync(int id)
        {
            var account = await _accountRepo.GetByIdAsync(id);
            if (account == null) return null;

            return new AccountResponseDTO
            {
                AccountId = account.AccountId,
                CustomerId = account.CustomerId,
                Balance = account.Balance
            };
        }

        public async Task CreateAccountAsync(AccountRequestDTO dto)
        {
            var account = new Account
            {
                CustomerId = dto.CustomerId,
                Balance = dto.InitialDeposit
            };

            await _accountRepo.AddAsync(account);

            // ✅ Log initial deposit as transaction (if > 0)
            if (dto.InitialDeposit > 0)
            {
                var transaction = new Transaction
                {
                    AccountId = account.AccountId,
                    Amount = dto.InitialDeposit,
                    Type = "Deposit",
                    Date = DateTime.UtcNow
                };
                await _transactionRepo.AddAsync(transaction);
            }
        }

        public async Task DepositAsync(int accountId, decimal amount)
        {
            var account = await _accountRepo.GetByIdAsync(accountId);
            if (account == null) throw new Exception("Account not found");

            account.Balance += amount;
            await _accountRepo.UpdateAsync(account);

            // ✅ Log transaction
            var transaction = new Transaction
            {
                AccountId = accountId,
                Amount = amount,
                Type = "Deposit",
                Date = DateTime.UtcNow
            };
            await _transactionRepo.AddAsync(transaction);
        }

        public async Task WithdrawAsync(int accountId, decimal amount)
        {
            var account = await _accountRepo.GetByIdAsync(accountId);
            if (account == null) throw new Exception("Account not found");
            if (account.Balance < amount) throw new Exception("Insufficient balance");

            account.Balance -= amount;
            await _accountRepo.UpdateAsync(account);

            // ✅ Log transaction
            var transaction = new Transaction
            {
                AccountId = accountId,
                Amount = amount,
                Type = "Withdrawal",
                Date = DateTime.UtcNow
            };
            await _transactionRepo.AddAsync(transaction);
        }

        public async Task TransferAsync(int fromAccountId, int toAccountId, decimal amount)
        {
            var fromAccount = await _accountRepo.GetByIdAsync(fromAccountId);
            var toAccount = await _accountRepo.GetByIdAsync(toAccountId);

            if (fromAccount == null || toAccount == null)
                throw new Exception("One or both accounts not found");

            if (fromAccount.Balance < amount)
                throw new Exception("Insufficient balance");

            fromAccount.Balance -= amount;
            toAccount.Balance += amount;

            await _accountRepo.UpdateAsync(fromAccount);
            await _accountRepo.UpdateAsync(toAccount);

            // ✅ Log debit transaction
            var debitTransaction = new Transaction
            {
                AccountId = fromAccountId,
                Amount = amount,
                Type = "Transfer - Debit",
                Date = DateTime.UtcNow
            };
            await _transactionRepo.AddAsync(debitTransaction);

            // ✅ Log credit transaction
            var creditTransaction = new Transaction
            {
                AccountId = toAccountId,
                Amount = amount,
                Type = "Transfer - Credit",
                Date = DateTime.UtcNow
            };
            await _transactionRepo.AddAsync(creditTransaction);
        }

        public async Task DeleteAsync(int id)
        {
            await _accountRepo.DeleteAsync(id);
        }


    }
}
