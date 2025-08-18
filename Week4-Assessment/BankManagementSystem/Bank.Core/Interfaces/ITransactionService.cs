using Bank.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Interfaces
{
    public interface ITransactionService
    {
        Task<List<TransactionResponseDTO>> GetAllAsync();
        Task<TransactionResponseDTO?> GetByIdAsync(int id);
        Task<List<TransactionResponseDTO>> GetByAccountIdAsync(int accountId);
    }
}
