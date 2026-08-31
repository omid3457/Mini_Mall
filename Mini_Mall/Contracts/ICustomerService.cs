using Mini_Mall.DTOs;
using Mini_Mall.Model;

namespace Mini_Mall.Contracts
{
    public interface ICustomerService
    {
        Task<bool> Add_Customer(CreateCustomerDto dto, string role);
        List<ReturnProductDto> GetAllProducts();
        Task<bool> Add_Order(CreateOrderDto createOrder);
        List<ReturnCustomerOrderDto> Get_Orders(string userid);
        Task<string> GetId(string username);
        Task<bool> Update(UpdateCustomerDto updateCustomer);
        List<ReturnCustomerDto> GetAll();

    }
}
