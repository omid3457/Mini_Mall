using Microsoft.EntityFrameworkCore;
using Mini_Mall.Contracts;
using Mini_Mall.Data;
using Mini_Mall.Model;

namespace Mini_Mall.CustomerRepo
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext context;
        private readonly IUserService _userService;

        public CustomerRepository(AppDbContext dbContext, IUserService userService)
        {
            this.context = dbContext;
            this._userService = userService;
        }

        public async Task<bool> Add(Customer item)
        {
            await context.Customers.AddAsync(item);
            var result = await context.SaveChangesAsync();

            return result > 0;
        }

        public List<Customer> GetAll()
        {
            return context.Customers.ToList();
        }

        public async Task<Customer> GetByid(int id)
        {
            Customer? customer = await context.Customers.FirstOrDefaultAsync(c => c.Id == id);
            ArgumentNullException.ThrowIfNull(customer);
            return customer;
        }

        public async Task<string> GetCustomerId(string username)
        {
            User user = await _userService.Get_User(username);
            ArgumentNullException.ThrowIfNull(user);

            Customer? customer = await context.Customers.FirstOrDefaultAsync(c => c.User == user);

            return customer!.Id.ToString();
        }

        public Task<bool> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(Customer item)
        {
            context.Customers.Update(item);
            var result = await context.SaveChangesAsync();
            return result > 0;
        }
    }
}
