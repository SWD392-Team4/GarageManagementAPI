using GarageManagementAPI.Entities.NewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class ServiceConfiguration : ConfigurationBase<Service>
    {
        protected override void ModelCreating(EntityTypeBuilder<Service> entity)
        {
            entity.HasKey(e => e.Id).HasName("service_id_primary");

            entity.ToTable("Service");

            entity.HasIndex(e => e.CarPartId, "service_carpartid_index");

            entity.HasIndex(e => new { e.ServiceCategory, e.WorkNature, e.Action, e.CarCategoryId }, "service_servicecategory_worknature_action_carcategoryid_unique").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Action).HasMaxLength(255);
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.ServiceCategory).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(255);
            entity.Property(e => e.WorkNature).HasMaxLength(255);

            entity.HasOne(d => d.CarCategory).WithMany(p => p.Services)
                .HasForeignKey(d => d.CarCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("service_carcategoryid_foreign");

            entity.HasOne(d => d.CarPart).WithMany(p => p.Services)
                .HasForeignKey(d => d.CarPartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("service_carpartid_foreign");


            entity.Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}




