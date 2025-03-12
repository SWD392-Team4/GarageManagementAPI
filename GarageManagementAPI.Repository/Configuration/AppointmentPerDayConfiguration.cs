using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class AppointmentPerDayConfiguration : ConfigurationBase<AppointmentPerDay>
    {
        protected override void ModelCreating(EntityTypeBuilder<AppointmentPerDay> entity)
        {
            entity.HasKey(e => e.Id).HasName("appointmentperdayy_id_primary");

            entity.ToTable("AppointmentPerDay");

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
        }
    }
}




