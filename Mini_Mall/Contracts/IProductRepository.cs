using Mini_Mall.DTOs;
using Mini_Mall.Model;

namespace Mini_Mall.Contracts
{
    public interface IProductRepository: IRepository<Products>
    {
        public List<Products> GetProducts();
        public Task<int> ProductAmount(int id);
        public Task<bool> ReduceAmount(int id, int amount);
        public Task<decimal> GetPrice(int id);
        public Task<bool> Partial_Update(UpdateProcuctDto procuctDto);
    }
}
