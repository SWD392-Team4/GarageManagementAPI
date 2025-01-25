using GarageManagementAPI.Entities.NewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class CarCategoryConfiguration : ConfigurationBase<CarCategory>
    {
        protected override void ModelCreating(EntityTypeBuilder<CarCategory> entity)
        {
            entity.HasKey(e => e.Id).HasName("carcategory_id_primary");

            entity.ToTable("CarCategory");

            entity.HasIndex(e => e.Category, "carcategory_category_unique").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Category).HasMaxLength(255);
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Status).HasMaxLength(255);


            entity.Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}




