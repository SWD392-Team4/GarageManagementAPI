using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Enums;
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
            entity.Property(e => e.Description).HasColumnType("nvarchar(max)");
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

            entity.Property(e => e.WorkNature)
                .HasConversion<string>();

            entity.Property(e => e.Action)
                .HasConversion<string>();

            entity.Property(e => e.ServiceCategory)
                .HasConversion<string>();
        }
        protected override void SeedData(EntityTypeBuilder<Service> entity)
        {
            entity.HasData(
                    //new 40 more
                    new Service()
                    {
                        Id = Guid.Parse("5c0b84e8-48df-41cd-a9b3-ff376d0c8d01"),
                        CarPartId = Guid.Parse("350B60F4-40FB-499B-9358-3A06EE2FF5F7"),
                        CarCategoryId = Guid.Parse("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), // Sedan
                        ServiceCategory = ServiceCategory.Maintenance,
                        ServiceName = "Transmission Fluid Change",
                        WorkNature = WorkNature.Preventive,
                        Action = ServiceAction.Replace,
                        Description = "Changing transmission fluid to ensure smooth gear shifts and prolong transmission life.",
                        EstimatedHours = 2,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                    },
                    // 2. Sedan – Brake Pad Replacement
                    new Service()
                    {
                        Id = Guid.Parse("2e7f0139-ca6b-4261-b8b1-92025af17c23"),
                        CarPartId = Guid.Parse("350B60F4-40FB-499B-9358-3A06EE2FF5F7"),
                        CarCategoryId = Guid.Parse("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), // Sedan
                        ServiceCategory = ServiceCategory.Repair,
                        ServiceName = "Brake Pad Replacement",
                        WorkNature = WorkNature.Corrective,
                        Action = ServiceAction.Repair,
                        Description = "Replacing worn brake pads to restore optimal braking performance.",
                        EstimatedHours = 2,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                    },
                    // 3. Hatchback – Engine Tune-Up Inspection
                    new Service()
                    {
                        Id = Guid.Parse("ae25aa47-7d00-4d8d-b858-6b68f2fa1461"),
                        CarPartId = Guid.Parse("350B60F4-40FB-499B-9358-3A06EE2FF5F7"),
                        CarCategoryId = Guid.Parse("983fba7a-11b2-4cdc-8ef0-64ddf6dfbfc4"), // Hatchback
                        ServiceCategory = ServiceCategory.Maintenance,
                        ServiceName = "Engine Tune-Up Inspection",
                        WorkNature = WorkNature.Preventive,
                        Action = ServiceAction.Inspect,
                        Description = "Conducting a comprehensive inspection to fine-tune engine performance.",
                        EstimatedHours = 1,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                    },
                    // 4. Hatchback – Suspension Repair
                    new Service()
                    {
                        Id = Guid.Parse("804addd4-32e2-40e2-8836-cba4314a37cb"),
                        CarPartId = Guid.Parse("350B60F4-40FB-499B-9358-3A06EE2FF5F7"),
                        CarCategoryId = Guid.Parse("983fba7a-11b2-4cdc-8ef0-64ddf6dfbfc4"), // Hatchback
                        ServiceCategory = ServiceCategory.Repair,
                        ServiceName = "Suspension Repair",
                        WorkNature = WorkNature.Corrective,
                        Action = ServiceAction.Repair,
                        Description = "Repairing suspension components to improve ride comfort and safety.",
                        EstimatedHours = 3,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                    },
                    // 5. Coupe – Infotainment System Upgrade
                    new Service()
                    {
                        Id = Guid.Parse("292e282b-441e-4eae-b4d3-fa66e998093d"),
                        CarPartId = Guid.Parse("350B60F4-40FB-499B-9358-3A06EE2FF5F7"),
                        CarCategoryId = Guid.Parse("5191690b-1d10-476e-b4f5-4044218e64c2"), // Coupe
                        ServiceCategory = ServiceCategory.Upgrade,
                        ServiceName = "Infotainment System Upgrade",
                        WorkNature = WorkNature.Enhancement,
                        Action = ServiceAction.Upgrade,
                        Description = "Upgrading the infotainment system for enhanced connectivity and features.",
                        EstimatedHours = 3,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                    },
                    // 6. Coupe – Engine Oil Lubrication
                    new Service()
                    {
                        Id = Guid.Parse("8e8f9751-ea57-41f1-aebe-653d7c2707e2"),
                        CarPartId = Guid.Parse("350B60F4-40FB-499B-9358-3A06EE2FF5F7"),
                        CarCategoryId = Guid.Parse("5191690b-1d10-476e-b4f5-4044218e64c2"), // Coupe
                        ServiceCategory = ServiceCategory.Maintenance,
                        ServiceName = "Engine Oil Lubrication",
                        WorkNature = WorkNature.Preventive,
                        Action = ServiceAction.Lubricate,
                        Description = "Lubricating engine components to reduce friction and wear.",
                        EstimatedHours = 1,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                    },
                    // 7. Convertible – Convertible Roof Cleaning
                    new Service()
                    {
                        Id = Guid.Parse("ae0292b9-460b-453b-a7e3-94f5e37c72b1"),
                        CarPartId = Guid.Parse("350B60F4-40FB-499B-9358-3A06EE2FF5F7"),
                        CarCategoryId = Guid.Parse("506b4f2f-68f7-4b69-ab81-1242de996a18"), // Convertible
                        ServiceCategory = ServiceCategory.CarWash,
                        ServiceName = "Convertible Roof Cleaning",
                        WorkNature = WorkNature.Aesthetic,
                        Action = ServiceAction.Clean,
                        Description = "Cleaning the roof mechanism to ensure smooth operation and a spotless finish.",
                        EstimatedHours = 1,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                    },
                    // 8. Convertible – Windshield Wiper Replacement
                    new Service()
                    {
                        Id = Guid.Parse("679799ff-ac1e-4db5-95c0-611bbb151930"),
                        CarPartId = Guid.Parse("350B60F4-40FB-499B-9358-3A06EE2FF5F7"),
                        CarCategoryId = Guid.Parse("506b4f2f-68f7-4b69-ab81-1242de996a18"), // Convertible
                        ServiceCategory = ServiceCategory.Maintenance,
                        ServiceName = "Windshield Wiper Replacement",
                        WorkNature = WorkNature.Preventive,
                        Action = ServiceAction.Replace,
                        Description = "Replacing worn wiper blades to maintain clear visibility during rain.",
                        EstimatedHours = 1,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                    },
                    // 9. Station Wagon – Interior Detailing & Polishing
                    new Service()
                    {
                        Id = Guid.Parse("0b9a2e4d-f0c5-4fd3-81cc-95ab24a98fed"),
                        CarPartId = Guid.Parse("350B60F4-40FB-499B-9358-3A06EE2FF5F7"),
                        CarCategoryId = Guid.Parse("13f81bcb-5943-4cfe-9a1f-c38c9dac0969"), // Station Wagon / Estate
                        ServiceCategory = ServiceCategory.Detailing,
                        ServiceName = "Interior Detailing & Polishing",
                        WorkNature = WorkNature.Aesthetic,
                        Action = ServiceAction.Polish,
                        Description = "Thorough cleaning and polishing of the cabin to restore a premium feel.",
                        EstimatedHours = 2,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                    },
                    // 10. Station Wagon – Brake Fluid Inspection
                    new Service()
                    {
                        Id = Guid.Parse("5764887f-1f3e-43d8-8ff2-4ec5acf2b625"),
                        CarPartId = Guid.Parse("350B60F4-40FB-499B-9358-3A06EE2FF5F7"),
                        CarCategoryId = Guid.Parse("13f81bcb-5943-4cfe-9a1f-c38c9dac0969"), // Station Wagon / Estate
                        ServiceCategory = ServiceCategory.Maintenance,
                        ServiceName = "Brake Fluid Inspection",
                        WorkNature = WorkNature.Preventive,
                        Action = ServiceAction.Inspect,
                        Description = "Inspecting brake fluid levels and condition to ensure reliable braking.",
                        EstimatedHours = 1,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                    },
                    // 11. SUV – Wheel Alignment Service
                    new Service()
                    {
                        Id = Guid.Parse("2ffc838c-bc9c-4f50-9aae-c1626d28f948"),
                        CarPartId = Guid.Parse("350B60F4-40FB-499B-9358-3A06EE2FF5F7"),
                        CarCategoryId = Guid.Parse("37a876a6-e608-4bff-9d5b-9bef9e671094"), // SUV
                        ServiceCategory = ServiceCategory.Maintenance,
                        ServiceName = "Wheel Alignment Service",
                        WorkNature = WorkNature.Corrective,
                        Action = ServiceAction.Align,
                        Description = "Adjusting wheel angles to ensure even tire wear and improved handling.",
                        EstimatedHours = 2,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                    },
                    // 12. SUV – Suspension System Repair
                    new Service()
                    {
                        Id = Guid.Parse("ca9e6960-f038-4e9f-97c9-9190378129a4"),
                        CarPartId = Guid.Parse("350B60F4-40FB-499B-9358-3A06EE2FF5F7"),
                        CarCategoryId = Guid.Parse("37a876a6-e608-4bff-9d5b-9bef9e671094"), // SUV
                        ServiceCategory = ServiceCategory.Repair,
                        ServiceName = "Suspension System Repair",
                        WorkNature = WorkNature.Corrective,
                        Action = ServiceAction.Repair,
                        Description = "Repairing faulty suspension components to restore ride quality.",
                        EstimatedHours = 3,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                    },
                    // 13. Crossover – Exterior Wash & Clean
                    new Service()
                    {
                        Id = Guid.Parse("108faee1-bdc5-4a21-99ab-1446d7070817"),
                        CarPartId = Guid.Parse("350B60F4-40FB-499B-9358-3A06EE2FF5F7"),
                        CarCategoryId = Guid.Parse("89bd23de-98f2-4de2-a753-403789911119"), // Crossover
                        ServiceCategory = ServiceCategory.CarWash,
                        ServiceName = "Exterior Wash & Clean",
                        WorkNature = WorkNature.Aesthetic,
                        Action = ServiceAction.Clean,
                        Description = "A complete exterior wash to remove dirt and restore shine.",
                        EstimatedHours = 1,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                    },
                    // 14. Crossover – Headlight Restoration
                    new Service()
                    {
                        Id = Guid.Parse("dbd23c8d-f822-4924-926e-c47d67bfb11c"),
                        CarPartId = Guid.Parse("350B60F4-40FB-499B-9358-3A06EE2FF5F7"),
                        CarCategoryId = Guid.Parse("89bd23de-98f2-4de2-a753-403789911119"), // Crossover
                        ServiceCategory = ServiceCategory.Detailing,
                        ServiceName = "Headlight Restoration",
                        WorkNature = WorkNature.Aesthetic,
                        Action = ServiceAction.Restore,
                        Description = "Restoring headlight clarity to improve nighttime visibility.",
                        EstimatedHours = 1,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                    },
                    // 15. Minivan/MPV – Air Filter Replacement
                    new Service()
                    {
                        Id = Guid.Parse("0fdac649-9fa0-4ed9-8b68-2c51290db904"),
                        CarPartId = Guid.Parse("350B60F4-40FB-499B-9358-3A06EE2FF5F7"),
                        CarCategoryId = Guid.Parse("1d25e83b-925e-472a-89d9-38c499dbfdea"), // Minivan / MPV
                        ServiceCategory = ServiceCategory.Maintenance,
                        ServiceName = "Air Filter Replacement",
                        WorkNature = WorkNature.Preventive,
                        Action = ServiceAction.Replace,
                        Description = "Replacing the air filter to maintain optimal engine performance.",
                        EstimatedHours = 1,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                    },
                    // 16. Minivan/MPV – Brake System Repair
                    new Service()
                    {
                        Id = Guid.Parse("19e4766f-30d7-4bf7-a5de-c38aa54c39ab"),
                        CarPartId = Guid.Parse("350B60F4-40FB-499B-9358-3A06EE2FF5F7"),
                        CarCategoryId = Guid.Parse("1d25e83b-925e-472a-89d9-38c499dbfdea"), // Minivan / MPV
                        ServiceCategory = ServiceCategory.Repair,
                        ServiceName = "Brake System Repair",
                        WorkNature = WorkNature.Corrective,
                        Action = ServiceAction.Repair,
                        Description = "Repairing malfunctioning brake components for safety.",
                        EstimatedHours = 2,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                    },
                    // 17. Pickup Truck – Coolant Refill Service
                    new Service()
                    {
                        Id = Guid.Parse("95417c69-fadd-45f8-94f9-70b89bbded4e"),
                        CarPartId = Guid.Parse("350B60F4-40FB-499B-9358-3A06EE2FF5F7"),
                        CarCategoryId = Guid.Parse("d904d7f0-674a-48dd-ae45-794d8e257583"), // Pickup Truck
                        ServiceCategory = ServiceCategory.Maintenance,
                        ServiceName = "Coolant Refill Service",
                        WorkNature = WorkNature.Preventive,
                        Action = ServiceAction.Refill,
                        Description = "Refilling the coolant system to prevent overheating.",
                        EstimatedHours = 1,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                    },
                    // 18. Pickup Truck – Drive Shaft Repair
                    new Service()
                    {
                        Id = Guid.Parse("6fc59687-aaf1-4fdc-821f-6fa276232515"),
                        CarPartId = Guid.Parse("350B60F4-40FB-499B-9358-3A06EE2FF5F7"),
                        CarCategoryId = Guid.Parse("d904d7f0-674a-48dd-ae45-794d8e257583"), // Pickup Truck
                        ServiceCategory = ServiceCategory.Repair,
                        ServiceName = "Drive Shaft Repair",
                        WorkNature = WorkNature.Corrective,
                        Action = ServiceAction.Repair,
                        Description = "Repairing the drive shaft to restore proper power transmission.",
                        EstimatedHours = 3,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                    },
                    // 19. Sports Car – Performance ECU Upgrade
                    new Service()
                    {
                        Id = Guid.Parse("d55973be-a40f-435b-8078-d489c74d0fd7"),
                        CarPartId = Guid.Parse("350B60F4-40FB-499B-9358-3A06EE2FF5F7"),
                        CarCategoryId = Guid.Parse("6f9e4206-d0a0-4366-a997-094827005006"), // Sports Car
                        ServiceCategory = ServiceCategory.Upgrade,
                        ServiceName = "Performance ECU Upgrade",
                        WorkNature = WorkNature.Enhancement,
                        Action = ServiceAction.Upgrade,
                        Description = "Upgrading the ECU for improved performance and responsiveness.",
                        EstimatedHours = 3,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                    },
                    // 20. Sports Car – Differential Lubrication
                    new Service()
                    {
                        Id = Guid.Parse("1aef6a6e-7376-42e2-ba86-50954246809e"),
                        CarPartId = Guid.Parse("350B60F4-40FB-499B-9358-3A06EE2FF5F7"),
                        CarCategoryId = Guid.Parse("6f9e4206-d0a0-4366-a997-094827005006"), // Sports Car
                        ServiceCategory = ServiceCategory.Maintenance,
                        ServiceName = "Differential Lubrication",
                        WorkNature = WorkNature.Preventive,
                        Action = ServiceAction.Lubricate,
                        Description = "Lubricating the differential to reduce wear and maintain performance.",
                        EstimatedHours = 1,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                    },
                    // 21. Luxury Car – Leather Seat Polishing
                    new Service()
                    {
                        Id = Guid.Parse("ca325344-f16a-44e5-b1cf-2b2c33375b16"),
                        CarPartId = Guid.Parse("350B60F4-40FB-499B-9358-3A06EE2FF5F7"),
                        CarCategoryId = Guid.Parse("7ebb6c15-8e16-439c-bd07-b998c4b26ab3"), // Luxury Car
                        ServiceCategory = ServiceCategory.Detailing,
                        ServiceName = "Leather Seat Polishing",
                        WorkNature = WorkNature.Aesthetic,
                        Action = ServiceAction.Polish,
                        Description = "Polishing leather seats to maintain a luxurious and refined interior.",
                        EstimatedHours = 2,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                    },
                    // 22. Luxury Car – Infotainment Software Update
                    new Service()
                    {
                        Id = Guid.Parse("1d001811-24d7-4f17-9b99-040417ee758c"),
                        CarPartId = Guid.Parse("350B60F4-40FB-499B-9358-3A06EE2FF5F7"),
                        CarCategoryId = Guid.Parse("7ebb6c15-8e16-439c-bd07-b998c4b26ab3"), // Luxury Car
                        ServiceCategory = ServiceCategory.Upgrade,
                        ServiceName = "Infotainment Software Update",
                        WorkNature = WorkNature.Digital,
                        Action = ServiceAction.Update,
                        Description = "Updating the infotainment software to incorporate the latest features.",
                        EstimatedHours = 2,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                    },
                    // 23. Electric Vehicle – Battery Management Software Update
                    new Service()
                    {
                        Id = Guid.Parse("49dcb9e8-cc88-417b-9cc2-da9223cba7bb"),
                        CarPartId = Guid.Parse("350B60F4-40FB-499B-9358-3A06EE2FF5F7"),
                        CarCategoryId = Guid.Parse("b8e9b4d0-8b60-451a-9810-1132482a0d92"), // Electric Vehicle (EV)
                        ServiceCategory = ServiceCategory.Upgrade,
                        ServiceName = "Battery Management Software Update",
                        WorkNature = WorkNature.Digital,
                        Action = ServiceAction.Update,
                        Description = "Updating software to optimize battery performance and safety.",
                        EstimatedHours = 2,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                    },
                    // 24. Electric Vehicle – High Voltage Cable Inspection
                    new Service()
                    {
                        Id = Guid.Parse("dd5961c4-d25d-4ccc-87d1-5d2509e9d2a0"),
                        CarPartId = Guid.Parse("350B60F4-40FB-499B-9358-3A06EE2FF5F7"),
                        CarCategoryId = Guid.Parse("b8e9b4d0-8b60-451a-9810-1132482a0d92"), // Electric Vehicle (EV)
                        ServiceCategory = ServiceCategory.Maintenance,
                        ServiceName = "High Voltage Cable Inspection",
                        WorkNature = WorkNature.Preventive,
                        Action = ServiceAction.Inspect,
                        Description = "Inspecting high voltage cables for damage or wear to ensure EV safety.",
                        EstimatedHours = 1,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                    },
                    // 25. Hybrid Car – Hybrid System Diagnostic Inspection
                    new Service()
                    {
                        Id = Guid.Parse("aaa8c312-e261-4a4b-8dee-ef1f9548df6a"),
                        CarPartId = Guid.Parse("350B60F4-40FB-499B-9358-3A06EE2FF5F7"),
                        CarCategoryId = Guid.Parse("961975c1-3dd5-4ed0-b260-b324b1c32eed"), // Hybrid Car
                        ServiceCategory = ServiceCategory.Maintenance,
                        ServiceName = "Hybrid System Diagnostic Inspection",
                        WorkNature = WorkNature.Preventive,
                        Action = ServiceAction.Inspect,
                        Description = "Performing diagnostic tests to ensure hybrid system efficiency.",
                        EstimatedHours = 1,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                    },
                    // 26. Hybrid Car – Electric Motor Repair
                    new Service()
                    {
                        Id = Guid.Parse("8cff9d86-e1f4-4ccd-9d4a-50d9b631d2ff"),
                        CarPartId = Guid.Parse("350B60F4-40FB-499B-9358-3A06EE2FF5F7"),
                        CarCategoryId = Guid.Parse("961975c1-3dd5-4ed0-b260-b324b1c32eed"), // Hybrid Car
                        ServiceCategory = ServiceCategory.Repair,
                        ServiceName = "Electric Motor Repair",
                        WorkNature = WorkNature.Corrective,
                        Action = ServiceAction.Repair,
                        Description = "Repairing the electric motor to restore hybrid performance.",
                        EstimatedHours = 3,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                    },
                    // 27. Roadster – Sport Exhaust Upgrade
                    new Service()
                    {
                        Id = Guid.Parse("465f7c43-42ad-446a-88a3-1de98daff9d5"),
                        CarPartId = Guid.Parse("350B60F4-40FB-499B-9358-3A06EE2FF5F7"),
                        CarCategoryId = Guid.Parse("a0ded8b7-8094-4ece-8cf7-d1670080ef60"), // Roadster
                        ServiceCategory = ServiceCategory.Upgrade,
                        ServiceName = "Sport Exhaust Upgrade",
                        WorkNature = WorkNature.Enhancement,
                        Action = ServiceAction.Upgrade,
                        Description = "Upgrading the exhaust system to boost performance and achieve a sporty sound.",
                        EstimatedHours = 3,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                    },
                    // 28. Roadster – Engine Oil Change
                    new Service()
                    {
                        Id = Guid.Parse("5699cd29-fc73-4495-86c2-d3854f3844c6"),
                        CarPartId = Guid.Parse("350B60F4-40FB-499B-9358-3A06EE2FF5F7"),
                        CarCategoryId = Guid.Parse("a0ded8b7-8094-4ece-8cf7-d1670080ef60"), // Roadster
                        ServiceCategory = ServiceCategory.Maintenance,
                        ServiceName = "Engine Oil Change",
                        WorkNature = WorkNature.Preventive,
                        Action = ServiceAction.Replace,
                        Description = "Changing engine oil to maintain performance and extend engine life.",
                        EstimatedHours = 1,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                    },
                    // 29. Muscle Car – Performance Exhaust Upgrade
                    new Service()
                    {
                        Id = Guid.Parse("8e09e528-ef74-4687-993d-33447cbc7b46"),
                        CarPartId = Guid.Parse("350B60F4-40FB-499B-9358-3A06EE2FF5F7"),
                        CarCategoryId = Guid.Parse("48b990a0-cce6-4d09-9a7e-e6d1a76bdb46"), // Muscle Car
                        ServiceCategory = ServiceCategory.Upgrade,
                        ServiceName = "Performance Exhaust Upgrade",
                        WorkNature = WorkNature.Enhancement,
                        Action = ServiceAction.Upgrade,
                        Description = "Upgrading the exhaust for enhanced performance and aggressive sound.",
                        EstimatedHours = 3,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                    },
                    // 30. Muscle Car – Engine Overhaul Repair
                    new Service()
                    {
                        Id = Guid.Parse("9d2bc061-81f1-46c7-96e4-97b9b7cd8f94"),
                        CarPartId = Guid.Parse("350B60F4-40FB-499B-9358-3A06EE2FF5F7"),
                        CarCategoryId = Guid.Parse("48b990a0-cce6-4d09-9a7e-e6d1a76bdb46"), // Muscle Car
                        ServiceCategory = ServiceCategory.Repair,
                        ServiceName = "Engine Overhaul Repair",
                        WorkNature = WorkNature.Corrective,
                        Action = ServiceAction.Repair,
                        Description = "Comprehensive repair of engine components to restore peak performance.",
                        EstimatedHours = 4,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                    },
                    // 31. Off-Road Vehicle – Differential Lubrication
                    new Service()
                    {
                        Id = Guid.Parse("1f3cc46a-b312-4100-9efc-12e3c64eb60c"),
                        CarPartId = Guid.Parse("350B60F4-40FB-499B-9358-3A06EE2FF5F7"),
                        CarCategoryId = Guid.Parse("5aa5a48b-686e-426e-a54e-c5e59bbc7373"), // Off-Road Vehicle
                        ServiceCategory = ServiceCategory.Maintenance,
                        ServiceName = "Differential Lubrication",
                        WorkNature = WorkNature.Preventive,
                        Action = ServiceAction.Lubricate,
                        Description = "Lubricating the differential to reduce friction in off-road conditions.",
                        EstimatedHours = 1,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                    },
                    // 32. Off-Road Vehicle – Suspension Mount Repair
                    new Service()
                    {
                        Id = Guid.Parse("bb3b64ea-6cf2-47cb-9ead-3914cb0505ad"),
                        CarPartId = Guid.Parse("350B60F4-40FB-499B-9358-3A06EE2FF5F7"),
                        CarCategoryId = Guid.Parse("5aa5a48b-686e-426e-a54e-c5e59bbc7373"), // Off-Road Vehicle
                        ServiceCategory = ServiceCategory.Repair,
                        ServiceName = "Suspension Mount Repair",
                        WorkNature = WorkNature.Corrective,
                        Action = ServiceAction.Repair,
                        Description = "Repairing suspension mounts to ensure durability on rough terrain.",
                        EstimatedHours = 3,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                    },
                    // 33. Compact Car – Regular Engine Inspection
                    new Service()
                    {
                        Id = Guid.Parse("0af80b56-c94e-4665-9660-2caf6f2faa92"),
                        CarPartId = Guid.Parse("350B60F4-40FB-499B-9358-3A06EE2FF5F7"),
                        CarCategoryId = Guid.Parse("d4018b86-eb87-4114-9b9e-5fae1034cbd8"), // Compact Car
                        ServiceCategory = ServiceCategory.Maintenance,
                        ServiceName = "Regular Engine Inspection",
                        WorkNature = WorkNature.Preventive,
                        Action = ServiceAction.Inspect,
                        Description = "Routine engine inspection to detect early signs of wear.",
                        EstimatedHours = 1,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                    },
                    // 34. Compact Car – Brake Pad Replacement
                    new Service()
                    {
                        Id = Guid.Parse("e320a34f-1e76-48d6-a2fa-a45b7eeddb07"),
                        CarPartId = Guid.Parse("350B60F4-40FB-499B-9358-3A06EE2FF5F7"),
                        CarCategoryId = Guid.Parse("d4018b86-eb87-4114-9b9e-5fae1034cbd8"), // Compact Car
                        ServiceCategory = ServiceCategory.Repair,
                        ServiceName = "Brake Pad Replacement",
                        WorkNature = WorkNature.Corrective,
                        Action = ServiceAction.Replace,
                        Description = "Replacing brake pads to maintain effective stopping power.",
                        EstimatedHours = 2,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                    },
                    // 35. Subcompact Car – Compact Car Exterior Wash
                    new Service()
                    {
                        Id = Guid.Parse("2f7203ad-ff0a-4fc6-b6bd-ff75f4855633"),
                        CarPartId = Guid.Parse("350B60F4-40FB-499B-9358-3A06EE2FF5F7"),
                        CarCategoryId = Guid.Parse("fc000760-6615-4f3b-96cc-7607ba6609a8"), // Subcompact Car
                        ServiceCategory = ServiceCategory.CarWash,
                        ServiceName = "Compact Car Exterior Wash",
                        WorkNature = WorkNature.Aesthetic,
                        Action = ServiceAction.Clean,
                        Description = "Exterior wash designed specifically for subcompact cars.",
                        EstimatedHours = 1,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                    },
                    // 36. Subcompact Car – Coolant Refill
                    new Service()
                    {
                        Id = Guid.Parse("dae53a3d-c422-4242-a6c6-752ad99223ec"),
                        CarPartId = Guid.Parse("350B60F4-40FB-499B-9358-3A06EE2FF5F7"),
                        CarCategoryId = Guid.Parse("fc000760-6615-4f3b-96cc-7607ba6609a8"), // Subcompact Car
                        ServiceCategory = ServiceCategory.Maintenance,
                        ServiceName = "Coolant Refill",
                        WorkNature = WorkNature.Preventive,
                        Action = ServiceAction.Refill,
                        Description = "Refilling the coolant to ensure the engine runs at optimal temperatures.",
                        EstimatedHours = 1,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                    },
                    // 37. Mid-Size Car – Power Steering Fluid Lubrication
                    new Service()
                    {
                        Id = Guid.Parse("9fc6018f-efcf-45c3-9208-a4b4eac755fb"),
                        CarPartId = Guid.Parse("350B60F4-40FB-499B-9358-3A06EE2FF5F7"),
                        CarCategoryId = Guid.Parse("61a22ffb-c41d-4365-b067-11213e5579f9"), // Mid-Size Car
                        ServiceCategory = ServiceCategory.Maintenance,
                        ServiceName = "Power Steering Fluid Lubrication",
                        WorkNature = WorkNature.Preventive,
                        Action = ServiceAction.Lubricate,
                        Description = "Lubricating the power steering system for smooth steering response.",
                        EstimatedHours = 1,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                    },
                    // 38. Mid-Size Car – Brake System Repair
                    new Service()
                    {
                        Id = Guid.Parse("3605af66-e2e0-4189-acfa-78b2151e8108"),
                        CarPartId = Guid.Parse("350B60F4-40FB-499B-9358-3A06EE2FF5F7"),
                        CarCategoryId = Guid.Parse("61a22ffb-c41d-4365-b067-11213e5579f9"), // Mid-Size Car
                        ServiceCategory = ServiceCategory.Repair,
                        ServiceName = "Brake System Repair",
                        WorkNature = WorkNature.Corrective,
                        Action = ServiceAction.Repair,
                        Description = "Repairing the brake system to ensure reliable stopping performance.",
                        EstimatedHours = 2,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                    },
                    // 39. Full-Size Car – Advanced Infotainment Upgrade
                    new Service()
                    {
                        Id = Guid.Parse("a1d96353-b314-4c19-ba52-c95252d838ed"),
                        CarPartId = Guid.Parse("350B60F4-40FB-499B-9358-3A06EE2FF5F7"),
                        CarCategoryId = Guid.Parse("f5bf5757-92b6-4cc2-b86b-1995f28d3fb6"), // Full-Size Car
                        ServiceCategory = ServiceCategory.Upgrade,
                        ServiceName = "Advanced Infotainment Upgrade",
                        WorkNature = WorkNature.Enhancement,
                        Action = ServiceAction.Upgrade,
                        Description = "Upgrading the infotainment system with advanced features for a superior experience.",
                        EstimatedHours = 3,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                    },
                    // 40. Full-Size Car – Full Interior Detailing
                    new Service()
                    {
                        Id = Guid.Parse("41e56392-31fc-4013-bcf1-a5a3348bce68"),
                        CarPartId = Guid.Parse("350B60F4-40FB-499B-9358-3A06EE2FF5F7"),
                        CarCategoryId = Guid.Parse("f5bf5757-92b6-4cc2-b86b-1995f28d3fb6"), // Full-Size Car
                        ServiceCategory = ServiceCategory.Detailing,
                        ServiceName = "Full Interior Detailing",
                        WorkNature = WorkNature.Aesthetic,
                        Action = ServiceAction.Polish,
                        Description = "Comprehensive interior detailing to restore and maintain a luxurious cabin finish.",
                        EstimatedHours = 3,
                        CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                        UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00")
                    }
            );
        }
    }
}




