using Bookstore.Data.DTOS;
using BookStore.core.IBookstoreRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Controllers;

namespace BookStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<BookController> _logger;

        public OrderController( IOrderRepository orderRepository, ILogger<BookController> logger)
        {
           
            _orderRepository = orderRepository;
            _logger = logger;
        }
        [HttpPost("PlaceOrder")]
        public async Task<IActionResult> PlaceOrder(OrderDetailDTO orderDetail)
        {
            try
            {
                var result = await _orderRepository.PlaceOrderAsync(orderDetail);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error placing order");
                return StatusCode(500, "An error occurred while placing the order.");
            }
        }
        [HttpGet("Revenue")]
        public async Task<IActionResult> GetRevenue(DateTime startDate, DateTime endDate)
        {
            try
            {
                var result = await _orderRepository.GetRevenueAsync(startDate, endDate);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting revenue");
                return StatusCode(500, "An error occurred while getting the revenue.");
            }
        }

    }
}
