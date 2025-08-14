using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Entities
{
    public class Account
    {
        public int AccountId { get; set; }
        public double Balance { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

    }
}
