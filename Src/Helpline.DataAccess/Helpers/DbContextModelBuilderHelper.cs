﻿using Helpline.DataAccess.Outbox;
using Helpline.DataAccess.Seeds;
using Helpline.Domain.Models.Entities;
using Helpline.Domain.Models.Entities.Associations;
using Microsoft.EntityFrameworkCore;

namespace Helpline.DataAccess.Helpers
{
    public static class DbContextModelBuilderHelper
    {
        public static void ModelCreator(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServiceClass>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<OutboxMessage>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<OutboxMessageConsumer>()
                .HasKey(outboxMessgaeConsumer => new
                {
                    outboxMessgaeConsumer.Id,
                    outboxMessgaeConsumer.Name
                });

            modelBuilder.Entity<Tag>()
                .HasIndex(t => t.TagName)
                .IsUnique();

            // ONE-TO-ONE RELATIONSHIP
            modelBuilder.Entity<Dealership>()
                .HasOne(a => a.Address)
                .WithOne(d => d.Dealership)
                .HasForeignKey<Dealership>(a => a.AddressId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.User)
                .WithOne(u => u.Customer)
                .HasForeignKey<Customer>(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.User)
                .WithOne(u => u.Employee)
                .HasForeignKey<Employee>(e => e.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Technician>()
                .HasOne(t => t.User)
                .WithOne(u => u.Technician)
                .HasForeignKey<Technician>(t => t.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DealershipContact>()
                .HasOne(d => d.User)
                .WithOne(u => u.DealershipContact)
                .HasForeignKey<DealershipContact>(d => d.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<RVRental>()
                .HasOne(c => c.Checkout)
                .WithOne(r => r.Rental)
                .HasForeignKey<RVRental>(c => c.CheckoutId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<RVRental>()
                .HasOne(r => r.Return)
                .WithOne(rent => rent.Rental)
                .HasForeignKey<RVRental>(r => r.ReturnId)
                .OnDelete(DeleteBehavior.NoAction);

            // ONE-TO-MANY RELATIONSHIPS
            // Address to Users
            modelBuilder.Entity<ApplicationUser>()
                .HasOne(a => a.Address)
                .WithMany(u => u.Users)
                .HasForeignKey(a => a.AddressId)
                .OnDelete(DeleteBehavior.NoAction);

            // Customer to Vehicles
            modelBuilder.Entity<CustomerVehicle>()
                .HasOne(c => c.Customer)
                .WithMany(cv => cv.CustomerVehicles)
                .HasForeignKey(cv => cv.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

            // Subscription to Customers
            modelBuilder.Entity<Customer>()
                .HasOne(s => s.Subscription)
                .WithMany(c => c.Customers)
                .HasForeignKey(s => s.SubscriptionId)
                .OnDelete(DeleteBehavior.NoAction);

            // Service Case To Vehicle
            modelBuilder.Entity<ServiceCase>()
                .HasOne(v => v.CustomerVehicle)
                .WithMany(sc => sc.ServiceCases)
                .HasForeignKey(v => v.CustomerVehicleId)
                .OnDelete(DeleteBehavior.NoAction);

            // Service Case To Customer
            modelBuilder.Entity<ServiceCase>()
                .HasOne(c => c.Customer)
                .WithMany(sc => sc.ServiceCases)
                .HasForeignKey(c => c.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

            // Service Case To Technician
            modelBuilder.Entity<ServiceCase>()
                .HasOne(t => t.Technician)
                .WithMany(sc => sc.ServiceCases)
                .HasForeignKey(t => t.TechnicianId)
                .OnDelete(DeleteBehavior.NoAction);

            // Service Case To Employee
            modelBuilder.Entity<ServiceCase>()
                .HasOne(e => e.Employee)
                .WithMany(sc => sc.ServiceCases)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);

            // Service Case Call to Service Cases
            modelBuilder.Entity<ServiceCaseCall>()
                .HasOne(scc => scc.ServiceCase)
                .WithMany(sc => sc.ServiceCaseCalls)
                .HasForeignKey(scc => scc.ServiceCaseId)
                .OnDelete(DeleteBehavior.NoAction);

            // Service Case Call to KnowledgeBase Libraries
            modelBuilder.Entity<ServiceCaseCall>()
                .HasOne(kb => kb.KnowledgeBaseLibrary)
                .WithMany(scc => scc.ServiceCaseCalls)
                .HasForeignKey(kb => kb.KnowledgeBaseLibraryId)
                .OnDelete(DeleteBehavior.NoAction);

            // Dealership Contact to Dealerships
            modelBuilder.Entity<DealershipContact>()
                .HasOne(d => d.Dealership)
                .WithMany(dc => dc.DealershipContacts)
                .HasForeignKey(d => d.DealershipId)
                .OnDelete(DeleteBehavior.NoAction);


            // Many to Many relationship between Rv and Rental
            // ServiceCaseCall-to-ServiceClass (Many-to-Many)
            modelBuilder.Entity<ServiceCaseCallServiceClass>()
                .HasKey(sc => new { sc.ServiceCaseCallId, sc.ServiceClassId });

            modelBuilder.Entity<ServiceCaseCallServiceClass>()
                .HasOne(sc => sc.ServiceCaseCall)
                .WithMany(s => s.ServiceCaseCallServiceClasses)
                .HasForeignKey(sc => sc.ServiceCaseCallId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ServiceCaseCallServiceClass>()
                .HasOne(sc => sc.ServiceClass)
                .WithMany(s => s.ServiceCaseCallServiceClasses)
                .HasForeignKey(sc => sc.ServiceClassId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ServiceCaseCallServiceClass>()
                .HasKey(scc => new { scc.ServiceCaseCallId, scc.ServiceClassId })
                .HasName("PK_ServiceCaseCallServiceClasses");

            modelBuilder.Entity<ServiceCaseCall>()
                .HasMany(sccsc => sccsc.ServiceCaseCallServiceClasses)
                .WithOne(scc => scc.ServiceCaseCall)
                .HasForeignKey(scc => scc.ServiceCaseCallId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ServiceCaseCall>()
                .HasKey(scc => scc.Id)
                .HasName("PK_ServiceCaseCalls");
            modelBuilder.Entity<ServiceCaseCall>()
                .Property(scc => scc.ServiceType)
                .HasConversion<byte>();

            modelBuilder.Entity<ServiceClass>()
                .HasMany(sc => sc.ServiceCaseCallServiceClasses)
                .WithOne(sc => sc.ServiceClass)
                .HasForeignKey(sc => sc.ServiceClassId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ServiceClass>()
                .HasKey(sc => sc.Id)
                .HasName("PK_ServiceClasses");
            modelBuilder.Entity<ServiceClass>()
                .Property(sc => sc.ServiceType)
                .HasConversion<byte>();

            modelBuilder.Entity<KnowledgeBaseLibrary>()
                .Property(k => k.ServiceType)
                .HasConversion<int>();

            // CustomerVehicle-to-Renter (Many-to-Many)
            modelBuilder.Entity<VehicleRvRenter>()
            .HasKey(vr => new { vr.RenterId, vr.VehicleId });
            modelBuilder.Entity<VehicleRvRenter>()
                .HasOne(vr => vr.Renter)
                .WithMany(r => r.VehicleRvRenters)
                .HasForeignKey(vr => vr.RenterId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<VehicleRvRenter>()
                .HasOne(vr => vr.Vehicle)
                .WithMany(v => v.VehicleRvRenters)
                .HasForeignKey(vr => vr.VehicleId)
                .OnDelete(DeleteBehavior.NoAction);

            // ServiceCase-to-Tag (Many-to-Many)
            modelBuilder.Entity<ServiceCaseTag>()
                .HasKey(sct => new { sct.ServiceCaseId, sct.TagId });
            modelBuilder.Entity<ServiceCaseTag>()
                .HasOne(sc => sc.ServiceCase)
                .WithMany(sct => sct.ServiceCaseTags)
                .HasForeignKey(sct => sct.ServiceCaseId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ServiceCaseTag>()
                .HasOne(t => t.Tag)
                .WithMany(sct => sct.ServiceCaseTags)
                .HasForeignKey(sct => sct.TagId)
                .OnDelete(DeleteBehavior.NoAction);

            // KnowledgeBaseLibrary-to-Tag (Many-to-Many)
            modelBuilder.Entity<KnowledgeBaseTag>()
                .HasKey(kbt => new { kbt.KnowledgeBaseId, kbt.TagId });
            modelBuilder.Entity<KnowledgeBaseTag>()
                .HasOne(kb => kb.KnowledgeBaseLibrary)
                .WithMany(kbt => kbt.KnowledgeBaseTags)
                .HasForeignKey(kbt => kbt.KnowledgeBaseId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<KnowledgeBaseTag>()
                .HasOne(t => t.Tag)
                .WithMany(kbt => kbt.KnowledgeBaseTags)
                .HasForeignKey(kbt => kbt.TagId)
                .OnDelete(DeleteBehavior.NoAction);

            // Employee-to-ServiceClass (Many-to-Many)
            modelBuilder.Entity<EmployeeService>()
                .HasKey(es => new { es.EmployeeId, es.ServiceId });
            modelBuilder.Entity<EmployeeService>()
                .HasOne(e => e.Employee)
                .WithMany(es => es.EmployeeServices)
                .HasForeignKey(es => es.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<EmployeeService>()
                .HasOne(s => s.Service)
                .WithMany(es => es.EmployeeServices)
                .HasForeignKey(es => es.ServiceId)
                .OnDelete(DeleteBehavior.NoAction);

            // Technician-to-ServiceClass (Many-to-Many)
            modelBuilder.Entity<TechnicianService>()
                .HasKey(ts => new { ts.TechnicianId, ts.ServiceId });
            modelBuilder.Entity<TechnicianService>()
                .HasOne(t => t.Technician)
                .WithMany(ts => ts.TechnicianServices)
                .HasForeignKey(ts => ts.TechnicianId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<TechnicianService>()
                .HasOne(s => s.Service)
                .WithMany(ts => ts.TechnicianServices)
                .HasForeignKey(ts => ts.ServiceId)
                .OnDelete(DeleteBehavior.NoAction);
        }
        public static void ModelSeeds(this ModelBuilder modelBuilder)
        {
            HelplineSeedResolver seedData = new();

            var addresses = seedData.LoadJsonDataAsync<Address>("address.json");
            modelBuilder.Entity<Address>().HasData(addresses);

            var tags = seedData.LoadJsonDataAsync<Tag>("tag.json");
            var tagSeeds = seedData.UpdateCreatedOnData(tags);
            modelBuilder.Entity<Tag>().HasData(tagSeeds);

            var services = seedData.LoadJsonDataAsync<RVService>("rvService.json");
            var serviceSeeds = seedData.UpdateCreatedOnData(services);
            modelBuilder.Entity<RVService>().HasData(serviceSeeds);

            var users = seedData.LoadJsonDataAsync<ApplicationUser>("user.json");
            var userSeeds = seedData.GetUserSeeds(users);
            modelBuilder.Entity<ApplicationUser>().HasData(userSeeds);

            var dealerships = seedData.LoadJsonDataAsync<Dealership>("dealership.json");
            var dealerSeeds = seedData.UpdateCreatedOnData(dealerships);
            modelBuilder.Entity<Dealership>().HasData(dealerSeeds);

            var employees = seedData.LoadJsonDataAsync<Employee>("employee.json");
            var empSeeds = seedData.UpdateCreatedOnData(employees);
            modelBuilder.Entity<Employee>().HasData(empSeeds);

            var technicians = seedData.LoadJsonDataAsync<Technician>("technician.json");
            var techSeeds = seedData.UpdateCreatedOnData(technicians);
            modelBuilder.Entity<Technician>().HasData(techSeeds);

            var subscriptions = seedData.LoadJsonDataAsync<Subscription>("subscription.json");
            var subscriptionSeeds = seedData.UpdateCreatedOnData(subscriptions);
            modelBuilder.Entity<Subscription>().HasData(subscriptionSeeds);

            var customers = seedData.LoadJsonDataAsync<Customer>("customer.json");
            var customerSeeds = seedData.CustomerUpdateData(customers);
            modelBuilder.Entity<Customer>().HasData(customerSeeds);

            var vehicles = seedData.LoadJsonDataAsync<CustomerVehicle>("customerVehicle.json");
            var rvSeeds = seedData.UpdateCreatedOnData(vehicles);
            modelBuilder.Entity<CustomerVehicle>().HasData(rvSeeds);

            var serviceType = seedData.LoadJsonDataAsync<ServiceClass>("servicesClass.json");
            var serviceTypeSeeds = seedData.UpdateCreatedOnData(serviceType);
            modelBuilder.Entity<ServiceClass>().HasData(serviceTypeSeeds);

            var serviceCases = seedData.LoadJsonDataAsync<ServiceCase>("serviceCase.json");
            var servCaseSeeds = seedData.ServiceUpdateData(serviceCases);
            modelBuilder.Entity<ServiceCase>().HasData(servCaseSeeds);

            var knowledgeBaseLibraries = seedData.LoadJsonDataAsync<KnowledgeBaseLibrary>("knowledgeBase.json");
            var kbSeeds = seedData.UpdateCreatedOnData(knowledgeBaseLibraries);
            modelBuilder.Entity<KnowledgeBaseLibrary>().HasData(kbSeeds);

            var serviceCaseCalls = seedData.LoadJsonDataAsync<ServiceCaseCall>("serviceCaseCall.json");
            var servCaseCallSeeds = seedData.UpdateCreatedOnData(serviceCaseCalls);
            modelBuilder.Entity<ServiceCaseCall>().HasData(servCaseCallSeeds);

            var renters = seedData.LoadJsonDataAsync<RVRenter>("renter.json");
            var renterSeeds = seedData.UpdateCreatedOnData(renters);
            modelBuilder.Entity<RVRenter>().HasData(renterSeeds);

            var rentals = seedData.LoadJsonDataAsync<RVRental>("rental.json");
            var rentalSeeds = seedData.UpdateStartAndEndDates(rentals);
            modelBuilder.Entity<RVRental>().HasData(rentalSeeds);

            var checkouts = seedData.LoadJsonDataAsync<RVCheckout>("checkout.json");
            var checkoutSeeds = seedData.UpdateCreatedOnData(checkouts);
            modelBuilder.Entity<RVCheckout>().HasData(checkouts);

            var returns = seedData.LoadJsonDataAsync<RVReturn>("return.json");
            var returnSeeds = seedData.UpdateCreatedOnData(returns);
            modelBuilder.Entity<RVReturn>().HasData(returns);

            var employeeServices = seedData.LoadJsonDataAsync<EmployeeService>("employeeService.json");
            modelBuilder.Entity<EmployeeService>().HasData(employeeServices);

            var kbTags = seedData.LoadJsonDataAsync<KnowledgeBaseTag>("knowledgeBaseTag.json");
            modelBuilder.Entity<KnowledgeBaseTag>().HasData(kbTags);

            var serviceCallServiceType = seedData.LoadJsonDataAsync<ServiceCaseCallServiceClass>("serviceCaseCallServiceType.json");
            modelBuilder.Entity<ServiceCaseCallServiceClass>().HasData(serviceCallServiceType);

            var serviceCaseTags = seedData.LoadJsonDataAsync<ServiceCaseTag>("serviceCaseTags.json");
            modelBuilder.Entity<ServiceCaseTag>().HasData(serviceCaseTags);

            var technicianServices = seedData.LoadJsonDataAsync<TechnicianService>("technicianService.json");
            modelBuilder.Entity<TechnicianService>().HasData(technicianServices);

            var vehicleRenters = seedData.LoadJsonDataAsync<VehicleRvRenter>("vehicleRenter.json");
            modelBuilder.Entity<VehicleRvRenter>().HasData(vehicleRenters);
        }
    }
}
