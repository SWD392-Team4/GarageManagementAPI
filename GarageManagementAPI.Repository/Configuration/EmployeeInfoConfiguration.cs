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

            entity.Property(e => e.Id).ValueGeneratedNever();
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
                    CreatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    DateOfBirth = DateOnly.MinValue,
                    Gender = true,
                },
                new EmployeeInfo()
                {
                    Id = new Guid("b78245a2-a2bf-45b4-8572-b2c3f1948629"),
                    CitizenIdentification = "5124",
                    WorkplaceId = new Guid("E3DBF2C8-899D-4B2A-91F7-D2315D3F3BCB"),
                    CreatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    DateOfBirth = DateOnly.MinValue,
                    Gender = true,
                }
                ,
                new EmployeeInfo()
                {
                    Id = new Guid("f8a4e60d-3113-4f25-8477-be205b0860c9"),
                    CitizenIdentification = "66316",
                    WorkplaceId = new Guid("E3DBF2C8-899D-4B2A-91F7-D2315D3F3BCB"),
                    CreatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    DateOfBirth = DateOnly.MinValue,
                    Gender = true,
                },
                new EmployeeInfo()
                {
                    Id = new Guid("e2060ff5-5fb9-4b20-a11a-bf6ae4716ad5"),
                    CitizenIdentification = "616747",
                    WorkplaceId = new Guid("C1AEB9E5-8C74-4B09-BC57-D4C3DF7857F9"),
                    CreatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    DateOfBirth = DateOnly.MinValue,
                    Gender = false,
                },
                new EmployeeInfo()
                {
                    Id = new Guid("de0d20e6-17e6-40e8-8274-c89a66e64fa5"),
                    CitizenIdentification = "782135",
                    WorkplaceId = new Guid("C1AEB9E5-8C74-4B09-BC57-D4C3DF7857F9"),
                    CreatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    DateOfBirth = DateOnly.MinValue,
                    Gender = true,
                }
            );
        }
    }
}




