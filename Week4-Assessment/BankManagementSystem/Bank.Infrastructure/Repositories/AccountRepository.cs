using Bank.Core.Entities;
using Bank.Core.Interfaces;
using Bank.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public readonly AppDbContext _context;

        public AccountRepository(AppDbContext context)
        {
            _context = context;
        }



        public async Task<List<Account>> GetAllAsync()
        {
            //return await _context.Accounts.ToListAsync();
            return await _context.Accounts
                         .Include(a => a.Customer)
                         .Include(a => a.Transactions)
                         .ToListAsync();
        }

        public async Task<Account?> GetByIdAsync(int id)
        {
            //return await _context.Accounts.FindAsync(id);
            return await _context.Accounts
                         .Include(a => a.Customer)
                         .Include(a => a.Transactions)
                         .FirstOrDefaultAsync(a => a.AccountId == id);
        }

        public async Task AddAsync(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account != null)
            {
                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Account?> GetAccountByCustomerIdAsync(int customerId)
        {
            return await _context.Accounts
                .Include(a => a.Customer)
                .Include(a => a.Transactions)
                .FirstOrDefaultAsync(a => a.CustomerId == customerId);
        }



    }
}
