using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mini_Mall.Contracts;
using Mini_Mall.DTOs;
using Mini_Mall.Services;

namespace Mini_Mall.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AcountController : ControllerBase
    {
        private readonly IUserService service;
        public AcountController(IUserService user)
        {
            this.service = user;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto loginDto)
        {
            string token = await service.Validate_User(loginDto);

            if(token is null)
            {
                return Unauthorized();
            }

            return Ok(new
            {
                token
            });
        }
    }
}
