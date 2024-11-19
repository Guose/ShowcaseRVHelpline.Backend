using Helpline.Domain.Data.Interfaces;

namespace Helpline.Domain.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IAddressRepository AddressRepo { get; }
        IApplicationUserRepository UserRepo { get; }
        ICustomerRepository CustomerRepo { get; }
        IEmployeeRepository EmployeeRepo { get; }
        ITechnicianRepository TechnicianRepo { get; }
        IDealershipContactRepository DealershipContactRepo { get; }
        IRVRenterRepository RVRenterRepo { get; }
        Task<bool> CompleteAsync(CancellationToken cancellationToken);
    }
}
