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
                    Id = new Guid("77f4ebf6-ed84-4fc2-8a58-3419d1464ee4"),
                    ProductId = new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"),
                    ProductPrice = 1500,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:40:40 AM +07:00")
                },
                new ProductHistory()
                {
                    Id = new Guid("423c3aa7-0281-4de1-95f2-53fe332417f2"),
                    ProductId = new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"),
                    ProductPrice = 120,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:38:40 AM +07:00")
                },
                new ProductHistory()
                {
                    Id = new Guid("15516af1-3245-4926-8dfe-bea85b6ec125"),
                    ProductId = new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"),
                    ProductPrice = 1300,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                },
                new ProductHistory()
                {
                    Id = new Guid("a660df09-451d-4f1e-bf73-152cd2ede38e"),
                    ProductId = new Guid("cee5a4d8-de84-4482-9da9-302e2290cb0f"),
                    ProductPrice = 1500,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:40:40 AM +07:00")
                },
                new ProductHistory()
                {
                    Id = new Guid("1b17747e-ae0a-4c6e-9ff7-d6539c6cd6b6"),
                    ProductId = new Guid("cee5a4d8-de84-4482-9da9-302e2290cb0f"),
                    ProductPrice = 120,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:38:40 AM +07:00")
                },
                new ProductHistory()
                {
                    Id = new Guid("5047c4b3-458a-4fbe-8df4-35f4b23dc439"),
                    ProductId = new Guid("cee5a4d8-de84-4482-9da9-302e2290cb0f"),
                    ProductPrice = 1300,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                }, new ProductHistory()
                {
                    Id = new Guid("913522ad-480e-4bc8-8932-79e3b4178016"),
                    ProductId = new Guid("e9a7beda-ff63-4ac5-92cb-b7fa152c41c2"),
                    ProductPrice = 1500,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:40:40 AM +07:00")
                },
                new ProductHistory()
                {
                    Id = new Guid("d806f85f-da06-4030-b98c-3c5561c14305"),
                    ProductId = new Guid("e9a7beda-ff63-4ac5-92cb-b7fa152c41c2"),
                    ProductPrice = 120,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:38:40 AM +07:00")
                },
                new ProductHistory()
                {
                    Id = new Guid("8258d59b-2955-4d2f-bced-ce747d6f303f"),
                    ProductId = new Guid("e9a7beda-ff63-4ac5-92cb-b7fa152c41c2"),
                    ProductPrice = 1300,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                }
                , new ProductHistory()
                {
                    Id = new Guid("f28b16c7-781c-4c11-9c31-1a3152c335e5"),
                    ProductId = new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"),
                    ProductPrice = 1500,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:40:40 AM +07:00")
                },
                new ProductHistory()
                {
                    Id = new Guid("de79c933-78d0-4498-becf-97d7228d39fd"),
                    ProductId = new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"),
                    ProductPrice = 120,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:38:40 AM +07:00")
                },
                new ProductHistory()
                {
                    Id = new Guid("fb7c7840-f5d2-4f36-97f8-e722e45ef441"),
                    ProductId = new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"),
                    ProductPrice = 1300,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                }
            );
        }
    }
}




