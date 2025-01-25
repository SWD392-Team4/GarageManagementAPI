using GarageManagementAPI.Entities.NewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class PackageImageConfiguration : ConfigurationBase<PackageImage>
    {
        protected override void ModelCreating(EntityTypeBuilder<PackageImage> entity)
        {
            entity.HasKey(e => e.Id).HasName("packageimage_id_primary");

            entity.ToTable("PackageImage");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Link).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(255);

            entity.HasOne(d => d.Package).WithMany(p => p.PackageImages)
                .HasForeignKey(d => d.PackageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("packageimage_packageid_foreign");

            entity.Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}




