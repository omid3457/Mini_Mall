using Mini_Mall.Model;

namespace Mini_Mall.Contracts
{
    public interface ICustomerRepository: IRepository<Customer>
    {
        Task<string> GetCustomerId(string username);
        List<Customer> GetAll();
    }
}
