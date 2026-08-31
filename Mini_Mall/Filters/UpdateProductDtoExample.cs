using Mini_Mall.DTOs;
using Swashbuckle.AspNetCore.Filters;

namespace Mini_Mall.Filters
{
    public class UpdateProductDtoExample
        : IExamplesProvider<UpdateProcuctDto>
    {
        public UpdateProcuctDto GetExamples()
        {
            return new UpdateProcuctDto
            {
                Name = null,
                Price = null,
                Amount = null
            };
        }
    }
}
