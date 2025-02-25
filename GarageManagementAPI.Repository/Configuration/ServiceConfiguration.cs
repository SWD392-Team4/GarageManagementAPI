using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class ServiceConfiguration : ConfigurationBase<Service>
    {
        protected override void ModelCreating(EntityTypeBuilder<Service> entity)
        {
            entity.HasKey(e => e.Id).HasName("service_id_primary");

            entity.ToTable("Service");

            entity.HasIndex(e => e.CarPartId, "service_carpartid_index");

            entity.HasIndex(e => new { e.ServiceCategory, e.WorkNature, e.Action, e.CarCategoryId }, "service_servicecategory_worknature_action_carcategoryid_unique").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            entity.Property(e => e.Action).HasMaxLength(255);
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.ServiceCategory).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(255);
            entity.Property(e => e.WorkNature).HasMaxLength(255);

            entity.HasOne(d => d.CarCategory).WithMany(p => p.Services)
                .HasForeignKey(d => d.CarCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("service_carcategoryid_foreign");

            entity.HasOne(d => d.CarPart).WithMany(p => p.Services)
                .HasForeignKey(d => d.CarPartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("service_carpartid_foreign");


            entity.Property(e => e.Status)
                .HasConversion<string>();
        }

        protected override void SeedData(EntityTypeBuilder<Service> entity)
        {
            entity.HasData(
                new Service()
                {
                    Id = new Guid("7d0e4fb5-6e8e-48fc-ba2b-daa570f5f96f"),
                    CarPartId = Guid.Parse("82B56CC1-7122-46EC-817E-B06CD0747F55"),
                    CarCategoryId = Guid.Parse("89BD23DE-98F2-4DE2-A753-403789911119"),
                    ServiceCategory = "Maintenance",
                    ServiceName = "Oil Change",
                    WorkNature = "Routine",
                    Action = "Replace",
                    Description = "Replace engine oil and oil filter",
                    EstimatedHours = 1,
                    CreatedAt = DateTimeOffset.UtcNow,
                    UpdatedAt = DateTimeOffset.UtcNow
                },
                new Service()
                {
                    Id = new Guid("fa7fab24-c298-43cf-b990-341b29a02996"),
                    CarPartId = Guid.Parse("45CDFEF2-2B7D-48AA-B8FA-F95C0AA194AD"),
                    CarCategoryId = Guid.Parse("1D25E83B-925E-472A-89D9-38C499DBFDEA"),
                    ServiceCategory = "Repair",
                    ServiceName = "Brake Pad Replacement",
                    WorkNature = "Safety",
                    Action = "Replace",
                    Description = "Replace worn-out brake pads",
                    EstimatedHours = 2,
                    CreatedAt = DateTimeOffset.UtcNow,
                    UpdatedAt = DateTimeOffset.UtcNow
                },
                new Service()
                {
                    Id = new Guid("6a927f4f-cc77-4d6d-963f-96a14a6a4fa9"),
                    CarPartId = Guid.Parse("82B56CC1-7122-46EC-817E-B06CD0747F55"),
                    CarCategoryId = Guid.Parse("F5BF5757-92B6-4CC2-B86B-1995F28D3FB6"),
                    ServiceCategory = "Repair",
                    ServiceName = "Shock Absorber Replacement",
                    WorkNature = "Performance",
                    Action = "Replace",
                    Description = "Replace faulty shock absorbers",
                    EstimatedHours = 3,
                    CreatedAt = DateTimeOffset.UtcNow,
                    UpdatedAt = DateTimeOffset.UtcNow
                },
                new Service()
                {
                    Id = new Guid("6ebc86c7-82e2-4ce4-b613-ebaac626bd18"),
                    CarPartId = Guid.Parse("82B56CC1-7122-46EC-817E-B06CD0747F55"),
                    CarCategoryId = Guid.Parse("506B4F2F-68F7-4B69-AB81-1242DE996A18"),
                    ServiceCategory = "Repair",
                    ServiceName = "Clutch Replacement",
                    WorkNature = "Performance",
                    Action = "Replace",
                    Description = "Replace worn-out clutch kit",
                    EstimatedHours = 4,
                    CreatedAt = DateTimeOffset.UtcNow,
                    UpdatedAt = DateTimeOffset.UtcNow
                },
                new Service()
                {
                    Id = new Guid("0be257e7-856d-48d6-ab5a-f984a75b67d5"),
                    CarPartId = Guid.Parse("45CDFEF2-2B7D-48AA-B8FA-F95C0AA194AD"),
                    CarCategoryId = Guid.Parse("B8E9B4D0-8B60-451A-9810-1132482A0D92"),
                    ServiceCategory = "Maintenance",
                    ServiceName = "Battery Replacement",
                    WorkNature = "Safety",
                    Action = "Replace",
                    Description = "Replace old battery with a new one",
                    EstimatedHours = 1,
                    CreatedAt = DateTimeOffset.UtcNow,
                    UpdatedAt = DateTimeOffset.UtcNow
                },
                new Service()
                {
                    Id = new Guid("ff884ca0-1e63-4bc1-84a1-4048a6eb627e"),
                    CarPartId = Guid.Parse("45CDFEF2-2B7D-48AA-B8FA-F95C0AA194AD"),
                    CarCategoryId = Guid.Parse("61A22FFB-C41D-4365-B067-11213E5579F9"),
                    ServiceCategory = "Repair",
                    ServiceName = "Muffler Replacement",
                    WorkNature = "Performance",
                    Action = "Replace",
                    Description = "Replace damaged muffler",
                    EstimatedHours = 2,
                    CreatedAt = DateTimeOffset.UtcNow,
                    UpdatedAt = DateTimeOffset.UtcNow
                },
                new Service()
                {
                    Id = new Guid("8d86d786-c02d-43a6-9b3f-3ef15761ba71"),
                    CarPartId = Guid.Parse("82B56CC1-7122-46EC-817E-B06CD0747F55"),
                    CarCategoryId = Guid.Parse("6F9E4206-D0A0-4366-A997-094827005006"),
                    ServiceCategory = "Repair",
                    ServiceName = "Radiator Replacement",
                    WorkNature = "Performance",
                    Action = "Replace",
                    Description = "Replace leaking radiator",
                    EstimatedHours = 3,
                    CreatedAt = DateTimeOffset.UtcNow,
                    UpdatedAt = DateTimeOffset.UtcNow
                }
            );
        }


    }
}




