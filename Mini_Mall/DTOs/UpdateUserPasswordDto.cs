namespace Mini_Mall.DTOs
{
    public class UpdateUserPasswordDto
    {
        public required string Id { get; set; }
        public required string OldPassword { get; set; }
        public required string NewPassword { get; set; }


    }
}
