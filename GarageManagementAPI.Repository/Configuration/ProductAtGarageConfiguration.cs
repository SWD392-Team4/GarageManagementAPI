using GarageManagementAPI.Entities.NewModels;
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

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ProductBarcodeAtGarage).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(255);

            entity.HasOne(d => d.GoodsIssuedDetail).WithOne(p => p.ProductAtGarage)
                .HasForeignKey<ProductAtGarage>(d => d.Id)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("productatgarage_goodsissueddetailid_foreign");

            entity.Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}




