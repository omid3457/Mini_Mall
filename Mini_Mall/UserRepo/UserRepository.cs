using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Mini_Mall.Contracts;
using Mini_Mall.Data;
using Mini_Mall.DTOs;
using Mini_Mall.Model;

namespace Mini_Mall.UserRepo
{
    public class UserRepository : IUserrepository
    {
        private readonly AppDbContext context;
        private readonly UserManager<User> userManager;

        public UserRepository(AppDbContext dbContext, UserManager<User> manager)
        {
            this.context = dbContext;
            this.userManager = manager;
        }

        public async Task<bool> AddRole(User user, string role)
        {
            var result = await userManager.AddToRoleAsync(user, role);

            return result.Succeeded;
        }

        public async Task<bool> Add(User item)
        {
            var result = await userManager.CreateAsync(item, item.PasswordHash!);

            return result.Succeeded;
        }

        public async Task<User> GetByid(int id)
        {
            User? user = await userManager.FindByIdAsync(id.ToString());
            ArgumentNullException.ThrowIfNull(user);

            return user;
        }

        public async Task<User> GetByid(string id)
        {
            User? user = await userManager.FindByIdAsync(id.ToString());
            ArgumentNullException.ThrowIfNull(user);

            return user;
        }

        public async Task<bool> Remove(int id)
        {
            User? user = await userManager.FindByIdAsync(id.ToString());
            ArgumentNullException.ThrowIfNull(user);

            var result = await userManager.DeleteAsync(user);
            return result.Succeeded;
        }

        public async Task<bool> Update(User item)
        {
            var result = await userManager.UpdateAsync(item);
            return result.Succeeded;
        }

        public async Task<bool> ValidateUser(UserLoginDto user)
        {
            var item = await userManager.FindByNameAsync(user.Username);

            if(item is null)
            {
                return false;
            }

            var result = await userManager.CheckPasswordAsync(item, user.Password!);

            if(result is false)
            {
                return false;
            }

            return true;
        }

        public async Task<string> GetRole(UserLoginDto user)
        {
            User? item = await userManager.FindByNameAsync(user.Username);

            var role = await userManager.GetRolesAsync(item!);
            return role[0];
            
        }

        public async Task<User> GetByUsername(string username)
        {
            User? user = await userManager.FindByNameAsync(username);
            ArgumentNullException.ThrowIfNull(user);

            return user;
        }

        public async Task<bool> Set_Order(string username, Order order)
        {
            User? user = await context.Users.FirstOrDefaultAsync(u => u.UserName == username);
            ArgumentNullException.ThrowIfNull(user);

            user.Orders.Add(order);
            var result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> Partial_Update(UpdateUserDto userDto)
        {
            User? user = await userManager.FindByIdAsync(userDto.Id);
            ArgumentNullException.ThrowIfNull(user);

            if(userDto.Name is not null)
            {
                user.Name = userDto.Name!;
            }

            if(userDto.Email is not null)
            {
                user.Email = userDto.Email;
            }

            if(userDto.PhoneNumber is not null)
            {
                user.PhoneNumber = userDto.PhoneNumber;
            }

            if (userDto.UserName is not null)
            {
                user.UserName = userDto.UserName;
            }

            var result = await userManager.UpdateAsync(user);
            return result.Succeeded;
        }

        public List<User> GetAll()
        {
            return userManager.Users.ToList();
        }

        public async Task<bool> Remove(string Id)
        {
            User? user = await userManager.FindByIdAsync(Id);
            ArgumentNullException.ThrowIfNull(user);

            var result = await userManager.DeleteAsync(user);
            return result.Succeeded;

        }

        public async Task<bool> Update_Password(UpdateUserPasswordDto passwordDto)
        {
            User? user = await userManager.FindByIdAsync(passwordDto.Id);
            ArgumentNullException.ThrowIfNull(user);

            var result = await userManager.ChangePasswordAsync(user, passwordDto.OldPassword, passwordDto.NewPassword);

            return result.Succeeded;
        }

        public async Task<string> GetRole(string username)
        {
            User? user = await userManager.FindByNameAsync(username);
            ArgumentNullException.ThrowIfNull(user);

            var item = await userManager.GetRolesAsync(user);

            return item[0];
        }
    }
}
