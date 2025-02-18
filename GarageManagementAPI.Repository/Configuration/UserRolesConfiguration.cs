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
                //Customer
                ,
                new IdentityUserRole<Guid>
                {
                    RoleId = new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"),
                    UserId = new Guid("f7a8b9c0-d1e2-4f3a-8b4c-6d7e8f901234")
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"),
                    UserId = new Guid("e6f7a8b9-c0d1-4e2f-9a3b-5c6d7e8f9012")
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"),
                    UserId = new Guid("d5e6f7a8-b9c0-4d1e-8f2a-4b5c6d7e8f90")
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"),
                    UserId = new Guid("c4d5e6f7-a8b9-4c0d-9e1f-3a4b5c6d7e8f")
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"),
                    UserId = new Guid("b3c5d6e7-f8a9-4b0c-8d1e-2f3a4b5c6d7e")
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"),
                    UserId = new Guid("a2e4f1b2-6f2d-42f7-a2b5-3a9b8c1d2e3f")
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"),
                    UserId = new Guid("f1a3d7c8-3d50-42b7-9b92-b53717b8e7a8")
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"),
                    UserId = new Guid("d4b8cfb8-8b97-4d6d-bf1b-90f17fd853f3")
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"),
                    UserId = new Guid("67f4a543-7ff4-4db9-bf4a-748d3f9e13b1")
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = new Guid("7d2b39a7-3d9d-4583-acd5-985611a29a5b"),
                    UserId = new Guid("773d6761-8990-4408-be8f-321a7659825a")
                }
                //Mechanic
                ,
                new IdentityUserRole<Guid>
                {
                    RoleId = new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"),
                    UserId = new Guid("0a1b2c3d-4e5f-6789-abcd-ef0123456789")
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"),
                    UserId = new Guid("1b2c3d4e-5f67-89ab-cdef-0123456789ab")
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"),
                    UserId = new Guid("2c3d4e5f-6789-abcd-ef01-23456789abcd")
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"),
                    UserId = new Guid("3d4e5f67-89ab-cdef-0123-456789abcdef")
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"),
                    UserId = new Guid("4e5f6789-abcd-ef01-2345-6789abcdef01")
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"),
                    UserId = new Guid("5f6789ab-cdef-0123-4567-89abcdef0123")
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"),
                    UserId = new Guid("6789abcd-ef01-2345-6789-abcdef012345")
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"),
                    UserId = new Guid("89abcdef-0123-4567-89ab-cdef01234567")
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"),
                    UserId = new Guid("9abcdef0-1234-5678-9abc-def012345678")
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = new Guid("3c5c548b-b789-41b5-b216-48ddfb5e732a"),
                    UserId = new Guid("789abcde-f012-3456-789a-bcdef0123456")
                }
                //Cashier
                ,
                new IdentityUserRole<Guid>
                {
                    RoleId = new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb739"),
                    UserId = new Guid("abcd1234-ef56-7890-abcd-ef1234567890")
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = new Guid("2bad4a96-6dff-4fa3-9c2e-6899264fb739"),
                    UserId = new Guid("bcde2345-f678-9012-bcde-f23456789012")
                }
                //Warehouse Manager
                ,
                new IdentityUserRole<Guid>
                {
                    RoleId = new Guid("b10aa072-2522-41d9-8e12-c20f28082a0e"),
                    UserId = new Guid("cdef3456-7890-1234-cdef-345678901234")
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = new Guid("b10aa072-2522-41d9-8e12-c20f28082a0e"),
                    UserId = new Guid("def45678-9012-3456-def0-456789012345")
                }
            );
        }
    }
}
