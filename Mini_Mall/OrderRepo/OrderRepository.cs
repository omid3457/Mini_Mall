using Mini_Mall.Contracts;
using Mini_Mall.Data;
using Mini_Mall.Model;
using Microsoft.EntityFrameworkCore;

namespace Mini_Mall.OrderRepo
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext context;
        private readonly IUserrepository _userrepository;

        public OrderRepository(AppDbContext dbContext, IUserrepository userrepository)
        {
            this.context = dbContext;
            this._userrepository = userrepository;
        }

        public async Task<bool> Add(Order item)
        {
            await context.Orders.AddAsync(item);
            var result = await context.SaveChangesAsync();

            return result > 0;
        }

        public Task<Order> GetByid(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetUserOrders(string userid)
        {
            List<Order> orders = [];
            orders = context.Orders.Where(o => o.UserId == userid).ToList();
            return orders;
        }

        public Task<bool> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Order item)
        {
            throw new NotImplementedException();
        }
    }
}
