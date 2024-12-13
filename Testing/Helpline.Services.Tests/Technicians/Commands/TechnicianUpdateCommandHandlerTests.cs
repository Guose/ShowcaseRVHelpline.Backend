using AutoMapper;
using FluentAssertions;
using Helpline.API.Gateway.MappingProfiles;
using Helpline.Contracts.v1.Requests;
using Helpline.Domain.Data;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.Errors;
using Helpline.Domain.Models.Entities;
using Helpline.Domain.Shared;
using Helpline.Services.Users.Technicians.Commands;
using Helpline.Services.Users.Technicians.Commands.Handlers;
using Moq;

namespace Helpline.Services.Tests.Technicians.Commands
{
    public class TechnicianUpdateCommandHandlerTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly IMapper _mapper;
        private readonly Mock<ITechnicianRepository> _technicianRepoMock;

        public TechnicianUpdateCommandHandlerTests()
        {
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<RequestToDomain>());

            _mapper = mapperConfiguration.CreateMapper();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _technicianRepoMock = new Mock<ITechnicianRepository>();
        }

        [Fact]
        public async Task Handler_Should_ReturnSuccessResult_OnTechnicianUpdate_WhenUserIsFound()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var command = new TechnicianUpdateCommand(
                userId,
                "Company-A",
                "Code123",
                true,
                string.Empty);

            var existingUser = new ApplicationUser()
            {
                Id = userId.ToString(),
                FirstName = "Last",               // Existing values before update
                LastName = "First",
            };

            var existingTechnician = new Technician()
            {
                UserId = existingUser.Id,
                User = existingUser
            };

            _technicianRepoMock.Setup(
                x => x.GetTechnicianByUserIdAsync(
                    It.Is<string>(id => id == userId.ToString()),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(existingTechnician);

            _technicianRepoMock.Setup(u => u.UpdateEntityAsync(
                It.IsAny<Technician>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(Result.Success());

            _unitOfWorkMock.Setup(u => u.CompleteAsync(It.IsAny<CancellationToken>()))
                   .ReturnsAsync(true);

            var handler = new TechnicianUpdateCommandHandler(
                _unitOfWorkMock.Object,
                _mapper,
                _technicianRepoMock.Object);

            // Act
            Result result = await handler.Handle(command, default);

            // Assert
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Handler_Should_ReturnError_WhenUserIsNotFound()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var command = new TechnicianUpdateCommand(
                userId,
                "Company-A",
                "Code123",
                true,
                string.Empty);

            _technicianRepoMock.Setup(
                x => x.GetTechnicianByUserIdAsync(
                    It.Is<string>(id => id == command.UserId.ToString()),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => null!);

            var handler = new TechnicianUpdateCommandHandler(
                _unitOfWorkMock.Object,
                _mapper,
                _technicianRepoMock.Object);

            // Act
            Result result = await handler.Handle(command, default);

            // Assert
            result.Error.Should().Be(DomainErrors.User.NotFound(command.UserId));

            _technicianRepoMock.Verify(x =>
                x.UpdateEntityAsync(It.IsAny<Technician>(), It.IsAny<CancellationToken>()), Times.Never);

            _unitOfWorkMock.Verify(x =>
                x.CompleteAsync(It.IsAny<CancellationToken>()), Times.Never());
        }

        [Fact]
        public async Task Handle_Should_Not_CallUnitOfWork_WhenMappingTechnicianFails()
        {
            // Arrange
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                //cfg.AddProfile<RequestToDomain>();

                // Add a custom mapping for EmployeeRequest to Employee that always returns null
                cfg.CreateMap<TechnicianRequest, Technician>()
                    .ConvertUsing(src => null!);
            });

            var mapper = mapperConfiguration.CreateMapper();

            var userId = Guid.NewGuid();
            var command = new TechnicianUpdateCommand(
                userId,
                "Company-A",
                "Code123",
                true,
                string.Empty);

            var existingUser = new ApplicationUser()
            {
                Id = userId.ToString(),
                FirstName = "Last",
                LastName = "First",
            };

            var existingTechnician = new Technician()
            {
                UserId = existingUser.Id,
                User = existingUser
            };

            _technicianRepoMock.Setup(
                x => x.GetTechnicianByUserIdAsync(
                    It.Is<string>(id => id == userId.ToString()),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(existingTechnician);

            var handler = new TechnicianUpdateCommandHandler(
                _unitOfWorkMock.Object,
                mapper,
                _technicianRepoMock.Object);

            // Act
            Result result = await handler.Handle(command, default);

            // Assert
            _technicianRepoMock.Verify(x =>
            x.UpdateEntityAsync(It.IsAny<Technician>(), CancellationToken.None), Times.Never());

            _unitOfWorkMock.Verify(x =>
                x.CompleteAsync(It.IsAny<CancellationToken>()), Times.Never());

            Assert.False(result.IsSuccess);
            Assert.NotNull(result.Error);
            Assert.Equal("Technician.Mapping", result.Error.Code);
            Assert.Equal("Failed to map TechnicianRequest to Technician.", result.Error.Message);
        }

        [Fact]
        public async Task Handle_Should_Not_CallUnitOfWork_WhenUpdateTechnicianFails()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var command = new TechnicianUpdateCommand(
                userId,
                "Company-A",
                "Code123",
                true,
                string.Empty);

            var existingUser = new ApplicationUser()
            {
                Id = command.UserId.ToString(),
                FirstName = "Last",               // Existing values before update
                LastName = "First",
            };

            var existingTechnician = new Technician()
            {
                UserId = existingUser.Id,
                User = existingUser
            };

            _technicianRepoMock.Setup(
                x => x.GetTechnicianByUserIdAsync(
                    It.Is<string>(id => id == command.UserId.ToString()),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(existingTechnician);

            _technicianRepoMock.Setup(u => u.UpdateEntityAsync(
                It.IsAny<Technician>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(Result.Failure(new Error("", "")));

            var handler = new TechnicianUpdateCommandHandler(
                _unitOfWorkMock.Object,
                _mapper,
                _technicianRepoMock.Object);

            // Act
            Result result = await handler.Handle(command, default);

            // Assert
            _unitOfWorkMock.Verify(x =>
                x.CompleteAsync(It.IsAny<CancellationToken>()), Times.Never());

            Assert.False(result.IsSuccess);

            Assert.NotNull(result.Error);
            Assert.Equal("Technician.UpdateUserInfo", result.Error.Code);
            Assert.Equal($"UpdateUserInfo to technician profile {userId} could not be completed.", result.Error.Message);
        }
    }
}
