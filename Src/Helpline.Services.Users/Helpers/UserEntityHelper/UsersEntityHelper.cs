﻿using Helpline.Contracts.v1.Types;
using Helpline.Domain.Data;
using Helpline.Domain.Models.Entities;

namespace Helpline.Services.Users.Helpers.UserEntityHelper
{
    public class UsersEntityHelper : IUserEntityHelper
    {
        public async Task<object?> GetUserEntityByUserIdAsync(RoleType role, string userId, IUnitOfWork unitOfWork, CancellationToken cancellationToken)
        {
            return role switch
            {
                RoleType.Employee => await unitOfWork.EmployeeRepo.GetEmployeeByUserIdAsync(userId, cancellationToken),
                RoleType.Customer => await unitOfWork.CustomerRepo.GetCustomerByUserIdAsync(userId, cancellationToken),
                RoleType.Dealership => await unitOfWork.DealershipContactRepo.GetDealershipContactByUserIdAsync(userId, cancellationToken),
                RoleType.Technician => await unitOfWork.TechnicianRepo.GetTechnicianByUserIdAsync(userId, cancellationToken),
                RoleType.RVRenter => await unitOfWork.RVRenterRepo.GetRenterByUserIdAsync(userId, cancellationToken),
                _ => null
            };
        }

        public async Task<bool> HandleUserEntityAsync(object entity, IUnitOfWork unitOfWork, string process, CancellationToken cancellationToken)
        {
            if (entity == null || string.IsNullOrWhiteSpace(process))
                return false;

            process = process.ToLowerInvariant();

            return entity switch
            {
                Customer customer => await ExecuteProcess(unitOfWork.CustomerRepo, customer, process, cancellationToken),
                Employee employee => await ExecuteProcess(unitOfWork.EmployeeRepo, employee, process, cancellationToken),
                Technician technician => await ExecuteProcess(unitOfWork.TechnicianRepo, technician, process, cancellationToken),
                RVRenter renter => await ExecuteProcess(unitOfWork.RVRenterRepo, renter, process, cancellationToken),
                DealershipContact contact => await ExecuteProcess(unitOfWork.DealershipContactRepo, contact, process, cancellationToken),
                _ => false
            };
        }

        private static async Task<bool> ExecuteProcess<TEntity, TKey>(
            IBaseRepository<TEntity, TKey> repository,
            TEntity entity,
            string process,
            CancellationToken cancellationToken)
            where TEntity : class
        {
            var deleteResult = await repository.DeleteEntityAsync(entity, cancellationToken);
            var updateResult = await repository.UpdateEntityAsync(entity, cancellationToken);
            var createResult = await repository.CreateEntityAsync(entity, cancellationToken);

            return process switch
            {
                "delete" => true,
                "update" => true,
                "create" => true,
                _ => throw new ArgumentException($"Invalid process type: {process}")
            };
        }
    }
}
