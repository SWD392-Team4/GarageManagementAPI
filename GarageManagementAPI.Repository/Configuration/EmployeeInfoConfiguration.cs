using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class EmployeeInfoConfiguration : ConfigurationBase<EmployeeInfo>
    {
        protected override void ModelCreating(EntityTypeBuilder<EmployeeInfo> entity)
        {
            entity.HasKey(e => e.Id).HasName("employeeinfo_userid_primary");

            entity.ToTable("EmployeeInfo");

            entity.HasIndex(e => e.CitizenIdentification, "employeeinfo_citizenidentification_unique").IsUnique();

            entity.HasIndex(e => e.WorkplaceId, "employeeinfo_workplaceid_index");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CitizenIdentification).HasMaxLength(255);

            entity.HasOne(d => d.User).WithOne(p => p.EmployeeInfo)
                .HasForeignKey<EmployeeInfo>(d => d.Id)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("employeeinfo_userid_foreign");

            entity.HasOne(d => d.Workplace).WithMany(p => p.EmployeeInfos)
                .HasForeignKey(d => d.WorkplaceId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("employeeinfo_workplaceid_foreign");


        }
    }
}




