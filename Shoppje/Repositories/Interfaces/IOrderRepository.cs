using Shoppje.Models;

namespace Shoppje.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task CreateOrder(OrderModel order);
        Task CreateOrderItem(OrderDetailModel orderItem);
        IEnumerable<OrderDetailModel> GetAllByOrderCode(string orderCode);
        Task<IEnumerable<OrderModel>> GetAllOrdersAsync();
        Task<OrderModel> GetOrderByIdAsync(int id);
    }
}