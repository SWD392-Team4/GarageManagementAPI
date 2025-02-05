using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class PackageDetailConfiguration : ConfigurationBase<PackageDetail>
    {
        protected override void ModelCreating(EntityTypeBuilder<PackageDetail> entity)
        {
            entity.HasKey(e => new { e.PackageHistoryId, e.ServiceId }).HasName("packagedetail_packagehistoryid_serviceid_primary");

            entity.ToTable("PackageDetail");

            entity.Property(e => e.Status).HasMaxLength(255);

            entity.HasOne(d => d.PackageHistory).WithMany(p => p.PackageDetails)
                .HasForeignKey(d => d.PackageHistoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("packagedetail_packagehistoryid_foreign");

            entity.HasOne(d => d.Service).WithMany(p => p.PackageDetails)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("packagedetail_serviceid_foreign");

            entity.Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}




