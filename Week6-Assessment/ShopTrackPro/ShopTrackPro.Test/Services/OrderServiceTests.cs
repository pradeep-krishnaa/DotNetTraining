using AutoMapper;
using Moq;
using ShopTrackPro.Core.DTOs;
using ShopTrackPro.Application.Services;
using ShopTrackPro.Core.DTOs;
using ShopTrackPro.Core.Entities;
using ShopTrackPro.Core.Interfaces;
using Xunit;

namespace ShopTrackPro.Tests.Services
{
    public class OrderServiceTests
    {
        private readonly Mock<IOrderRepository> _mockRepo;
        private readonly Mock<IMapper> _mockMapper;
        private readonly OrderService _service;

        public OrderServiceTests()
        {
            _mockRepo = new Mock<IOrderRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new OrderService(_mockRepo.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetOrderByIdAsync_ShouldReturnMappedOrder_WhenOrderExists()
        {
            // Arrange
            var order = new Order { Id = 1, Status = "Pending", User = new User { UserName = "John" } };
            var orderDto = new OrderResponseDTO { Id = 1, Status = "Pending", UserName = "John" };

            _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(order);
            _mockMapper.Setup(m => m.Map<OrderResponseDTO?>(order)).Returns(orderDto);

            // Act
            var result = await _service.GetOrderByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Pending", result.Status);
            _mockRepo.Verify(r => r.GetByIdAsync(1), Times.Once);
        }

        [Fact]
        public async Task AddOrderAsync_ShouldSaveOrderWithItems()
        {
            // Arrange
            var request = new OrderRequestDTO
            {
                UserId = 1,
                Items = new List<OrderItemRequestDTO>
                {
                    new OrderItemRequestDTO { ProductId = 10, Quantity = 2 }
                }
            };

            // Act
            await _service.AddOrderAsync(request);

            // Assert
            _mockRepo.Verify(r => r.AddAsync(It.Is<Order>(o =>
                o.UserId == 1 &&
                o.OrderItems.Count == 1 &&
                o.OrderItems.First().ProductId == 10
            )), Times.Once);
        }

        [Fact]
        public async Task DeleteOrderAsync_ShouldCallRepositoryDelete()
        {
            // Arrange
            int orderId = 5;

            // Act
            await _service.DeleteOrderAsync(orderId);

            // Assert
            _mockRepo.Verify(r => r.DeleteAsync(orderId), Times.Once);
        }
    }
}
