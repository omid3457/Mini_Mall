using Swashbuckle.AspNetCore.Annotations;
using Mini_Mall.Filters;
namespace Mini_Mall.DTOs
{
    public class UpdateProcuctDto
    {
        public int Id { get; set; }
        public int? Amount { get; set; }
        public decimal? Price { get; set; }
        public string? Name { get; set; }

    }
}
