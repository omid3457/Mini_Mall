using Mini_Mall.DTOs;

namespace Mini_Mall.Contracts
{
    public interface IProductService
    {
        Task<int> GetAmount(int id);
        Task<bool> ReduceAmount(int id, int amount);
        Task<decimal> GetPrice(int id);
        List<ReturnProductDto> Get_Products();
        Task<bool> AddProduct(CreateProductsDto productsDto);
        Task<bool> Update_Product(UpdateProcuctDto updateProcuct);
        Task<bool> Partial_Update_Product(UpdateProcuctDto updateProcuct);
        Task<bool> Remove_ById(int id);
    }
}
