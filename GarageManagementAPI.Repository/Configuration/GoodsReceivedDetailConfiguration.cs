using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class GoodsReceivedDetailConfiguration : ConfigurationBase<GoodsReceivedDetail>
    {
        protected override void ModelCreating(EntityTypeBuilder<GoodsReceivedDetail> entity)
        {
            entity.HasKey(e => e.Id).HasName("goodsreceiveddetail_id_primary");

            entity.ToTable("GoodsReceivedDetail");

            entity.HasIndex(e => e.GoodsReceivedId, "goodsreceiveddetail_goodsreceivedid_index");

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            entity.Property(e => e.Status).HasMaxLength(255);
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.GoodsReceived).WithMany(p => p.GoodsReceivedDetails)
                .HasForeignKey(d => d.GoodsReceivedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("goodsreceiveddetail_goodsreceivedid_foreign");

            entity.HasOne(d => d.Product).WithMany(p => p.GoodsReceivedDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("goodsreceiveddetail_productid_foreign");


            entity.Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}




