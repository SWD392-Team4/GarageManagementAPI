using GarageManagementAPI.Entities.NewModels;
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

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ProductPrice).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.Status).HasMaxLength(255);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductHistories)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("producthistory_productid_foreign");


            entity.Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}




