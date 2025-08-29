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
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly AppDbContext _context;

        public OrderItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrderItem>> GetAllAsync()
        {
            return await _context.OrderItems.ToListAsync();
        }

        public async Task<OrderItem?> GetByIdAsync(int id)
        {
            return await _context.OrderItems.FindAsync(id);
        }

        public async Task AddAsync(OrderItem OrderItem)
        {
            _context.OrderItems.Add(OrderItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrderItem OrderItem)
        {
            _context.OrderItems.Update(OrderItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var OrderItem = await _context.OrderItems.FindAsync(id);
            if (OrderItem != null)
            {
                _context.OrderItems.Remove(OrderItem);
                await _context.SaveChangesAsync();
            }
        }


    }
}
