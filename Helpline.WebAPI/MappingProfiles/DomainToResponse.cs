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
            CreateMap<ApplicationUser, UserResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));

            // Customer-specific mapping
            CreateMap<Customer, CustomerResponse>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));

            // Employee-specific mapping
            CreateMap<Employee, EmployeeResponse>();

            // Technician-specific mapping
            CreateMap<Technician, TechnicianResponse>();

            // Address mapping
            CreateMap<Address, AddressResponse>();
        }
    }
}
