using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class RolesConfiguration : ConfigurationBase<Roles>
    {
        protected override void SeedData(EntityTypeBuilder<Roles> entity)
        {
            entity.HasData(
                new Roles
                {
                    Id = new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb739"),
                    Name = SystemRole.Cashier.ToString(),
                    NormalizedName = SystemRole.Cashier.ToString().ToUpper(),
                },
                new Roles
                {
                    Id = new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"),
                    Name = SystemRole.Mechanic.ToString(),
                    NormalizedName = SystemRole.Mechanic.ToString().ToUpper(),
                },
                new Roles
                {
                    Id = new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"),
                    Name = SystemRole.Customer.ToString(),
                    NormalizedName = SystemRole.Customer.ToString().ToUpper(),
                },
                new Roles
                {
                    Id = new Guid("b10aa072-2522-41d9-8e12-c20f28082a0e"),
                    Name = SystemRole.WarehouseManager.ToString(),
                    NormalizedName = SystemRole.WarehouseManager.ToString().ToUpper(),
                },
                new Roles
                {
                    Id = new Guid("ef3629ba-332e-4c46-9fa8-54444803f925"),
                    Name = SystemRole.Administrator.ToString(),
                    NormalizedName = SystemRole.Administrator.ToString().ToUpper(),
                });
        }
    }
}




