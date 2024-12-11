using AutoMapper;
using Helpline.Contracts.v1.Requests;
using Helpline.Domain.Models.Entities;
using Helpline.Services.Users.ApplicationUsers.Commands;

namespace Helpline.API.Gateway.MappingProfiles
{
    public class RequestToDomain : Profile
    {
        public RequestToDomain()
        {
            // Base User to User Response mapping
            CreateMap<UserRequest, ApplicationUser>();
            CreateMap<UserUpdateCommand, ApplicationUser>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId.ToString()))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.SecondaryPhone, opt => opt.MapFrom(src => src.SecondaryPhone));
            CreateMap<UserPermissionsUpdateCommand, ApplicationUser>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId.ToString()))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.Permissions, opt => opt.MapFrom(src => src.Permissions));

            // Customer-specific mapping
            CreateMap<CustomerRequest, Customer>();

            // Employee-specific mapping
            CreateMap<EmployeeRequest, Employee>();

            // Technician-specific mapping
            CreateMap<TechnicianRequest, Technician>();

            // Address mapping
            CreateMap<AddressRequest, Address>();

            // Service Case mapping
            CreateMap<ServiceCaseRequest, ServiceCase>();
        }
    }
}
