using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.DTOs
{
    public class CustomerResponseDTO
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public List<AccountResponseDTO> Accounts { get; set; }
    }
}
