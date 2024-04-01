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
