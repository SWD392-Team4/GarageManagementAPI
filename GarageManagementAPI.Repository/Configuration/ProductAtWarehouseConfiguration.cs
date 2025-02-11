using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class ProductAtWarehouseConfiguration : ConfigurationBase<ProductAtWarehouse>
    {
        protected override void ModelCreating(EntityTypeBuilder<ProductAtWarehouse> entity)
        {
            entity.HasKey(e => e.Id).HasName("productatwarehouse_goodsreceiveddetailid_primary");

            entity.ToTable("ProductAtWarehouse");

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            entity.Property(e => e.Status).HasMaxLength(255);

            entity.HasOne(d => d.GoodsReceivedDetail).WithOne(p => p.ProductAtWarehouse)
                .HasForeignKey<ProductAtWarehouse>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("productatwarehouse_goodsreceiveddetailid_foreign");

            entity.Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}




