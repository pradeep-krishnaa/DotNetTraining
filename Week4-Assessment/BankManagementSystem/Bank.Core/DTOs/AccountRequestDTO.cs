using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.DTOs
{
    public class AccountRequestDTO
    {
        public decimal InitialDeposit { get; set; }
        public int CustomerId { get; set; }
    }
}
