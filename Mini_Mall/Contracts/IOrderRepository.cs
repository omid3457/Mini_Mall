using Mini_Mall.Model;

namespace Mini_Mall.Contracts
{
    public interface IOrderRepository: IRepository<Order>
    {
        List<Order> GetUserOrders(string username);
    }
}
