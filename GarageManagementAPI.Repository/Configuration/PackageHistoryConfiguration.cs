using GarageManagementAPI.Entities.Models;
using Microsoft.AspNetCore.Identity;
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

            entity.HasIndex(e => e.CreatedAt);

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            entity.Property(e => e.PackagePrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TimeUnit).HasMaxLength(255);
            entity.Property(e => e.Description).HasColumnType("nvarchar(max)");
            entity.HasOne(d => d.Package).WithMany(p => p.PackageHistories)
                .HasForeignKey(d => d.PackageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("packagehistory_packageid_foreign");

            entity.HasOne(d => d.CarCategory).WithMany(p => p.PackageHistories)
                .HasForeignKey(d => d.CarCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("packagehistory_carcategoryid_foreign");

            entity.Property(e => e.TimeUnit)
                .HasConversion<string>();

            entity.Property(e => e.ServiceCategory)
                .HasConversion<string>();

            entity.Property(e => e.Type)
                .HasConversion<string>();

            entity.HasMany(p => p.Services)
               .WithMany(s => s.PackageHistories)
               .UsingEntity<PackageDetail>(
                   j => j.HasOne<Service>().WithMany().HasForeignKey(pd => pd.ServiceId),
                   j => j.HasOne<PackageHistory>().WithMany().HasForeignKey(pd => pd.PackageHistoryId),
                   j =>
                   {
                       j.HasKey(pd => new { pd.ServiceId, pd.PackageHistoryId });
                       j.ToTable("PackageDetail");
                   });
        }
    }
}




