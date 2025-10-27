using Application.Order.ServiceInterfaces;
using Domain.Order.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService) 
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult> PostNewOrderAsync([FromBody] OrderDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Succes = false, Message = "Invalid request" });

            var order = await _orderService.CreateNewOrderAsync(request);
            if (order == null)
                return BadRequest(new { Succes = false, Message = "An error occured"});

            return Ok(new { Succes = true, Message = "Order added succesfully" });
        }
    }
}
