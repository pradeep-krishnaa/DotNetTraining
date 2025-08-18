using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.DTOs
{
    public class TransactionRequestDTO
    {
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } // "Deposit", "Withdrawal" , "Transfer"
        public int? TragetAccountId { get; set; } //for transfer , can be null

    }
}
