using AutoMapper;
using FluentAssertions;
using Helpline.API.Gateway.MappingProfiles;
using Helpline.Contracts.v1.Requests;
using Helpline.Domain.Data;
using Helpline.Domain.Data.Interfaces;
using Helpline.Domain.Errors;
using Helpline.Domain.Models.Entities;
using Helpline.Domain.Shared;
using Helpline.Services.Users.Employees.Commands;
using Helpline.Services.Users.Employees.Commands.Handlers;
using Moq;

namespace Helpline.Services.Tests.Employees.Commands
{
    public class EmployeeUpdateCommandHandlerTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly IMapper _mapper;
        private readonly Mock<IEmployeeRepository> _employeeRepoMock;

        public EmployeeUpdateCommandHandlerTests()
        {
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<RequestToDomain>());

            _mapper = mapperConfiguration.CreateMapper();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _employeeRepoMock = new Mock<IEmployeeRepository>();
        }

        [Fact]
        public async Task Handler_Should_ReturnSuccessResult_OnEmployeeUpdate_WhenUserIsFound()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var command = new EmployeeUpdateCommand(
                userId,
                true,
                "");

            var existingUser = new ApplicationUser()
            {
                Id = command.UserId.ToString(),
                FirstName = "Last",               // Existing values before update
                LastName = "First",
            };

            var existingEmployee = new Employee()
            {
                UserId = existingUser.Id,
                User = existingUser
            };
            _employeeRepoMock.Setup(
                x => x.GetEmployeeByUserIdAsync(
                    It.Is<string>(id => id == command.UserId.ToString()),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(existingEmployee);

            _employeeRepoMock.Setup(u => u.UpdateEntityAsync(
                It.IsAny<Employee>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(Result.Success());

            _unitOfWorkMock.Setup(u => u.CompleteAsync(It.IsAny<CancellationToken>()))
                   .ReturnsAsync(true);

            var handler = new EmployeeUpdateCommandHandler(
                _unitOfWorkMock.Object,
                _mapper,
                _employeeRepoMock.Object);

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
            var command = new EmployeeUpdateCommand(
                userId,
                true,
                "");

            _employeeRepoMock.Setup(
                x => x.GetEmployeeByUserIdAsync(
                    It.Is<string>(id => id == command.UserId.ToString()),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => null!);

            var handler = new EmployeeUpdateCommandHandler(
                _unitOfWorkMock.Object,
                _mapper,
                _employeeRepoMock.Object);

            // Act
            Result result = await handler.Handle(command, default);

            // Assert
            result.Error.Should().Be(DomainErrors.User.NotFound(command.UserId));

            _employeeRepoMock.Verify(x =>
                x.UpdateEntityAsync(It.IsAny<Employee>(), It.IsAny<CancellationToken>()), Times.Never);

            _unitOfWorkMock.Verify(x =>
                x.CompleteAsync(It.IsAny<CancellationToken>()), Times.Never());
        }

        [Fact]
        public async Task Handle_Should_Not_CallUnitOfWork_WhenMappingEmployeeFails()
        {
            // Arrange
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                //cfg.AddProfile<RequestToDomain>();

                // Add a custom mapping for EmployeeRequest to Employee that always returns null
                cfg.CreateMap<EmployeeRequest, Employee>()
                    .ConvertUsing(src => null!);
            });

            var mapper = mapperConfiguration.CreateMapper();

            var userId = Guid.NewGuid();
            var command = new EmployeeUpdateCommand(
                userId,
                true,
                string.Empty);

            var existingUser = new ApplicationUser()
            {
                Id = userId.ToString(),
                FirstName = "Last",
                LastName = "First",
            };

            var existingEmployee = new Employee()
            {
                UserId = existingUser.Id,
                User = existingUser,
                IsActive = true,
                ReferralCode = ""
            };

            _employeeRepoMock.Setup(
                x => x.GetEmployeeByUserIdAsync(
                    It.Is<string>(id => id == userId.ToString()),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(existingEmployee);

            var handler = new EmployeeUpdateCommandHandler(
                _unitOfWorkMock.Object,
                mapper,
                _employeeRepoMock.Object);

            // Act
            Result result = await handler.Handle(command, default);

            // Assert
            _employeeRepoMock.Verify(x =>
            x.UpdateEntityAsync(It.IsAny<Employee>(), CancellationToken.None), Times.Never());

            _unitOfWorkMock.Verify(x =>
                x.CompleteAsync(It.IsAny<CancellationToken>()), Times.Never());

            Assert.False(result.IsSuccess);
            Assert.NotNull(result.Error);
            Assert.Equal("Employee.Mapping", result.Error.Code);
            Assert.Equal("Failed to map EmployeeRequest to Employee.", result.Error.Message);
        }

        [Fact]
        public async Task Handle_Should_Not_CallUnitOfWork_WhenUpdateEmployeeFails()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var command = new EmployeeUpdateCommand(
                userId,
                true,
                "");

            var existingUser = new ApplicationUser()
            {
                Id = command.UserId.ToString(),
                FirstName = "Last",               // Existing values before update
                LastName = "First",
            };

            var existingEmployee = new Employee()
            {
                UserId = existingUser.Id,
                User = existingUser,
                IsActive = true,
                ReferralCode = ""
            };

            _employeeRepoMock.Setup(
                x => x.GetEmployeeByUserIdAsync(
                    It.Is<string>(id => id == command.UserId.ToString()),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(existingEmployee);

            _employeeRepoMock.Setup(u => u.UpdateEntityAsync(
                It.IsAny<Employee>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(Result.Failure(new Error("", "")));

            var handler = new EmployeeUpdateCommandHandler(
                _unitOfWorkMock.Object,
                _mapper,
                _employeeRepoMock.Object);

            // Act
            Result result = await handler.Handle(command, default);

            // Assert
            _unitOfWorkMock.Verify(x =>
                x.CompleteAsync(It.IsAny<CancellationToken>()), Times.Never());

            Assert.False(result.IsSuccess);

            Assert.NotNull(result.Error);
            Assert.Equal("Employee.UpdateUserInfo", result.Error.Code);
            Assert.Equal($"UpdateUserInfo to employee profile {command.UserId} could not be completed.", result.Error.Message);
        }
    }
}
