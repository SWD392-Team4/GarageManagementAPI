using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class PackageConditionConfiguration : ConfigurationBase<PackageCondition>
    {
        protected override void ModelCreating(EntityTypeBuilder<PackageCondition> entity)
        {
            entity.HasKey(e => e.Id).HasName("packagecondition_id_primary");

            entity.ToTable("PackageCondition");

            entity.HasIndex(e => new { e.ConditionType, e.ConditionValue }, "packagecondition_conditiontype_conditionvalue_unique").IsUnique();

            entity.HasIndex(e => e.PackageId, "packagecondition_packageid_index");

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            entity.Property(e => e.ConditionType).HasMaxLength(255);

            entity.HasOne(d => d.Package).WithMany(p => p.PackageConditions)
                .HasForeignKey(d => d.PackageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("packagecondition_packageid_foreign");


            entity.Property(e => e.ConditionType)
                .HasConversion<string>();
        }
    }
}




