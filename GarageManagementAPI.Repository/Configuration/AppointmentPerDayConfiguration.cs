using GarageManagementAPI.Entities.NewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class AppointmentPerDayConfiguration : ConfigurationBase<AppointmentPerDay>
    {
        protected override void ModelCreating(EntityTypeBuilder<AppointmentPerDay> entity)
        {
            entity.HasKey(e => e.Id).HasName("appointmentperday_id_primary");

            entity.ToTable("AppointmentPerDay");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Status).HasMaxLength(255);


            entity.Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}




