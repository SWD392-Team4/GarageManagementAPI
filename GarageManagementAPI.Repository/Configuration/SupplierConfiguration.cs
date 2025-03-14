using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class SupplierConfiguration : ConfigurationBase<Supplier>
    {
        protected override void ModelCreating(EntityTypeBuilder<Supplier> entity)
        {
            entity.HasKey(e => e.Id).HasName("supplier_id_primary");

            entity.ToTable("Supplier");

            entity.HasIndex(e => new { e.Address, e.Province, e.District, e.Wards }, "supplier_address_province_district_wards_unique").IsUnique();

            entity.HasIndex(e => e.Name, "supplier_name_unique").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.District).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Province).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(255);
            entity.Property(e => e.SupplierCategory).HasMaxLength(255);
            entity.Property(e => e.TaxCode).HasMaxLength(255);
            entity.Property(e => e.Wards).HasMaxLength(50);


            entity.Property(e => e.Status)
                .HasConversion<string>();
        }

        protected override void SeedData(EntityTypeBuilder<Supplier> entity)
        {
            entity.HasData(
                    new Supplier()
                    {
                        Id = new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"),
                        Name = "Trần Huy Hanh",
                        TaxCode = "123456789",
                        Address = "123 Street",
                        Province = "Hanoi",
                        District = "Ba Dinh",
                        Wards = "Ward 1",
                        Status = SupplierStatus.Active,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:40:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:40:40 AM +07:00"),
                        SupplierCategory = "Automotive"
                    },
                    new Supplier()
                    {
                        Id = new Guid("cee5a4d8-de84-4482-9da9-302e2290cb0f"),
                        Name = "Bùi Duy Khánh",
                        TaxCode = "987654321",
                        Address = "456 Avenue",
                        Province = "HCMC",
                        District = "District 1",
                        Wards = "Ward 2",
                        Status = SupplierStatus.Active,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:40:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:40:40 AM +07:00"),
                        SupplierCategory = "Parts"
                    },
                    new Supplier()
                    {
                        Id = new Guid("e9a7beda-ff63-4ac5-92cb-b7fa152c41c2"),
                        Name = "Nguyễn Hoàng Nhật Tân",
                        TaxCode = "123456799",
                        Address = "789 Road",
                        Province = "Da Nang",
                        District = "Hai Chau",
                        Wards = "Ward 3",
                        Status = SupplierStatus.Active,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:40:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:40:40 AM +07:00"),
                        SupplierCategory = "Maintenance"
                    },
                    new Supplier()
                    {
                        Id = new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"),
                        Name = "Lê Tân",
                        TaxCode = "654321987",
                        Address = "321 Boulevard",
                        Province = "Can Tho",
                        District = "Ninh Kieu",
                        Wards = "Ward 4",
                        Status = SupplierStatus.Active,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:40:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:40:40 AM +07:00"),
                        SupplierCategory = "Electronics"
                    }
             );
        }
    }
}




