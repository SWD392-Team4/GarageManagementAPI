using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class GoodsIssuedConfiguration : ConfigurationBase<GoodsIssued>
    {
        protected override void ModelCreating(EntityTypeBuilder<GoodsIssued> entity)
        {
            entity.HasKey(e => e.Id).HasName("goodsissued_id_primary");

            entity.ToTable("GoodsIssued");

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            entity.Property(e => e.InvoiceCode).HasMaxLength(255);
            entity.Property(e => e.ReferenceNumber).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(255);
            entity.Property(e => e.TotalCost).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.CreatedWareHouseManager).WithMany(p => p.GoodsIssueds)
                .HasForeignKey(d => d.CreatedWareHouseManagerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("goodsissued_createdwarehousemanagerid_foreign");

            entity.HasOne(d => d.Garage).WithMany(p => p.GoodsIssuedGarages)
                .HasForeignKey(d => d.GarageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("goodsissued_garageid_foreign");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.GoodsIssuedWarehouses)
                .HasForeignKey(d => d.WarehouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("goodsissued_warehouseid_foreign");


            entity.Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}




