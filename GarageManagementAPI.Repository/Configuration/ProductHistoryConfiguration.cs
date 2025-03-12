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

            entity.HasOne(d => d.Product).WithMany(p => p.ProductHistories)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("producthistory_productid_foreign");
        }
        protected override void SeedData(EntityTypeBuilder<ProductHistory> entity)
         {
             entity.HasData(
                 new ProductHistory()
                 {
                     Id = new Guid("cee5a4d8-de84-4482-9da9-302e2290cb0f"),
                     ProductId = new Guid("F5FD6EE3-A8B6-452C-9042-146E8AFC875F"), // Electronics
                     ProductPrice = 500,
                     CreatedAt = DateTimeOffset.Parse("2025-02-25T00:36:40Z")
                 },
                 new ProductHistory()
                 {
                     Id = new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"),
                     ProductId = new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"), // Electronics
                     ProductPrice = 520,
                     CreatedAt = DateTimeOffset.Parse("2025-02-25T00:36:40Z")
                 },
                 new ProductHistory()
                 {
                     Id = new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"),
                     ProductId = new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"), // Clothing
                     ProductPrice = 1200,
                     CreatedAt = DateTimeOffset.Parse("2025-02-25T00:36:40Z")
                 },
                
                 new ProductHistory()
                 {
                     Id = new Guid("537c1813-334d-41c0-987b-0ed1509475f7"),
                     ProductId = new Guid("e9a7beda-ff63-4ac5-92cb-b7fa152c41c2"), // Home & Kitchen
                     ProductPrice = 200,
                     CreatedAt = DateTimeOffset.Parse("2025-02-25T00:36:40Z")
                 }
             );
         }
    }
}




