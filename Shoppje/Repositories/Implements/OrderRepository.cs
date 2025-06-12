using Shoppje.data;
using Shoppje.Models;
using Shoppje.Repositories.Interfaces;

namespace Shoppje.Repositories.Implements
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;
        public OrderRepository(DataContext context)
        {
            _context = context;
        }
        public async Task CreateOrder(OrderModel order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task CreateOrderItem(OrderDetailModel orderItem)
        {
            await _context.OrderDetails.AddAsync(orderItem);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<OrderDetailModel> GetAllByOrderCode(string orderCode)
        {
            return _context.OrderDetails.Where(od => od.OrderCode == orderCode).ToList();
        }

        public Task<IEnumerable<OrderModel>> GetAllOrdersAsync()
        {
            return Task.FromResult<IEnumerable<OrderModel>>(_context.Orders.ToList());
        }

        public Task<OrderModel> GetOrderByIdAsync(int id)
        {
            return Task.FromResult(_context.Orders.FirstOrDefault(od => od.Id == id));
        }
    }
}
