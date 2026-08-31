using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Mini_Mall.Model
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public required string UserId { get; set; }
        public required User User { get; set; }
        [Precision(6, 2)]
        public decimal Price { get; set; }
        [Required]
        public required List<OrderItem> OrderItems { get; set; }
        public DateTime Date { get; set; }
    }
}
