using Microsoft.IdentityModel.Tokens;
using Mini_Mall.Contracts;
using Mini_Mall.DTOs;
using Mini_Mall.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Mini_Mall.Services
{
    public class JWTService : IJWTservice
    {
        private readonly IConfiguration _configuration;

        public JWTService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(UserLoginDto user, string role)
        {
            var claims = new List<Claim> 
            {
                new(ClaimTypes.Name, user.Username!),
                new(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(
                _configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(
                    double.Parse(
                        _configuration["Jwt:ExpirationMinutes"]!)),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }
    }
}
