using Helpline.DataAccess.Helpers;
using Helpline.Shared.Models;
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
        public DbSet<RVPartsDepartment> RVPartsDepartments => Set<RVPartsDepartment>();
        public DbSet<RVRental> RVRentals => Set<RVRental>();
        public DbSet<ServiceDetail> ServiceDetails => Set<ServiceDetail>();
        public DbSet<ServiceCase> ServiceCases => Set<ServiceCase>();
        public DbSet<ServiceCaseCall> ServiceCaseCalls => Set<ServiceCaseCall>();
        public DbSet<Subscription> Subscriptions => Set<Subscription>();
        public DbSet<Tags> Tags => Set<Tags>();
        public DbSet<ApplicationUser> ApplicationUsers => Set<ApplicationUser>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ModelCreator();
            modelBuilder.ModelSeeds();
        }
    }
}
