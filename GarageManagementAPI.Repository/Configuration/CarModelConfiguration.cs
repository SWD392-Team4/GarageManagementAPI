using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class CarModelConfiguration : ConfigurationBase<CarModel>
    {
        protected override void ModelCreating(EntityTypeBuilder<CarModel> entity)
        {
            entity.HasKey(e => e.Id).HasName("carmodel_id_primary");

            entity.ToTable("CarModel");

            entity.HasIndex(e => e.BrandId, "carmodel_brandid_index");

            entity.HasIndex(e => new { e.BrandId, e.CarCategoryId, e.ModelName, e.ModelYear }).IsUnique();

            entity.HasIndex(e => e.CarCategoryId, "carmodel_carcategoryid_index");

            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            entity.Property(e => e.ModelName).HasMaxLength(255);
            entity.Property(e => e.ModelYear).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(255);

            entity.HasOne(d => d.Brand).WithMany(p => p.CarModels)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("carmodel_brandid_foreign");

            entity.HasOne(d => d.CarCategory).WithMany(p => p.CarModels)
                .HasForeignKey(d => d.CarCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("carmodel_carcategoryid_foreign");

            entity.HasMany(d => d.Products).WithMany(p => p.CarModels)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductCarModel",
                    r => r.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("productcarmodel_productid_foreign"),
                    l => l.HasOne<CarModel>().WithMany()
                        .HasForeignKey("CarModelId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("productcarmodel_carmodelid_foreign"),
                    j =>
                    {
                        j.HasKey("CarModelId", "ProductId").HasName("productcarmodel_carmodelid_productid_primary");
                        j.ToTable("ProductCarModel");
                    });


            entity.Property(e => e.Status)
                .HasConversion<string>();
        }

        protected override void SeedData(EntityTypeBuilder<CarModel> entity)
        {
            entity.HasData(
                 new CarModel
                 {
                     Id = new Guid("9f56523e-903c-4dc4-a1a8-df7730bc1ccd"),
                     BrandId = new Guid("47cc8b19-70ce-46f3-aef9-eb933eea2182"),
                     CarCategoryId = new Guid("d4018b86-eb87-4114-9b9e-5fae1034cbd8"), // Compact Car
                     ModelName = "Corolla",
                     ModelYear = new DateOnly(1966, 1, 1),
                     Status = CarModelStatus.Active,
                     CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                     UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                 },
                new CarModel
                {
                    Id = new Guid("c062a7b0-8bc4-43ff-af1b-14ce393f89b3"),
                    BrandId = new Guid("47cc8b19-70ce-46f3-aef9-eb933eea2182"),
                    CarCategoryId = new Guid("61a22ffb-c41d-4365-b067-11213e5579f9"), // Mid-Size Car
                    ModelName = "Camry",
                    ModelYear = new DateOnly(1982, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Ford (BrandId: 30e45fc3-a2d1-4006-be2b-9de2b1c5130c)
                new CarModel
                {
                    Id = new Guid("e63c596e-0889-453d-8772-8918ffec7bb9"),
                    BrandId = new Guid("30e45fc3-a2d1-4006-be2b-9de2b1c5130c"),
                    CarCategoryId = new Guid("48b990a0-cce6-4d09-9a7e-e6d1a76bdb46"), // Muscle Car
                    ModelName = "Mustang",
                    ModelYear = new DateOnly(1964, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("0b079daa-528a-4a2d-bff4-c33c093c7f95"),
                    BrandId = new Guid("30e45fc3-a2d1-4006-be2b-9de2b1c5130c"),
                    CarCategoryId = new Guid("d904d7f0-674a-48dd-ae45-794d8e257583"), // Pickup Truck
                    ModelName = "F-150",
                    ModelYear = new DateOnly(1975, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Volkswagen (BrandId: 23e128b8-73fe-4e74-bfdf-97d82911af47)
                new CarModel
                {
                    Id = new Guid("e3baed85-5ab4-43b0-8648-bde97d1a27f9"),
                    BrandId = new Guid("23e128b8-73fe-4e74-bfdf-97d82911af47"),
                    CarCategoryId = new Guid("983fba7a-11b2-4cdc-8ef0-64ddf6dfbfc4"), // Hatchback
                    ModelName = "Golf",
                    ModelYear = new DateOnly(1974, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("078bf0ae-414f-4bd3-9880-4cbef3ed1d69"),
                    BrandId = new Guid("23e128b8-73fe-4e74-bfdf-97d82911af47"),
                    CarCategoryId = new Guid("61a22ffb-c41d-4365-b067-11213e5579f9"), // Mid-Size Car
                    ModelName = "Passat",
                    ModelYear = new DateOnly(1973, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Honda (BrandId: 14cc790e-323d-4020-b1ac-5ff5bb96336d)
                new CarModel
                {
                    Id = new Guid("444cae6b-9521-4997-8619-21d8628cc14f"),
                    BrandId = new Guid("14cc790e-323d-4020-b1ac-5ff5bb96336d"),
                    CarCategoryId = new Guid("d4018b86-eb87-4114-9b9e-5fae1034cbd8"), // Compact Car
                    ModelName = "Civic",
                    ModelYear = new DateOnly(1972, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("726e5e9e-1fdf-4a12-b307-2b07cc3cac2e"),
                    BrandId = new Guid("14cc790e-323d-4020-b1ac-5ff5bb96336d"),
                    CarCategoryId = new Guid("61a22ffb-c41d-4365-b067-11213e5579f9"), // Mid-Size Car
                    ModelName = "Accord",
                    ModelYear = new DateOnly(1976, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Chevrolet (BrandId: 793ed2e4-eba2-407e-a814-ab8d5ddcdfc7)
                new CarModel
                {
                    Id = new Guid("57c0e845-7c0e-436a-a458-4166b8bf87e8"),
                    BrandId = new Guid("793ed2e4-eba2-407e-a814-ab8d5ddcdfc7"),
                    CarCategoryId = new Guid("f5bf5757-92b6-4cc2-b86b-1995f28d3fb6"), // Full-Size Car
                    ModelName = "Impala",
                    ModelYear = new DateOnly(1958, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("e41eed79-a74e-4f3e-b73b-8f75a73b9eef"),
                    BrandId = new Guid("793ed2e4-eba2-407e-a814-ab8d5ddcdfc7"),
                    CarCategoryId = new Guid("48b990a0-cce6-4d09-9a7e-e6d1a76bdb46"), // Muscle Car
                    ModelName = "Camaro",
                    ModelYear = new DateOnly(1966, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Nissan (BrandId: 4224e14b-fce0-47cb-904f-0c7c286d45f8)
                new CarModel
                {
                    Id = new Guid("f7aceb18-a3f6-441f-a243-78d65dea2520"),
                    BrandId = new Guid("4224e14b-fce0-47cb-904f-0c7c286d45f8"),
                    CarCategoryId = new Guid("61a22ffb-c41d-4365-b067-11213e5579f9"), // Mid-Size Car
                    ModelName = "Altima",
                    ModelYear = new DateOnly(1992, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("fa8da65d-fa4c-4382-9dfa-2a550a3e7633"),
                    BrandId = new Guid("4224e14b-fce0-47cb-904f-0c7c286d45f8"),
                    CarCategoryId = new Guid("6f9e4206-d0a0-4366-a997-094827005006"), // Sports Car
                    ModelName = "GT-R",
                    ModelYear = new DateOnly(2007, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // BMW (BrandId: 5b4d0698-cf56-41ff-927f-3226f1146f0f)
                new CarModel
                {
                    Id = new Guid("6869ab0a-21e1-4232-a060-eb01662e70cd"),
                    BrandId = new Guid("5b4d0698-cf56-41ff-927f-3226f1146f0f"),
                    CarCategoryId = new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), // Sedan
                    ModelName = "3 Series",
                    ModelYear = new DateOnly(1975, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("a1575758-cb4b-4389-9b09-416dc9faff00"),
                    BrandId = new Guid("5b4d0698-cf56-41ff-927f-3226f1146f0f"),
                    CarCategoryId = new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"), // SUV
                    ModelName = "X5",
                    ModelYear = new DateOnly(1999, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Mercedes-Benz (BrandId: f7f6b4fc-0e88-4cb6-af7e-c0834bfb2b2c)
                new CarModel
                {
                    Id = new Guid("5391d472-b17f-4edc-b0a0-97a825d08037"),
                    BrandId = new Guid("f7f6b4fc-0e88-4cb6-af7e-c0834bfb2b2c"),
                    CarCategoryId = new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), // Sedan
                    ModelName = "C-Class",
                    ModelYear = new DateOnly(1993, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("46262201-7c4f-4cc8-b0c0-b70ff84071b6"),
                    BrandId = new Guid("f7f6b4fc-0e88-4cb6-af7e-c0834bfb2b2c"),
                    CarCategoryId = new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"), // SUV
                    ModelName = "GLE",
                    ModelYear = new DateOnly(2015, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Audi (BrandId: 4d8aaaa6-448a-431c-a50f-a313dba5b3e5)
                new CarModel
                {
                    Id = new Guid("32d4f172-fa59-4a15-be8b-f2f9c539814d"),
                    BrandId = new Guid("4d8aaaa6-448a-431c-a50f-a313dba5b3e5"),
                    CarCategoryId = new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), // Sedan
                    ModelName = "A4",
                    ModelYear = new DateOnly(1994, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("dd601366-9262-4058-a0cb-efe4706b7886"),
                    BrandId = new Guid("4d8aaaa6-448a-431c-a50f-a313dba5b3e5"),
                    CarCategoryId = new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"), // SUV
                    ModelName = "Q7",
                    ModelYear = new DateOnly(2005, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Hyundai (BrandId: 1f13210f-6d0b-4cb9-86b9-fc0fa5898afd)
                new CarModel
                {
                    Id = new Guid("304937c8-e8b5-4322-9707-81ee54917f09"),
                    BrandId = new Guid("1f13210f-6d0b-4cb9-86b9-fc0fa5898afd"),
                    CarCategoryId = new Guid("d4018b86-eb87-4114-9b9e-5fae1034cbd8"), // Compact Car
                    ModelName = "Elantra",
                    ModelYear = new DateOnly(1990, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("35b311c9-0315-47c2-8615-6497c6161797"),
                    BrandId = new Guid("1f13210f-6d0b-4cb9-86b9-fc0fa5898afd"),
                    CarCategoryId = new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"), // SUV
                    ModelName = "Santa Fe",
                    ModelYear = new DateOnly(2000, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Kia (BrandId: 0131e761-bdeb-4fd0-8aba-b3cc0769d0c4)
                new CarModel
                {
                    Id = new Guid("ef19e53a-86e5-4794-a160-a2b1009fed10"),
                    BrandId = new Guid("0131e761-bdeb-4fd0-8aba-b3cc0769d0c4"),
                    CarCategoryId = new Guid("89bd23de-98f2-4de2-a753-403789911119"), // Crossover
                    ModelName = "Soul",
                    ModelYear = new DateOnly(2009, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("d40079b8-bad2-4892-96cf-e33f8f64c3ba"),
                    BrandId = new Guid("0131e761-bdeb-4fd0-8aba-b3cc0769d0c4"),
                    CarCategoryId = new Guid("61a22ffb-c41d-4365-b067-11213e5579f9"), // Mid-Size Car
                    ModelName = "Optima",
                    ModelYear = new DateOnly(2000, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Subaru (BrandId: 84062c49-1fe2-4b97-86c4-49e4d0f5449b)
                new CarModel
                {
                    Id = new Guid("0c027854-f172-4c85-b345-5a2a50a2540e"),
                    BrandId = new Guid("84062c49-1fe2-4b97-86c4-49e4d0f5449b"),
                    CarCategoryId = new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), // Sedan
                    ModelName = "Impreza",
                    ModelYear = new DateOnly(1992, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("44556cfd-a389-4b43-b7f4-b13d8374e4f8"),
                    BrandId = new Guid("84062c49-1fe2-4b97-86c4-49e4d0f5449b"),
                    CarCategoryId = new Guid("13f81bcb-5943-4cfe-9a1f-c38c9dac0969"), // Station Wagon / Estate
                    ModelName = "Outback",
                    ModelYear = new DateOnly(1994, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Lexus (BrandId: 2c74b21a-5ec4-4dce-b376-b6b0601d7a84)
                new CarModel
                {
                    Id = new Guid("fc90a161-8393-4cf9-a41b-ceb04ab4d65b"),
                    BrandId = new Guid("2c74b21a-5ec4-4dce-b376-b6b0601d7a84"),
                    CarCategoryId = new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"), // SUV
                    ModelName = "RX",
                    ModelYear = new DateOnly(1998, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("58ad4554-54e2-4374-b20b-80eb92a5ce32"),
                    BrandId = new Guid("2c74b21a-5ec4-4dce-b376-b6b0601d7a84"),
                    CarCategoryId = new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), // Sedan
                    ModelName = "ES",
                    ModelYear = new DateOnly(1989, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Dodge (BrandId: 350b60f4-40fb-499b-9358-3a06ee2ff5f7)
                new CarModel
                {
                    Id = new Guid("d9de80a0-0669-48dc-b4fa-6c2da348ae21"),
                    BrandId = new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"),
                    CarCategoryId = new Guid("48b990a0-cce6-4d09-9a7e-e6d1a76bdb46"), // Muscle Car
                    ModelName = "Charger",
                    ModelYear = new DateOnly(1966, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("90398dd5-a925-4a42-9da0-1fb4ca4db86f"),
                    BrandId = new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"),
                    CarCategoryId = new Guid("48b990a0-cce6-4d09-9a7e-e6d1a76bdb46"), // Muscle Car
                    ModelName = "Challenger",
                    ModelYear = new DateOnly(1970, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Jeep (BrandId: 855f8a55-c9d0-4532-81ee-6da2bd0db1f6)
                new CarModel
                {
                    Id = new Guid("e0da9f81-d53d-43df-a09b-54dc4d1c7056"),
                    BrandId = new Guid("855f8a55-c9d0-4532-81ee-6da2bd0db1f6"),
                    CarCategoryId = new Guid("5aa5a48b-686e-426e-a54e-c5e59bbc7373"), // Off-Road Vehicle
                    ModelName = "Wrangler",
                    ModelYear = new DateOnly(1986, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("70117f5d-6ff1-4858-8d5a-61023d7bfe97"),
                    BrandId = new Guid("855f8a55-c9d0-4532-81ee-6da2bd0db1f6"),
                    CarCategoryId = new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"), // SUV
                    ModelName = "Grand Cherokee",
                    ModelYear = new DateOnly(1992, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Cadillac (BrandId: abadc9e1-c8e6-4f40-b078-47f609d1cf79)
                new CarModel
                {
                    Id = new Guid("382a5533-5b8c-49ca-bb3e-242e8aa4675d"),
                    BrandId = new Guid("abadc9e1-c8e6-4f40-b078-47f609d1cf79"),
                    CarCategoryId = new Guid("7ebb6c15-8e16-439c-bd07-b998c4b26ab3"), // Luxury Car
                    ModelName = "Escalade",
                    ModelYear = new DateOnly(1999, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("f5ca917c-681f-4b4b-97e0-250e6c14fe66"),
                    BrandId = new Guid("abadc9e1-c8e6-4f40-b078-47f609d1cf79"),
                    CarCategoryId = new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), // Sedan
                    ModelName = "CTS",
                    ModelYear = new DateOnly(2003, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // GMC (BrandId: 4b3039f3-b460-46be-aa39-e43d4c29af19)
                new CarModel
                {
                    Id = new Guid("7182e277-e952-4879-b2f7-ab5dc04584e1"),
                    BrandId = new Guid("4b3039f3-b460-46be-aa39-e43d4c29af19"),
                    CarCategoryId = new Guid("d904d7f0-674a-48dd-ae45-794d8e257583"), // Pickup Truck
                    ModelName = "Sierra",
                    ModelYear = new DateOnly(1998, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("117cdc46-af9f-4574-a012-b083c2412d50"),
                    BrandId = new Guid("4b3039f3-b460-46be-aa39-e43d4c29af19"),
                    CarCategoryId = new Guid("f5bf5757-92b6-4cc2-b86b-1995f28d3fb6"), // Full-Size Car
                    ModelName = "Yukon",
                    ModelYear = new DateOnly(1992, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Mitsubishi (BrandId: 1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef)
                new CarModel
                {
                    Id = new Guid("42845e68-16d7-4dca-8ecf-4d6a9424da6a"),
                    BrandId = new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"),
                    CarCategoryId = new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), // Sedan
                    ModelName = "Lancer",
                    ModelYear = new DateOnly(1973, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("cb7fef13-3f55-4121-a274-0937d1d0c810"),
                    BrandId = new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"),
                    CarCategoryId = new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"), // SUV
                    ModelName = "Outlander",
                    ModelYear = new DateOnly(2001, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Porsche (BrandId: cee5a4d8-de84-4482-9da9-302e2290cb0f)
                new CarModel
                {
                    Id = new Guid("cd831f07-859d-44b9-981a-91472c7428a9"),
                    BrandId = new Guid("cee5a4d8-de84-4482-9da9-302e2290cb0f"),
                    CarCategoryId = new Guid("6f9e4206-d0a0-4366-a997-094827005006"), // Sports Car
                    ModelName = "911",
                    ModelYear = new DateOnly(1964, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("8599ac63-b85c-41d5-b789-46b062d05e5d"),
                    BrandId = new Guid("cee5a4d8-de84-4482-9da9-302e2290cb0f"),
                    CarCategoryId = new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"), // SUV
                    ModelName = "Cayenne",
                    ModelYear = new DateOnly(2002, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Volvo (BrandId: e9a7beda-ff63-4ac5-92cb-b7fa152c41c2)
                new CarModel
                {
                    Id = new Guid("71f51929-7b86-4f0f-b576-d7ff85e90747"),
                    BrandId = new Guid("e9a7beda-ff63-4ac5-92cb-b7fa152c41c2"),
                    CarCategoryId = new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), // Sedan
                    ModelName = "S60",
                    ModelYear = new DateOnly(2000, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("6efa7da6-8d4a-403b-afd3-738eb0e9bd98"),
                    BrandId = new Guid("e9a7beda-ff63-4ac5-92cb-b7fa152c41c2"),
                    CarCategoryId = new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"), // SUV
                    ModelName = "XC90",
                    ModelYear = new DateOnly(2002, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Land Rover (BrandId: f5fd6ee3-a8b6-452c-9042-146e8afc875f)
                new CarModel
                {
                    Id = new Guid("0af1bd43-7aca-47f2-a682-5085fdcd9254"),
                    BrandId = new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"),
                    CarCategoryId = new Guid("7ebb6c15-8e16-439c-bd07-b998c4b26ab3"), // Luxury Car
                    ModelName = "Range Rover",
                    ModelYear = new DateOnly(1970, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("a153be07-ddda-4b52-b540-b37fe38e6263"),
                    BrandId = new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"),
                    CarCategoryId = new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"), // SUV
                    ModelName = "Discovery",
                    ModelYear = new DateOnly(1989, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Mazda (BrandId: e99dfd5c-ffe7-454d-9ae2-c4622eaa8200)
                new CarModel
                {
                    Id = new Guid("237a7434-e92a-44a7-abdf-88bc1e5722f1"),
                    BrandId = new Guid("e99dfd5c-ffe7-454d-9ae2-c4622eaa8200"),
                    CarCategoryId = new Guid("d4018b86-eb87-4114-9b9e-5fae1034cbd8"), // Compact Car
                    ModelName = "Mazda3",
                    ModelYear = new DateOnly(2003, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("2772a079-889e-491e-8f0a-1f5c674c32d4"),
                    BrandId = new Guid("e99dfd5c-ffe7-454d-9ae2-c4622eaa8200"),
                    CarCategoryId = new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"), // SUV
                    ModelName = "CX-5",
                    ModelYear = new DateOnly(2012, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Infiniti (BrandId: 71bd8b35-0d22-4783-8638-78eb48bd5629)
                new CarModel
                {
                    Id = new Guid("1e04fadf-3f54-4856-9952-f5141ad5d346"),
                    BrandId = new Guid("71bd8b35-0d22-4783-8638-78eb48bd5629"),
                    CarCategoryId = new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), // Sedan
                    ModelName = "Q50",
                    ModelYear = new DateOnly(2013, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("ef025de9-516e-4a89-9a5e-381efbbf363b"),
                    BrandId = new Guid("71bd8b35-0d22-4783-8638-78eb48bd5629"),
                    CarCategoryId = new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"), // SUV
                    ModelName = "QX60",
                    ModelYear = new DateOnly(2004, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Buick (BrandId: 91f09ff2-24ed-4d60-b3c5-5e76204a90ff)
                new CarModel
                {
                    Id = new Guid("e41ed308-cfbf-4597-8c74-d2bff7956e22"),
                    BrandId = new Guid("91f09ff2-24ed-4d60-b3c5-5e76204a90ff"),
                    CarCategoryId = new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), // Sedan
                    ModelName = "Regal",
                    ModelYear = new DateOnly(1973, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("c2706a10-3499-45de-a011-cc8d332c7230"),
                    BrandId = new Guid("91f09ff2-24ed-4d60-b3c5-5e76204a90ff"),
                    CarCategoryId = new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"), // SUV
                    ModelName = "Enclave",
                    ModelYear = new DateOnly(2008, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Acura (BrandId: 867a1f57-a7dc-4d8a-95f0-9b1e1b086809)
                new CarModel
                {
                    Id = new Guid("6b4b10f7-50aa-41e1-99b5-0cea46b4417c"),
                    BrandId = new Guid("867a1f57-a7dc-4d8a-95f0-9b1e1b086809"),
                    CarCategoryId = new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), // Sedan
                    ModelName = "TLX",
                    ModelYear = new DateOnly(2014, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("1ef45e5a-6014-46ba-8edd-2ebc5bd4ec51"),
                    BrandId = new Guid("867a1f57-a7dc-4d8a-95f0-9b1e1b086809"),
                    CarCategoryId = new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"), // SUV
                    ModelName = "RDX",
                    ModelYear = new DateOnly(2006, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Fiat (BrandId: b3126c73-0e1e-40fd-8dec-f7c4d2789dd9)
                new CarModel
                {
                    Id = new Guid("f4784e36-400b-4a68-ae3c-28c0d24e0154"),
                    BrandId = new Guid("b3126c73-0e1e-40fd-8dec-f7c4d2789dd9"),
                    CarCategoryId = new Guid("fc000760-6615-4f3b-96cc-7607ba6609a8"), // Subcompact Car
                    ModelName = "500",
                    ModelYear = new DateOnly(1957, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("6dc0c636-498f-4391-8569-d9321efc1939"),
                    BrandId = new Guid("b3126c73-0e1e-40fd-8dec-f7c4d2789dd9"),
                    CarCategoryId = new Guid("d4018b86-eb87-4114-9b9e-5fae1034cbd8"), // Compact Car
                    ModelName = "Panda",
                    ModelYear = new DateOnly(1980, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Mini (BrandId: 306fd99b-7914-4c4d-a92b-f3d998f3b772)
                new CarModel
                {
                    Id = new Guid("789a06d0-ff12-4251-b03f-3709cb545736"),
                    BrandId = new Guid("306fd99b-7914-4c4d-a92b-f3d998f3b772"),
                    CarCategoryId = new Guid("d4018b86-eb87-4114-9b9e-5fae1034cbd8"), // Compact Car
                    ModelName = "Cooper",
                    ModelYear = new DateOnly(1959, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("69f92b34-0a15-4497-b843-6addc4e56e34"),
                    BrandId = new Guid("306fd99b-7914-4c4d-a92b-f3d998f3b772"),
                    CarCategoryId = new Guid("983fba7a-11b2-4cdc-8ef0-64ddf6dfbfc4"), // Hatchback
                    ModelName = "Clubman",
                    ModelYear = new DateOnly(2007, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Chrysler (BrandId: e9a0d0d3-3a43-406a-b465-b630c5d93f6f)
                new CarModel
                {
                    Id = new Guid("8046ad13-b68e-4c1a-b0c7-f74d15e9837a"),
                    BrandId = new Guid("e9a0d0d3-3a43-406a-b465-b630c5d93f6f"),
                    CarCategoryId = new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), // Sedan
                    ModelName = "300",
                    ModelYear = new DateOnly(2004, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("ad6c4793-befb-49d9-ba29-f179174916db"),
                    BrandId = new Guid("e9a0d0d3-3a43-406a-b465-b630c5d93f6f"),
                    CarCategoryId = new Guid("1d25e83b-925e-472a-89d9-38c499dbfdea"), // Minivan / MPV
                    ModelName = "Pacifica",
                    ModelYear = new DateOnly(2017, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Tesla (BrandId: 22d61e55-50e5-4dcd-bf40-209fc2fcae12)
                new CarModel
                {
                    Id = new Guid("1ab3d403-fdd9-4443-87be-5bc3987c7350"),
                    BrandId = new Guid("22d61e55-50e5-4dcd-bf40-209fc2fcae12"),
                    CarCategoryId = new Guid("b8e9b4d0-8b60-451a-9810-1132482a0d92"), // Electric Vehicle
                    ModelName = "Model S",
                    ModelYear = new DateOnly(2012, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("69e9f0e8-9823-42ce-8deb-01d0a69c607c"),
                    BrandId = new Guid("22d61e55-50e5-4dcd-bf40-209fc2fcae12"),
                    CarCategoryId = new Guid("b8e9b4d0-8b60-451a-9810-1132482a0d92"), // Electric Vehicle
                    ModelName = "Model 3",
                    ModelYear = new DateOnly(2017, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Renault (BrandId: 72d247fb-5249-4ce1-a400-fce2559e7db0)
                new CarModel
                {
                    Id = new Guid("5fee507a-e299-4dea-b9b3-c2621a5d12cd"),
                    BrandId = new Guid("72d247fb-5249-4ce1-a400-fce2559e7db0"),
                    CarCategoryId = new Guid("983fba7a-11b2-4cdc-8ef0-64ddf6dfbfc4"), // Hatchback
                    ModelName = "Clio",
                    ModelYear = new DateOnly(1990, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("6397f180-d2b0-4244-8ef9-3c30fab15579"),
                    BrandId = new Guid("72d247fb-5249-4ce1-a400-fce2559e7db0"),
                    CarCategoryId = new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), // Sedan
                    ModelName = "Megane",
                    ModelYear = new DateOnly(1995, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Peugeot (BrandId: e5e319f9-ef2a-4ab7-a847-5f0d3c7a1caf)
                new CarModel
                {
                    Id = new Guid("3e65852a-2f29-4617-b145-650d02b92703"),
                    BrandId = new Guid("e5e319f9-ef2a-4ab7-a847-5f0d3c7a1caf"),
                    CarCategoryId = new Guid("983fba7a-11b2-4cdc-8ef0-64ddf6dfbfc4"), // Hatchback
                    ModelName = "308",
                    ModelYear = new DateOnly(2007, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("c6bca118-85de-4d7a-94a5-4609d0738542"),
                    BrandId = new Guid("e5e319f9-ef2a-4ab7-a847-5f0d3c7a1caf"),
                    CarCategoryId = new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), // Sedan
                    ModelName = "508",
                    ModelYear = new DateOnly(2010, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Suzuki (BrandId: 537c1813-334d-41c0-987b-0ed1509475f7)
                new CarModel
                {
                    Id = new Guid("3f0b103c-d953-40d8-bf11-8b74e0f0760c"),
                    BrandId = new Guid("537c1813-334d-41c0-987b-0ed1509475f7"),
                    CarCategoryId = new Guid("fc000760-6615-4f3b-96cc-7607ba6609a8"), // Subcompact Car
                    ModelName = "Swift",
                    ModelYear = new DateOnly(1983, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("1d5d22e0-80fb-4840-b1de-81587c86b3c1"),
                    BrandId = new Guid("537c1813-334d-41c0-987b-0ed1509475f7"),
                    CarCategoryId = new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"), // SUV
                    ModelName = "Vitara",
                    ModelYear = new DateOnly(1988, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Skoda (BrandId: 2254581b-c244-4c41-b5e4-c353629c2105)
                new CarModel
                {
                    Id = new Guid("b695c394-dc9a-4e8d-88fc-c6b39ec3d244"),
                    BrandId = new Guid("2254581b-c244-4c41-b5e4-c353629c2105"),
                    CarCategoryId = new Guid("d4018b86-eb87-4114-9b9e-5fae1034cbd8"), // Compact Car
                    ModelName = "Octavia",
                    ModelYear = new DateOnly(1996, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("e0ca3b3e-b6d8-42b0-8931-86e685804b5c"),
                    BrandId = new Guid("2254581b-c244-4c41-b5e4-c353629c2105"),
                    CarCategoryId = new Guid("f5bf5757-92b6-4cc2-b86b-1995f28d3fb6"), // Full-Size Car
                    ModelName = "Superb",
                    ModelYear = new DateOnly(2001, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Opel (BrandId: 97b8ca2f-9784-4262-a57e-5695f3f0f642)
                new CarModel
                {
                    Id = new Guid("38801743-71f9-4265-a680-f77c0a601876"),
                    BrandId = new Guid("97b8ca2f-9784-4262-a57e-5695f3f0f642"),
                    CarCategoryId = new Guid("d4018b86-eb87-4114-9b9e-5fae1034cbd8"), // Compact Car
                    ModelName = "Astra",
                    ModelYear = new DateOnly(1991, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("b78f0ea5-2866-4ec2-bb8b-ac9824babb5e"),
                    BrandId = new Guid("97b8ca2f-9784-4262-a57e-5695f3f0f642"),
                    CarCategoryId = new Guid("fc000760-6615-4f3b-96cc-7607ba6609a8"), // Subcompact Car
                    ModelName = "Corsa",
                    ModelYear = new DateOnly(1982, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Alfa Romeo (BrandId: 7d0e4fb5-6e8e-48fc-ba2b-daa570f5f96f)
                new CarModel
                {
                    Id = new Guid("7c471545-35a0-484c-bf97-f62b6a362e32"),
                    BrandId = new Guid("7d0e4fb5-6e8e-48fc-ba2b-daa570f5f96f"),
                    CarCategoryId = new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), // Sedan
                    ModelName = "Giulia",
                    ModelYear = new DateOnly(2016, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("cf57a9f5-459e-48ed-8886-f073da7db496"),
                    BrandId = new Guid("7d0e4fb5-6e8e-48fc-ba2b-daa570f5f96f"),
                    CarCategoryId = new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"), // SUV
                    ModelName = "Stelvio",
                    ModelYear = new DateOnly(2017, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Saab (BrandId: fa7fab24-c298-43cf-b990-341b29a02996)
                new CarModel
                {
                    Id = new Guid("75a19a55-2eea-4d73-abe8-a0edbb76aecb"),
                    BrandId = new Guid("fa7fab24-c298-43cf-b990-341b29a02996"),
                    CarCategoryId = new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), // Sedan
                    ModelName = "9-3",
                    ModelYear = new DateOnly(1998, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("1e8e784c-b9d2-427d-b4ad-c16f4a088ad7"),
                    BrandId = new Guid("fa7fab24-c298-43cf-b990-341b29a02996"),
                    CarCategoryId = new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), // Sedan
                    ModelName = "9-5",
                    ModelYear = new DateOnly(2001, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Genesis (BrandId: 6a927f4f-cc77-4d6d-963f-96a14a6a4fa9)
                new CarModel
                {
                    Id = new Guid("bf758d69-4028-4560-a5de-758fae3dad94"),
                    BrandId = new Guid("6a927f4f-cc77-4d6d-963f-96a14a6a4fa9"),
                    CarCategoryId = new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), // Sedan
                    ModelName = "G70",
                    ModelYear = new DateOnly(2017, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("cd733067-7346-4a1e-abcc-09621c28c99d"),
                    BrandId = new Guid("6a927f4f-cc77-4d6d-963f-96a14a6a4fa9"),
                    CarCategoryId = new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"), // SUV
                    ModelName = "GV80",
                    ModelYear = new DateOnly(2020, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Lincoln (BrandId: 6ebc86c7-82e2-4ce4-b613-ebaac626bd18)
                new CarModel
                {
                    Id = new Guid("c490a1a7-fc47-44b9-8839-e2cd0f854dae"),
                    BrandId = new Guid("6ebc86c7-82e2-4ce4-b613-ebaac626bd18"),
                    CarCategoryId = new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), // Sedan
                    ModelName = "MKZ",
                    ModelYear = new DateOnly(2005, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("247edaa4-9c42-47bb-9809-5e2e7af462bd"),
                    BrandId = new Guid("6ebc86c7-82e2-4ce4-b613-ebaac626bd18"),
                    CarCategoryId = new Guid("f5bf5757-92b6-4cc2-b86b-1995f28d3fb6"), // Full-Size Car
                    ModelName = "Navigator",
                    ModelYear = new DateOnly(1998, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Isuzu (BrandId: 0be257e7-856d-48d6-ab5a-f984a75b67d5)
                new CarModel
                {
                    Id = new Guid("8e6a6ca8-fbe1-4d15-92f6-70970006fffb"),
                    BrandId = new Guid("0be257e7-856d-48d6-ab5a-f984a75b67d5"),
                    CarCategoryId = new Guid("d904d7f0-674a-48dd-ae45-794d8e257583"), // Pickup Truck
                    ModelName = "D-Max",
                    ModelYear = new DateOnly(2002, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("992017e3-0db0-41b4-b07a-ee6f291b3560"),
                    BrandId = new Guid("0be257e7-856d-48d6-ab5a-f984a75b67d5"),
                    CarCategoryId = new Guid("37a876a6-e608-4bff-9d5b-9bef9e671094"), // SUV
                    ModelName = "MU-X",
                    ModelYear = new DateOnly(2005, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Bentley (BrandId: ff884ca0-1e63-4bc1-84a1-4048a6eb627e)
                new CarModel
                {
                    Id = new Guid("9e285f15-c966-4154-ad18-1534ab5030ea"),
                    BrandId = new Guid("ff884ca0-1e63-4bc1-84a1-4048a6eb627e"),
                    CarCategoryId = new Guid("7ebb6c15-8e16-439c-bd07-b998c4b26ab3"), // Luxury Car
                    ModelName = "Continental GT",
                    ModelYear = new DateOnly(2003, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("30b0d0a8-0d50-4025-8583-6a41747c1138"),
                    BrandId = new Guid("ff884ca0-1e63-4bc1-84a1-4048a6eb627e"),
                    CarCategoryId = new Guid("7ebb6c15-8e16-439c-bd07-b998c4b26ab3"), // Luxury Car
                    ModelName = "Flying Spur",
                    ModelYear = new DateOnly(2005, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Aston Martin (BrandId: 8d86d786-c02d-43a6-9b3f-3ef15761ba71)
                new CarModel
                {
                    Id = new Guid("feba8e7f-d732-4eb0-8a12-7831c9b714dd"),
                    BrandId = new Guid("8d86d786-c02d-43a6-9b3f-3ef15761ba71"),
                    CarCategoryId = new Guid("7ebb6c15-8e16-439c-bd07-b998c4b26ab3"), // Luxury Car
                    ModelName = "DB11",
                    ModelYear = new DateOnly(2016, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("458f42e3-b7ce-4fb4-b63d-7dac89efe0a8"),
                    BrandId = new Guid("8d86d786-c02d-43a6-9b3f-3ef15761ba71"),
                    CarCategoryId = new Guid("6f9e4206-d0a0-4366-a997-094827005006"), // Sports Car
                    ModelName = "Vantage",
                    ModelYear = new DateOnly(2005, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Maserati (BrandId: 3c18fcda-19de-42ee-88fa-7f9a5c60268f)
                new CarModel
                {
                    Id = new Guid("3de05ece-3ef8-48a2-b27d-412a9de7b52c"),
                    BrandId = new Guid("3c18fcda-19de-42ee-88fa-7f9a5c60268f"),
                    CarCategoryId = new Guid("7ebb6c15-8e16-439c-bd07-b998c4b26ab3"), // Luxury Car
                    ModelName = "Ghibli",
                    ModelYear = new DateOnly(2013, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("4dce94b1-6053-479f-b4e2-0dbdf578305f"),
                    BrandId = new Guid("3c18fcda-19de-42ee-88fa-7f9a5c60268f"),
                    CarCategoryId = new Guid("7ebb6c15-8e16-439c-bd07-b998c4b26ab3"), // Luxury Car
                    ModelName = "Quattroporte",
                    ModelYear = new DateOnly(1963, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Jaguar (BrandId: da9ca2f3-3a68-4311-b189-cc99c3fcebaa)
                new CarModel
                {
                    Id = new Guid("b6246e92-dad1-40e7-b3b6-7962d7986d77"),
                    BrandId = new Guid("da9ca2f3-3a68-4311-b189-cc99c3fcebaa"),
                    CarCategoryId = new Guid("6f9e4206-d0a0-4366-a997-094827005006"), // Sports Car
                    ModelName = "F-Type",
                    ModelYear = new DateOnly(2013, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("1d509463-fa11-4729-b3e8-3b928547784e"),
                    BrandId = new Guid("da9ca2f3-3a68-4311-b189-cc99c3fcebaa"),
                    CarCategoryId = new Guid("3a6129c6-36ce-4e85-b0a0-8ffbee30ddf1"), // Sedan
                    ModelName = "XE",
                    ModelYear = new DateOnly(2004, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Ferrari (BrandId: d263567a-41b2-407d-b40d-6bad18eb32ca)
                new CarModel
                {
                    Id = new Guid("96924990-3a5f-439c-9890-f8c8c0851ec0"),
                    BrandId = new Guid("d263567a-41b2-407d-b40d-6bad18eb32ca"),
                    CarCategoryId = new Guid("6f9e4206-d0a0-4366-a997-094827005006"), // Sports Car
                    ModelName = "488 GTB",
                    ModelYear = new DateOnly(2009, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("1f9f9bce-f9f2-4ac6-a614-004ae7fd9d6a"),
                    BrandId = new Guid("d263567a-41b2-407d-b40d-6bad18eb32ca"),
                    CarCategoryId = new Guid("506b4f2f-68f7-4b69-ab81-1242de996a18"), // Convertible
                    ModelName = "Portofino",
                    ModelYear = new DateOnly(2017, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Lamborghini (BrandId: 61c63482-0890-497e-9013-6c1509e819eb)
                new CarModel
                {
                    Id = new Guid("ec4d118f-a22a-49da-bf50-93b504b2e623"),
                    BrandId = new Guid("61c63482-0890-497e-9013-6c1509e819eb"),
                    CarCategoryId = new Guid("6f9e4206-d0a0-4366-a997-094827005006"), // Sports Car
                    ModelName = "Aventador",
                    ModelYear = new DateOnly(2011, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("a5f3f9f6-8d0a-4cb9-81cd-006b8d0ff567"),
                    BrandId = new Guid("61c63482-0890-497e-9013-6c1509e819eb"),
                    CarCategoryId = new Guid("6f9e4206-d0a0-4366-a997-094827005006"), // Sports Car
                    ModelName = "Huracan",
                    ModelYear = new DateOnly(2014, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Bugatti (BrandId: 04d6430b-5665-4a0b-b33f-f782d5da2a58)
                new CarModel
                {
                    Id = new Guid("3b22fb62-233c-481d-a6db-3ccc71e92414"),
                    BrandId = new Guid("04d6430b-5665-4a0b-b33f-f782d5da2a58"),
                    CarCategoryId = new Guid("6f9e4206-d0a0-4366-a997-094827005006"), // Sports Car
                    ModelName = "Veyron",
                    ModelYear = new DateOnly(2005, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("04d301dc-d20d-4985-b124-0edfe96aeede"),
                    BrandId = new Guid("04d6430b-5665-4a0b-b33f-f782d5da2a58"),
                    CarCategoryId = new Guid("6f9e4206-d0a0-4366-a997-094827005006"), // Sports Car
                    ModelName = "Chiron",
                    ModelYear = new DateOnly(2016, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // McLaren (BrandId: b9333f92-0e83-4343-973a-760182aea47e)
                new CarModel
                {
                    Id = new Guid("2f0d3e9a-4e57-4146-a25a-b8e1ac1f109d"),
                    BrandId = new Guid("b9333f92-0e83-4343-973a-760182aea47e"),
                    CarCategoryId = new Guid("6f9e4206-d0a0-4366-a997-094827005006"), // Sports Car
                    ModelName = "720S",
                    ModelYear = new DateOnly(2017, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("3977dc0e-af17-454c-a798-60c4a1e44893"),
                    BrandId = new Guid("b9333f92-0e83-4343-973a-760182aea47e"),
                    CarCategoryId = new Guid("6f9e4206-d0a0-4366-a997-094827005006"), // Sports Car
                    ModelName = "570S",
                    ModelYear = new DateOnly(2015, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Rolls-Royce (BrandId: adae589c-555f-48ac-9925-71fa96fa3d88)
                new CarModel
                {
                    Id = new Guid("8095ada4-712b-4805-b806-7d00d95d6858"),
                    BrandId = new Guid("adae589c-555f-48ac-9925-71fa96fa3d88"),
                    CarCategoryId = new Guid("7ebb6c15-8e16-439c-bd07-b998c4b26ab3"), // Luxury Car
                    ModelName = "Phantom",
                    ModelYear = new DateOnly(1925, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("56ee2663-5e97-48a6-934d-618ac3ff1cea"),
                    BrandId = new Guid("adae589c-555f-48ac-9925-71fa96fa3d88"),
                    CarCategoryId = new Guid("7ebb6c15-8e16-439c-bd07-b998c4b26ab3"), // Luxury Car
                    ModelName = "Ghost",
                    ModelYear = new DateOnly(2003, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Pagani (BrandId: 7a021389-57ea-453d-b194-3c692735671d)
                new CarModel
                {
                    Id = new Guid("9869d0b2-8f87-44b6-9f48-02fe4db7d229"),
                    BrandId = new Guid("7a021389-57ea-453d-b194-3c692735671d"),
                    CarCategoryId = new Guid("6f9e4206-d0a0-4366-a997-094827005006"), // Sports Car
                    ModelName = "Huayra",
                    ModelYear = new DateOnly(2011, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("9f56523e-903c-4dc4-a1a8-df7730bc1cce"), // Reusing an unused GUID from list (if needed, adjust accordingly)
                    BrandId = new Guid("7a021389-57ea-453d-b194-3c692735671d"),
                    CarCategoryId = new Guid("6f9e4206-d0a0-4366-a997-094827005006"), // Sports Car
                    ModelName = "Zonda",
                    ModelYear = new DateOnly(1999, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                // Koenigsegg (BrandId: 51ae4906-854f-4a0a-8629-a0ba2656b9b9)
                new CarModel
                {
                    Id = new Guid("328e80cf-251d-460d-928b-345e08cf642b"),
                    BrandId = new Guid("51ae4906-854f-4a0a-8629-a0ba2656b9b9"),
                    CarCategoryId = new Guid("6f9e4206-d0a0-4366-a997-094827005006"), // Sports Car
                    ModelName = "Agera",
                    ModelYear = new DateOnly(1999, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                },
                new CarModel
                {
                    Id = new Guid("3977dc0e-af17-454c-a798-60c4a1c44893"),
                    BrandId = new Guid("51ae4906-854f-4a0a-8629-a0ba2656b9b9"),
                    CarCategoryId = new Guid("6f9e4206-d0a0-4366-a997-094827005006"), // Sports Car
                    ModelName = "Regera",
                    ModelYear = new DateOnly(2016, 1, 1),
                    Status = CarModelStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                }
                );
        }
    }
}




