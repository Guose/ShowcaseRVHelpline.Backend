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
            modelBuilder.Entity<ApplicationUser>()
                .HasOne(a => a.Address)
                .WithOne(u => u.User)
                .HasForeignKey<ApplicationUser>(a => a.AddressId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Dealership>()
                .HasOne(a => a.Address)
                .WithOne(d => d.Dealership)
                .HasForeignKey<Dealership>(a => a.AddressId)
                .OnDelete(DeleteBehavior.Restrict);

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

            modelBuilder.Entity<RVRental>()
                .HasOne(c => c.Checkout)
                .WithOne(r => r.Rental)
                .HasForeignKey<RVRental>(c => c.CheckoutId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RVRental>()
                .HasOne(r => r.Return)
                .WithOne(rent => rent.Rental)
                .HasForeignKey<RVRental>(r => r.ReturnId)
                .OnDelete(DeleteBehavior.Restrict);

            // ONE-TO-MANY RELATIONSHIPS
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

            modelBuilder.Entity<Technician>()
                .HasMany(s => s.Services)
                .WithOne();
            
            modelBuilder.Entity<Employee>()
                .HasMany(s => s.Services)
                .WithOne();


            // Many to Many relationship between Rv and Rental
            // ServiceCaseCall-to-ServiceType (Many-to-Many)
            modelBuilder.Entity<ServiceCaseCallServiceType>()
                .HasKey(sc => new { sc.ServiceCaseCallId, sc.ServiceTypeId });
            modelBuilder.Entity<ServiceCaseCallServiceType>()
                .HasOne(sc => sc.ServiceCaseCall)
                .WithMany(s => s.ServiceCaseCallServiceTypes)
                .HasForeignKey(sc => sc.ServiceCaseCallId);
            modelBuilder.Entity<ServiceCaseCallServiceType>()
                .HasOne(sc => sc.ServiceType)
                .WithMany(s => s.ServiceCaseCallServiceTypes)
                .HasForeignKey(sc => sc.ServiceTypeId);

            // CustomerVehicle-to-Renter (Many-to-Many)
            modelBuilder.Entity<VehicleRvRenter>()
            .HasKey(vr => new { vr.RenterId, vr.VehicleId });
            modelBuilder.Entity<VehicleRvRenter>()
                .HasOne(vr => vr.Renter)
                .WithMany(r => r.VehicleRvRenters)
                .HasForeignKey(vr => vr.RenterId);
            modelBuilder.Entity<VehicleRvRenter>()
                .HasOne(vr => vr.Vehicle)
                .WithMany(v => v.VehicleRvRenters)
                .HasForeignKey(vr => vr.VehicleId);

            // ServiceCase-to-Tag (Many-to-Many)
            modelBuilder.Entity<ServiceCaseTag>()
                .HasKey(sct => new { sct.ServiceCaseId, sct.TagId });
            modelBuilder.Entity<ServiceCaseTag>()
                .HasOne(sc => sc.ServiceCase)
                .WithMany(sct => sct.ServiceCaseTags)
                .HasForeignKey(sct => sct.ServiceCaseId);
            modelBuilder.Entity<ServiceCaseTag>()
                .HasOne(t => t.Tag)
                .WithMany(sct => sct.ServiceCaseTags)
                .HasForeignKey(sct => sct.TagId);

            modelBuilder.Entity<KnowledgeBaseTag>()
                .HasKey(kbt => new { kbt.KnowledgeBaseId, kbt.TagId });
            modelBuilder.Entity<KnowledgeBaseTag>()
                .HasOne(kb => kb.KnowledgeBaseLibrary)
                .WithMany(kbt => kbt.KnowledgeBaseTags)
                .HasForeignKey(kbt => kbt.KnowledgeBaseId);
            modelBuilder.Entity<KnowledgeBaseTag>()
                .HasOne(t => t.Tag)
                .WithMany(kbt => kbt.KnowledgeBaseTags)
                .HasForeignKey(kbt => kbt.TagId);
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
            modelBuilder.Entity<RVRental>().HasData(seedData.GetRVRentalsSeeds());
            modelBuilder.Entity<ServiceDetail>().HasData(seedData.GetServiceDetailSeeds());
            modelBuilder.Entity<ServiceCase>().HasData(seedData.GetServiceCaseSeeds());
            modelBuilder.Entity<ServiceCaseCall>().HasData(seedData.GetServiceCaseCallSeeds());
            modelBuilder.Entity<Subscription>().HasData(seedData.GetSubscriptionSeeds());
            modelBuilder.Entity<Technician>().HasData(seedData.GetTechnicianSeeds());
        }
    }
}
