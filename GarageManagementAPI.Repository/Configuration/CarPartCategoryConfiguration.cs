using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class CarPartCategoryConfiguration : ConfigurationBase<CarPartCategory>
    {
        protected override void ModelCreating(EntityTypeBuilder<CarPartCategory> entity)
        {
            entity.HasKey(e => e.Id).HasName("carpartcategory_id_primary");

            entity.ToTable("CarPartCategory");

            entity.HasIndex(e => e.PartCategory, "carpartcategory_partcategory_unique").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.PartCategory).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(255);


            entity.Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}




