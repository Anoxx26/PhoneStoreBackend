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
    }
}
