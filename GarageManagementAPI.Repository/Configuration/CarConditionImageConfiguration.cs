using GarageManagementAPI.Entities.NewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class CarConditionImageConfiguration : ConfigurationBase<CarConditionImage>
    {
        protected override void ModelCreating(EntityTypeBuilder<CarConditionImage> entity)
        {
            entity.HasKey(e => e.Id).HasName("carconditionimage_id_primary");

            entity.ToTable("CarConditionImage");

            entity.HasIndex(e => e.AppointmentDetailId, "carconditionimage_appointmentdetailid_index");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ConditionStage).HasMaxLength(255);
            entity.Property(e => e.Link).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(255);

            entity.HasOne(d => d.AppointmentDetail).WithMany(p => p.CarConditionImages)
                .HasForeignKey(d => d.AppointmentDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("carconditionimage_appointmentdetailid_foreign");


            entity.Property(e => e.Status)
                .HasConversion<string>();

            entity.Property(e => e.ConditionStage)
                .HasConversion<string>();
        }
    }
}




