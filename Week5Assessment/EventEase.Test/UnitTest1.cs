using AutoMapper;
using EventEase.Application.Services;
using EventEase.Core.DTOs;
using EventEase.Core.Entities;
using EventEase.Core.Exceptions;
using EventEase.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using EventEase.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace EventEase.Test
{
    public class RegistrationServiceTests
    {
        private readonly Mock<IRegistrationRepository> _mockRepo;
        private readonly IMapper _mapper;
        private readonly DbContextOptions<EventEase.Infrastructure.Data.AppDbContext> _dbOptions;

        public RegistrationServiceTests()
        {
            _mockRepo = new Mock<IRegistrationRepository>();

            // AutoMapper config
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RegistrationRequestDTO, Registration>();
                cfg.CreateMap<Registration, RegistrationResponseDTO>();
            });
            _mapper = config.CreateMapper();

            // InMemory EF for testing DbContext dependency
            _dbOptions = new DbContextOptionsBuilder<EventEase.Infrastructure.Data.AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
        }

        [Fact]
        public async Task RegisterUserForEventAsync_Should_Add_Registration_When_Valid()
        {
            // Arrange
            using var context = new EventEase.Infrastructure.Data.AppDbContext(_dbOptions);
            context.Users.Add(new User { Id = 1, Name = "TestUser" });
            context.Event.Add(new Event { Id = 1, Title = "Test Event" });
            context.SaveChanges();

            var service = new RegistrationService(_mockRepo.Object, _mapper, context);

            var dto = new RegistrationRequestDTO { UserId = 1, EventId = 1 };

            // Act
            await service.RegisterUserForEventAsync(dto);

            // Assert
            _mockRepo.Verify(r => r.AddAsync(It.IsAny<Registration>()), Times.Once);
        }

        [Fact]
        public async Task RegisterUserForEventAsync_Should_Throw_InvalidRegistration_When_UserOrEvent_NotFound()
        {
            // Arrange
            using var context = new EventEase.Infrastructure.Data.AppDbContext(_dbOptions);
            var service = new RegistrationService(_mockRepo.Object, _mapper, context);

            var dto = new RegistrationRequestDTO { UserId = 99, EventId = 99 };

            // Act & Assert
            await Assert.ThrowsAsync<InvalidRegistration>(() => service.RegisterUserForEventAsync(dto));
        }

        [Fact]
        public async Task GetRegistrationsByEventIdAsync_Should_Return_List()
        {
            // Arrange
            var registrations = new List<Registration>
            {
                new Registration { Id = 1, UserId = 1, EventId = 1 },
                new Registration { Id = 2, UserId = 2, EventId = 1 }
            };

            _mockRepo.Setup(r => r.GetRegistrationsByEventIdAsync(1))
                     .ReturnsAsync(registrations);

            var service = new RegistrationService(_mockRepo.Object, _mapper, new EventEase.Infrastructure.Data.AppDbContext(_dbOptions));

            // Act
            var result = await service.GetRegistrationsByEventIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }
    }
}
