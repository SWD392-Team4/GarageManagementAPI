using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class EmployeeInfoConfiguration : ConfigurationBase<EmployeeInfo>
    {
        protected override void ModelCreating(EntityTypeBuilder<EmployeeInfo> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.User)
                  .WithOne(u => u.EmployeeInfo)
                  .HasForeignKey<EmployeeInfo>(e => e.Id)
                  .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(e => e.CitizenIdentification).IsUnique();
        }
    }
}
