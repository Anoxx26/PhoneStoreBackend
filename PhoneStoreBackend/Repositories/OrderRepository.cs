using Microsoft.EntityFrameworkCore;
using PhoneStoreBackend.Data;
using PhoneStoreBackend.Models;

namespace PhoneStoreBackend.Repositories
{
    public class OrderRepository
    {
        private ApplicationContext _context;

        public OrderRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAllOrders()
        {
           return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(x => x.OrderId == id);
        }

        public async Task AddOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrder(Order order)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
}
