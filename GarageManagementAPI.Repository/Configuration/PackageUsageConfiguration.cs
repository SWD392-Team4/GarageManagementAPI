using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class PackageUsageConfiguration : ConfigurationBase<PackageUsage>
    {
        protected override void ModelCreating(EntityTypeBuilder<PackageUsage> entity)
        {
            entity.HasKey(e => e.Id).HasName("packageusage_id_primary");

            entity.ToTable("PackageUsage");

            entity.HasIndex(e => e.CustomerCarId, "packageusage_customercarid_index");

            entity.HasIndex(e => e.InvoiceAppointmentId, "packageusage_invoiceappointmentid_unique").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            entity.Property(e => e.Status).HasMaxLength(255);

            entity.HasOne(d => d.CustomerCar).WithMany(p => p.PackageUsages)
                .HasForeignKey(d => d.CustomerCarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("packageusage_customercarid_foreign");

            entity.HasOne(d => d.InvoiceAppointment).WithOne(p => p.PackageUsage)
                .HasForeignKey<PackageUsage>(d => d.InvoiceAppointmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("packageusage_invoiceappointmentid_foreign");

            entity.HasOne(d => d.PackageHistory).WithMany(p => p.PackageUsages)
                .HasForeignKey(d => d.PackageHistoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("packageusage_packagehistoryid_foreign");

            entity.Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}




