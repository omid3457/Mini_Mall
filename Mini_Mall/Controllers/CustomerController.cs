using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mini_Mall.Contracts;
using Mini_Mall.DTOs;
using Mini_Mall.Services;

namespace Mini_Mall.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService service;
        private readonly IUserService userService;
        private string GetUsername() => User.Identity!.Name!;

        public CustomerController(ICustomerService customer, IUserService service)
        {
            this.service = customer;
            this.userService = service;
        }

        [HttpGet("Get_Products")]
        public IActionResult Get_Products()
        {
            var item = service.GetAllProducts();

            if(item is null)
            {
                return StatusCode(503);
            }

            return Ok(item);
        }

        [HttpPost("Add_Order")]
        public async Task<IActionResult> Add_Order(CreateOrderDto createOrder)
        {
            var _Username = GetUsername();
            createOrder.UserUsername = _Username;

            var result = await service.Add_Order(createOrder);

            if(result is false)
            {
                return StatusCode(503);
            }

            return Ok();
        }

        [HttpGet("Get_Orders")]
        public async Task<IActionResult> Get_Orders()
        {
            string _username = GetUsername();

            var customerid = await userService.Get_User(_username);

            var item = service.Get_Orders(customerid.Id);
            if(item.Count == 0)
            {
                return NoContent();
            }

            return Ok(item);
        }

        [HttpGet("Get_All")]
        public IActionResult Get_All()
        {
            var item = service.GetAll();
            if (item.Count == 0)
                return NoContent();

            return Ok(item);
        }

        [HttpPost("Update_Customer")]
        public async Task<IActionResult> Update_Customer(UpdateCustomerDto dto)
        {
            var result = await service.Update(dto);

            if (result is false)
                return BadRequest();

            return Ok();
        }
    }
}
