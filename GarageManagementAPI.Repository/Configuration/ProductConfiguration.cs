using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
    }
}




