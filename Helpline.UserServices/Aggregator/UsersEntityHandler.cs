using Helpline.Common.Models;
using Helpline.Common.Types;
using Helpline.Domain.Data;

namespace Helpline.UserServices.Aggregator
{
    public static class UsersEntityHandler
    {
        public static async Task<object?> GetUserEntityByUserIdAsync(RoleType role, string userId, IUnitOfWork unitOfWork)
        {
            return role switch
            {
                RoleType.Employee => await unitOfWork.EmployeeRepo.GetEmployeeByUserIdAsync(userId),
                RoleType.Customer => await unitOfWork.CustomerRepo.GetCustomerByUserIdAsync(userId),
                RoleType.Dealership => await unitOfWork.DealershipContactRepo.GetDealershipContactByUserIdAsync(userId),
                RoleType.Technician => await unitOfWork.TechnicianRepo.GetTechnicianByUserIdAsync(userId),
                RoleType.RVRenter => await unitOfWork.RVRenterRepo.GetRenterByUserIdAsync(userId),
                _ => null
            };
        }

        public static async Task<bool> HandleUserEntityAsync(object entity, IUnitOfWork unitOfWork, string process)
        {
            if (entity == null || string.IsNullOrWhiteSpace(process))
                return false;

            process = process.ToLowerInvariant();

            return entity switch
            {
                Customer customer => await ExecuteProcess(unitOfWork.CustomerRepo, customer, process),
                Employee employee => await ExecuteProcess(unitOfWork.EmployeeRepo, employee, process),
                Technician technician => await ExecuteProcess(unitOfWork.TechnicianRepo, technician, process),
                RVRenter renter => await ExecuteProcess(unitOfWork.RVRenterRepo, renter, process),
                DealershipContact contact => await ExecuteProcess(unitOfWork.DealershipContactRepo, contact, process),
                _ => false
            };
        }

        private static async Task<bool> ExecuteProcess<TEntity, TKey>(IBaseRepository<TEntity, TKey> repository, TEntity entity, string process)
            where TEntity : class
        {
            return process switch
            {
                "delete" => await repository.DeleteEntityAsync(entity),
                "update" => await repository.UpdateEntityAsync(entity),
                "create" => await repository.CreateEntityAsync(entity),
                _ => throw new ArgumentException($"Invalid process type: {process}")
            };
        }
    }
}
