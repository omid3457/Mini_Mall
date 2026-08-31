using Mini_Mall.DTOs;
using Mini_Mall.Model;

namespace Mini_Mall.Contracts
{
    public interface IUserService
    {
        Task<bool> Add_User(CreateUserDto dto);
        Task<User> Get_User(string username);
        Task<string> Validate_User(UserLoginDto userLogin);
        Task<bool> Update(UpdateUserDto userDto);
        Task<bool> Partial_Update(UpdateUserDto userDto);
        Task<List<ReturnUsersDto>> GeAll();
        Task<bool> Remove(int id);
        Task<bool> Remove(string id);
        Task<bool> Update_Password(UpdateUserPasswordDto passwordDto);
    }
}
