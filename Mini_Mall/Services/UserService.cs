using Microsoft.AspNetCore.Identity;
using Mini_Mall.DTOs;
using Mini_Mall.Model;
using Mini_Mall.Contracts;

namespace Mini_Mall.Services
{
    public class UserService : IUserService
    {
        private readonly IUserrepository repository;
        private readonly IJWTservice jWTService;

        public UserService(IUserrepository userRepository, IJWTservice jWT)
        {
            this.repository = userRepository;
            this.jWTService = jWT;
        }


        public async Task<bool> Add_User(CreateUserDto dto)
        {
            User user = new() 
            {
                Name = dto.Name,
                UserName = dto.Username,
                Email = dto.Email,
                PasswordHash = dto.Password
            };

            bool result = await repository.Add(user);

            if(result is false)
            {
                return false;
            }

            result = await repository.AddRole(user, dto.Role);
            return result;
        }

        public async Task<string> Validate_User(UserLoginDto userLogin)
        {
            bool result = await repository.ValidateUser(userLogin);

            if(result is false)
            {
                return null!;
            }

            string token = jWTService.GenerateToken(userLogin, await repository.GetRole(userLogin));

            return token;
        }

        public async Task<User> Get_User(string username)
        {
            return await repository.GetByUsername(username);
        }

        public async Task<bool> Update(UpdateUserDto userDto)
        {
            User user = await repository.GetByid(userDto.Id);

            user.Name = userDto.Name!;
            user.UserName = userDto.UserName!;
            user.Email = userDto.Email;
            user.PhoneNumber = userDto.PhoneNumber!;

            return await repository.Update(user);
        }

        public async Task<bool> Partial_Update(UpdateUserDto userDto)
        {
            return await repository.Partial_Update(userDto);
        }

        public async Task<List<ReturnUsersDto>> GeAll()
        {
            var users = repository.GetAll();

            List<ReturnUsersDto> returnUsers = [];

            foreach(var item in users)
            {
                var role = await repository.GetRole(item.UserName!);

                returnUsers.Add(new() 
                {
                    Id = item.Id,
                    Name = item.Name,
                    Username = item.UserName!,
                    PhoneNumber = item.PhoneNumber!,
                    Role = role
                });
            }


            return returnUsers;
        }

        public async Task<bool> Remove(string id)
        {
            return await repository.Remove(id);
        }

        public async Task<bool> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update_Password(UpdateUserPasswordDto passwordDto)
        {
            return await repository.Update_Password(passwordDto);
        }
    }
}
