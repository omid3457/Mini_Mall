using Mini_Mall.Contracts;
using Mini_Mall.Data;
using Mini_Mall.DTOs;
using Mini_Mall.Model;

namespace Mini_Mall.Services
{
    public class OrderService: IOrderService
    {
        private readonly IOrderRepository repository;
        private readonly IProductService _productService;
        private readonly IUserrepository _userrepository;

        public OrderService(IOrderRepository orderRepository, IProductService productService, IUserrepository userrepository)
        {
            this._productService = productService;
            this._userrepository = userrepository;
            this.repository = orderRepository;
        }

        public async Task<bool> Add_Order(CreateOrderDto dto)
        {
            List<OrderItem> orderItems = [];
            User user = await _userrepository.GetByUsername(dto.UserUsername);

            Order order = new() 
            {
                UserId = user.Id,
                User = user,
                OrderItems = []
            };

            decimal totalprice = 0;

            foreach(var item in dto.OrderItems)
            {
                var amount = await _productService.GetAmount(item.ProductId);

                if(amount - item.Amount < 0)
                {
                    return false;
                }

                _ = await _productService.ReduceAmount(item.ProductId, item.Amount);
                var price =  await _productService.GetPrice(item.ProductId);
                price = price * item.Amount;
                totalprice += price;


                orderItems.Add(new OrderItem() 
                {
                    Order = order,
                    ProductId = item.ProductId,
                    Amount = item.Amount,
                });

                order.OrderItems = orderItems;
                order.Price = totalprice;            }

            return await _userrepository.Set_Order(dto.UserUsername, order);
        }

        public List<Order> GetOrders(string userid)
        {
            return repository.GetUserOrders(userid);
        }
    }
}
