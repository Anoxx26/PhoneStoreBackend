using Microsoft.EntityFrameworkCore;
using PhoneStoreBackend.Data;
using PhoneStoreBackend.Models;

namespace PhoneStoreBackend.Repositories
{
    public class OrderDetailsRepository
    {
        private ApplicationContext _context;

        public OrderDetailsRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<OrderDetails>> GetAllOrderDetails()
        {
            return await _context.OrderDetails.ToListAsync();
        }

        public async Task<List<OrderDetails>> GetOrderDetailsById(int orderId)
        {
            return await _context.OrderDetails.Include(o => o.Product).Where(o => o.OrderDetailsID == orderId).ToListAsync();
        }
        public async Task AddOrderDetails(OrderDetails order)
        {
            _context.OrderDetails.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderDetails(OrderDetails order)
        {
            _context.OrderDetails.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderDetails(OrderDetails order)
        {
            _context.OrderDetails.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
}
