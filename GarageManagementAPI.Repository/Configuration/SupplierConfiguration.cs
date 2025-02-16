using GarageManagementAPI.Entities.Models;
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

            entity.Property(e => e.Id).ValueGeneratedNever();
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
    }
}




