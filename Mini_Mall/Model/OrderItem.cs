using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Mini_Mall.Model
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public int Amount { get; set; } = 0;
        public Order? Order { get; set; }
        [Required]
        public required int ProductId { get; set; }
    }
}
