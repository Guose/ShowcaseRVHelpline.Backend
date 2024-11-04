﻿using Helpline.Domain.Data.Interfaces;

namespace Helpline.Domain.Data
{
    public interface IUnitOfWork
    {
        IAddressRepository AddressRepo { get; }
        IApplicationUserRepository UserRepo { get; }
        ICustomerRepository CustomerRepo { get; }
        IEmployeeRepository EmployeeRepo { get; }
        ITechnicianRepository TechnicianRepo { get; }
        Task<bool> CompleteAsync();
    }
}
