using AutoMapper;
using FluentAssertions;
using Helpline.Domain.Data;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.Errors;
using Helpline.Domain.Models.Entities;
using Helpline.Domain.Shared;
using Helpline.Services.Users.Addresses.Commands;
using Helpline.WebAPI.MappingProfiles;
using Moq;

namespace Helpline.Services.Tests.Addresses.Commands
{
    public class AddressUpdateCommandHandlerTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly IMapper _mapper;
        private readonly Mock<IAddressRepository> _addressRepoMock;
        private readonly Mock<IApplicationUserRepository> _userRepoMock;

        public AddressUpdateCommandHandlerTests()
        {
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<RequestToDomain>());
            _mapper = mapperConfiguration.CreateMapper();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _addressRepoMock = new Mock<IAddressRepository>();
            _userRepoMock = new Mock<IApplicationUserRepository>();
        }

        [Fact]
        public async Task Handler_Should_ReturnSuccessResult_WhenUserIsFound()
        {
            // Arrange
            var command = new AddressUpdateCommand(
                Guid.Parse("F759B392-3461-48E7-A687-21499EFE0301"),
                "123 Main St",
                string.Empty,
                "Anytown",
                "AS",
                "12345");

            var existingUser = new ApplicationUser()
            {
                Id = command.UserId.ToString(),
                FirstName = "Last",               // Existing values before update
                LastName = "First",
                PhoneNumber = "5555555555",
                SecondaryPhone = "6664445555",
                Address = new Address()
                {
                    Id = 1,
                    Address1 = command.Address1,
                    Address2 = command.Address2,
                    City = command.City,
                    State = command.State,
                    PostalCode = command.PostalCode,
                },
                AddressId = 1
            };

            _userRepoMock.Setup(
                x => x.GetEntityByIdAsync(
                    It.Is<string>(id => id == command.UserId.ToString()),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(existingUser);

            _addressRepoMock.Setup(u => u.CreateEntityAsync(
                It.IsAny<Address>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            _unitOfWorkMock.Setup(u => u.CompleteAsync(It.IsAny<CancellationToken>()))
                   .ReturnsAsync(true);

            var handler = new AddressUpdateCommandHandler(
                _unitOfWorkMock.Object,
                _mapper,
                _addressRepoMock.Object,
                _userRepoMock.Object);

            // Act
            Result result = await handler.Handle(command, default);

            // Assert
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Handler_Should_CallCreateOnRepository_WhenUserIsFound()
        {
            // Arrange
            var command = new AddressUpdateCommand(
                Guid.Parse("F759B392-3461-48E7-A687-21499EFE0301"),
                "123 Main St",
                string.Empty,
                "Anytown",
                "AS",
                "12345");

            var existingUser = new ApplicationUser()
            {
                Id = command.UserId.ToString(),
                FirstName = "Last",               // Existing values before update
                LastName = "First",
                PhoneNumber = "5555555555",
                SecondaryPhone = "6664445555",
                Address = new Address()
                {
                    Id = 1,
                    Address1 = command.Address1,
                    Address2 = command.Address2,
                    City = command.City,
                    State = command.State,
                    PostalCode = command.PostalCode,
                },
                AddressId = 1
            };

            _userRepoMock.Setup(
                x => x.GetEntityByIdAsync(
                    It.Is<string>(id => id == command.UserId.ToString()),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(existingUser);

            _addressRepoMock.Setup(u => u.CreateEntityAsync(
                It.IsAny<Address>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            _unitOfWorkMock.Setup(u => u.CompleteAsync(It.IsAny<CancellationToken>()))
                   .ReturnsAsync(true);

            var handler = new AddressUpdateCommandHandler(
                _unitOfWorkMock.Object,
                _mapper,
                _addressRepoMock.Object,
                _userRepoMock.Object);

            // Act
            Result result = await handler.Handle(command, default);

            // Assert
            result.IsSuccess.Should().BeTrue();

            _addressRepoMock.Verify(u => u.CreateEntityAsync(
                It.Is<Address>(x =>
                    x.Address1 == command.Address1 &&
                    x.Address2 == command.Address2 &&
                    x.City == command.City &&
                    x.State == command.State &&
                    x.PostalCode == command.PostalCode),
                It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task Handle_Should_Not_CallUnitOfWork_WhenCreateAddressFails()
        {
            // Arrange
            var command = new AddressUpdateCommand(
                Guid.Parse("F759B392-3461-48E7-A687-21499EFE0301"),
                "123 Main St",
                string.Empty,
                "Anytown",
                "AS",
                "12345");

            var existingUser = new ApplicationUser()
            {
                Id = command.UserId.ToString(),
                FirstName = "Last",               // Existing values before update
                LastName = "First",
                PhoneNumber = "5555555555",
                SecondaryPhone = "6664445555",
                Address = new Address()
                {
                    Id = 1,
                    Address1 = command.Address1,
                    Address2 = command.Address2,
                    City = command.City,
                    State = command.State,
                    PostalCode = command.PostalCode,
                },
                AddressId = 1
            };

            _userRepoMock.Setup(
                x => x.GetEntityByIdAsync(
                    It.Is<string>(id => id == command.UserId.ToString()),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(existingUser);

            _addressRepoMock.Setup(u => u.CreateEntityAsync(
                It.IsAny<Address>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            var handler = new AddressUpdateCommandHandler(
                _unitOfWorkMock.Object,
                _mapper,
                _addressRepoMock.Object,
                _userRepoMock.Object);

            // Act
            Result result = await handler.Handle(command, default);

            // Assert
            _unitOfWorkMock.Verify(x =>
                x.CompleteAsync(It.IsAny<CancellationToken>()), Times.Never());

            Assert.False(result.IsSuccess);
            Assert.NotNull(result.Error);
            Assert.Equal("Address.Create", result.Error.Code);
            Assert.Equal("Failed to create new Address for user.", result.Error.Message);
        }

        [Fact]
        public async Task Handle_Should_Not_CallUnitOfWork_WhenUserIsNull()
        {
            // Arrange
            var command = new AddressUpdateCommand(
                Guid.Parse("F759B392-3461-48E7-A687-21499EFE0301"),
                "123 Main St",
                string.Empty,
                "Anytown",
                "AS",
                "12345");

            var existingUser = new ApplicationUser()
            {
                Id = command.UserId.ToString(),
                FirstName = "Last",               // Existing values before update
                LastName = "First",
                PhoneNumber = "5555555555",
                SecondaryPhone = "6664445555",
                Address = new Address()
                {
                    Id = 1,
                    Address1 = command.Address1,
                    Address2 = command.Address2,
                    City = command.City,
                    State = command.State,
                    PostalCode = command.PostalCode,
                },
                AddressId = 1
            };

            _userRepoMock.Setup(
                x => x.GetEntityByIdAsync(
                    It.Is<string>(id => id == command.UserId.ToString()),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => null!);

            var handler = new AddressUpdateCommandHandler(
                _unitOfWorkMock.Object,
                _mapper,
                _addressRepoMock.Object,
                _userRepoMock.Object);

            // Act
            Result result = await handler.Handle(command, default);

            // Assert
            result.Error.Should().Be(DomainErrors.User.NotFound(command.UserId));

            _addressRepoMock.Verify(x =>
                x.CreateEntityAsync(It.IsAny<Address>(), It.IsAny<CancellationToken>()), Times.Never);

            _unitOfWorkMock.Verify(x =>
                x.CompleteAsync(It.IsAny<CancellationToken>()), Times.Never());
        }
    }
}
