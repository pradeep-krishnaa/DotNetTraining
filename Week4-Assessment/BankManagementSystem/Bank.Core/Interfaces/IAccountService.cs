using Bank.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Interfaces
{
    public interface IAccountService
    {
        Task<List<AccountResponseDTO>> GetAllAccountsAsync();
        Task<AccountResponseDTO?> GetAccountByIdAsync(int id);
        Task AddAccountAsync(AccountRequestDTO account);
        Task UpdateAccountAsync(int id, AccountRequestDTO account);
        Task DeleteAccountAsync(int id);
        Task<AccountResponseDTO?> GetAccountByCustomerIdAsync(int customerId);
    }
}
