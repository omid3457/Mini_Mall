using Microsoft.EntityFrameworkCore;

namespace Mini_Mall.DTOs
{
    public class CreateProductsDto
    {
        public int Amount { get; set; } = 0;
        public decimal Price { get; set; } = 0.0m;
        public string Name { get; set; } = string.Empty;

    }
}
