using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using GarageManagementAPI.Shared.Enums.SystemStatuss;

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

       /* protected override void SeedData(EntityTypeBuilder<ProductCategory> entity)
        {
            entity.HasData(
               new ProductCategory()
               {
                   Id = new Guid("f4b8eff5-c7d2-4625-adb1-f4af19a922dd"),
                   Category = "Electronics",
                   Status = ProductCategoryStatus.Active,
                   CreatedAt = DateTimeOffset.Parse("2025-02-25T00:36:40Z"),
                   UpdatedAt = DateTimeOffset.Parse("2025-02-25T00:36:40Z")
               },
               new ProductCategory()
               {
                   Id = new Guid("c9bb6d84-350a-4ecb-ad5c-51d1924efee1"),
                   Category = "Clothing",
                   Status = ProductCategoryStatus.Active,
                   CreatedAt = DateTimeOffset.Parse("2025-02-25T00:36:40Z"),
                   UpdatedAt = DateTimeOffset.Parse("2025-02-25T00:36:40Z")
               },
               new ProductCategory()
               {
                   Id = new Guid("3a891899-546f-4380-aee2-81c7939a0f99"),
                   Category = "Home & Kitchen",
                   Status = ProductCategoryStatus.Active,
                   CreatedAt = DateTimeOffset.Parse("2025-02-25T00:36:40Z"),
                   UpdatedAt = DateTimeOffset.Parse("2025-02-25T00:36:40Z")
               }
         );
        }*/
    }
}




