using Mini_Mall.Contracts;
using Mini_Mall.DTOs;
using Mini_Mall.Model;

namespace Mini_Mall.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository repository;
        public ProductService(IProductRepository product)
        {
            this.repository = product;
        }

        public async Task<bool> AddProduct(CreateProductsDto productsDto)
        {
            Products products = new() 
            {
                Name = productsDto.Name,
                Price = productsDto.Price,
                Amount = productsDto.Amount
            };

            return await repository.Add(products);
        }

        public List<ReturnProductDto> Get_Products()
        {
            List<Products> item = repository.GetProducts();
            List<ReturnProductDto> productDtos = [];

            foreach(var product in item)
            {
                productDtos.Add(new ReturnProductDto() 
                {
                    PruductId = product.Id,
                    Amount = product.Amount,
                    Price = product.Price,
                    Name =product.Name
                });
            }

            return productDtos;
        }

        public async Task<int> GetAmount(int id)
        {
            var result = await repository.ProductAmount(id);
            return result;
        }

        public async Task<bool> ReduceAmount(int id, int amount)
        {
            return await repository.ReduceAmount(id, amount);
        }

        public async Task<decimal> GetPrice(int id)
        {
            return await repository.GetPrice(id);
        }

        public async Task<bool> Update_Product(UpdateProcuctDto updateProcuct)
        {
            Products product = new()
            {
                Id = updateProcuct.Id,
                Name = updateProcuct.Name!,
                Price = (decimal)updateProcuct.Price!,
                Amount = (int)updateProcuct.Amount!
            };

            return await repository.Update(product);
        }

        public async Task<bool> Partial_Update_Product(UpdateProcuctDto updateProcuct)
        {
            return await repository.Partial_Update(updateProcuct);
        }

        public async Task<bool> Remove_ById(int id)
        {
            return await repository.Remove(id);
        }
    }
}
