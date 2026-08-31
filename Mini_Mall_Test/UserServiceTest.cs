using Mini_Mall.Contracts;
using Mini_Mall.DTOs;
using Mini_Mall.Services;
using Mini_Mall.Model;
using Moq;
using Xunit;


namespace Mini_Mall_Test
{
    public class UserServiceTest
    {
        [Fact]
        public async Task Add_User_WhenUserIsAdded_ReturnsTrue()
        {
            //Arrange

            var repository = new Mock<IUserrepository>();
            repository.Setup(r => r.Add(It.IsAny<User>()))
                .ReturnsAsync(true);

            repository.Setup(r => r.AddRole(It.IsAny<User>(), "Admin"))
                .ReturnsAsync(true);

            var jwt = new Mock<IJWTservice>();

            CreateUserDto userDto = new() 
            {
                Name = "Omid",
                Username = "docomid",
                Email = "",
                Password = "1234",
                Role = "Admin"
            };

            UserService userService = new(repository.Object, jwt.Object);

            //Act

            var result = await userService.Add_User(userDto);

            //Assert

            Assert.True(result);
            repository.Verify(u => u.Add(It.Is<User>(
                u => u.Name == "Omid"
                && u.UserName == "docomid"
                && u.PasswordHash == "1234"
                && u.Email == ""
                )));
        }
    }
}
