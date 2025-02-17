using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class PackageConfiguration : ConfigurationBase<Package>
    {
        protected override void ModelCreating(EntityTypeBuilder<Package> entity)
        {
            entity.HasKey(e => e.Id).HasName("package_id_primary");

            entity.ToTable("Package");

            entity.HasIndex(e => e.CarCategoryId, "package_carcategoryid_index");

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.PackageName).HasMaxLength(255);
            entity.Property(e => e.ServiceCategory).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(255);

            entity.HasOne(d => d.CarCategory).WithMany(p => p.Packages)
                .HasForeignKey(d => d.CarCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("package_carcategoryid_foreign");

            entity.Property(e => e.Status)
                .HasConversion<string>();

            entity.Property(e => e.Type)
                .HasConversion<string>();
        }
    }
}




