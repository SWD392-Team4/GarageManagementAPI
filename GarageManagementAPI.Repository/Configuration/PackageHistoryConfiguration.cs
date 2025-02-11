using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class PackageHistoryConfiguration : ConfigurationBase<PackageHistory>
    {
        protected override void ModelCreating(EntityTypeBuilder<PackageHistory> entity)
        {
            entity.HasKey(e => e.Id).HasName("packagehistory_id_primary");

            entity.ToTable("PackageHistory");

            entity.HasIndex(e => e.PackageId, "packagehistory_packageid_index");

            entity.HasIndex(e => new { e.PackageId, e.PackagePrice, e.ValidityPeriod, e.TimeUnit, e.UsageLimit }, "packagehistory_packageid_packageprice_validityperiod_timeunit_usagelimit_unique").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            entity.Property(e => e.PackagePrice).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.Status).HasMaxLength(255);
            entity.Property(e => e.TimeUnit).HasMaxLength(255);

            entity.HasOne(d => d.Package).WithMany(p => p.PackageHistories)
                .HasForeignKey(d => d.PackageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("packagehistory_packageid_foreign");


            entity.Property(e => e.Status)
                .HasConversion<string>();

            entity.Property(e => e.TimeUnit)
                .HasConversion<string>();
        }
    }
}




