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
    public class CustomerRepository : ICustomerRepository
    {
        public readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

       

        public async Task<List<Customer>> GetAllAsync()
        {
            //return await _context.Customers.ToListAsync();
            return await _context.Customers
                         .Include(c => c.Accounts)
                         .ToListAsync();
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            //return await _context.Customers.FindAsync(id);
            return await _context.Customers
                         .Include(c => c.Accounts)
                         .FirstOrDefaultAsync(c => c.CustomerId == id);
        }

        public async Task AddAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }



    }
}
