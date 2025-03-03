using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GarageManagementAPI.Repository.Configuration
{
    public class CarPartCategoryConfiguration : ConfigurationBase<CarPartCategory>
    {
        protected override void ModelCreating(EntityTypeBuilder<CarPartCategory> entity)
        {
            entity.HasKey(e => e.Id).HasName("carpartcategory_id_primary");

            entity.ToTable("CarPartCategory");

            entity.HasIndex(e => e.PartCategory, "carpartcategory_partcategory_unique").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            entity.Property(e => e.PartCategory).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(255);


            entity.Property(e => e.Status)
                .HasConversion<string>();
        }
        protected override void SeedData(EntityTypeBuilder<CarPartCategory> entity)
        {
            entity.HasData(
                new CarPartCategory()
                {
                    Id = new Guid("47cc8b19-70ce-46f3-aef9-eb933eea2182"),
                    PartCategory = "Engine Part",
                    Status = CarPartCategoryStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2025-02-26T00:00:00Z"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-26T00:00:00Z")
                },
                new CarPartCategory()
                {
                    Id = new Guid("30e45fc3-a2d1-4006-be2b-9de2b1c5130c"),
                    PartCategory = "Brake System",
                    Status = CarPartCategoryStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2025-02-26T00:00:00Z"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-26T00:00:00Z")
                },
                new CarPartCategory()
                {
                    Id = new Guid("23e128b8-73fe-4e74-bfdf-97d82911af47"),
                    PartCategory = "Suspension",
                    Status = CarPartCategoryStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2025-02-26T00:00:00Z"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-26T00:00:00Z")
                },
                new CarPartCategory()
                {
                    Id = new Guid("793ed2e4-eba2-407e-a814-ab8d5ddcdfc7"),
                    PartCategory = "Electrical System",
                    Status = CarPartCategoryStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2025-02-26T00:00:00Z"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-26T00:00:00Z")
                },
                new CarPartCategory()
                {
                    Id = new Guid("4224e14b-fce0-47cb-904f-0c7c286d45f8"),
                    PartCategory = "Exhaust System",
                    Status = CarPartCategoryStatus.Inactive,
                    CreatedAt = DateTimeOffset.Parse("2025-02-26T00:00:00Z"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-26T00:00:00Z")
                },
                new CarPartCategory()
                {
                    Id = new Guid("5b4d0698-cf56-41ff-927f-3226f1146f0f"),
                    PartCategory = "Cooling System",
                    Status = CarPartCategoryStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2025-02-26T00:00:00Z"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-26T00:00:00Z")
                },
                new CarPartCategory()
                {
                    Id = new Guid("f7f6b4fc-0e88-4cb6-af7e-c0834bfb2b2c"),
                    PartCategory = "Fuel System",
                    Status = CarPartCategoryStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2025-02-26T00:00:00Z"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-26T00:00:00Z")
                },
                new CarPartCategory()
                {
                    Id = new Guid("4d8aaaa6-448a-431c-a50f-a313dba5b3e5"),
                    PartCategory = "Steering System",
                    Status = CarPartCategoryStatus.Inactive,
                    CreatedAt = DateTimeOffset.Parse("2025-02-26T00:00:00Z"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-26T00:00:00Z")
                },
                new CarPartCategory()
                {
                    Id = new Guid("1f13210f-6d0b-4cb9-86b9-fc0fa5898afd"),
                    PartCategory = "Interior Parts",
                    Status = CarPartCategoryStatus.Inactive,
                    CreatedAt = DateTimeOffset.Parse("2025-02-26T00:00:00Z"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-26T00:00:00Z")
                }
            );
        }

    }
}




