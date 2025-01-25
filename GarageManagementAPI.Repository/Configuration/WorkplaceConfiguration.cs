using GarageManagementAPI.Entities.NewModels;
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

            entity.HasIndex(e => new { e.Address, e.Province, e.District, e.Wards }, "workplace_address_province_district_wards_unique").IsUnique();

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
            entity.Property(e => e.Wards).HasMaxLength(50);
            entity.Property(e => e.WorkplaceType).HasMaxLength(255);


            entity.Property(e => e.Status)
                .HasConversion<string>();

            entity.Property(e => e.WorkplaceType)
                .HasConversion<string>();
        }
    }
}




