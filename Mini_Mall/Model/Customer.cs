using System.ComponentModel.DataAnnotations;

namespace Mini_Mall.Model
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required User User { get; set; }

        public string Address { get; set; } = string.Empty;

        public Order? Order { get; set; }
    }
}
