using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mini_Mall.Contracts;
using Mini_Mall.DTOs;
using Mini_Mall.Services;

namespace Mini_Mall.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IUserService service;
        private readonly IProductService _productService;
        private readonly ICustomerService _customerService;
        public AdminController(IUserService userService, IProductService productService, ICustomerService customerService)
        {
            this.service = userService;
            this._productService = productService;
            this._customerService = customerService;
        }

        [HttpPost("Add_User")]
        public async Task<IActionResult> Add_User(CreateUserDto createUser)
        {
            var result = await service.Add_User(createUser);
            
            if(result is false)
            {
                return BadRequest();
            }

            return Created();
        }

        [HttpPost("Add_Customer")]
        public async Task<IActionResult> Add_Customer(CreateCustomerDto customerDto)
        {
            var result = await _customerService.Add_Customer(customerDto, "Customer");

            if (result is false)
            {
                return BadRequest();
            }

            return Created();
        }

        [HttpPost("Add_Products")]
        public async Task<IActionResult> Add_Products(CreateProductsDto productsDto)
        {
            var result = await _productService.AddProduct(productsDto);

            if(result is false)
            {
                return StatusCode(400);
            }

            return Created();
        }

        [HttpGet("Get_Products")]
        public IActionResult Get_Products()
        {
            var item = _productService.Get_Products();

            if (item is null)
            {
                return StatusCode(400);
            }

            return Ok(item);
        }

        [HttpPost("Update_Product")]
        public async Task<IActionResult> Update_Product(UpdateProcuctDto updateProcuct)
        {
            var result = await _productService.Update_Product(updateProcuct);

            if(result is false)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPatch("Partial_Update")]
        public async Task<IActionResult> Partial_Update(UpdateProcuctDto updateProcuct)
        {
            var result = await _productService.Partial_Update_Product(updateProcuct);
            if(result is false)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("Remove_Product")]
        public async Task<IActionResult> Remove_Product(Remove_ProductDto productDto)
        {
            var result = await _productService.Remove_ById(productDto.Id);

            if (result is false)
                return BadRequest();

            return Ok();
        }

        [HttpGet("Get_AllUsers")]
        public async Task<IActionResult> Get_AllUsers()
        {
            var users = await service.GeAll();
            if(users.Count == 0)
            {
                return StatusCode(403);
            }

            return Ok(users);
        }

        [HttpPost("Update_User")]
        public async Task<IActionResult> Update_User(UpdateUserDto updateUserDto)
        {
            var result = await service.Update(updateUserDto);

            if (result is false)
                return BadRequest();

            return Ok();
        }


        [HttpPost("Partial_Update_User")]
        public async Task<IActionResult> Partial_Update_User(UpdateUserDto updateUserDto)
        {
            var result = await service.Partial_Update(updateUserDto);

            if (result is false)
                return BadRequest();

            return Ok();
        }

        [HttpPost("Update_User_Password")]
        public async Task<IActionResult> Update_User_Password(UpdateUserPasswordDto updateUserDto)
        {
            var result = await service.Update_Password(updateUserDto);

            if (result is false)
                return BadRequest();

            return Ok();
        }


        [HttpDelete("Delete_User")]
        public async Task<IActionResult> Delete_User(RemoveUserDto userDto)
        {
            var result = await service.Remove(userDto.Id);

            if (result is false)
                return BadRequest();

            return Ok();
        }

    }
}
