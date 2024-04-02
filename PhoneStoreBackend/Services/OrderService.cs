using PhoneStoreBackend.Models;
using PhoneStoreBackend.Models.DTOs;
using PhoneStoreBackend.Repositories;

namespace PhoneStoreBackend.Services
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepository;

        private readonly OrderDetailsRepository _orderDetailsRepository;

        public OrderService(OrderRepository orderRepository, OrderDetailsRepository orderDetailsRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailsRepository = orderDetailsRepository;
        }

        public async Task<List<Order>> GetOrders()
        {
            return await _orderRepository.GetAllOrders();
        }

        public async Task<List<OrderDetails>> GetOrderDetails()
        {
            return await _orderDetailsRepository.GetAllOrderDetails();
        }

        public async Task<string> UpdateOrder(Order order)
        {
            await _orderRepository.UpdateOrder(order);

            return "True";
        }
        public async Task<string> AddNewOrder(OrderDTO order)
        {

            List<Order> orders = await _orderRepository.GetAllOrders();

            int maxId = orders.Max(order => order.OrderId);

            Order or = new Order
            {
                OrderId = maxId + 1,
                StatusId = order.StatusId,
                UserId = order.UserId,
                TotalPrice = order.TotalPrice,
                OrderCreate = DateOnly.FromDateTime(DateTime.Today),
                OrderEnd = DateOnly.FromDateTime(DateTime.Today).AddDays(5)
            };

            await _orderRepository.AddOrder(or);

            foreach(var det in order.OrderDetails)
            {
                OrderDetails od = new OrderDetails
                {
                    OrderDetailsID = maxId + 1,
                    ProductId = det.ProductId,
                    Quantity = det.Quantity,
                };

               await _orderDetailsRepository.AddOrderDetails(od);

            }

            return "True";

        }
    }
}
