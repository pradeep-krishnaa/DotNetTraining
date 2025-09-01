using AutoMapper;
using Moq;
using ShopTrackPro.Core.DTOs;
using ShopTrackPro.Infrastructure.Repositories;
using ShopTrackPro.Application.Services;
using ShopTrackPro.Core.Entities;
using ShopTrackPro.Core.Interfaces;
using Xunit;

namespace ShopTrackPro.Tests.Services
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _mockRepo;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ProductService _service;

        public ProductServiceTests()
        {
            _mockRepo = new Mock<IProductRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new ProductService(_mockRepo.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAllProductsAsync_ShouldReturnMappedProducts()
        {
            // Arrange
            var products = new List<Product> { new Product { Id = 1, Name = "Laptop" } };
            var productDtos = new List<ProductResponseDTO> { new ProductResponseDTO { Id = 1, Name = "Laptop" } };

            _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(products);
            _mockMapper.Setup(m => m.Map<List<ProductResponseDTO>>(products)).Returns(productDtos);

            // Act
            var result = await _service.GetAllProductsAsync();

            // Assert
            Assert.Single(result);
            Assert.Equal("Laptop", result[0].Name);
            _mockRepo.Verify(r => r.GetAllAsync(), Times.Once);
        }

        [Fact]
        public async Task AddProductAsync_ShouldCallRepositoryAdd()
        {
            // Arrange
            var request = new ProductRequestDTO { Name = "Phone", Description = "Smartphone", Price = 500, Category = "Electronics" };
            var product = new Product { Id = 2, Name = "Phone" };

            _mockMapper.Setup(m => m.Map<Product>(request)).Returns(product);

            // Act
            await _service.AddProductAsync(request);

            // Assert
            _mockRepo.Verify(r => r.AddAsync(It.Is<Product>(p => p.Name == "Phone")), Times.Once);
        }
    }
}
