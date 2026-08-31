using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Mini_Mall.Model
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        public int Amount { get; set; } = 0;
        [Precision(6, 2)]
        public decimal Price { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
