using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class AppointmentReplacementPartConfiguration : ConfigurationBase<AppointmentReplacementParts>
    {
        protected override void ModelCreating(EntityTypeBuilder<AppointmentReplacementParts> builder)
        {
            builder.HasKey(x => x.Id);

        }

        protected override void SeedData(EntityTypeBuilder<AppointmentReplacementParts> builder)
        {
            base.SeedData(builder);
        }
    }

}
