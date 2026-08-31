using Mini_Mall.Contracts;
using Mini_Mall.DTOs;
using Mini_Mall.Model;

namespace Mini_Mall.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository repository;
        private readonly IUserService userService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;

        public CustomerService(ICustomerRepository customerRepository, IProductService productService, IUserService user, IOrderService order)
        {
            this._orderService = order;
            this.userService = user;
            this.repository = customerRepository;
            this._productService = productService;
        }

        public async Task<bool> Add_Customer(CreateCustomerDto dto, string role)
        {
            var result = await userService.Add_User(new CreateUserDto() 
            {
                 Name = dto.Name,
                 Username = dto.Username,
                 Password = dto.Password,
                 Email = dto.Email,
                 Role = role
            });

            if(result is false)
            {
                return false;
            }

            User user = await userService.Get_User(dto.Username);


            Customer customer = new() 
            {
                User = user,
                Address = dto.Address
            };

            return await repository.Add(customer);

        }

        public List<ReturnProductDto> GetAllProducts()
        {
            return _productService.Get_Products();
        }

        public async Task<bool> Add_Order(CreateOrderDto createOrder)
        {
            return await _orderService.Add_Order(createOrder);
        }

        public List<ReturnCustomerOrderDto> Get_Orders(string userid)
        {
            List<ReturnCustomerOrderDto> orderDtos = [];

            var items = _orderService.GetOrders(userid);

            foreach(var item in items)
            {
                orderDtos.Add(new() 
                {
                    Price = item.Price,
                    Date = item.Date,
                    OrderItems = item.OrderItems
                });
            }

            return orderDtos;
        }

        public async Task<string> GetId(string username)
        {
            return await repository.GetCustomerId(username);
        }

        public async Task<bool> Update(UpdateCustomerDto updateCustomer)
        {
            var item = await repository.GetByid(updateCustomer.Id);
            item.Address = updateCustomer.Address;
            return await repository.Update(item);
        }

        public List<ReturnCustomerDto> GetAll()
        {
            var items = repository.GetAll();
            List<ReturnCustomerDto> returnCustomers = [];

            foreach(var item in items)
            {
                returnCustomers.Add(new() 
                {
                    Id = item.Id,
                    Address = item.Address
                });
            }

            return returnCustomers;
        }
    }
}
