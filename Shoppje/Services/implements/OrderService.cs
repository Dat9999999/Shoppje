using Shoppje.Models;
using Shoppje.Repositories.Interfaces;
using Shoppje.Services.interfaces;

namespace Shoppje.Services.implements
{
   
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<OrderService> _logger;
        public OrderService(IOrderRepository orderRepository, ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }
        public async Task<IEnumerable<OrderModel>> GetAllOrdersAsync()
        {
            var orders=  await _orderRepository.GetAllOrdersAsync();
            _logger.LogInformation("Fetched {Count} orders", orders.Count());
            return orders;
        }
    }
}
