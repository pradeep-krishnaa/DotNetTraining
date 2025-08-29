using Microsoft.EntityFrameworkCore;
using ShopTrackPro.Core.Entities;
using ShopTrackPro.Core.Interfaces;
using ShopTrackPro.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTrackPro.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task AddAsync(Order Order)
        {
            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order Order)
        {
            _context.Orders.Update(Order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var Order = await _context.Orders.FindAsync(id);
            if (Order != null)
            {
                _context.Orders.Remove(Order);
                await _context.SaveChangesAsync();
            }
        }


    }
}
