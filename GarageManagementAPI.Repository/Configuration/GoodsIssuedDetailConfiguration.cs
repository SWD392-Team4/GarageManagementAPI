using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class GoodsIssuedDetailConfiguration : ConfigurationBase<GoodsIssuedDetail>
    {
        protected override void ModelCreating(EntityTypeBuilder<GoodsIssuedDetail> entity)
        {
            entity.HasKey(e => e.Id).HasName("goodsissueddetail_id_primary");

            entity.ToTable("GoodsIssuedDetail");

            entity.HasIndex(e => e.GoodsIssuedId, "goodsissueddetail_goodsissuedid_index");

            entity.HasIndex(e => e.ProductAtWareHouseId, "goodsissueddetail_productatwarehouseid_index");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Status).HasMaxLength(255);

            entity.HasOne(d => d.GoodsIssued).WithMany(p => p.GoodsIssuedDetails)
                .HasForeignKey(d => d.GoodsIssuedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("goodsissueddetail_goodsissuedid_foreign");

            entity.HasOne(d => d.ProductAtWareHouse).WithMany(p => p.GoodsIssuedDetails)
                .HasForeignKey(d => d.ProductAtWareHouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("goodsissueddetail_productatwarehouseid_foreign");


            entity.Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}




