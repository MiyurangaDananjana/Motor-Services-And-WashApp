using Microsoft.EntityFrameworkCore;
using MotorServicesAndWashApp.Models.Domain;

namespace MotorServicesAndWashApp.Data
{
    public class MotorServiceDbContext:DbContext
    {
        public MotorServiceDbContext(DbContextOptions options): base(options)
        {

        }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<UserSesstion> UserSesstions { get; set; }
        public DbSet<Districts> Districts { get; set; }
        public DbSet<Provinces> Provinces { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<VehicleTypes> VehicleTypes { get; set; }
        public DbSet<DayOfWeeksModel> DayOfWeeks { get; set; }
        public DbSet<DaysOfCloseModel> DaysOfClose { get; set; }
        public DbSet<ServiceCenter> ServiceCenter { get; set; }
        public DbSet<ServiceCenterLoginModel> ServiceCenterLogins { get; set; }
        public DbSet<ServiceVehicles> ServiceVehicles { get; set; }
    }
}
