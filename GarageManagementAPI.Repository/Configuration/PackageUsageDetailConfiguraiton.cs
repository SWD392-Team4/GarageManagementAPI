using GarageManagementAPI.Entities.NewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class PackageUsageDetailConfiguraiton : ConfigurationBase<PackageUsageDetail>
    {
        protected override void ModelCreating(EntityTypeBuilder<PackageUsageDetail> entity)
        {
            entity.HasKey(e => e.Id).HasName("packageusagedetail_id_primary");

            entity.HasIndex(e => new { e.PackageUsageId, e.AppointmentId }, "packageusagedetail_packageusageid_appointmentid_unique").IsUnique();

            entity.ToTable("PackageUsageDetail");

            entity.HasIndex(e => e.AppointmentId, "packageusagedetail_appointmentid_unique").IsUnique();

            entity.HasIndex(e => e.PackageUsageId, "packageusagedetail_packageusageid_index");

            entity.Property(e => e.Status).HasMaxLength(255);

            entity.HasOne(d => d.Appointment).WithOne(p => p.PackageUsageDetail)
                .HasForeignKey<PackageUsageDetail>(d => d.AppointmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("packageusagedetail_appointmentid_foreign");

            entity.HasOne(d => d.PackageUsage).WithMany(p => p.PackageUsageDetails)
                .HasForeignKey(d => d.PackageUsageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("packageusagedetail_packageusageid_foreign");


            entity.Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}




