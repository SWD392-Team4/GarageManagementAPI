using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class CarCategoryConfiguration : ConfigurationBase<CarCategory>
    {
        protected override void ModelCreating(EntityTypeBuilder<CarCategory> entity)
        {
            entity.HasKey(e => e.Id).HasName("carcategory_id_primary");

            entity.ToTable("CarCategory");

            entity.HasIndex(e => e.Category, "carcategory_category_unique").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            entity.Property(e => e.Category).HasMaxLength(255);
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Status).HasMaxLength(255);


            entity.Property(e => e.Status)
                .HasConversion<string>();
        }

        protected override void SeedData(EntityTypeBuilder<CarCategory> entity)
        {
            entity.HasData(
                 new CarCategory()
                 {
                     Id = new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"),
                     Category = "Sedan",
                     Description = "A sedan is a passenger car with a three-box configuration (engine, passenger, cargo) that offers comfort and efficiency for daily commuting.",
                     Status = CarCategoryStatus.Active,
                     CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                     UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                 },
                new CarCategory()
                {
                    Id = new Guid("983fba7a-11b2-4cdc-8ef0-64ddf6dfbfc4"),
                    Category = "Hatchback",
                    Description = "A hatchback features a rear door that swings upward, providing versatile cargo space while maintaining a compact footprint.",
                    Status = CarCategoryStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarCategory()
                {
                    Id = new Guid("5191690b-1d10-476e-b4f5-4044218e64c2"),
                    Category = "Coupe",
                    Description = "A coupe is a two-door car known for its sporty design and performance, often emphasizing style over practicality.",
                    Status = CarCategoryStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarCategory()
                {
                    Id = new Guid("506b4f2f-68f7-4b69-ab81-1242de996a18"),
                    Category = "Convertible",
                    Description = "A convertible offers a retractable roof for open-air driving, blending the appeal of sporty performance with leisure versatility.",
                    Status = CarCategoryStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarCategory()
                {
                    Id = new Guid("13f81bcb-5943-4cfe-9a1f-c38c9dac0969"),
                    Category = "Station Wagon / Estate",
                    Description = "A station wagon (estate) features extended cargo space via a rear liftgate, making it ideal for families and long trips.",
                    Status = CarCategoryStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarCategory()
                {
                    Id = new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"),
                    Category = "SUV (Sport Utility Vehicle)",
                    Description = "SUVs offer a high driving position, ample cargo space, and often off-road capability, making them versatile for various terrains.",
                    Status = CarCategoryStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarCategory()
                {
                    Id = new Guid("89bd23de-98f2-4de2-a753-403789911119"),
                    Category = "Crossover",
                    Description = "A crossover blends features of SUVs and sedans, offering a balance of comfort, efficiency, and a modern design.",
                    Status = CarCategoryStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarCategory()
                {
                    Id = new Guid("1d25e83b-925e-472a-89d9-38c499dbfdea"),
                    Category = "Minivan / MPV",
                    Description = "Minivans (or MPVs) are designed for family transport with spacious interiors, sliding doors, and flexible seating arrangements.",
                    Status = CarCategoryStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarCategory()
                {
                    Id = new Guid("d904d7f0-674a-48dd-ae45-794d8e257583"),
                    Category = "Pickup Truck",
                    Description = "Pickup trucks are built for utility with a separate cargo bed, robust performance for hauling and towing, and off-road potential.",
                    Status = CarCategoryStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarCategory()
                {
                    Id = new Guid("6f9e4206-d0a0-4366-a997-094827005006"),
                    Category = "Sports Car",
                    Description = "Sports cars are engineered for high performance and agility, providing an exhilarating driving experience with a focus on speed.",
                    Status = CarCategoryStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarCategory()
                {
                    Id = new Guid("7ebb6c15-8e16-439c-bd07-b998c4b26ab3"),
                    Category = "Luxury Car",
                    Description = "Luxury cars offer premium comfort, cutting-edge technology, and superior craftsmanship for a refined and sophisticated driving experience.",
                    Status = CarCategoryStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarCategory()
                {
                    Id = new Guid("b8e9b4d0-8b60-451a-9810-1132482a0d92"),
                    Category = "Electric Vehicle (EV)",
                    Description = "Electric vehicles are powered solely by electric motors and batteries, providing a sustainable and energy-efficient alternative to traditional fuel.",
                    Status = CarCategoryStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarCategory()
                {
                    Id = new Guid("961975c1-3dd5-4ed0-b260-b324b1c32eed"),
                    Category = "Hybrid Car",
                    Description = "Hybrid cars combine a conventional internal combustion engine with an electric motor, boosting fuel efficiency and reducing emissions.",
                    Status = CarCategoryStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarCategory()
                {
                    Id = new Guid("a0ded8b7-8094-4ece-8cf7-d1670080ef60"),
                    Category = "Roadster",
                    Description = "Roadsters are lightweight, two-seater cars designed for spirited driving and open-air enjoyment, emphasizing agility and performance.",
                    Status = CarCategoryStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarCategory()
                {
                    Id = new Guid("48b990a0-cce6-4d09-9a7e-e6d1a76bdb46"),
                    Category = "Muscle Car",
                    Description = "Muscle cars are characterized by their powerful engines and aggressive styling, designed for high performance and an exhilarating drive.",
                    Status = CarCategoryStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarCategory()
                {
                    Id = new Guid("5aa5a48b-686e-426e-a54e-c5e59bbc7373"),
                    Category = "Off-Road Vehicle",
                    Description = "Off-road vehicles are engineered with high ground clearance and durable suspension systems, built to tackle rough terrain and challenging environments.",
                    Status = CarCategoryStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarCategory()
                {
                    Id = new Guid("d4018b86-eb87-4114-9b9e-5fae1034cbd8"),
                    Category = "Compact Car",
                    Description = "Compact cars are small, fuel-efficient vehicles designed for city driving while offering practicality for everyday use.",
                    Status = CarCategoryStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarCategory()
                {
                    Id = new Guid("fc000760-6615-4f3b-96cc-7607ba6609a8"),
                    Category = "Subcompact Car",
                    Description = "Subcompact cars are even smaller than compact models, offering excellent maneuverability and efficiency for urban environments.",
                    Status = CarCategoryStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarCategory()
                {
                    Id = new Guid("61a22ffb-c41d-4365-b067-11213e5579f9"),
                    Category = "Mid-Size Car",
                    Description = "Mid-size cars balance space, comfort, and efficiency, providing versatility for both personal and family use.",
                    Status = CarCategoryStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarCategory()
                {
                    Id = new Guid("f5bf5757-92b6-4cc2-b86b-1995f28d3fb6"),
                    Category = "Full-Size Car",
                    Description = "Full-size cars offer maximum interior space and premium comfort, ideal for long-distance travel and upscale driving experiences.",
                    Status = CarCategoryStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                });
        }
    }
}




