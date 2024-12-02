using Helpline.Domain.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System.Security.Claims;

namespace Helpline.Services.Tests.Helpers
{
    public static class MockIdentityUserHelper
    {
        public static Mock<RoleManager<IdentityRole>> GetMockRoleManager(
            IdentityResult identityResult,
            bool roleExits = true)
        {
            // Mock IRoleStore<IdentityRole>
            var roleStoreMock = new Mock<IRoleStore<IdentityRole>>();

            // Create RoleManager manually with required dependencies
            var roleManager = new Mock<RoleManager<IdentityRole>>(
                roleStoreMock.Object,
                new List<IRoleValidator<IdentityRole>>
                {
                    new RoleValidator<IdentityRole>()
                },
                new UpperInvariantLookupNormalizer(),
                new IdentityErrorDescriber(),
                Mock.Of<ILogger<RoleManager<IdentityRole>>>());

            roleManager
                .Setup(rm => rm.RoleExistsAsync(It.IsAny<string>()))
                .ReturnsAsync(roleExits);

            // Setup CreateAsync
            roleManager
                .Setup(rm => rm.CreateAsync(It.IsAny<IdentityRole>()))
                .ReturnsAsync(identityResult);

            return roleManager;
        }

        public static Mock<UserManager<ApplicationUser>> MockUserManager(
            bool addClaimSucceeds = true,
            bool addRoleSucceeds = true,
            bool removeClaimSucceeds = true,
            bool removeRolesSucceeds = true,
            List<Claim>? claims = null,
            List<string>? roles = null)
        {
            // Mock IUserStore
            var userStoreMock = new Mock<IUserStore<ApplicationUser>>();

            // Create non-null IServiceProvider
            var serviceProviderMock = new Mock<IServiceProvider>();
            serviceProviderMock
                .Setup(sp => sp.GetService(It.IsAny<Type>()))
                .Returns(userStoreMock.Object);

            // Mock other services as needed or leave them untested
            serviceProviderMock
                .Setup(sp => sp.GetService(It.IsAny<Type>()))
                .Returns((Type type) => Activator.CreateInstance(type));

            // Provide all required dependencies
            var identityOptions = Options.Create(new IdentityOptions());
            var passwordHasher = new PasswordHasher<ApplicationUser>();
            var userValidators = new List<IUserValidator<ApplicationUser>> { new UserValidator<ApplicationUser>() };
            var passwordValidators = new List<IPasswordValidator<ApplicationUser>> { new PasswordValidator<ApplicationUser>() };
            var lookupNormalizer = new UpperInvariantLookupNormalizer();
            var identityErrorDescriber = new IdentityErrorDescriber();
            var logger = new Mock<ILogger<UserManager<ApplicationUser>>>();

            // Fully initialize UserManager
            var mockUserManager = new Mock<UserManager<ApplicationUser>>(
                userStoreMock.Object,
                identityOptions,
                passwordHasher,
                userValidators,
                passwordValidators,
                lookupNormalizer,
                identityErrorDescriber,
                serviceProviderMock.Object, // Provide a mock service provider here
                logger.Object
            );

            // Mock AddClaimAsync
            mockUserManager
                .Setup(um => um.AddClaimAsync(It.IsAny<ApplicationUser>(), It.IsAny<Claim>()))
                .ReturnsAsync(addClaimSucceeds ? IdentityResult.Success : IdentityResult.Failed(new IdentityError
                {
                    Code = "AddClaimFailed",
                    Description = "Failed to add claim."
                }));

            // Mock AddToRoleAsync
            mockUserManager
                .Setup(um => um.AddToRoleAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(addRoleSucceeds ? IdentityResult.Success : IdentityResult.Failed(new IdentityError
                {
                    Code = "AddRoleFailed",
                    Description = "Failed to add role."
                }));

            // Mock GetClaimsAsync
            mockUserManager
                .Setup(um => um.GetClaimsAsync(It.IsAny<ApplicationUser>()))
                .ReturnsAsync(claims ?? new List<Claim>());

            // Mock RemoveClaimAsync
            mockUserManager
                .Setup(um => um.RemoveClaimAsync(It.IsAny<ApplicationUser>(), It.IsAny<Claim>()))
                .ReturnsAsync(removeClaimSucceeds ? IdentityResult.Success : IdentityResult.Failed(new IdentityError
                {
                    Code = "RemoveClaimFailed",
                    Description = "Failed to remove claim."
                }));

            // Mock GetRolesAsync
            mockUserManager
                .Setup(um => um.GetRolesAsync(It.IsAny<ApplicationUser>()))
                .ReturnsAsync(roles ?? new List<string>());

            // Mock RemoveFromRolesAsync
            mockUserManager
                .Setup(um => um.RemoveFromRolesAsync(It.IsAny<ApplicationUser>(), It.IsAny<IEnumerable<string>>()))
                .ReturnsAsync(removeRolesSucceeds ? IdentityResult.Success : IdentityResult.Failed(new IdentityError
                {
                    Code = "RemoveRolesFailed",
                    Description = "Failed to remove roles."
                }));

            return mockUserManager;
        }
    }
}
