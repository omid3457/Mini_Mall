namespace Mini_Mall.DTOs
{
    public class UpdateUserDto
    {
        public required string Id { get; set; }
        public string? Name { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
