using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class EmployeeInfoConfiguration : ConfigurationBase<EmployeeInfo>
    {
        protected override void ModelCreating(EntityTypeBuilder<EmployeeInfo> entity)
        {
            entity.HasKey(e => e.Id).HasName("employeeinfo_userid_primary");

            entity.ToTable("EmployeeInfo");

            entity.HasIndex(e => e.CitizenIdentification, "employeeinfo_citizenidentification_unique").IsUnique();

            entity.HasIndex(e => e.WorkplaceId, "employeeinfo_workplaceid_index");

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            entity.Property(e => e.CitizenIdentification).HasMaxLength(255);

            entity.HasOne(d => d.User).WithOne(p => p.EmployeeInfo)
                .HasForeignKey<EmployeeInfo>(d => d.Id)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("employeeinfo_userid_foreign");

            entity.HasOne(d => d.Workplace).WithMany(p => p.EmployeeInfos)
                .HasForeignKey(d => d.WorkplaceId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("employeeinfo_workplaceid_foreign");


        }

        protected override void SeedData(EntityTypeBuilder<EmployeeInfo> entity)
        {
            entity.HasData(
                new EmployeeInfo()
                {
                    Id = new Guid("1230a288-3e5e-4ee1-a75c-3fd7af6480a0"),
                    CitizenIdentification = "1234",
                    WorkplaceId = new Guid("E3DBF2C8-899D-4B2A-91F7-D2315D3F3BCB"),
                    DateOfBirth = DateOnly.MinValue,
                    Gender = true,
                },
                new EmployeeInfo()
                {
                    Id = new Guid("b78245a2-a2bf-45b4-8572-b2c3f1948629"),
                    CitizenIdentification = "5124",
                    WorkplaceId = new Guid("E3DBF2C8-899D-4B2A-91F7-D2315D3F3BCB"),
                    DateOfBirth = DateOnly.MinValue,
                    Gender = true,
                }
                ,
                new EmployeeInfo()
                {
                    Id = new Guid("f8a4e60d-3113-4f25-8477-be205b0860c9"),
                    CitizenIdentification = "66316",
                    WorkplaceId = new Guid("E3DBF2C8-899D-4B2A-91F7-D2315D3F3BCB"),
                    DateOfBirth = DateOnly.MinValue,
                    Gender = true,
                },
                new EmployeeInfo()
                {
                    Id = new Guid("e2060ff5-5fb9-4b20-a11a-bf6ae4716ad5"),
                    CitizenIdentification = "616747",
                    WorkplaceId = new Guid("C1AEB9E5-8C74-4B09-BC57-D4C3DF7857F9"),
                    DateOfBirth = DateOnly.MinValue,
                    Gender = false,
                },
                new EmployeeInfo()
                {
                    Id = new Guid("de0d20e6-17e6-40e8-8274-c89a66e64fa5"),
                    CitizenIdentification = "782135",
                    WorkplaceId = new Guid("C1AEB9E5-8C74-4B09-BC57-D4C3DF7857F9"),
                    DateOfBirth = DateOnly.MinValue,
                    Gender = true,
                }
                //Mechanic
                ,
                new EmployeeInfo()
                {
                    Id = new Guid("0a1b2c3d-4e5f-6789-abcd-ef0123456789"),
                    CitizenIdentification = "78213515",
                    WorkplaceId = new Guid("c1aeb9e5-8c74-4b09-bc57-d4c3df7857f9"),
                    DateOfBirth = DateOnly.MinValue,
                    Gender = true,
                },
                new EmployeeInfo()
                {
                    Id = new Guid("1b2c3d4e-5f67-89ab-cdef-0123456789ab"),
                    CitizenIdentification = "78213514",
                    WorkplaceId = new Guid("c1aeb9e5-8c74-4b09-bc57-d4c3df7857f9"),
                    DateOfBirth = DateOnly.MinValue,
                    Gender = true,
                },
                new EmployeeInfo()
                {
                    Id = new Guid("2c3d4e5f-6789-abcd-ef01-23456789abcd"),
                    CitizenIdentification = "78213513",
                    WorkplaceId = new Guid("c1aeb9e5-8c74-4b09-bc57-d4c3df7857f9"),
                    DateOfBirth = DateOnly.MinValue,
                    Gender = true,
                },
                new EmployeeInfo()
                {
                    Id = new Guid("3d4e5f67-89ab-cdef-0123-456789abcdef"),
                    CitizenIdentification = "78213512",
                    WorkplaceId = new Guid("c1aeb9e5-8c74-4b09-bc57-d4c3df7857f9"),
                    DateOfBirth = DateOnly.MinValue,
                    Gender = true,
                },
                new EmployeeInfo()
                {
                    Id = new Guid("4e5f6789-abcd-ef01-2345-6789abcdef01"),
                    CitizenIdentification = "78213511",
                    WorkplaceId = new Guid("c1aeb9e5-8c74-4b09-bc57-d4c3df7857f9"),
                    DateOfBirth = DateOnly.MinValue,
                    Gender = true,
                },
                //Garage 2
                new EmployeeInfo()
                {
                    Id = new Guid("5f6789ab-cdef-0123-4567-89abcdef0123"),
                    CitizenIdentification = "51249",
                    WorkplaceId = new Guid("6760cbb7-f1fa-445f-a175-97e3f060c861"),
                    DateOfBirth = DateOnly.MinValue,
                    Gender = true,
                },
                new EmployeeInfo()
                {
                    Id = new Guid("6789abcd-ef01-2345-6789-abcdef012345"),
                    CitizenIdentification = "51248",
                    WorkplaceId = new Guid("6760cbb7-f1fa-445f-a175-97e3f060c861"),
                    DateOfBirth = DateOnly.MinValue,
                    Gender = true,
                },
                new EmployeeInfo()
                {
                    Id = new Guid("789abcde-f012-3456-789a-bcdef0123456"),
                    CitizenIdentification = "51247",
                    WorkplaceId = new Guid("6760cbb7-f1fa-445f-a175-97e3f060c861"),
                    DateOfBirth = DateOnly.MinValue,
                    Gender = true,
                },
                new EmployeeInfo()
                {
                    Id = new Guid("89abcdef-0123-4567-89ab-cdef01234567"),
                    CitizenIdentification = "51246",
                    WorkplaceId = new Guid("6760cbb7-f1fa-445f-a175-97e3f060c861"),
                    DateOfBirth = DateOnly.MinValue,
                    Gender = true,
                },
                new EmployeeInfo()
                {
                    Id = new Guid("9abcdef0-1234-5678-9abc-def012345678"),
                    CitizenIdentification = "51245",
                    WorkplaceId = new Guid("6760cbb7-f1fa-445f-a175-97e3f060c861"),
                    DateOfBirth = DateOnly.MinValue,
                    Gender = true,
                },
                //Cashier
                new EmployeeInfo()
                {
                    Id = new Guid("abcd1234-ef56-7890-abcd-ef1234567890"),
                    CitizenIdentification = "7821354",
                    WorkplaceId = new Guid("C1AEB9E5-8C74-4B09-BC57-D4C3DF7857F9"),
                    DateOfBirth = DateOnly.MinValue,
                    Gender = true,
                },
                new EmployeeInfo()
                {
                    Id = new Guid("bcde2345-f678-9012-bcde-f23456789012"),
                    CitizenIdentification = "51243",
                    WorkplaceId = new Guid("6760cbb7-f1fa-445f-a175-97e3f060c861"),
                    DateOfBirth = DateOnly.MinValue,
                    Gender = true,
                },
                //Warehouse manager
                new EmployeeInfo()
                {
                    Id = new Guid("cdef3456-7890-1234-cdef-345678901234"),
                    CitizenIdentification = "7821352",
                    WorkplaceId = new Guid("4c809c47-7e87-4cec-a883-30e2718fed5e"),
                    DateOfBirth = DateOnly.MinValue,
                    Gender = true,
                },
                new EmployeeInfo()
                {
                    Id = new Guid("def45678-9012-3456-def0-456789012345"),
                    CitizenIdentification = "51241",
                    WorkplaceId = new Guid("E3DBF2C8-899D-4B2A-91F7-D2315D3F3BCB"),
                    DateOfBirth = DateOnly.MinValue,
                    Gender = true,
                }
            );
        }
    }
}




