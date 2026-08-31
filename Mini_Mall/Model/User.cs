using Microsoft.AspNetCore.Identity;

namespace Mini_Mall.Model
{
    public class User: IdentityUser
    {
        public string Name { get; set; } = string.Empty;
        public List<Order> Orders { get; set; } = [];
    }
}
