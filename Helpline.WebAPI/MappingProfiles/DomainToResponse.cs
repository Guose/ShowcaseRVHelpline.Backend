using AutoMapper;
using Helpline.Common.Models;
using Helpline.UserServices.DTOs.Responses;

namespace Helpline.WebAPI.MappingProfiles
{
    public class DomainToResponse : Profile
    {
        public DomainToResponse()
        {
            // Base User to User Response mapping
            CreateMap<ApplicationUser, UserResponse>();

            // Customer-specific mapping
            CreateMap<Customer, CustomerResponse>();

            // Employee-specific mapping
            CreateMap<Employee, EmployeeResponse>();

            // Technician-specific mapping
            CreateMap<Technician, TechnicianResponse>();

            // Address mapping
            CreateMap<Address, AddressResponse>();
        }
    }
}
