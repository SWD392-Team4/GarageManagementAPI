using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GarageManagementAPI.Repository.Configuration
{
    public class GoodsTransactionConfiguaration : ConfigurationBase<GoodsTransaction>
    {
        protected override void ModelCreating(EntityTypeBuilder<GoodsTransaction> entity)
        {
            entity.ToTable("GoodsTransaction");
            entity.HasIndex(e => e.GoodsReceivedId, "goodsTransaction_goodsReceivedId_index");

            entity.HasIndex(e => e.GoodsIssuedDetailId, "goodsTransaction_goodsIssuedDetailId_index");

            entity.HasOne(d => d.GoodsReceived).WithMany(p => p.GoodsTransactions)
                .HasForeignKey(d => d.GoodsReceivedId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("goodsTransaction_goodsReceivedId_foreign");

            entity.HasOne(d => d.GoodsIssuedDetail).WithMany(p => p.GoodsTransactions)
                .HasForeignKey(d => d.GoodsIssuedDetailId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("goodsTransaction_goodsIssuedDetailId_foreign");
        }
    }
}
