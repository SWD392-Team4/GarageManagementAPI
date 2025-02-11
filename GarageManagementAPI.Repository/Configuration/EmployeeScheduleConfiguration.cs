using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class EmployeeScheduleConfiguration : ConfigurationBase<EmployeeSchedule>
    {
        protected override void ModelCreating(EntityTypeBuilder<EmployeeSchedule> entity)
        {
            entity.HasKey(e => e.Id).HasName("employeeschedule_id_primary");

            entity.ToTable("EmployeeSchedule");

            entity.HasIndex(e => new { e.AppointmentDetailId, e.EmployeeId }, "employeeschedule_appointmentdetailid_employeeid_unique").IsUnique();

            entity.HasIndex(e => e.AppointmentDetailId, "employeeschedule_appointmentdetailid_index");

            entity.HasIndex(e => e.EmployeeId, "employeeschedule_employeeid_index");

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            entity.Property(e => e.Status).HasMaxLength(255);

            entity.HasOne(d => d.AppointmentDetail).WithMany(p => p.EmployeeSchedules)
                .HasForeignKey(d => d.AppointmentDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employeeschedule_appointmentdetailid_foreign");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeSchedules)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employeeschedule_employeeid_foreign");


            entity.Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}




