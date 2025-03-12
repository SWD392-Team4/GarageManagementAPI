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

            entity.HasIndex(e => e.GarageId).IsUnique();

            entity.HasOne(d => d.Garage).WithOne(p => p.AppointmentPerDay)
              .HasForeignKey<AppointmentPerDay>(d => d.GarageId)
              .OnDelete(DeleteBehavior.Cascade)
              .HasConstraintName("appointmentperday_garageid_foreign");
        }

        protected override void SeedData(EntityTypeBuilder<AppointmentPerDay> entity)
        {
            base.SeedData(entity);
            entity.HasData(
                new AppointmentPerDay()
                {
                    CountPerDay = 10,
                    GarageId = new Guid("c1aeb9e5-8c74-4b09-bc57-d4c3df7857f9"),
                    Id = new Guid("c637eb36-0dee-4190-9338-3c5053ea3ea6")
                },
                new AppointmentPerDay()
                {
                    CountPerDay = 5,
                    GarageId = new Guid("6760cbb7-f1fa-445f-a175-97e3f060c861"),
                    Id = new Guid("fa657400-f856-4a91-965d-b20dc194ac66")
                }
                );
        }
    }
}




