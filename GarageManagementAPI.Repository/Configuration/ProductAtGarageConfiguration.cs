using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class ProductAtGarageConfiguration : ConfigurationBase<ProductAtGarage>
    {
        protected override void ModelCreating(EntityTypeBuilder<ProductAtGarage> entity)
        {
            entity.HasKey(e => e.Id).HasName("productatgarage_goodsissueddetailid_primary");

            entity.ToTable("ProductAtGarage");

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            entity.Property(e => e.ProductBarcodeAtGarage).HasMaxLength(255);
            entity.HasOne(e => e.Product).WithOne(p => p.ProductAtGarage)
                .HasForeignKey<ProductAtGarage>(p => p.ProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("productatgarage_productid_foreign");

            entity.HasOne(d => d.GoodsIssuedDetail).WithOne(p => p.ProductAtGarage)
                .HasForeignKey<ProductAtGarage>(d => d.GoodsIssuedDetailId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("productatgarage_goodsissueddetailid_foreign");
        }
    }
}




