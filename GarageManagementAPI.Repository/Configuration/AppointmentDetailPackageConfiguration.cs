using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class AppointmentDetailPackageConfiguration : ConfigurationBase<AppointmentDetailPackage>
    {
        protected override void ModelCreating(EntityTypeBuilder<AppointmentDetailPackage> entity)
        {
            entity.HasKey(e => e.Id).HasName("appointmentdetailpackage_id_primary");

            entity.ToTable("AppointmentDetailPackage");

            entity.HasIndex(e => new { e.PackageHistoryId, e.AppointmentId }, "appointmentdetailpackage_packagehistoryid_appointmentid_unique").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            entity.Property(e => e.Status).HasMaxLength(255);

            entity.HasOne(d => d.Appointment).WithMany(p => p.AppointmentDetailPackages)
                .HasForeignKey(d => d.AppointmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("appointmentdetailpackage_appointmentid_foreign");

            entity.HasOne(d => d.PackageHistory).WithMany(p => p.AppointmentDetailPackages)
                .HasForeignKey(d => d.PackageHistoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("appointmentdetailpackage_packagehistoryid_foreign");

            entity.Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}




