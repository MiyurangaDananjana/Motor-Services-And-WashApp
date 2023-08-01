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
    }
}
