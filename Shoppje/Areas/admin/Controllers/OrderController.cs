using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shoppje.Services.interfaces;

namespace Shoppje.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;
        public OrderController(ILogger<OrderController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return View(orders);
        }
        public async Task<IActionResult> Detail(int id)
        {
            var orderViewModel = await _orderService.GetOrderDetailViewModelByOrderId(id);
            return View(orderViewModel);
        }
    }
}
