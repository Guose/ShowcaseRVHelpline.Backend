using Helpline.DataAccess.Helpers;
using Helpline.DataAccess.Models.Entities;
using Helpline.DataAccess.Models.Entities.Associations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Helpline.DataAccess.Context
{
    public class HelplineContext : IdentityDbContext<ApplicationUser>
    {
        public HelplineContext(DbContextOptions options) : base(options) { }

        public DbSet<Address> Addresses => Set<Address>();
        public DbSet<ApplicationUser> ApplicationUsers => Set<ApplicationUser>();
        public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<CustomerVehicle> CustomerVehicles => Set<CustomerVehicle>();
        public DbSet<Dealership> Dealerships => Set<Dealership>();
        public DbSet<DealershipContact> DealershipContacts => Set<DealershipContact>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<EmployeeService> EmployeeServices => Set<EmployeeService>();
        public DbSet<KnowledgeBaseLibrary> KnowledgeBaseLibraries => Set<KnowledgeBaseLibrary>();
        public DbSet<KnowledgeBaseTag> KnowledgeBaseTags => Set<KnowledgeBaseTag>();
        public DbSet<RVCheckout> Checkouts => Set<RVCheckout>();
        public DbSet<RVRental> RVRentals => Set<RVRental>();
        public DbSet<RVRenter> RVRenters => Set<RVRenter>();
        public DbSet<RVReturn> Returns => Set<RVReturn>();
        public DbSet<ServiceCase> ServiceCases => Set<ServiceCase>();
        public DbSet<ServiceCaseCall> ServiceCaseCalls => Set<ServiceCaseCall>();
        public DbSet<ServiceCaseCallServiceClass> ServiceCaseCallServiceClasses => Set<ServiceCaseCallServiceClass>();
        public DbSet<ServiceCaseTag> ServiceCaseTags => Set<ServiceCaseTag>();
        public DbSet<RVService> RVServices => Set<RVService>();
        public DbSet<ServiceClass> ServiceClasses => Set<ServiceClass>();
        public DbSet<Subscription> Subscriptions => Set<Subscription>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<Technician> Technicians => Set<Technician>();
        public DbSet<TechnicianService> TechnicianServices => Set<TechnicianService>();
        public DbSet<VehicleRvRenter> VehicleRvRenters => Set<VehicleRvRenter>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");

            modelBuilder.ModelCreator();

            modelBuilder.Entity<ServiceClass>()
                .HasKey(x => x.Id);

            // modelBuilder.ModelSeeds();
        }
    }
}
