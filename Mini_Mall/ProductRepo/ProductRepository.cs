using Microsoft.EntityFrameworkCore;
using Mini_Mall.Contracts;
using Mini_Mall.Data;
using Mini_Mall.DTOs;
using Mini_Mall.Model;

namespace Mini_Mall.ProductRepo
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext context;
        public ProductRepository(AppDbContext appDb)
        {
            this.context = appDb;
        }
        public async Task<bool> Add(Products item)
        {
            await context.Products.AddAsync(item);

            var result = await context.SaveChangesAsync();

            return result > 0;
        }

        public Task<Products> GetByid(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<decimal> GetPrice(int id)
        {
            decimal price = await context.Products.Where(p => p.Id == id).Select(p => p.Price).FirstOrDefaultAsync();
            return price;
        }

        public List<Products> GetProducts()
        {
            List<Products> products = [];

            products = [.. context.Products];

            return products;
        }

        public async Task<bool> Partial_Update(UpdateProcuctDto procuctDto)
        {
            Products? product = await context.Products.FirstOrDefaultAsync(p => p.Id == procuctDto.Id);
            ArgumentNullException.ThrowIfNull(product);

            if(procuctDto.Name is not null)
            {
                product.Name = procuctDto.Name;
            }
            
            if(procuctDto.Price is not null)
            {
                product.Price = (decimal)procuctDto.Price;
            }

            if(procuctDto.Amount is not null)
            {
                product.Amount = (int)procuctDto.Amount;
            }

            var result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<int> ProductAmount(int id)
        {
            return await context.Products.Where(p => p.Id == id).Select(p => p.Amount).FirstOrDefaultAsync();
        }

        public async Task<bool> ReduceAmount(int id, int amount)
        {
            Products? item = await context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if(item is null)
            {
                return false;
            }

            item.Amount = item.Amount - amount;
            context.Products.Update(item);

            var result = await context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> Remove(int id)
        {
            Products? product = await context.Products.FirstOrDefaultAsync(p => p.Id == id);

            ArgumentNullException.ThrowIfNull(product);

            context.Products.Remove(product);
            var result = await context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> Update(Products item)
        {
            //Products? product = await context.Products.FirstOrDefaultAsync(p => p.Id == item.Id);
            //ArgumentNullException.ThrowIfNull(product);

            context.Products.Update(item);

            var result = await context.SaveChangesAsync();
            return result > 0;
        }
    }
}
