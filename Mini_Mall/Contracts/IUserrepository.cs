using Microsoft.EntityFrameworkCore;
using Mini_Mall.DTOs;
using Mini_Mall.Model;

namespace Mini_Mall.Contracts
{
    public interface IUserrepository: IRepository<User>
    {
        Task<bool> ValidateUser(UserLoginDto item);
        Task<bool> AddRole(User user, string role);
        Task<string> GetRole(UserLoginDto user);
        Task<string> GetRole(string username);
        Task<User> GetByUsername(string username);
        Task<bool> Set_Order(string username, Order order);
        Task<bool> Partial_Update(UpdateUserDto userDto);
        List<User> GetAll();
        Task<User> GetByid(string id);
        Task<bool> Remove(string Id);
        Task<bool> Update_Password(UpdateUserPasswordDto passwordDto);
    }
}
