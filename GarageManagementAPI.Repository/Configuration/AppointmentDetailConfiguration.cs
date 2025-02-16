using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class AppointmentDetailConfiguration : ConfigurationBase<AppointmentDetail>
    {
        protected override void ModelCreating(EntityTypeBuilder<AppointmentDetail> entity)
        {
            entity.HasKey(e => e.Id).HasName("appointmentdetail_id_primary");

            entity.ToTable("AppointmentDetail");

            entity.HasIndex(e => e.AppointmentId, "appointmentdetail_appointmentid_index");

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()"); ;
            entity.Property(e => e.ServiceNote).HasColumnType("text");
            entity.Property(e => e.Status).HasMaxLength(255);

            entity.HasOne(d => d.Appointment).WithMany(p => p.AppointmentDetails)
                .HasForeignKey(d => d.AppointmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("appointmentdetail_appointmentid_foreign");

            entity.HasOne(d => d.ServiceHistory).WithMany(p => p.AppointmentDetails)
                .HasForeignKey(d => d.ServiceHistoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("appointmentdetail_servicehistoryid_foreign");

            entity.HasOne(d => d.UpdateByCustomer).WithMany(p => p.AppointmentDetailUpdateByCustomers)
                .HasForeignKey(d => d.UpdateByCustomerId)
                .HasConstraintName("appointmentdetail_updatebycustomerid_foreign");

            entity.HasOne(d => d.UpdateByEmployee).WithMany(p => p.AppointmentDetailUpdateByEmployees)
                .HasForeignKey(d => d.UpdateByEmployeeId)
                .HasConstraintName("appointmentdetail_updatebyemployeeid_foreign");

            entity.Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}




