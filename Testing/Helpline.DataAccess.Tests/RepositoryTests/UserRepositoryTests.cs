using FluentAssertions;
using Helpline.Common.Interfaces;
using Helpline.DataAccess.Context;
using Helpline.DataAccess.Data.Repositories;
using Helpline.Domain.Models.Entities;
using Helpline.Domain.ValueObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace Helpline.DataAccess.Tests.RepositoryTests
{
    [Collection("Non-Parallel Tests")]
    public class UserRepositoryTests : IClassFixture<DatabaseFixture>
    {
        private readonly HelplineContext context;
        private readonly ApplicationUserRepository userRepository;

        public UserRepositoryTests(DatabaseFixture fixture)
        {
            context = fixture.Context;
            userRepository = new ApplicationUserRepository(
                context,
                new Mock<ILogging>().Object,
                MockUserManager(context.Users).Object);
        }

        [Fact]
        public async Task GetAllEntitiesAsync_Returns_All_Records()
        {
            // Act
            var result = await userRepository.GetAllEntitiesAsync(CancellationToken.None);

            // Assert
            result.Should().NotBeNull().And.HaveCount(2);
            result.Should().Contain(u => u.Email == "user1@test.com");
            result.Should().Contain(u => u.Email == "user2@test.com");
        }

        [Fact]
        public async Task GetEntitieByUsernameAsync_Returns_One_Record()
        {
            // Arrange
            var userName = UserName.Create("user1");

            // Act
            var result = await userRepository.GetUserByUsernameAsync(userName.Value, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result!.UserName.Should().NotBe("user2");
            result.Email.Should().Be("user1@test.com");
        }

        [Fact]
        public async Task IsEmailUniqueAsync_Returns_True_When_Email_Is_Unique()
        {
            // Arrange
            var email = Email.Create("unique@test.com");

            // Act
            var result = await userRepository.IsEmailUniqueAsync(email.Value);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task IsEmailUniqueAsync_Returns_False_When_Email_Is_Not_Unique()
        {
            // Arrange
            var email = Email.Create("user1@test.com");

            // Act
            var result = await userRepository.IsEmailUniqueAsync(email.Value);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public async Task IsUserNameUniqueAsync_Returns_True_When_UserName_Is_Unique()
        {
            // Arrange
            var userName = UserName.Create("unique@test.com");

            // Act
            var result = await userRepository.IsUserNameUniqueAsync(userName.Value, CancellationToken.None);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task IsUserNameUniqueAsync_Returns_False_When_UserName_Is_Unique()
        {
            // Arrange
            var userName = UserName.Create("user2");

            // Act
            var result = await userRepository.IsUserNameUniqueAsync(userName.Value, CancellationToken.None);

            // Assert
            result.Should().BeFalse();
        }

        private void SeedData()
        {
            var users = new List<ApplicationUser>
        {
            new ApplicationUser
            {
                Id = "57A57CA5-5430-403B-B0A5-23FD4E710749",
                Email = "user1@test.com",
                UserName = "user1",
                PasswordHash = "password1"
            },
            new ApplicationUser
            {
                Id = "A6E6AD91-1BC1-4A1F-8189-522F7742D81F",
                Email = "user2@test.com",
                UserName = "user2",
                PasswordHash = "password2"
            }
        };

            context.AddRange(users);
            context.SaveChanges();
        }

        private static Mock<UserManager<ApplicationUser>> MockUserManager(DbSet<ApplicationUser> users)
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

            // Setup behavior for FindByNameAsync
            mockUserManager
                .Setup(um => um.FindByNameAsync(It.IsAny<string>()))
                .Returns((string userName) => users.FirstOrDefaultAsync(u => u.UserName == userName));

            return mockUserManager;
        }

        private static Mock<DbSet<T>> CreateMockDbSet<T>(IEnumerable<T> data) where T : class
        {
            // Convert the data to IQueryable
            var queryableData = data.AsQueryable();

            // Create a mock DbSet
            var mockDbSet = new Mock<DbSet<T>>();

            // Mock IQueryable<T> methods for LINQ functionality
            mockDbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryableData.Provider);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryableData.Expression);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryableData.ElementType);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryableData.GetEnumerator());

            // Mock ToListAsync by returning the data asynchronously
            mockDbSet.Setup(m => m.ToListAsync(It.IsAny<CancellationToken>()))
                .Returns((T entity, CancellationToken cancellationToken) => new Mock<EntityEntry<T>>().Object);

            // Mock AddAsync method for adding entities
            mockDbSet.Setup(m => m.AddAsync(It.IsAny<T>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((T entity, CancellationToken cancellationToken) => new Mock<EntityEntry<T>>().Object);

            return mockDbSet;
        }
    }
}
