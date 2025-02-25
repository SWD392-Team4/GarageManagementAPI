using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

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

        protected override void SeedData(EntityTypeBuilder<ProductCategory> entity)
        {
            entity.HasData(
               new ProductCategory()
               {
                   Id = new Guid("cee5a4d8-de84-4482-9da9-302e2290cb0f"),
                   Category = "Electronics",
                   CreatedAt = DateTimeOffset.Parse("2025-02-25T00:36:40Z"),
                   UpdatedAt = DateTimeOffset.Parse("2025-02-25T00:36:40Z")
               },
               new ProductCategory()
               {
                   Id = new Guid("e9a7beda-ff63-4ac5-92cb-b7fa152c41c2"),
                   Category = "Clothing",
                   CreatedAt = DateTimeOffset.Parse("2025-02-25T00:36:40Z"),
                   UpdatedAt = DateTimeOffset.Parse("2025-02-25T00:36:40Z")
               },
               new ProductCategory()
               {
                   Id = new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"),
                   Category = "Home & Kitchen",
                   CreatedAt = DateTimeOffset.Parse("2025-02-25T00:36:40Z"),
                   UpdatedAt = DateTimeOffset.Parse("2025-02-25T00:36:40Z")
               }
         );
        }
    }
}




