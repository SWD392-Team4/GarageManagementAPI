using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

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

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
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
      /*  protected override void SeedData(EntityTypeBuilder<Service> entity)
        {
            entity.HasData(
    new Service()
    {
        Id = Guid.NewGuid(),
        CarPartId = Guid.Parse("350B60F4-40FB-499B-9358-3A06EE2FF5F7"),
        CarCategoryId = Guid.Parse("69246D30-53C9-4804-A89B-F692919172DE"),
        ServiceCategory = "Transmission",
        ServiceName = "Transmission Fluid Change",
        WorkNature = "Regular Maintenance",
        Action = "Replace Transmission Fluid",
        Description = "Changing transmission fluid to ensure smooth gear shifts.",
        EstimatedHours = 2,
        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
    },
    new Service()
    {
        Id = Guid.NewGuid(),
        CarPartId = Guid.Parse("ABADC9E1-C8E6-4F40-B078-47F609D1CF79"),
        CarCategoryId = Guid.Parse("B88688EC-8E1C-46A2-999F-F1B8E92B8F24"),
        ServiceCategory = "Electrical System",
        ServiceName = "Battery Replacement",
        WorkNature = "Replacement",
        Action = "Replace Car Battery",
        Description = "Replacing old battery with a new one to ensure proper electrical function.",
        EstimatedHours = 1,
        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
    },
    new Service()
    {
        Id = Guid.NewGuid(),
        CarPartId = Guid.Parse("84062C49-1FE2-4B97-86C4-49E4D0F5449B"),
        CarCategoryId = Guid.Parse("A0EEB005-F9E8-49FA-AD32-DE352A0A04AB"),
        ServiceCategory = "Cooling System",
        ServiceName = "Radiator Flush",
        WorkNature = "Maintenance",
        Action = "Flush Radiator",
        Description = "Flushing the radiator to remove debris and old coolant.",
        EstimatedHours = 2,
        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
    },
    new Service()
    {
        Id = Guid.NewGuid(),
        CarPartId = Guid.Parse("D263567A-41B2-407D-B40D-6BAD18EB32CA"),
        CarCategoryId = Guid.Parse("2D31F83E-1508-48AB-934C-93D46266B57B"),
        ServiceCategory = "Exhaust System",
        ServiceName = "Muffler Replacement",
        WorkNature = "Repair",
        Action = "Replace Muffler",
        Description = "Replacing the muffler to reduce noise and improve exhaust flow.",
        EstimatedHours = 2,
        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
    },
    new Service()
    {
        Id = Guid.NewGuid(),
        CarPartId = Guid.Parse("855F8A55-C9D0-4532-81EE-6DA2BD0DB1F6"),
        CarCategoryId = Guid.Parse("E0101BA3-DF29-4DF3-A0D1-68BB0853A86B"),
        ServiceCategory = "Tires",
        ServiceName = "Tire Rotation",
        WorkNature = "Regular Maintenance",
        Action = "Rotate Tires",
        Description = "Rotating tires to ensure even wear and extend tire life.",
        EstimatedHours = 1,
        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
    },
    new Service()
    {
        Id = Guid.NewGuid(),
        CarPartId = Guid.Parse("1C1FFD05-3B06-48BF-B78C-86B6EF2D3CEF"),
        CarCategoryId = Guid.Parse("47B2CCC3-0570-4D9A-ACBE-4D95D03001C7"),
        ServiceCategory = "Air Conditioning",
        ServiceName = "AC Recharge",
        WorkNature = "Maintenance",
        Action = "Recharge AC System",
        Description = "Recharging the AC system to restore cooling efficiency.",
        EstimatedHours = 1,
        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
    },
    new Service()
    {
        Id = Guid.NewGuid(),
        CarPartId = Guid.Parse("0131E761-BDEB-4FD0-8ABA-B3CC0769D0C4"),
        CarCategoryId = Guid.Parse("2EAED576-3F1E-43AA-B92D-4B45990DF71F"),
        ServiceCategory = "Fuel System",
        ServiceName = "Fuel Filter Replacement",
        WorkNature = "Maintenance",
        Action = "Replace Fuel Filter",
        Description = "Replacing the fuel filter to ensure clean fuel delivery to the engine.",
        EstimatedHours = 1,
        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
    },
    new Service()
    {
        Id = Guid.NewGuid(),
        CarPartId = Guid.Parse("2C74B21A-5EC4-4DCE-B376-B6B0601D7A84"),
        CarCategoryId = Guid.Parse("12CA3969-C9FF-4B3E-91D0-1FE421C9D2F4"),
        ServiceCategory = "Lighting",
        ServiceName = "Headlight Bulb Replacement",
        WorkNature = "Replacement",
        Action = "Replace Headlight Bulb",
        Description = "Replacing a burnt-out headlight bulb to ensure proper visibility.",
        EstimatedHours = 1,
        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
    },
    new Service()
    {
        Id = Guid.NewGuid(),
        CarPartId = Guid.Parse("4B3039F3-B460-46BE-AA39-E43D4C29AF19"),
        CarCategoryId = Guid.Parse("D8123055-C15D-4932-90BA-127E415C36B4"),
        ServiceCategory = "Windscreen",
        ServiceName = "Windscreen Wiper Replacement",
        WorkNature = "Replacement",
        Action = "Replace Windscreen Wipers",
        Description = "Replacing worn-out windscreen wipers to ensure clear visibility during rain.",
        EstimatedHours = 1,
        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
    },
    new Service()
    {
        Id = Guid.NewGuid(),
        CarPartId = Guid.Parse("4B3039F3-B460-46BE-AA39-E43D4C29AF19"),
        CarCategoryId = Guid.Parse("AB9B4F29-FEA5-4D09-A0B3-02DD5DEDC6E5"),
        ServiceCategory = "Interior",
        ServiceName = "Cabin Air Filter Replacement",
        WorkNature = "Maintenance",
        Action = "Replace Cabin Air Filter",
        Description = "Replacing the cabin air filter to improve air quality inside the vehicle.",
        EstimatedHours = 1,
        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
    }
);
        }*/
    }
}




