using Shoppje.Models;

namespace Shoppje.Services.interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderModel>> GetAllOrdersAsync();
        Task<OrderDetailViewModel> GetOrderDetailViewModelByOrderId(int id);
    }
}
