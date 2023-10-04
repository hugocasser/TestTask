using TestTask.Models;

namespace TestTask.Application.Interfaces
{
    public interface IOrderService
    {
        public Task<Order> GetOrder();

        public Task<List<Order>> GetOrders();
    }
}
