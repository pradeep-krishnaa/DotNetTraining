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
        private readonly ICustomerRepository _customerRepo;

        public AccountService(IAccountRepository accountRepo, ICustomerRepository customerRepo)
        {
            _accountRepo = accountRepo;
            _customerRepo = customerRepo;
        }

        public async Task<AccountResponseDTO?> GetAccountByIdAsync(int id)
        {
            var account = await _accountRepo.GetByIdAsync(id);
            if (account == null) return null;

            return new AccountResponseDTO
            {
                AccountId = account.AccountId,
                Balance = account.Balance,
                CustomerId = account.CustomerId
            };
        }

        public async Task<List<AccountResponseDTO>> GetAllAccountsAsync()
        {
            var accounts = await _accountRepo.GetAllAsync();
            return accounts.Select(a => new AccountResponseDTO
            {
                AccountId = a.AccountId,
                Balance = a.Balance,
                CustomerId = a.CustomerId
            }).ToList();
        }

        public async Task CreateAccountAsync(AccountRequestDTO dto)
        {
            var customer = await _customerRepo.GetByIdAsync(dto.CustomerId);
            if (customer == null) throw new Exception("Customer not found");

            var account = new Account
            {
                Balance = dto.InitialDeposit,
                CustomerId = dto.CustomerId
            };

            await _accountRepo.AddAsync(account);
        }

        public async Task DepositAsync(int accountId, decimal amount)
        {
            var account = await _accountRepo.GetByIdAsync(accountId);
            if (account == null) throw new Exception("Account not found");

            account.Balance += amount;
            await _accountRepo.UpdateAsync(account);
        }

        public async Task WithdrawAsync(int accountId, decimal amount)
        {
            var account = await _accountRepo.GetByIdAsync(accountId);
            if (account == null) throw new Exception("Account not found");
            if (account.Balance < amount) throw new Exception("Insufficient balance");

            account.Balance -= amount;
            await _accountRepo.UpdateAsync(account);
        }

        public async Task TransferAsync(int fromAccountId, int toAccountId, decimal amount)
        {
            var fromAcc = await _accountRepo.GetByIdAsync(fromAccountId);
            var toAcc = await _accountRepo.GetByIdAsync(toAccountId);

            if (fromAcc == null || toAcc == null)
                throw new Exception("One or both accounts not found");

            if (fromAcc.Balance < amount)
                throw new Exception("Insufficient balance");

            fromAcc.Balance -= amount;
            toAcc.Balance += amount;

            await _accountRepo.UpdateAsync(fromAcc);
            await _accountRepo.UpdateAsync(toAcc);
        }

        public async Task DeleteAsync(int id)
        {
            await _accountRepo.DeleteAsync(id);
        }


    }
}
