using Helpline.Domain.Data.Interfaces;

namespace Helpline.Domain.Data
{
    public interface IUnitOfWork
    {
        IAddressRepository AddressRepo { get; }
        IApplicationUserRepository UserRepo { get; }
        Task<bool> CompleteAsync();
    }
}
