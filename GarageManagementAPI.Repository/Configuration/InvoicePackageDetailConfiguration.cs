using GarageManagementAPI.Entities.NewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class InvoicePackageDetailConfiguration : ConfigurationBase<InvoicePackageDetail>
    {
        protected override void ModelCreating(EntityTypeBuilder<InvoicePackageDetail> entity)
        {
            entity.HasKey(e => e.Id).HasName("invoicepackagedetail_id_primary");

            entity.ToTable("InvoicePackageDetail");

            entity.HasIndex(e => e.InvoiceId, "invoicepackagedetail_invoiceid_index");

            entity.HasIndex(e => new { e.InvoiceId, e.PackageHistoryId }, "invoicepackagedetail_invoiceid_packagehistoryid_unique").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Invoice).WithMany(p => p.InvoicePackageDetails)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("invoicepackagedetail_invoiceid_foreign");

            entity.HasOne(d => d.PackageHistory).WithMany(p => p.InvoicePackageDetails)
                .HasForeignKey(d => d.PackageHistoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("invoicepackagedetail_packagehistoryid_foreign");


        }
    }
}




