using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class BrandConfiguration : ConfigurationBase<Brand>
    {
        protected override void ModelCreating(EntityTypeBuilder<Brand> entity)
        {
            entity.HasKey(e => e.Id).HasName("brand_id_primary");

            entity.ToTable("Brand");

            entity.HasIndex(e => e.BrandName, "brand_brandname_unique").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.BrandName).HasMaxLength(255);
            entity.Property(e => e.LinkLogo).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(255);


            entity.Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}




