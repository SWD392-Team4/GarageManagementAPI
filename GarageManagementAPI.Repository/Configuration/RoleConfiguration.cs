using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Enum;
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
                    Name = SystemRole.Cashier.ToString(),
                    NormalizedName = SystemRole.Cashier.ToString().ToUpper(),
                },
                new IdentityRole
                {
                    Id = "3c5c548b-b789-41b5-b216-48ddfb5e732a",
                    Name = SystemRole.Mechanic.ToString(),
                    NormalizedName = SystemRole.Mechanic.ToString().ToUpper(),
                },
                new IdentityRole
                {
                    Id = "7d2b39a7-3d9d-4583-acd5-985611a29a5b",
                    Name = SystemRole.Customer.ToString(),
                    NormalizedName = SystemRole.Customer.ToString().ToUpper(),
                },
                new IdentityRole
                {
                    Id = "b10aa072-2522-41d9-8e12-c20f28082a0e",
                    Name = SystemRole.WarehouseManager.ToString(),
                    NormalizedName = SystemRole.WarehouseManager.ToString().ToUpper(),
                },
                new IdentityRole
                {
                    Id = "ef3629ba-332e-4c46-9fa8-54444803f925",
                    Name = SystemRole.Admin.ToString(),
                    NormalizedName = SystemRole.Admin.ToString().ToUpper(),
                });

        }
    }
}
