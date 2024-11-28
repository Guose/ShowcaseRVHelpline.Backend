using AutoMapper;
using FluentAssertions;
using Helpline.Domain.Data;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.Errors;
using Helpline.Domain.Models.Entities;
using Helpline.Domain.Shared;
using Helpline.Services.Users.ApplicationUsers.Commands;
using Helpline.Services.Users.ApplicationUsers.Commands.Handlers;
using Helpline.WebAPI.MappingProfiles;
using Moq;

namespace Helpline.Services.Tests.Users.Commands
{
    public class UserUpdateCommandHandlerTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly IMapper _mapper;
        private readonly Mock<IApplicationUserRepository> _userRepoMock;

        public UserUpdateCommandHandlerTests()
        {
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<RequestToDomain>());
            _mapper = mapperConfiguration.CreateMapper();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _userRepoMock = new Mock<IApplicationUserRepository>();
        }

        [Fact]
        public async Task Handler_Should_ReturnFailureResult_WhenUserDoesNotExist()
        {
            // Arrange
            var command = new UserUpdateCommand(Guid.Parse("F759B392-3461-48E7-A687-21499EFE0301"), "First", "Last", "5555555555", "6664445555");

            _userRepoMock.Setup(
                x => x.GetEntityByIdAsync(
                    It.Is<string>(id => id != "F759B392-3461-48E7-A687-21499EFE0301"),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => null!);

            var handler = new UserUpdateCommandHandler(
                _unitOfWorkMock.Object,
                _mapper,
                _userRepoMock.Object);

            // Act
            Result result = await handler.Handle(command, default);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(DomainErrors.User.NotFound(command.UserId));
        }

        [Fact]
        public async Task Handler_Should_ReturnSuccessResult_WhenUserIsFound()
        {
            // Arrange
            var command = new UserUpdateCommand(
                Guid.Parse("F759B392-3461-48E7-A687-21499EFE0301"), "First", "Last", "5555555555", "6664445555");

            var existingUser = new ApplicationUser()
            {
                Id = "F759B392-3461-48E7-A687-21499EFE0301",
                FirstName = "Last",               // Existing values before update
                LastName = "First",
                PhoneNumber = "5555555555",
                SecondaryPhone = "6664445555"
            };

            _userRepoMock.Setup(
                x => x.GetByIdWithNoTrackingToUpdateUserProfileAsync(
                    It.Is<Guid>(id => id == command.UserId),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(existingUser);

            _userRepoMock.Setup(u => u.UpdateEntityAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            _unitOfWorkMock.Setup(u => u.CompleteAsync(It.IsAny<CancellationToken>()))
                   .ReturnsAsync(true);

            var handler = new UserUpdateCommandHandler(
                _unitOfWorkMock.Object,
                _mapper,
                _userRepoMock.Object);

            // Act
            Result result = await handler.Handle(command, default);

            // Assert
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Handler_Should_CallUpdateOnRepository_WhenUserIsFound()
        {
            // Arrange
            var command = new UserUpdateCommand(
                Guid.Parse("F759B392-3461-48E7-A687-21499EFE0301"), "First", "Last", "5555555555", "6664445555");

            var existingUser = new ApplicationUser()
            {
                Id = command.UserId.ToString(),
                FirstName = "Last",               // Existing values before update
                LastName = "First",
                PhoneNumber = "5555555555",
                SecondaryPhone = "6664445555"
            };

            _userRepoMock.Setup(
                x => x.GetByIdWithNoTrackingToUpdateUserProfileAsync(
                    It.Is<Guid>(id => id == command.UserId),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(existingUser);

            _userRepoMock.Setup(u => u.UpdateEntityAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            _unitOfWorkMock.Setup(u => u.CompleteAsync(It.IsAny<CancellationToken>()))
                   .ReturnsAsync(true);

            var handler = new UserUpdateCommandHandler(
                _unitOfWorkMock.Object,
                _mapper,
                _userRepoMock.Object);

            // Act
            Result result = await handler.Handle(command, default);

            // Assert
            result.IsSuccess.Should().BeTrue();

            _userRepoMock.Verify(u => u.UpdateEntityAsync(
                It.Is<ApplicationUser>(x =>
                    x.Id == existingUser.Id),
                It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task Handle_Should_Not_CallUnitOfWork_WhenUpdateUserFails()
        {
            // Arrange
            var command = new UserUpdateCommand(
                Guid.Parse("F759B392-3461-48E7-A687-21499EFE0301"), "First", "Last", "5555555555", "6664445555");

            var existingUser = new ApplicationUser()
            {
                Id = command.UserId.ToString(),
                FirstName = "Last",               // Existing values before update
                LastName = "First",
                PhoneNumber = "5555555555",
                SecondaryPhone = "6664445555"
            };

            _userRepoMock.Setup(
                x => x.GetByIdWithNoTrackingToUpdateUserProfileAsync(
                    It.Is<Guid>(id => id == command.UserId),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(existingUser);

            _userRepoMock.Setup(u => u.UpdateEntityAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            var handler = new UserUpdateCommandHandler(
                _unitOfWorkMock.Object,
                _mapper,
                _userRepoMock.Object);

            // Act
            Result result = await handler.Handle(command, default);

            // Assert
            _unitOfWorkMock.Verify(x =>
                x.CompleteAsync(It.IsAny<CancellationToken>()), Times.Never());

            Assert.False(result.IsSuccess);

            Assert.NotNull(result.Error);
            Assert.Equal("User.Updated", result.Error.Code);
            Assert.Equal("User could not be updated.", result.Error.Message);
        }

        [Fact]
        public async Task Handler_Should_Not_CallUnitOfWork_WhenUserIsNull()
        {
            // Arrange
            var command = new UserUpdateCommand(
                Guid.Parse("F759B392-3461-48E7-A687-21499EFE0301"), "First", "Last", "5555555555", "6664445555");

            var existingUser = new ApplicationUser()
            {
                Id = command.UserId.ToString(),
                FirstName = "Last",               // Existing values before update
                LastName = "First",
                PhoneNumber = "5555555555",
                SecondaryPhone = "6664445555"
            };

            _userRepoMock.Setup(
                x => x.GetByIdWithNoTrackingToUpdateUserProfileAsync(
                    It.Is<Guid>(id => id == command.UserId),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => null!);

            var handler = new UserUpdateCommandHandler(
                _unitOfWorkMock.Object,
                _mapper,
                _userRepoMock.Object);

            // Act
            Result result = await handler.Handle(command, default);

            // Assert
            result.Error.Should().Be(DomainErrors.User.NotFound(command.UserId));

            _userRepoMock.Verify(x =>
                x.UpdateEntityAsync(It.IsAny<ApplicationUser>(), It.IsAny<CancellationToken>()), Times.Never);

            _unitOfWorkMock.Verify(x =>
                x.CompleteAsync(It.IsAny<CancellationToken>()), Times.Never());
        }
    }
}
