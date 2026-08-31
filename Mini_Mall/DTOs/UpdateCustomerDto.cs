namespace Mini_Mall.DTOs
{
    public class UpdateCustomerDto
    {
        public required int Id { get; set; }
        public string Address { get; set; } = string.Empty;
    }
}
