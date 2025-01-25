using GarageManagementAPI.Entities.NewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class ServiceHistoryConfiguration : ConfigurationBase<ServiceHistory>
    {
        protected override void ModelCreating(EntityTypeBuilder<ServiceHistory> entity)
        {
            entity.HasKey(e => e.Id).HasName("servicehistory_id_primary");

            entity.ToTable("ServiceHistory");

            entity.HasIndex(e => e.ServiceId, "servicehistory_serviceid_index");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Price).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.Status).HasMaxLength(255);

            entity.HasOne(d => d.Service).WithMany(p => p.ServiceHistories)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("servicehistory_serviceid_foreign");


            entity.Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}




