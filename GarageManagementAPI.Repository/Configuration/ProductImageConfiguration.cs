using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            entity.Property(e => e.Link).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(255);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductImages)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("productimage_productid_foreign");


            entity.Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}




