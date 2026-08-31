using Mini_Mall.Model;

namespace Mini_Mall.DTOs
{
    public class CreateOrderDto
    {
        public required List<CreateOrderItemDto> OrderItems { get; set; }
        public required string UserUsername { get; set; }
        public DateTime Date { get; set; }

    }
}
