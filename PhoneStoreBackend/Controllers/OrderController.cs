using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PhoneStoreBackend.Models;
using PhoneStoreBackend.Models.DTOs;
using PhoneStoreBackend.Services;

namespace PhoneStoreBackend.Controllers
{
    [ApiController]
    [EnableCors("AllowAll")]
    [Route("[controller]")]
    public class OrderController
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [Authorize]
        [HttpGet("GetProducts")]
        public async Task<ActionResult<List<Order>>> GetOrders()
        {
            return await _orderService.GetOrders();
        }

        [Authorize]
        [HttpGet("GetOrderByUserId")]
        public async Task<ActionResult<List<Order>>> GetOrderByUserId(int userId)
        {
            return await _orderService.GetOrderByIdUser(userId);
        }

        [Authorize]
        [HttpGet("GetOrderDetailById")]
        public async Task<ActionResult<List<OrderDetails>>> GetOrderDeatilsById(int orderId)
        {
            return await _orderService.GetOrderDetailById(orderId);
        }

        [Authorize]
        [HttpPatch("UpdateOrder")]
        public async Task<ActionResult<string>> UpdateOrders(Order order)
        {
            return await _orderService.UpdateOrder(order);
        }

        [Authorize]
        [HttpGet("UpdateOrderStatus")]
        public async Task<ActionResult<string>> UpdateOrderStatus(int orderId, int statusId)
        {
            return await _orderService.UpdateOrderStatus(orderId, statusId);
        }

        [Authorize]
        [HttpPost("AddOrder")]
        public async Task<ActionResult<string>> AddOrder(OrderDTO oreder)
        {
            if (oreder.UserId != null)
            {
                return await _orderService.AddNewOrder(oreder);

            }
            else
            {
                return "False";
            }
        }

    }
}
