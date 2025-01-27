using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class GoodsReceivedConfiguration : ConfigurationBase<GoodsReceived>
    {
        protected override void ModelCreating(EntityTypeBuilder<GoodsReceived> entity)
        {
            entity.HasKey(e => e.Id).HasName("goodsreceived_id_primary");

            entity.ToTable("GoodsReceived");

            entity.HasIndex(e => e.SupplierContactId, "goodsreceived_suppliercontactid_index");

            entity.HasIndex(e => e.WarehouseId, "goodsreceived_warehouseid_index");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.InvoiceCode).HasMaxLength(255);
            entity.Property(e => e.RefereneceNumber).HasMaxLength(255);
            entity.Property(e => e.SourceAddress).HasMaxLength(255);
            entity.Property(e => e.SourceDistrict).HasMaxLength(255);
            entity.Property(e => e.SourceProvince).HasMaxLength(255);
            entity.Property(e => e.SourceWards).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(255);
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(8, 2)");

            entity.HasOne(d => d.CreatedWarehouseManager).WithMany(p => p.GoodsReceiveds)
                .HasForeignKey(d => d.CreatedWarehouseManagerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("goodsreceived_createdwarehousemanagerid_foreign");

            entity.HasOne(d => d.SupplierContact).WithMany(p => p.GoodsReceiveds)
                .HasForeignKey(d => d.SupplierContactId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("goodsreceived_suppliercontactid_foreign");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.GoodsReceiveds)
                .HasForeignKey(d => d.WarehouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("goodsreceived_warehouseid_foreign");


            entity.Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}




