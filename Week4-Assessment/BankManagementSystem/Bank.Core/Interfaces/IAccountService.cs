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
        Task CreateAccountAsync(AccountRequestDTO dto);
        Task DepositAsync(int accountId, decimal amount);
        Task WithdrawAsync(int accountId, decimal amount);
        Task TransferAsync(int fromAccountId, int toAccountId, decimal amount);
        Task DeleteAsync(int id);
    }
}
