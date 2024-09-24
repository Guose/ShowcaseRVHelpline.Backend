using Helpline.DataAccess.Helpers;
using Helpline.Shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Helpline.DataAccess.Context
{
    public class HelplineContext : IdentityDbContext<ApplicationUser>
    {
        public HelplineContext(DbContextOptions options) : base(options) { }

        public DbSet<Address> Addresses => Set<Address>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<CustomerVehicle> CustomerVehicles => Set<CustomerVehicle>();
        public DbSet<Dealership> Dealerships => Set<Dealership>();
        public DbSet<DealershipContact> DealershipContacts => Set<DealershipContact>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<KnowledgeBaseLibrary> KnowledgeBaseLibraries => Set<KnowledgeBaseLibrary>();
        public DbSet<RVRental> RVRentals => Set<RVRental>();
        public DbSet<RVReturn> Returns => Set<RVReturn>();
        public DbSet<RVCheckout> Checkouts => Set<RVCheckout>();
        public DbSet<ServiceDetail> ServiceDetails => Set<ServiceDetail>();
        public DbSet<ServiceCase> ServiceCases => Set<ServiceCase>();
        public DbSet<ServiceCaseCall> ServiceCaseCalls => Set<ServiceCaseCall>();
        public DbSet<Subscription> Subscriptions => Set<Subscription>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<ApplicationUser> ApplicationUsers => Set<ApplicationUser>();
        public DbSet<VehicleRvRenter> VehicleRvRenters => Set<VehicleRvRenter>();
        public DbSet<ServiceCaseTag> ServiceCaseTags => Set<ServiceCaseTag>();
        public DbSet<KnowledgeBaseTag> KnowledgeBaseTags => Set<KnowledgeBaseTag>();

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
            //modelBuilder.ModelSeeds();
        }
    }
}
