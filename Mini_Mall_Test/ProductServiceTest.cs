using Mini_Mall.Contracts;
using Mini_Mall.DTOs;
using Mini_Mall.Services;
using Mini_Mall.Model;
using Moq;
using Xunit;

namespace Mini_Mall_Test
{
    public class ProductServiceTest
    {
        [Fact]
        public async Task AddProduct_WhenProductIsAdded_ReturnTrue()
        {
            //Arrange

            var repository = new Mock<IProductRepository>();
            repository.Setup(x => x.Add(It.IsAny<Products>()))
                .ReturnsAsync(true);

            CreateProductsDto productsDto = new() 
            {
                Name = "Hour",
                Amount = 2,
                Price = 300
            };

            ProductService productService = new(repository.Object);

            //Act

            var result = await productService.AddProduct(productsDto);

            //Assert

            Assert.True(result);
            repository.Verify(x => x.Add(It.Is<Products>
                       (p =>
                             p.Name == "Hour" &&
                             p.Amount == 2 &&
                             p.Price == 300
                       )),
                        Times.Once
                            );
        }

        [Fact]
        public async Task Get_Products_WhenProductExits_ReturnProducts()
        {
            //Arrange

            List<Products> products = 
                [
                    new()
                    {
                        Id = 1,
                        Name = "kir",
                        Price = 1000,
                        Amount = 10
                    },
                    new()
                    {
                        Id = 2,
                        Name = "kir2",
                        Price = 450,
                        Amount = 7
                    }
                ];

            var repository = new Mock<IProductRepository>();
            repository.Setup(x => x.GetProducts())
                .Returns(products);

            List<ReturnProductDto> productDtos = 
                [
                    new()
                    {
                        PruductId = 1,
                        Name = "kir",
                        Price = 1000,
                        Amount = 10
                    },
                    new()
                    {
                        PruductId = 2,
                        Name = "kir2",
                        Price = 450,
                        Amount = 7
                    }
                ];

            ProductService productService = new(repository.Object);

            //Act

            var result = productService.Get_Products();

            //Assert

            Assert.Equal(productDtos, result);
        }
    }
}