using Mini_Mall.DTOs;

namespace Mini_Mall.Contracts
{
    public interface IJWTservice
    {
        string GenerateToken(UserLoginDto user, string role);
    }
}
