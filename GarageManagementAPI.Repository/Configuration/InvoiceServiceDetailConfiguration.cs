using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class InvoiceServiceDetailConfiguration : ConfigurationBase<InvoiceServiceDetail>
    {
        protected override void ModelCreating(EntityTypeBuilder<InvoiceServiceDetail> entity)
        {
            entity.HasKey(e => e.Id).HasName("invoiceservicedetail_id_primary");

            entity.ToTable("InvoiceServiceDetail");

            entity.HasIndex(e => e.InvoiceId, "invoiceservicedetail_invoiceid_index");

            entity.HasIndex(e => new { e.InvoiceId, e.ServiceHistoryId }, "invoiceservicedetail_invoiceid_servicehistoryid_unique").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");

            entity.HasOne(d => d.Invoice).WithMany(p => p.InvoiceServiceDetails)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("invoiceservicedetail_invoiceid_foreign");

            entity.HasOne(d => d.ServiceHistory).WithMany(p => p.InvoiceServiceDetails)
                .HasForeignKey(d => d.ServiceHistoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("invoiceservicedetail_servicehistoryid_foreign");


        }
    }
}




