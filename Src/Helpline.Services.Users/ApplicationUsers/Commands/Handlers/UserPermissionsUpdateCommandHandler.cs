using AutoMapper;
using Helpline.Contracts.v1.Requests;
using Helpline.Domain.Data;
using Helpline.Domain.Errors;
using Helpline.Domain.Models.Entities;
using Helpline.Domain.Shared;
using Helpline.Services.Abstractions.Messaging;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Helpline.Services.Users.ApplicationUsers.Commands.Handlers
{
    internal sealed class UserPermissionsUpdateCommandHandler : ICommandHandler<UserPermissionsUpdateCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserPermissionsUpdateCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task<Result> Handle(UserPermissionsUpdateCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByIdAsync(request.UserId.ToString());
            if (user is null)
                return Result.Failure(DomainErrors.User.NotFound(request.UserId));

            await RemoveExistingUserRoles(user);

            await RemoveExistingUserPermissions(request, user);

            await CreateUserRole(request);

            await AddUserRole(request, user);

            await AddUserClaim(request, user);

            // map domain changes
            var userRequest = new UserRequest();
            userRequest.UpdateUserRoleAndPermission(request.Role, request.Permissions);
            var updatedUser = mapper.Map(userRequest, user);

            // persist changes
            if (!await unitOfWork.UserRepo.UpdateEntityAsync(updatedUser, cancellationToken))
                return Result.Failure(new Error("User.UpdateAccess", $"Could not update user roles and permissions for Id {user.Id}."));

            if (!await unitOfWork.CompleteAsync(cancellationToken))
                return Result.Failure(new Error("User.UpdateAccess", $"Could not save user roles and permissions for Id {user.Id}."));

            return Result.Success();
        }

        private async Task<Result> AddUserClaim(UserPermissionsUpdateCommand request, ApplicationUser user)
        {
            var addPermissionResult = await userManager.AddClaimAsync(
                            user, new Claim(request.Permissions.ToString(), request.Permissions.ToString()));

            if (!addPermissionResult.Succeeded)
                return Result.Failure(new Error("User.AddPermissions", $"Could not add permissions for user {user.Id}"));

            return Result.Success();
        }

        private async Task<Result> AddUserRole(UserPermissionsUpdateCommand request, ApplicationUser user)
        {
            var addRoleResult = await userManager.AddToRoleAsync(user, request.Role.ToString());
            if (!addRoleResult.Succeeded)
                return Result.Failure(new Error("User.AddRoles", $"Could not add role for user {user.Id}"));

            return Result.Success();
        }

        private async Task<Result> CreateUserRole(UserPermissionsUpdateCommand request)
        {
            // Ensure the requested role exists in the system
            var roleExists = await roleManager.RoleExistsAsync(request.Role.ToString());
            if (!roleExists)
            {
                // If the role does not exist, create it
                var createRoleResult = await roleManager.CreateAsync(new IdentityRole(request.Role.ToString()));
                if (!createRoleResult.Succeeded)
                    return Result.Failure(new Error("User.CreateRole", $"Could not create role {request.Role.ToString()}"));
            }

            return Result.Success();
        }

        private async Task<Result> RemoveExistingUserPermissions(UserPermissionsUpdateCommand request, ApplicationUser user)
        {
            // update user permissions
            var claims = await userManager.GetClaimsAsync(user);
            var permissionClaim = claims.FirstOrDefault(c => c.Type == request.Permissions.ToString());

            if (permissionClaim is not null)
            {
                var removePermissionResult = await userManager.RemoveClaimAsync(user, permissionClaim!);
                if (!removePermissionResult.Succeeded)
                    return Result.Failure(new Error("User.RemovePermissions", $"Could not remove permissions for user {user.Id}"));
            }

            return Result.Success();
        }

        private async Task<Result> RemoveExistingUserRoles(ApplicationUser user)
        {
            // update user roles
            var currentRoles = await userManager.GetRolesAsync(user);
            if (currentRoles.Any())
            {
                var removeRoleResult = await userManager.RemoveFromRolesAsync(user, currentRoles);
                if (!removeRoleResult.Succeeded)
                    return Result.Failure(new Error("User.RemoveRoles", $"Could not remove roles for user {user.Id}"));
            }

            return Result.Success();
        }
    }
}
