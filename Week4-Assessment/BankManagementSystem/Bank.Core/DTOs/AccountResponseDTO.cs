using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.DTOs
{
    public class AccountResponseDTO
    {
        public int AccountId { get; set; }
        public decimal Balance { get; set; }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
    }

}
