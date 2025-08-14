using AutoMapper;
using Bank.Core.DTOs;
using Bank.Core.Entities;
using Bank.Core.Interfaces;
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
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository accountRepo, IMapper mapper , ICustomerRepository customerRepository)
        {
            _accountRepo = accountRepo;
            _mapper = mapper;
            _customerRepo = customerRepository;
        }

        public async Task<List<AccountResponseDTO>> GetAllAccountsAsync()
        {
            var accounts = await _accountRepo.Accounts
                                         .Include(a => a.Customer)
                                         .Include(a => a.Transactions)
                                         .ToListAsync();
            return _mapper.Map<List<AccountResponseDTO>>(accounts);
        }

        public async Task<AccountResponseDTO?> GetAccountByIdAsync(int id)
        {
            var account = await _accountRepo.GetByIdAsync(id);
            return _mapper.Map<AccountResponseDTO?>(account);
        }

        public async Task AddAccountAsync(AccountRequestDTO accountDto)
        {
            var account = _mapper.Map<Account>(accountDto);
            await _accountRepo.AddAsync(account);
        }

        public async Task UpdateAccountAsync(int id, AccountRequestDTO accountDto)
        {
            var account = _mapper.Map<Account>(accountDto);
            account.AccountId = id;
            await _accountRepo.UpdateAsync(account);
        }

        public async Task DeleteAccountAsync(int id)
        {
            await _accountRepo.DeleteAsync(id);
        }

        public async Task<AccountResponseDTO?> GetAccountByCustomerIdAsync(int customerId)
        {
            var account = await _accountRepo.GetAccountByCustomerIdAsync(customerId);
            return _mapper.Map<AccountResponseDTO?>(account);
        }


    }
}
