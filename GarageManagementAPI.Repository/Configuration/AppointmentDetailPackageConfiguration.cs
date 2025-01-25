using GarageManagementAPI.Entities.NewModels;
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

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Status).HasMaxLength(255);

            entity.HasOne(d => d.Appointment).WithMany(p => p.AppointmentDetailPackages)
                .HasForeignKey(d => d.AppointmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("appointmentdetailpackage_appointmentid_foreign");

            entity.HasOne(d => d.PackageHistory).WithMany(p => p.AppointmentDetailPackages)
                .HasForeignKey(d => d.PackageHistoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("appointmentdetailpackage_packagehistoryid_foreign");

            entity.HasOne(d => d.UpdateByCustomer).WithMany(p => p.AppointmentDetailPackageUpdateByCustomers)
                .HasForeignKey(d => d.UpdateByCustomerId)
                .HasConstraintName("appointmentdetailpackage_updatebycustomerid_foreign");

            entity.HasOne(d => d.UpdateByEmployee).WithMany(p => p.AppointmentDetailPackageUpdateByEmployees)
                .HasForeignKey(d => d.UpdateByEmployeeId)
                .HasConstraintName("appointmentdetailpackage_updatebyemployeeid_foreign");

            entity.Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}




