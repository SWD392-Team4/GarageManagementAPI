using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class ServiceFeedBackConfiguraiton : ConfigurationBase<ServiceFeedBack>
    {
        protected override void ModelCreating(EntityTypeBuilder<ServiceFeedBack> entity)
        {
            entity.HasKey(e => e.Id).HasName("servicefeedback_id_primary");

            entity.ToTable("ServiceFeedBack");

            entity.HasIndex(e => e.CustomerId, "servicefeedback_customerid_index");

            entity.HasIndex(e => e.ServiceId, "servicefeedback_serviceid_index");

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            entity.Property(e => e.Emoji).HasMaxLength(255);
            entity.Property(e => e.FeedBack).HasColumnType("text");
            entity.Property(e => e.Status).HasMaxLength(255);

            entity.HasOne(d => d.Customer).WithMany(p => p.ServiceFeedBacks)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("servicefeedback_customerid_foreign");

            entity.HasOne(d => d.Service).WithMany(p => p.ServiceFeedBacks)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("servicefeedback_serviceid_foreign");


            entity.Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}




