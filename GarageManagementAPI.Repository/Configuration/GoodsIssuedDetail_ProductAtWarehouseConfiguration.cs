using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class GoodsIssuedDetail_ProductAtWarehouseConfiguration : ConfigurationBase<GoodsIssuedDetail_ProductAtWarehouse>
    {
        protected override void ModelCreating(EntityTypeBuilder<GoodsIssuedDetail_ProductAtWarehouse> entity)
        {

            entity.HasKey(gp => new { gp.GoodsIssuedDetailId, gp.ProductAtWarehouseId });

            entity.HasOne(gp => gp.GoodsIssuedDetail)
                .WithMany(gid => gid.GoodsIssuedDetail_ProductAtWarehouse)
                .HasForeignKey(gp => gp.GoodsIssuedDetailId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(gp => gp.ProductAtWarehouse)
                .WithMany(pw => pw.GoodsIssuedDetail_ProductAtWarehouse)
                .HasForeignKey(gp => gp.ProductAtWarehouseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
