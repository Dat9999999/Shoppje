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
    }
}
