using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GarageManagementAPI.Repository.Configuration
{
    public class ProductImageConfiguration : ConfigurationBase<ProductImage>
    {
        protected override void ModelCreating(EntityTypeBuilder<ProductImage> entity)
        {
            entity.HasKey(e => e.Id).HasName("productimage_id_primary");

            entity.ToTable("ProductImage");

            entity.HasIndex(e => e.ProductId, "productimage_productid_index");

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            entity.Property(e => e.ImageLink).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(255);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductImages)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("productimage_productid_foreign");


            entity.Property(e => e.Status)
                .HasConversion<string>();
        }
        protected override void SeedData(EntityTypeBuilder<ProductImage> entity)
        {
            entity.HasData(
                new ProductImage()
                {
                    Id = new Guid("71bd8b35-0d22-4783-8638-78eb48bd5629"),
                    ProductId = Guid.Parse("F5FD6EE3-A8B6-452C-9042-146E8AFC875F"), // Electronics
                    ImageLink = "https://example.com/images/1.jpg",
                    CreatedAt = DateTimeOffset.Parse("2025-02-25T00:36:40Z"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-25T00:36:40Z")
                },
                new ProductImage()
                {
                    Id = new Guid("91f09ff2-24ed-4d60-b3c5-5e76204a90ff"),
                    ProductId =  Guid.Parse("CEE5A4D8-DE84-4482-9DA9-302E2290CB0F"), // Clothing
                    ImageLink = "https://example.com/images/2.jpg",
                    CreatedAt = DateTimeOffset.Parse("2025-02-25T00:36:40Z"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-25T00:36:40Z")
                },
                new ProductImage()
                {
                    Id = new Guid("867a1f57-a7dc-4d8a-95f0-9b1e1b086809"),
                    ProductId = Guid.Parse("AC103CCC-BD82-44CA-ADB7-5B478B95965A"), // Home & Kitchen
                    ImageLink = "https://example.com/images/3.jpg",
                    CreatedAt = DateTimeOffset.Parse("2025-02-25T00:36:40Z"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-25T00:36:40Z")
                },
                new ProductImage()
                {
                    Id = new Guid("b3126c73-0e1e-40fd-8dec-f7c4d2789dd9"),
                    ProductId = new Guid("1C1FFD05-3B06-48BF-B78C-86B6EF2D3CEF"), // Home & Kitchen
                    ImageLink = "https://example.com/images/4.jpg",
                    CreatedAt = DateTimeOffset.Parse("2025-02-25T00:36:40Z"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-25T00:36:40Z")
                },
                new ProductImage()
                {
                    Id = new Guid("306fd99b-7914-4c4d-a92b-f3d998f3b772"),
                    ProductId = Guid.Parse("E9A7BEDA-FF63-4AC5-92CB-B7FA152C41C2"), // Clothing
                    ImageLink = "https://example.com/images/5.jpg",
                    CreatedAt = DateTimeOffset.Parse("2025-02-25T00:36:40Z"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-25T00:36:40Z")
                }
            );
        }

    }
}




