using GarageManagementAPI.Entities.NewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class ServiceImageConfiguration : ConfigurationBase<ServiceImage>
    {
        protected override void ModelCreating(EntityTypeBuilder<ServiceImage> entity)
        {
            entity.HasKey(e => e.Id).HasName("serviceimage_id_primary");

            entity.ToTable("ServiceImage");

            entity.HasIndex(e => e.ServiceId, "serviceimage_serviceid_index");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Link).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(255);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ServiceImage)
                .HasForeignKey<ServiceImage>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("serviceimage_id_foreign");


            entity.Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}




