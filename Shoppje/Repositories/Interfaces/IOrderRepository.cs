using Shoppje.Models;

namespace Shoppje.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task CreateOrder(OrderModel order);
    }
}