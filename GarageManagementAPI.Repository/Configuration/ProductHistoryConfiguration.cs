using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class ProductHistoryConfiguration : ConfigurationBase<ProductHistory>
    {
        protected override void ModelCreating(EntityTypeBuilder<ProductHistory> entity)
        {
            entity.HasKey(e => e.Id).HasName("producthistory_id_primary");

            entity.ToTable("ProductHistory");

            entity.HasIndex(e => e.ProductId, "producthistory_productid_index");

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            entity.Property(e => e.ProductPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Status).HasMaxLength(255);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductHistories)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("producthistory_productid_foreign");


            entity.Property(e => e.Status)
                .HasConversion<string>();
        }
        protected override void SeedData(EntityTypeBuilder<ProductHistory> entity)
        {
            entity.HasData(
                new ProductHistory()
                {
                    Id = new Guid("e9a0d0d3-3a43-406a-b465-b630c5d93f6f"),
                    ProductId = new Guid("F5FD6EE3-A8B6-452C-9042-146E8AFC875F"), // Electronics
                    ProductPrice = 500,
                    CreatedAt = DateTimeOffset.Parse("2025-02-25T00:36:40Z")
                },
                new ProductHistory()
                {
                    Id = new Guid("22d61e55-50e5-4dcd-bf40-209fc2fcae12"),
                    ProductId = new Guid("CEE5A4D8-DE84-4482-9DA9-302E2290CB0F"), // Electronics
                    ProductPrice = 520,
                    CreatedAt = DateTimeOffset.Parse("2025-02-25T00:36:40Z")
                },
                new ProductHistory()
                {
                    Id = new Guid("72d247fb-5249-4ce1-a400-fce2559e7db0"),
                    ProductId = new Guid("AC103CCC-BD82-44CA-ADB7-5B478B95965A"), // Clothing
                    ProductPrice = 1200,
                    CreatedAt = DateTimeOffset.Parse("2025-02-25T00:36:40Z")
                },
                new ProductHistory()
                {
                    Id = new Guid("e5e319f9-ef2a-4ab7-a847-5f0d3c7a1caf"),
                    ProductId = new Guid("1C1FFD05-3B06-48BF-B78C-86B6EF2D3CEF"), // Home & Kitchen
                    ProductPrice = 150,
                    CreatedAt = DateTimeOffset.Parse("2025-02-25T00:36:40Z")
                },
                new ProductHistory()
                {
                    Id = new Guid("537c1813-334d-41c0-987b-0ed1509475f7"),
                    ProductId = new Guid("E9A7BEDA-FF63-4AC5-92CB-B7FA152C41C2"), // Home & Kitchen
                    ProductPrice = 200,
                    CreatedAt = DateTimeOffset.Parse("2025-02-25T00:36:40Z")
                },
                new ProductHistory()
                {
                    Id = new Guid("2254581b-c244-4c41-b5e4-c353629c2105"),
                    ProductId = new Guid("1C1FFD05-3B06-48BF-B78C-86B6EF2D3CEF"), // Clothing
                    ProductPrice = 300,
                    CreatedAt = DateTimeOffset.Parse("2025-02-25T00:36:40Z")
                },
                new ProductHistory()
                {
                    Id = new Guid("97b8ca2f-9784-4262-a57e-5695f3f0f642"),
                    ProductId = new Guid("AC103CCC-BD82-44CA-ADB7-5B478B95965A"), // Electronics
                    ProductPrice = 450,
                    CreatedAt = DateTimeOffset.Parse("2025-02-25T00:36:40Z")
                }
            );
        }
    }
}




