using Mini_Mall.Model;

namespace Mini_Mall.DTOs
{
    public class ReturnCustomerOrderDto
    {
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public List<OrderItem> OrderItems { get; set; } = [];
    }
}
