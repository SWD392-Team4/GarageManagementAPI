using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Repository.Configuration;
using Microsoft.EntityFrameworkCore;

namespace GarageManagementAPI.Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GarageConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }

        public DbSet<Garage>? Garages { get; set; }

        public DbSet<Employee>? Employees { get; set; }
    }
}
