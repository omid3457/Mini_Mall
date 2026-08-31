using Mini_Mall.DTOs;
using Mini_Mall.Model;

namespace Mini_Mall.Contracts
{
    public interface IOrderService
    {
        Task<bool> Add_Order(CreateOrderDto dto);
        List<Order> GetOrders(string userid);
    }
}
