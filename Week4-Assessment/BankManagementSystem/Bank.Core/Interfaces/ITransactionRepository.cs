using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bank.Core.Entities;

namespace Bank.Core.Interfaces
{
    public interface ITransactionRepository : IRepository<Transaction>

    {
    }
}
