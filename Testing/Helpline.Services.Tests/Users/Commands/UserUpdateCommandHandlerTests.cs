using AutoMapper;
using FluentAssertions;
using Helpline.Contracts.v1.Types;
using Helpline.Domain.Data;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.Errors;
using Helpline.Domain.Models.Entities;
using Helpline.Domain.Shared;
using Helpline.Services.Tests.Helpers;
using Helpline.Services.Users.ApplicationUsers.Commands;
using Helpline.Services.Users.ApplicationUsers.Commands.Handlers;
using Helpline.WebAPI.MappingProfiles;
using Microsoft.AspNetCore.Identity;
using Moq;
using System.Security.Claims;

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
                FirstName = "Last",
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

        [Fact]
        public async Task Handle_Should_UserManager_ChangeExistingUserRoles()
        {
            // Arrange
            var command = new UserPermissionsUpdateCommand(
                Guid.Parse("F759B392-3461-48E7-A687-21499EFE0301"),
                RoleType.None, PermissionType.None);

            var existingUser = new ApplicationUser()
            {
                Id = command.UserId.ToString(),
                FirstName = "Last",               // Existing values before update
                LastName = "First",
                PhoneNumber = "5555555555",
                SecondaryPhone = "6664445555",
                Role = Domain.Models.Types.RoleType.Contractor,
                Permissions = Domain.Models.Types.PermissionType.Contractor
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

            var mockUserManager = MockIdentityUserHelper.MockUserManager();
            var mockRoleManager = MockIdentityUserHelper.GetMockRoleManager(IdentityResult.Success);

            mockRoleManager
                .Setup(rm => rm.RoleExistsAsync(It.IsAny<string>()))
                .ReturnsAsync(true);

            var handler = new UserPermissionsUpdateCommandHandler(
                _unitOfWorkMock.Object,
                _mapper,
                mockUserManager.Object,
                mockRoleManager.Object,
                _userRepoMock.Object);

            // Act
            Result result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Handle_Should_Not_RoleManager_CreateUserRoleSuccessfully()
        {
            // Arrange
            var command = new UserPermissionsUpdateCommand(
                Guid.Parse("F759B392-3461-48E7-A687-21499EFE0301"),
                RoleType.None, PermissionType.None);

            var existingUser = new ApplicationUser()
            {
                Id = command.UserId.ToString(),
                FirstName = "Last",               // Existing values before update
                LastName = "First",
                PhoneNumber = "5555555555",
                SecondaryPhone = "6664445555",
                Role = Domain.Models.Types.RoleType.Contractor,
                Permissions = Domain.Models.Types.PermissionType.Contractor
            };

            _userRepoMock.Setup(
                x => x.GetByIdWithNoTrackingToUpdateUserProfileAsync(
                    It.Is<Guid>(id => id == command.UserId),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(existingUser);

            var mockUserManager = MockIdentityUserHelper.MockUserManager();
            var mockRoleManager = MockIdentityUserHelper.GetMockRoleManager(IdentityResult.Failed(), false);

            var handler = new UserPermissionsUpdateCommandHandler(
                _unitOfWorkMock.Object,
                _mapper,
                mockUserManager.Object,
                mockRoleManager.Object,
                _userRepoMock.Object);

            // Act
            Result result = await handler.Handle(command, CancellationToken.None);

            // Assert
            mockRoleManager.Verify(rs => rs.RoleExistsAsync(It.IsAny<string>()), Times.Once);
            mockRoleManager.Verify(rs => rs.CreateAsync(It.IsAny<IdentityRole>()), Times.Once);

            Assert.Equal("User.CreateRole", result.Error.Code);
            Assert.Equal($"Could not create user role {command.Role}", result.Error.Message);
        }

        [Fact]
        public async Task Handle_Should_Not_UserManager_RemoveExistingUserRoles()
        {
            // Arrange
            var listOfRoles = new List<string>
            {
                RoleType.None.ToString(),
                RoleType.Admin.ToString(),
                RoleType.Contractor.ToString(),
            };

            var command = new UserPermissionsUpdateCommand(
                Guid.Parse("F759B392-3461-48E7-A687-21499EFE0301"),
                RoleType.None, PermissionType.None);

            var existingUser = new ApplicationUser()
            {
                Id = command.UserId.ToString(),
                FirstName = "Last",               // Existing values before update
                LastName = "First",
                PhoneNumber = "5555555555",
                SecondaryPhone = "6664445555",
                Role = Domain.Models.Types.RoleType.Contractor,
                Permissions = Domain.Models.Types.PermissionType.Contractor
            };

            _userRepoMock.Setup(
                x => x.GetByIdWithNoTrackingToUpdateUserProfileAsync(
                    It.Is<Guid>(id => id == command.UserId),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(existingUser);

            var mockRoleManager = MockIdentityUserHelper.GetMockRoleManager(IdentityResult.Success);
            var mockUserManager = MockIdentityUserHelper.MockUserManager(true, true, true, false, null, listOfRoles);

            // Mock GetRolesAsync
            mockUserManager
                .Setup(um => um.GetRolesAsync(It.IsAny<ApplicationUser>()))
                .ReturnsAsync(listOfRoles);

            // Mock RemoveFromRolesAsync
            mockUserManager
                .Setup(um => um.RemoveFromRolesAsync(It.IsAny<ApplicationUser>(), It.IsAny<IEnumerable<string>>()))
                .ReturnsAsync(IdentityResult.Failed());

            var handler = new UserPermissionsUpdateCommandHandler(
                _unitOfWorkMock.Object,
                _mapper,
                mockUserManager.Object,
                mockRoleManager.Object,
                _userRepoMock.Object);

            // Act
            Result result = await handler.Handle(command, CancellationToken.None);

            // Assert
            mockUserManager.Verify(rs => rs.GetRolesAsync(It.IsAny<ApplicationUser>()), Times.Once);
            mockUserManager.Verify(rs => rs.RemoveFromRolesAsync(
                It.IsAny<ApplicationUser>(), listOfRoles), Times.Once);

            Assert.Equal("User.RemoveRoles", result.Error.Code);
            Assert.Equal($"Could not remove existing roles for user {existingUser.Id}", result.Error.Message);
        }

        [Fact]
        public async Task Handle_Should_Not_UserManager_RemoveExistingUserPermissions()
        {
            // Arrange
            var listOfClaims = new List<Claim>
            {
                new(PermissionType.None.ToString(), PermissionType.None.ToString()),
                new(PermissionType.Admin.ToString(), PermissionType.Admin.ToString()),
                new(PermissionType.Contractor.ToString(), PermissionType.Contractor.ToString())
            };

            var command = new UserPermissionsUpdateCommand(
                Guid.Parse("F759B392-3461-48E7-A687-21499EFE0301"),
                RoleType.None, PermissionType.None);

            var existingUser = new ApplicationUser()
            {
                Id = command.UserId.ToString(),
                FirstName = "Last",               // Existing values before update
                LastName = "First",
                PhoneNumber = "5555555555",
                SecondaryPhone = "6664445555",
                Role = Domain.Models.Types.RoleType.Contractor,
                Permissions = Domain.Models.Types.PermissionType.Contractor
            };

            _userRepoMock.Setup(
                x => x.GetByIdWithNoTrackingToUpdateUserProfileAsync(
                    It.Is<Guid>(id => id == command.UserId),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(existingUser);

            var mockRoleManager = MockIdentityUserHelper.GetMockRoleManager(IdentityResult.Success);
            var mockUserManager = MockIdentityUserHelper.MockUserManager(true, true, false, true, listOfClaims, null);

            var handler = new UserPermissionsUpdateCommandHandler(
                _unitOfWorkMock.Object,
                _mapper,
                mockUserManager.Object,
                mockRoleManager.Object,
                _userRepoMock.Object);

            // Act
            Result result = await handler.Handle(command, CancellationToken.None);

            // Assert
            mockUserManager.Verify(rs => rs.GetClaimsAsync(
                It.IsAny<ApplicationUser>()), Times.Once);

            mockUserManager.Verify(rs => rs.RemoveClaimAsync(
                It.IsAny<ApplicationUser>(), It.IsAny<Claim>()), Times.Once);

            Assert.Equal("User.RemovePermissions", result.Error.Code);
            Assert.Equal($"Could not remove existing permissions for user {existingUser.Id}", result.Error.Message);
        }

        [Fact]
        public async Task Handle_Should_Not_UserManager_AddUserRole()
        {
            // Arrange
            var command = new UserPermissionsUpdateCommand(
                Guid.Parse("F759B392-3461-48E7-A687-21499EFE0301"),
                RoleType.None, PermissionType.None);

            var existingUser = new ApplicationUser()
            {
                Id = command.UserId.ToString(),
                FirstName = "Last",               // Existing values before update
                LastName = "First",
                PhoneNumber = "5555555555",
                SecondaryPhone = "6664445555",
                Role = Domain.Models.Types.RoleType.Contractor,
                Permissions = Domain.Models.Types.PermissionType.Contractor
            };

            _userRepoMock.Setup(
                x => x.GetByIdWithNoTrackingToUpdateUserProfileAsync(
                    It.Is<Guid>(id => id == command.UserId),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(existingUser);

            var mockRoleManager = MockIdentityUserHelper.GetMockRoleManager(IdentityResult.Success);
            var mockUserManager = MockIdentityUserHelper.MockUserManager(true, false, true, true, null, null);

            var handler = new UserPermissionsUpdateCommandHandler(
                _unitOfWorkMock.Object,
                _mapper,
                mockUserManager.Object,
                mockRoleManager.Object,
                _userRepoMock.Object);

            // Act
            Result result = await handler.Handle(command, CancellationToken.None);

            // Assert
            mockUserManager.Verify(rs => rs.AddToRoleAsync(
                It.IsAny<ApplicationUser>(), It.IsAny<string>()), Times.Once);

            Assert.Equal("User.AddRoles", result.Error.Code);
            Assert.Equal($"Could not add role for user {existingUser.Id}", result.Error.Message);
        }

        [Fact]
        public async Task Handle_Should_Not_UserManager_AddUserClaim()
        {
            // Arrange
            var command = new UserPermissionsUpdateCommand(
                Guid.Parse("F759B392-3461-48E7-A687-21499EFE0301"),
                RoleType.None, PermissionType.None);

            var existingUser = new ApplicationUser()
            {
                Id = command.UserId.ToString(),
                FirstName = "Last",               // Existing values before update
                LastName = "First",
                PhoneNumber = "5555555555",
                SecondaryPhone = "6664445555",
                Role = Domain.Models.Types.RoleType.Contractor,
                Permissions = Domain.Models.Types.PermissionType.Contractor
            };

            _userRepoMock.Setup(
                x => x.GetByIdWithNoTrackingToUpdateUserProfileAsync(
                    It.Is<Guid>(id => id == command.UserId),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(existingUser);

            var mockRoleManager = MockIdentityUserHelper.GetMockRoleManager(IdentityResult.Success);
            var mockUserManager = MockIdentityUserHelper.MockUserManager(false, true, true, true, null, null);

            var handler = new UserPermissionsUpdateCommandHandler(
                _unitOfWorkMock.Object,
                _mapper,
                mockUserManager.Object,
                mockRoleManager.Object,
                _userRepoMock.Object);

            // Act
            Result result = await handler.Handle(command, CancellationToken.None);

            // Assert
            mockUserManager.Verify(rs => rs.AddClaimAsync(
                It.IsAny<ApplicationUser>(), It.IsAny<Claim>()), Times.Once);

            Assert.Equal("User.AddPermissions", result.Error.Code);
            Assert.Equal($"Could not add permissions for user {existingUser.Id}", result.Error.Message);
        }
    }
}
