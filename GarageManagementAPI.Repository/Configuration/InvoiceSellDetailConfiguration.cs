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


            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");

            entity.HasOne(d => d.Invoice).WithMany(p => p.InvoiceSellProducts)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("invoicesellproduct_invoiceid_foreign");

            entity.HasOne(d => d.Product)
                          .WithMany(p => p.InvoiceSellProducts)
                          .HasForeignKey(d => d.ProductId)
                          .OnDelete(DeleteBehavior.ClientSetNull)
                          .HasConstraintName("invoicesellproduct_productid_foreign");
        }
    }
}




