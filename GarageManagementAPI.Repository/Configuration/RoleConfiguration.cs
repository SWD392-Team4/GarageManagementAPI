using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Constant;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class RoleConfiguration : ConfigurationBase<IdentityRole>
    {
        protected override void SeedData(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "2bad4a96-6dff-4fa3-9c2e-6899264fb739",
                    Name = SystemRole.Cashier,
                    NormalizedName = SystemRole.Cashier.ToUpper(),
                },
                new IdentityRole
                {
                    Id = "3c5c548b-b789-41b5-b216-48ddfb5e732a",
                    Name = SystemRole.Mechanic,
                    NormalizedName = SystemRole.Mechanic.ToUpper(),
                },
                new IdentityRole
                {
                    Id = "7d2b39a7-3d9d-4583-acd5-985611a29a5b",
                    Name = SystemRole.Customer,
                    NormalizedName = SystemRole.Customer.ToUpper(),
                },
                new IdentityRole
                {
                    Id = "b10aa072-2522-41d9-8e12-c20f28082a0e",
                    Name = SystemRole.WarehouseManager,
                    NormalizedName = SystemRole.WarehouseManager.ToUpper(),
                },
                new IdentityRole
                {
                    Id = "ef3629ba-332e-4c46-9fa8-54444803f925",
                    Name = SystemRole.Administrator,
                    NormalizedName = SystemRole.Administrator.ToUpper(),
                });

        }
    }
}
