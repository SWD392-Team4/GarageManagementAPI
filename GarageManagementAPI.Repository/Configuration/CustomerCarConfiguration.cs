using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class CustomerCarConfiguration : ConfigurationBase<CustomerCar>
    {
        protected override void ModelCreating(EntityTypeBuilder<CustomerCar> entity)
        {
            entity.HasKey(e => e.Id).HasName("customercar_id_primary");

            entity.ToTable("CustomerCar");

            entity.HasIndex(e => e.CreatedByEmployeeId, "customercar_createdbyemployeeid_index");

            entity.HasIndex(e => e.CustomerId, "customercar_customerid_index");

            entity.HasIndex(e => e.LicensePlateNumber, "customercar_licenseplatenumber_unique").IsUnique();

            entity.HasIndex(e => e.VehicleIdentificationNumber, "customercar_vehicleidentificationnumber_unique").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            entity.Property(e => e.Color).HasMaxLength(255);
            entity.Property(e => e.EngineNumber).HasMaxLength(255);
            entity.Property(e => e.FuelType).HasMaxLength(255);
            entity.Property(e => e.LicensePlateNumber).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(255);
            entity.Property(e => e.VehicleIdentificationNumber).HasMaxLength(255);

            entity.HasOne(d => d.CarModel).WithMany(p => p.CustomerCars)
                .HasForeignKey(d => d.CarModelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("customercar_carmodelid_foreign");

            entity.HasOne(d => d.CreatedByEmployee).WithMany(p => p.CustomerCarCreatedByEmployees)
                .HasForeignKey(d => d.CreatedByEmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("customercar_createdbyemployeeid_foreign");

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerCarCustomers)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("customercar_customerid_foreign");


            entity.Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}




