using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class UserRolesConfiguration : ConfigurationBase<IdentityUserRole<Guid>>
    {
        protected override void SeedData(EntityTypeBuilder<IdentityUserRole<Guid>> entity)
        {
            entity.HasData
            (
                new IdentityUserRole<Guid>
                {
                    RoleId = new Guid("ef3629ba-332e-4c46-9fa8-54444803f925"),
                    UserId = new Guid("1230a288-3e5e-4ee1-a75c-3fd7af6480a0")
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = new Guid("ef3629ba-332e-4c46-9fa8-54444803f925"),
                    UserId = new Guid("b78245a2-a2bf-45b4-8572-b2c3f1948629")
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = new Guid("ef3629ba-332e-4c46-9fa8-54444803f925"),
                    UserId = new Guid("f8a4e60d-3113-4f25-8477-be205b0860c9")
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = new Guid("ef3629ba-332e-4c46-9fa8-54444803f925"),
                    UserId = new Guid("e2060ff5-5fb9-4b20-a11a-bf6ae4716ad5")
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = new Guid("ef3629ba-332e-4c46-9fa8-54444803f925"),
                    UserId = new Guid("de0d20e6-17e6-40e8-8274-c89a66e64fa5")
                }
            );
        }
    }
}
