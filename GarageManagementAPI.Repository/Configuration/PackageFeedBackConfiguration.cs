using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class PackageFeedBackConfiguration : ConfigurationBase<PackageFeedBack>
    {
        protected override void ModelCreating(EntityTypeBuilder<PackageFeedBack> entity)
        {
            entity.HasKey(e => e.Id).HasName("packagefeedback_id_primary");

            entity.ToTable("PackageFeedBack");

            entity.HasIndex(e => e.CustomerId, "packagefeedback_customerid_index");

            entity.HasIndex(e => e.PackageId, "packagefeedback_packageid_index");

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            entity.Property(e => e.Emoji).HasMaxLength(255);
            entity.Property(e => e.FeedBack).HasColumnType("text");
            entity.Property(e => e.Status).HasMaxLength(255);

            entity.HasOne(d => d.Customer).WithMany(p => p.PackageFeedBacks)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("packagefeedback_customerid_foreign");

            entity.HasOne(d => d.Package).WithMany(p => p.PackageFeedBacks)
                .HasForeignKey(d => d.PackageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("packagefeedback_packageid_foreign");


            entity.Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}




