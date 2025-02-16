using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class InvoiceSellDetailConfiguration : ConfigurationBase<InvoiceSellProduct>
    {
        protected override void ModelCreating(EntityTypeBuilder<InvoiceSellProduct> entity)
        {
            entity.HasKey(e => e.Id).HasName("invoicesellproduct_id_primary");

            entity.ToTable("InvoiceSellProduct");

            entity.HasIndex(e => e.InvoiceId, "invoicesellproduct_invoiceid_index");

            entity.HasIndex(e => new { e.ProductHistoryId, e.InvoiceId, e.ProductAtGarageId }, "invoicesellproduct_producthistoryid_invoiceid_productatgarageid_unique").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Invoice).WithMany(p => p.InvoiceSellProducts)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("invoicesellproduct_invoiceid_foreign");

            entity.HasOne(d => d.ProductAtGarage).WithMany(p => p.InvoiceSellProducts)
                .HasForeignKey(d => d.ProductAtGarageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("invoicesellproduct_productatgarageid_foreign");

            entity.HasOne(d => d.ProductHistory).WithMany(p => p.InvoiceSellProducts)
                .HasForeignKey(d => d.ProductHistoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("invoicesellproduct_producthistoryid_foreign");


        }
    }
}




