using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class AppointmentConfiguration : ConfigurationBase<Appointment>
    {
        protected override void ModelCreating(EntityTypeBuilder<Appointment> entity)
        {
            entity.HasKey(e => e.Id).HasName("appointment_id_primary");

            entity.ToTable("Appointment");

            entity.HasIndex(e => e.CustomerEmail, "appointment_customeremail_index");

            entity.HasIndex(e => new { e.CustomerPhoneNumber, e.CustomerEmail }, "appointment_customerphonenumber_customeremail_index");

            entity.HasIndex(e => e.CustomerPhoneNumber, "appointment_customerphonenumber_index");

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            entity.Property(e => e.AppointmentType).HasMaxLength(255);
            entity.Property(e => e.CanceledReason).HasColumnType("text");
            entity.Property(e => e.CarCondition).HasColumnType("text");
            entity.Property(e => e.CarLicensePlateNumber).HasMaxLength(255);
            entity.Property(e => e.CustomerEmail).HasMaxLength(255);
            entity.Property(e => e.CustomerName).HasMaxLength(255);
            entity.Property(e => e.CustomerPhoneNumber).HasMaxLength(255);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Status).HasMaxLength(255);

            entity.HasOne(d => d.ApproveByEmployee).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.ApproveByEmployeeId)
                .HasConstraintName("appointment_approvebyemployeeid_foreign");

            entity.HasOne(d => d.CarModel).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.CarModelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("appointment_carmodelid_foreign");

            entity.HasOne(d => d.Garage).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.GarageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("appointment_garageid_foreign");

            entity.Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}




