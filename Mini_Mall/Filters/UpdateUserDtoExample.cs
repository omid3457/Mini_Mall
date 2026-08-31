using Mini_Mall.DTOs;
using Swashbuckle.AspNetCore.Filters;

namespace Mini_Mall.Filters
{
    public class UpdateUserDtoExample : IExamplesProvider<UpdateUserDto>
    {
        public UpdateUserDto GetExamples()
        {
            return new UpdateUserDto()
            {
                Id = "",
                UserName = null,
                Name = null,
                Email = null,
                PhoneNumber = null,
            };

        }
    }
}
