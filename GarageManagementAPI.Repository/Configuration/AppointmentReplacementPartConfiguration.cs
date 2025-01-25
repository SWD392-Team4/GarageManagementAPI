using GarageManagementAPI.Entities.NewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class AppointmentReplacementPartConfiguration : ConfigurationBase<AppointmentReplacementPart>
    {
        protected override void ModelCreating(EntityTypeBuilder<AppointmentReplacementPart> entity)
        {
            entity.HasKey(e => e.Id).HasName("appointmentreplacementpart_id_primary");

            entity.ToTable("AppointmentReplacementPart");

            entity.HasIndex(e => e.AppointmentDetailId, "appointmentreplacementpart_appointmentdetailid_index");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Status).HasMaxLength(255);

            entity.HasOne(d => d.AppointmentDetail).WithMany(p => p.AppointmentReplacementParts)
                .HasForeignKey(d => d.AppointmentDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("appointmentreplacementpart_appointmentdetailid_foreign");

            entity.HasOne(d => d.ProductAtGarage).WithMany(p => p.AppointmentReplacementParts)
                .HasForeignKey(d => d.ProductAtGarageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("appointmentreplacementpart_productatgarageid_foreign");

            entity.HasOne(d => d.ProductHistory).WithMany(p => p.AppointmentReplacementParts)
                .HasForeignKey(d => d.ProductHistoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("appointmentreplacementpart_producthistoryid_foreign");


            entity.Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}




