using Helpline.DataAccess.Seeds;
using Helpline.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Helpline.DataAccess.Helpers
{
    public static class DbContextModelBuilderHelper
    {
        public static void ModelCreator(this ModelBuilder modelBuilder)
        {
            // ONE-TO-ONE RELATIONSHIP
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.User)
                .WithOne(u => u.Customer)
                .HasForeignKey<Customer>(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.User)
                .WithOne(u => u.Employee)
                .HasForeignKey<Employee>(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Technician>()
                .HasOne(t => t.User)
                .WithOne(u => u.Technician)
                .HasForeignKey<Technician>(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DealershipContact>()
                .HasOne(d => d.User)
                .WithOne(u => u.DealershipContact)
                .HasForeignKey<DealershipContact>(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // ONE-TO-MANY RELATIONSHIPS
            // User to Addresses
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(a => a.Addresses)
                .WithOne(au => au.User)
                .HasForeignKey(au => au.UserId);

            // Customer to Vehicles
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.CustomerVehicles)
                .WithOne(cv => cv.Customer)
                .HasForeignKey(cv => cv.CustomerId);

            // Vehicle to Service Cases
            modelBuilder.Entity<CustomerVehicle>()
                .HasMany(cv => cv.ServiceCases)
                .WithOne(sc => sc.CustomerVehicle)
                .HasForeignKey(sc => sc.CustomerVehicleId);

            // Service Case to Service Case Calls
            modelBuilder.Entity<ServiceCase>()
                .HasMany(sc => sc.ServiceCaseCalls)
                .WithOne(scc => scc.ServiceCase)
                .HasForeignKey(scc => scc.ServiceCaseId);

            // Technician to Service Cases
            modelBuilder.Entity<Technician>()
                .HasMany(t => t.ServiceCases)
                .WithOne(sc => sc.Technician)
                .HasForeignKey(sc => sc.TechnicianId);

            // Employee to Service Cases
            modelBuilder.Entity<Employee>()
                .HasMany(sc => sc.ServiceCases)
                .WithOne(e => e.Employee)
                .HasForeignKey(e => e.EmployeeId);

            // KnowledgeBase Library to Service Case Calls
            modelBuilder.Entity<KnowledgeBaseLibrary>()
                .HasMany(sc => sc.ServiceCaseCalls)
                .WithOne(k => k.KnowledgeBaseLibrary)
                .HasForeignKey(k => k.KnowledgeBaseLibraryId);

            // Dealership to Dealership Contacts
            modelBuilder.Entity<Dealership>()
                .HasMany(d => d.DealershipContacts)
                .WithOne(dc => dc.Dealership)
                .HasForeignKey(dc => dc.DealershipId);
        }
        public static void ModelSeeds(this ModelBuilder modelBuilder)
        {
            var seedData = new HelplineSeedResolver();

            modelBuilder.Entity<ApplicationUser>().HasData(seedData.GetUserSeeds());
            modelBuilder.Entity<Address>().HasData(seedData.GetAddressSeeds());
            modelBuilder.Entity<Customer>().HasData(seedData.GetCustomerSeeds());
            modelBuilder.Entity<CustomerVehicle>().HasData(seedData.GetCustomerVehicleSeeds());
            modelBuilder.Entity<Dealership>().HasData(seedData.GetDealershipSeeds());
            modelBuilder.Entity<DealershipContact>().HasData(seedData.GetDealershipContactSeeds());
            modelBuilder.Entity<Employee>().HasData(seedData.GetEmployeeSeeds());
            modelBuilder.Entity<KnowledgeBaseLibrary>().HasData(seedData.GetKnowledgeBaseLibrarySeeds());
            modelBuilder.Entity<RVPartsDepartment>().HasData(seedData.GetRVPartsDepartmentSeeds());
            modelBuilder.Entity<RVRental>().HasData(seedData.GetRVRentalsSeeds());
            modelBuilder.Entity<ServiceDetail>().HasData(seedData.GetRVServicesSeeds());
            modelBuilder.Entity<ServiceCase>().HasData(seedData.GetServiceCaseSeeds());
            modelBuilder.Entity<ServiceCaseCall>().HasData(seedData.GetServiceCaseCallSeeds());
            modelBuilder.Entity<Subscription>().HasData(seedData.GetSubscriptionSeeds());
            modelBuilder.Entity<Technician>().HasData(seedData.GetTechnicianSeeds());
        }
    }
}
