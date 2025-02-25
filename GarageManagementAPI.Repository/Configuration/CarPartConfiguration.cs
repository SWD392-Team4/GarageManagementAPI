using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GarageManagementAPI.Repository.Configuration
{
    public class CarPartConfiguration : ConfigurationBase<CarPart>
    {
        protected override void ModelCreating(EntityTypeBuilder<CarPart> entity)
        {
            entity.HasKey(e => e.Id).HasName("carpart_id_primary");

            entity.ToTable("CarPart");

            entity.HasIndex(e => e.CarPartCategoryId, "carpart_carpartcategoryid_index");

            entity.HasIndex(e => e.PartName, "carpart_partname_unique").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            entity.Property(e => e.PartName).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(255);

            entity.HasOne(d => d.CarPartCategory).WithMany(p => p.CarParts)
                .HasForeignKey(d => d.CarPartCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("carpart_carpartcategoryid_foreign");

            entity.HasMany(d => d.Products).WithMany(p => p.CarParts)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductCarPart",
                    r => r.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("productcarpart_productid_foreign"),
                    l => l.HasOne<CarPart>().WithMany()
                        .HasForeignKey("CarPartId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("productcarpart_carpartid_foreign"),
                    j =>
                    {
                        j.HasKey("CarPartId", "ProductId").HasName("productcarpart_carpartid_productid_primary");
                        j.ToTable("ProductCarPart");
                    });


            entity.Property(e => e.Status)
                .HasConversion<string>();
        }
        protected override void SeedData(EntityTypeBuilder<CarPart> entity)
        {
            entity.HasData(
                new CarPart()
                {
                    Id = new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"),
                    CarPartCategoryId = new Guid("47cc8b19-70ce-46f3-aef9-eb933eea2182"), // Engine Parts
                    PartName = "Engine Oil",
                    Status = CarPartStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2025-02-26T00:00:00Z"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-26T00:00:00Z")
                },
                new CarPart()
                {
                    Id = new Guid("4b3039f3-b460-46be-aa39-e43d4c29af19"),
                    CarPartCategoryId = new Guid("30e45fc3-a2d1-4006-be2b-9de2b1c5130c"), // Engine Parts
                    PartName = "Air Filter",
                    Status = CarPartStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2025-02-26T00:00:00Z"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-26T00:00:00Z")
                },
                new CarPart()
                {
                    Id = new Guid("abadc9e1-c8e6-4f40-b078-47f609d1cf79"),
                    CarPartCategoryId = new Guid("23e128b8-73fe-4e74-bfdf-97d82911af47"), // Brake System
                    PartName = "Brake Pad",
                    Status = CarPartStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2025-02-26T00:00:00Z"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-26T00:00:00Z")
                },
                new CarPart()
                {
                    Id = new Guid("855f8a55-c9d0-4532-81ee-6da2bd0db1f6"),
                    CarPartCategoryId = new Guid("5b4d0698-cf56-41ff-927f-3226f1146f0f"), // Brake System
                    PartName = "Brake Disc",
                    Status = CarPartStatus.Inactive,
                    CreatedAt = DateTimeOffset.Parse("2025-02-26T00:00:00Z"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-26T00:00:00Z")
                },
                new CarPart()
                {
                    Id = new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"),
                    CarPartCategoryId = new Guid("5b4d0698-cf56-41ff-927f-3226f1146f0f"), // Suspension
                    PartName = "Shock Absorber",
                    Status = CarPartStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2025-02-26T00:00:00Z"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-26T00:00:00Z")
                },
                new CarPart()
                {
                    Id = new Guid("2c74b21a-5ec4-4dce-b376-b6b0601d7a84"),
                    CarPartCategoryId = new Guid("5b4d0698-cf56-41ff-927f-3226f1146f0f"), // Transmission
                    PartName = "Clutch Plate",
                    Status = CarPartStatus.Inactive,
                    CreatedAt = DateTimeOffset.Parse("2025-02-26T00:00:00Z"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-26T00:00:00Z")
                },
                new CarPart()
                {
                    Id = new Guid("84062c49-1fe2-4b97-86c4-49e4d0f5449b"),
                    CarPartCategoryId = new Guid("5b4d0698-cf56-41ff-927f-3226f1146f0f"), // Electrical System
                    PartName = "Battery",
                    Status = CarPartStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2025-02-26T00:00:00Z"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-26T00:00:00Z")
                },
                new CarPart()
                {
                    Id = new Guid("0131e761-bdeb-4fd0-8aba-b3cc0769d0c4"),
                    CarPartCategoryId = new Guid("f7f6b4fc-0e88-4cb6-af7e-c0834bfb2b2c"), // Exhaust System
                    PartName = "Exhaust Pipe",
                    Status = CarPartStatus.Inactive,
                    CreatedAt = DateTimeOffset.Parse("2025-02-26T00:00:00Z"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-26T00:00:00Z")
                }
            );
        }

    }
}




