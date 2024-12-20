﻿using AutoMapper;
using Helpline.Contracts.v1.Responses;
using Helpline.Domain.Models.Entities;

namespace Helpline.API.Gateway.MappingProfiles
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

            // Vehicle mapping
            CreateMap<CustomerVehicle, VehicleResponse>();

            // Subscription mapping
            CreateMap<Subscription, SubscriptionResponse>();

            // ServiceCase mapping
            CreateMap<ServiceCase, ServiceCaseResponse>();
        }
    }
}
