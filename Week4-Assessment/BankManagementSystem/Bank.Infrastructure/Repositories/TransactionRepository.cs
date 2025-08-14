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
    public class TransactionRepository : ITransactionRepository
    {
        public readonly AppDbContext _context;

        public TransactionRepository(AppDbContext context)
        {
            _context = context;
        }



        public async Task<List<Transaction>> GetAllAsync()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<Transaction?> GetByIdAsync(int id)
        {
            return await _context.Transactions.FindAsync(id);
        }

        public async Task AddAsync(Transaction Transaction)
        {
            _context.Transactions.Add(Transaction);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Transaction Transaction)
        {
            _context.Transactions.Update(Transaction);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var Transaction = await _context.Transactions.FindAsync(id);
            if (Transaction != null)
            {
                _context.Transactions.Remove(Transaction);
                await _context.SaveChangesAsync();
            }
        }



    }
}
