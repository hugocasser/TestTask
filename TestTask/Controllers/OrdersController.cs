using Microsoft.AspNetCore.Mvc;
using TestTask.Application.Interfaces;

namespace TestTask.Controllers
{
    /// <summary>
    /// Orders controller.
    /// DO NOT change anything here. Use created contract and provide only needed implementation.
    /// </summary>
    [Route("api/v1/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Returns selected order. 
        /// Selection rules are specified in Task description provided by recruiter
        /// </summary>
        [HttpGet]
        [Route("selected-order")]
        public async Task<IActionResult> Get()
        {
            var result = await _orderService.GetOrder();
            return Ok(result);
        }

        /// <summary>
        /// Returns list of selected orders. 
        /// Selection rules are specified in Task description provided by recruiter
        /// </summary>
        [HttpGet]
        [Route("selected-orders")]
        public async Task<IActionResult> GetOrders()
        {
            var result = await _orderService.GetOrders();
            return Ok(result);
        }
    }
}
