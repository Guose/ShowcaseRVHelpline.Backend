using AutoMapper;
using Helpline.Common.Models;
using Helpline.UserServices.DTOs.Requests;
using Microsoft.AspNetCore.Identity;

namespace Helpline.WebAPI.MappingProfiles
{
    public class RequestToDomain : Profile
    {
        public RequestToDomain()
        {
            // Base User to User Response mapping
            CreateMap<UserRequest, ApplicationUser>()
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => HashPassword(src)));

            // Customer-specific mapping
            CreateMap<CustomerRequest, Customer>();

            // Employee-specific mapping
            CreateMap<EmployeeRequest, Employee>();

            // Technician-specific mapping
            CreateMap<TechnicianRequest, Technician>();

            // Address mapping
            CreateMap<AddressRequest, Address>();
        }

        private static string HashPassword(UserRequest src)
        {
            return new PasswordHasher<UserRequest>().HashPassword(src, src.Password);
        }
    }
}
