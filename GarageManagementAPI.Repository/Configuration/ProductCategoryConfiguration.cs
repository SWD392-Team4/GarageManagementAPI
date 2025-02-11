using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class ProductCategoryConfiguration : ConfigurationBase<ProductCategory>
    {
        protected override void ModelCreating(EntityTypeBuilder<ProductCategory> entity)
        {
            entity.HasKey(e => e.Id).HasName("productcategory_id_primary");

            entity.ToTable("ProductCategory");

            entity.HasIndex(e => e.Category, "productcategory_category_unique").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            entity.Property(e => e.Category).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(255);


            entity.Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}




