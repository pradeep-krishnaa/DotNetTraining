using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.DTOs
{
    public class AccountRequestDTO
    {
        public double Balance { get; set; }
        public int CustomerId { get; set; }
    }
}
