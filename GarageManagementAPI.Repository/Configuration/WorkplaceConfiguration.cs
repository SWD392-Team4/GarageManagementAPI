using Bogus;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class WorkplaceConfiguration : ConfigurationBase<Workplace>
    {
        protected override void ModelCreating(EntityTypeBuilder<Workplace> entity)
        {
            entity.HasKey(e => e.Id).HasName("workplace_id_primary");

            entity.ToTable("Workplace");

            entity.HasIndex(e => new { e.Address, e.Province, e.District, e.Ward }, "workplace_address_province_district_wards_unique").IsUnique();

            entity.HasIndex(e => e.Name, "workplace_name_unique").IsUnique();

            entity.HasIndex(e => e.PhoneNumber, "workplace_phonenumber_unique").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.District).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(255);
            entity.Property(e => e.Province).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(255);
            entity.Property(e => e.Ward).HasMaxLength(50);
            entity.Property(e => e.WorkplaceType).HasMaxLength(255);


            entity.Property(e => e.Status)
                .HasConversion<string>();

            entity.Property(e => e.WorkplaceType)
                .HasConversion<string>();
        }

        protected override void SeedData(EntityTypeBuilder<Workplace> entity)
        {
            var workplaces = new List<Workplace>
            {
                new Workplace
                {
                    Id = Guid.Parse("c1aeb9e5-8c74-4b09-bc57-d4c3df7857f9"),
                    Name = "Garage 1",
                    PhoneNumber = "0983456789",
                    Address = "123 Static St.",
                    Province = "Static Province",
                    District = "Static District",
                    Ward = "12345",
                    WorkplaceType = WorkplaceType.Garage,
                    CreatedAt = DateTimeOffset.Parse("2025-01-01T00:00:00+07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2025-01-10T00:00:00+07:00"),
                    Status = WorkplaceStatus.Active
                },
                new Workplace
                {
                    Id = Guid.Parse("e3dbf2c8-899d-4b2a-91f7-d2315d3f3bcb"),
                    Name = "Warehouse 1",
                    PhoneNumber = "0987654321",
                    Address = "456 Static Ave.",
                    Province = "Another Province",
                    District = "Another District",
                    Ward = "67890",
                    WorkplaceType = WorkplaceType.Warehouse,
                    CreatedAt = DateTimeOffset.Parse("2025-01-01T00:00:00+07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2025-01-15T00:00:00+07:00"),
                    Status = WorkplaceStatus.Active
                },
                new Workplace
                {
                    Id = Guid.Parse("6760cbb7-f1fa-445f-a175-97e3f060c861"),
                    Name = "Garage 2",
                    PhoneNumber = "0983456139",
                    Address = "124 Static St.",
                    Province = "Static Province",
                    District = "Static District",
                    Ward = "12345",
                    WorkplaceType = WorkplaceType.Garage,
                    CreatedAt = DateTimeOffset.Parse("2025-01-01T00:00:00+07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2025-01-10T00:00:00+07:00"),
                    Status = WorkplaceStatus.Active
                },
                new Workplace
                {
                    Id = Guid.Parse("4c809c47-7e87-4cec-a883-30e2718fed5e"),
                    Name = "Warehouse 2",
                    PhoneNumber = "0987084321",
                    Address = "432 Static Ave.",
                    Province = "Another Province",
                    District = "Another District",
                    Ward = "60890",
                    WorkplaceType = WorkplaceType.Warehouse,
                    CreatedAt = DateTimeOffset.Parse("2025-01-01T00:00:00+07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2025-01-15T00:00:00+07:00"),
                    Status = WorkplaceStatus.Active
                }

            };

            entity.HasData(workplaces);
        }
    }
}




