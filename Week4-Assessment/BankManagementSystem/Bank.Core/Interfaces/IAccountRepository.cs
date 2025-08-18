using Bank.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {
        //Task<Account?> GetAccountByCustomerIdAsync(int customerId);
    }
}
