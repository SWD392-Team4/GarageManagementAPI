using GarageManagementAPI.Entities.NewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class ReplacementPartConfiguration : ConfigurationBase<ReplacementPart>
    {
        protected override void ModelCreating(EntityTypeBuilder<ReplacementPart> entity)
        {
            entity.HasKey(e => e.Id).HasName("replacementpart_id_primary");

            entity.ToTable("ReplacementPart");

            entity.HasIndex(e => e.InvoiceDetailId, "replacementpart_invoiceappointmentdetailid_index");

            entity.HasIndex(e => new { e.InvoiceDetailId, e.ProductHistoryId, e.ProductAtGarageId }, "replacementpart_invoiceappointmentdetailid_producthistoryid_productatgarageid_unique").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(8, 2)");

            entity.HasOne(d => d.InvoiceDetail).WithMany(p => p.ReplacementParts)
                .HasForeignKey(d => d.InvoiceDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("replacementpart_invoiceappointmentdetailid_foreign");

            entity.HasOne(d => d.ProductAtGarage).WithMany(p => p.ReplacementParts)
                .HasForeignKey(d => d.ProductAtGarageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("replacementpart_productatgarageid_foreign");

            entity.HasOne(d => d.ProductHistory).WithMany(p => p.ReplacementParts)
                .HasForeignKey(d => d.ProductHistoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("replacementpart_producthistoryid_foreign");


        }
    }
}




