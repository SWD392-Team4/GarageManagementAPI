using Microsoft.EntityFrameworkCore;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GarageManagementAPI.Repository.Configuration
{
    public class ProductConfiguration : ConfigurationBase<Product>
    {
        protected override void ModelCreating(EntityTypeBuilder<Product> entity)
        {
            entity.HasKey(e => e.Id).HasName("product_id_primary");

            entity.ToTable("Product");

            entity.HasIndex(e => e.BrandId, "product_brandid_index");

            entity.HasIndex(e => e.ProductBarcode, "product_productbarcode_unique").IsUnique();

            entity.HasIndex(e => e.ProductCategoryId, "product_productcategoryid_index");

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            entity.Property(e => e.ProductBarcode).HasMaxLength(255);
            entity.Property(e => e.ProductDescription).HasColumnType("text");
            entity.Property(e => e.ProductName).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(255);

            entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("product_brandid_foreign");

            entity.HasOne(d => d.ProductCategory).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("product_productcategoryid_foreign");


            entity.Property(e => e.Status)
                .HasConversion<string>();
        }
        protected override void SeedData(EntityTypeBuilder<Product> entity)
        {
            entity.HasData(
                    new Product()
                    {
                        Id = new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"),
                        ProductName = "Toyota Camry",
                        ProductBarcode = "6291041500213",
                        ProductDescription = "The Smartphone XYZ Pro is a premium device featuring a 6.7-inch AMOLED display with 4K resolution and HDR10+ technology. Powered by the Snapdragon 888 chipset, 12GB of RAM, and 256GB of internal storage, this phone delivers smooth performance for all tasks. The 108MP main camera supports 8K video recording, and the 5000mAh battery supports 65W fast charging.",
                        ProductCategoryId = Guid.Parse("C29A6297-20CD-449D-8CA8-6353E7CD4505"),
                        BrandId = Guid.Parse("abadc9e1-c8e6-4f40-b078-47f609d1cf79"),
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        Status = ProductStatus.Active
                    },
                    new Product()
                    {
                        Id = new Guid("cee5a4d8-de84-4482-9da9-302e2290cb0f"),
                        ProductName = "Ford Mustang",
                        ProductBarcode = "5901234123457",
                        ProductDescription = "The UltraBook 2023 is an ultra-thin and lightweight laptop, weighing just 1.2kg, with a 14-inch 2.5K resolution display. It is equipped with a 12th Gen Intel Core i7 processor, 16GB of RAM, and a 512GB SSD. With up to 12 hours of battery life and Thunderbolt 4 connectivity, it is perfect for mobile work and entertainment.",
                        ProductCategoryId = Guid.Parse("40C29595-CBFE-4226-BBD4-61AC6874FFBC"),
                        BrandId = Guid.Parse("855f8a55-c9d0-4532-81ee-6da2bd0db1f6"),
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        Status = ProductStatus.Active
                    },
                    new Product()
                    {
                        Id = new Guid("e9a7beda-ff63-4ac5-92cb-b7fa152c41c2"),
                        ProductName = "Volkswagen Golf",
                        ProductBarcode = "4006381333931",
                        ProductDescription = "The Mirrorless Alpha Z9 is the perfect choice for professional photographers. With a 45MP full-frame sensor, 6K video recording, and 5-axis image stabilization, this camera delivers sharp and true-to-life image quality. It also offers a continuous shooting speed of up to 20 frames per second.",
                        ProductCategoryId = Guid.Parse("6E8F9461-9115-4847-83B9-60067DB961AB"),
                        BrandId = Guid.Parse("350b60f4-40fb-499b-9358-3a06ee2ff5f7"),
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        Status = ProductStatus.Active
                    },
                    new Product()
                    {
                        Id = new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"),
                        ProductName = "Honda Civic",
                        ProductBarcode = "9780201379624",
                        ProductDescription = "The SoundWave 360 Smart Speaker features an integrated AI virtual assistant and supports voice control. With 360-degree surround sound and 50W of power, it delivers an immersive audio experience. It connects wirelessly via Bluetooth 5.0 and Wi-Fi, and is compatible with smart home devices.",
                        ProductCategoryId = Guid.Parse("4584997B-918A-4422-90D9-434BF2315458"),
                        BrandId = Guid.Parse("abadc9e1-c8e6-4f40-b078-47f609d1cf79"),
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        Status = ProductStatus.Active
                    }
                );

        }
    }
}




