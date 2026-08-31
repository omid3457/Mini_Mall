namespace Mini_Mall.DTOs
{
    public record ReturnProductDto
    {
        public int Amount { get; set; } = 0;
        public decimal Price { get; set; }
        public int PruductId { get; set; } = 0;
        public string Name { get; set; } = string.Empty;

    }
}
