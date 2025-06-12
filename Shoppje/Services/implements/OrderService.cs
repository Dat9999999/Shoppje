using Shoppje.Models;
using Shoppje.Repositories.Interfaces;
using Shoppje.Services.interfaces;

namespace Shoppje.Services.implements
{
   
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly ILogger<OrderService> _logger;
        public OrderService(IOrderRepository orderRepository, ILogger<OrderService> logger, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _logger = logger;
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<OrderModel>> GetAllOrdersAsync()
        {
            var orders=  await _orderRepository.GetAllOrdersAsync();
            _logger.LogInformation("Fetched {Count} orders", orders.Count());
            return orders;
        }


        public async Task<OrderDetailViewModel> GetOrderDetailViewModelByOrderId(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            if (order == null)
            {
                _logger.LogWarning("Order with ID {Id} not found", id);
                return await Task.FromResult<OrderDetailViewModel>(null);
            }

            var orderDetails = _orderRepository.GetAllByOrderCode(order.OrderCode);
            List<OrderItemViewModel> orderItems = new List<OrderItemViewModel>();

            foreach (var orderDetail in orderDetails)
            {
                var product = await _productRepository.GetProductById(orderDetail.ProductId);
                var orderItem = new OrderItemViewModel
                {
                    ProductId = orderDetail.ProductId,
                    Quantity = orderDetail.Quantity,
                    ProductPrice = orderDetail.Price,
                    ProductName = product?.Name ?? "Unknown Product",
                    ProductDescription = product?.Description ?? "No description available",
                    ProductImageUrl = product?.Img ?? "none" // Default image if none exists
                };
                orderItems.Add(orderItem);
            }


            var orderDetailViewModel = new OrderDetailViewModel
            {
                items = orderItems
            };
            _logger.LogInformation("Fetched order details for Order count: {0}", orderDetailViewModel.items.Count());
            return orderDetailViewModel;

        }

    }
}
