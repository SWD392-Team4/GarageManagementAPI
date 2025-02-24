using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class BrandConfiguration : ConfigurationBase<Brand>
    {
        protected override void ModelCreating(EntityTypeBuilder<Brand> entity)
        {
            entity.HasKey(e => e.Id).HasName("brand_id_primary");

            entity.ToTable("Brand");

            entity.HasIndex(e => e.BrandName, "brand_brandname_unique").IsUnique();

            // Đảm bảo cột Id có giá trị GUID được sinh ra tự động từ cơ sở dữ liệu
            entity.Property(e => e.Id)
                .HasDefaultValueSql("NEWID()")  // Cấu hình cơ sở dữ liệu sinh GUID
                .ValueGeneratedOnAdd();         // Đảm bảo GUID sẽ được tạo khi thêm mới
            entity.Property(e => e.BrandName).HasMaxLength(255);
            entity.Property(e => e.LogoLink).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(255);

            // Chuyển đổi giá trị Status từ Enum sang chuỗi khi lưu vào cơ sở dữ liệu
            entity.Property(e => e.Status)
                .HasConversion<string>();
        }

        protected override void SeedData(EntityTypeBuilder<Brand> entity)
        {
            entity.HasData(
                 new Brand()
                 {
                     Id = new Guid("47cc8b19-70ce-46f3-aef9-eb933eea2182"),
                     BrandName = "Toyota",
                     CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                     UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                     LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421861/Brand/jh1rqnn0oavjilladcuy.png",
                     LogoId = "Brand/jh1rqnn0oavjilladcuy",
                     Status = BrandStatus.Active
                 },
                new Brand()
                {
                    Id = new Guid("30e45fc3-a2d1-4006-be2b-9de2b1c5130c"),
                    BrandName = "Ford",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421924/Brand/qb6avmc6okdc39zg0uzz.png",
                    LogoId = "Brand/qb6avmc6okdc39zg0uzz",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("23e128b8-73fe-4e74-bfdf-97d82911af47"),
                    BrandName = "Volkswagen",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421976/Brand/gahdhvt1wvon18doxhvy.png",
                    LogoId = "Brand/gahdhvt1wvon18doxhvy",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("14cc790e-323d-4020-b1ac-5ff5bb96336d"),
                    BrandName = "Honda",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422018/Brand/kx3xsj26x6czy664rjrx.png",
                    LogoId = "Brand/kx3xsj26x6czy664rjrx",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("793ed2e4-eba2-407e-a814-ab8d5ddcdfc7"),
                    BrandName = "Chevrolet",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422071/Brand/lovrlrwiei2xukzv6zq3.png",
                    LogoId = "Brand/lovrlrwiei2xukzv6zq3",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("4224e14b-fce0-47cb-904f-0c7c286d45f8"),
                    BrandName = "Nissan",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422160/Brand/qhnes6tgs3i6nsbft8dk.png",
                    LogoId = "Brand/qhnes6tgs3i6nsbft8dk",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("5b4d0698-cf56-41ff-927f-3226f1146f0f"),
                    BrandName = "BMW",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422278/Brand/akxxqktdh9mhylbhywxj.png",
                    LogoId = "Brand/akxxqktdh9mhylbhywxj",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("f7f6b4fc-0e88-4cb6-af7e-c0834bfb2b2c"),
                    BrandName = "Mercedes-Benz",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422229/Brand/nkhahhkmagpxarghm1us.png",
                    LogoId = "Brand/nkhahhkmagpxarghm1us",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("4d8aaaa6-448a-431c-a50f-a313dba5b3e5"),
                    BrandName = "Audi",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422333/Brand/biocmnahytbpqzvdtj3k.png",
                    LogoId = "Brand/biocmnahytbpqzvdtj3k",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("1f13210f-6d0b-4cb9-86b9-fc0fa5898afd"),
                    BrandName = "Hyundai",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422392/Brand/n4vgf2iu2xlddjq0fies.png",
                    LogoId = "Brand/n4vgf2iu2xlddjq0fies",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("0131e761-bdeb-4fd0-8aba-b3cc0769d0c4"),
                    BrandName = "Kia",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422439/Brand/wfmlm6uwd5hnguwpbioj.png",
                    LogoId = "Brand/wfmlm6uwd5hnguwpbioj",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("84062c49-1fe2-4b97-86c4-49e4d0f5449b"),
                    BrandName = "Subaru",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421768/Brand/dpq3tgrogw3ilo6jwqoz.png",
                    LogoId = "Brand/dpq3tgrogw3ilo6jwqoz",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("2c74b21a-5ec4-4dce-b376-b6b0601d7a84"),
                    BrandName = "Lexus",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422492/Brand/qmp6fgd6qktgt52viovi.png",
                    LogoId = "Brand/qmp6fgd6qktgt52viovi",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"),
                    BrandName = "Dodge",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422553/Brand/sy90i7nnlc45r3l9xxff.png",
                    LogoId = "Brand/sy90i7nnlc45r3l9xxff",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("855f8a55-c9d0-4532-81ee-6da2bd0db1f6"),
                    BrandName = "Jeep",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423926/Brand/xqggwm0nnswweukoaoxd.png",
                    LogoId = "Brand/xqggwm0nnswweukoaoxd",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("abadc9e1-c8e6-4f40-b078-47f609d1cf79"),
                    BrandName = "Cadillac",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423856/Brand/m5yackgrajh62hnouttj.png",
                    LogoId = "Brand/m5yackgrajh62hnouttj",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("4b3039f3-b460-46be-aa39-e43d4c29af19"),
                    BrandName = "GMC",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423772/Brand/kchfjjavlom9a4qnywvg.png",
                    LogoId = "Brand/kchfjjavlom9a4qnywvg",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"),
                    BrandName = "Mitsubishi",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423615/Brand/lyu7mi3lyfunwizhju9r.png",
                    LogoId = "Brand/lyu7mi3lyfunwizhju9r",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("cee5a4d8-de84-4482-9da9-302e2290cb0f"),
                    BrandName = "Porsche",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423565/Brand/sbmjof2ugzzsuwoyj7r5.png",
                    LogoId = "Brand/sbmjof2ugzzsuwoyj7r5",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("e9a7beda-ff63-4ac5-92cb-b7fa152c41c2"),
                    BrandName = "Volvo",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423480/Brand/n3dc1tql2hvqydjaekzl.png",
                    LogoId = "Brand/n3dc1tql2hvqydjaekzl",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"),
                    BrandName = "Land Rover",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423422/Brand/ulvsdpqvmfvib7i6wxos.png",
                    LogoId = "Brand/ulvsdpqvmfvib7i6wxos",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("e99dfd5c-ffe7-454d-9ae2-c4622eaa8200"),
                    BrandName = "Mazda",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423366/Brand/kkxeemoptvcenvt86l3w.png",
                    LogoId = "Brand/kkxeemoptvcenvt86l3w",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("71bd8b35-0d22-4783-8638-78eb48bd5629"),
                    BrandName = "Infiniti",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423282/Brand/vkk2c8pgwgsdov9omkyd.png",
                    LogoId = "Brand/vkk2c8pgwgsdov9omkyd",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("91f09ff2-24ed-4d60-b3c5-5e76204a90ff"),
                    BrandName = "Buick",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423195/Brand/pbdy8azpl3zaj57jqsjh.png",
                    LogoId = "Brand/pbdy8azpl3zaj57jqsjh",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("867a1f57-a7dc-4d8a-95f0-9b1e1b086809"),
                    BrandName = "Acura",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423136/Brand/mkyjol2tpt7jhjmaofaz.png",
                    LogoId = "Brand/mkyjol2tpt7jhjmaofaz",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("b3126c73-0e1e-40fd-8dec-f7c4d2789dd9"),
                    BrandName = "Fiat",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423064/Brand/ifubhf1jsnt9k6xkwhv7.png",
                    LogoId = "Brand/ifubhf1jsnt9k6xkwhv7",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("306fd99b-7914-4c4d-a92b-f3d998f3b772"),
                    BrandName = "Mini",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422988/Brand/w6ca9jl8nxdrtsluak70.png",
                    LogoId = "Brand/w6ca9jl8nxdrtsluak70",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("e9a0d0d3-3a43-406a-b465-b630c5d93f6f"),
                    BrandName = "Chrysler",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422880/Brand/umb5c1sp4044krzzpo88.png",
                    LogoId = "Brand/umb5c1sp4044krzzpo88",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("22d61e55-50e5-4dcd-bf40-209fc2fcae12"),
                    BrandName = "Tesla",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423698/Brand/tmplel6lrqlfazu1bhy0.png",
                    LogoId = "Brand/tmplel6lrqlfazu1bhy0",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("72d247fb-5249-4ce1-a400-fce2559e7db0"),
                    BrandName = "Renault",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422660/Brand/dtvvsfc8hclugj3rt6fi.png",
                    LogoId = "Brand/dtvvsfc8hclugj3rt6fi",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("e5e319f9-ef2a-4ab7-a847-5f0d3c7a1caf"),
                    BrandName = "Peugeot",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422609/Brand/diqhpfvayh4esj3vion2.png",
                    LogoId = "Brand/diqhpfvayh4esj3vion2",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("537c1813-334d-41c0-987b-0ed1509475f7"),
                    BrandName = "Suzuki",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421766/Brand/elsbmo9uhii4prclhfx2.png",
                    LogoId = "Brand/elsbmo9uhii4prclhfx2",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("2254581b-c244-4c41-b5e4-c353629c2105"),
                    BrandName = "Skoda",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421656/Brand/zndqli8qgxhwjmr7fyo5.png",
                    LogoId = "Brand/zndqli8qgxhwjmr7fyo5",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("97b8ca2f-9784-4262-a57e-5695f3f0f642"),
                    BrandName = "Opel",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421597/Brand/zkby3nlbmv7path5ujwj.png",
                    LogoId = "Brand/zkby3nlbmv7path5ujwj",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("7d0e4fb5-6e8e-48fc-ba2b-daa570f5f96f"),
                    BrandName = "Alfa Romeo",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421522/Brand/ot1xglmql3kdxpdbwcte.png",
                    LogoId = "Brand/ot1xglmql3kdxpdbwcte",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("fa7fab24-c298-43cf-b990-341b29a02996"),
                    BrandName = "Saab",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421444/Brand/lexnrqalxuzivogd6mov.png",
                    LogoId = "Brand/lexnrqalxuzivogd6mov",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("6a927f4f-cc77-4d6d-963f-96a14a6a4fa9"),
                    BrandName = "Genesis",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421364/Brand/bn8lek9t1qielpj33asx.png",
                    LogoId = "Brand/bn8lek9t1qielpj33asx",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("6ebc86c7-82e2-4ce4-b613-ebaac626bd18"),
                    BrandName = "Lincoln",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421296/Brand/dvxwxwkt98k2vm237hb3.png",
                    LogoId = "Brand/dvxwxwkt98k2vm237hb3",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("0be257e7-856d-48d6-ab5a-f984a75b67d5"),
                    BrandName = "Isuzu",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421187/Brand/zrlnucqkikvx4necltgs.png",
                    LogoId = "Brand/zrlnucqkikvx4necltgs",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("ff884ca0-1e63-4bc1-84a1-4048a6eb627e"),
                    BrandName = "Bentley",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421127/Brand/uu8ru4pxd9lywnclld9y.png",
                    LogoId = "Brand/uu8ru4pxd9lywnclld9y",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("8d86d786-c02d-43a6-9b3f-3ef15761ba71"),
                    BrandName = "Aston Martin",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421051/Brand/hnposen4390ckqokcgcq.png",
                    LogoId = "Brand/hnposen4390ckqokcgcq",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("3c18fcda-19de-42ee-88fa-7f9a5c60268f"),
                    BrandName = "Maserati",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740420549/Brand/dcfpdtrz6pqk5b7rkdfn.png",
                    LogoId = "Brand/dcfpdtrz6pqk5b7rkdfn",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("da9ca2f3-3a68-4311-b189-cc99c3fcebaa"),
                    BrandName = "Jaguar",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740420465/Brand/jbn02u6cdkbhr9suovy1.png",
                    LogoId = "Brand/jbn02u6cdkbhr9suovy1",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("d263567a-41b2-407d-b40d-6bad18eb32ca"),
                    BrandName = "Ferrari",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740420390/Brand/k8qf8xzk746w5ff9j6wx.png",
                    LogoId = "Brand/k8qf8xzk746w5ff9j6wx",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("61c63482-0890-497e-9013-6c1509e819eb"),
                    BrandName = "Lamborghini",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740420327/Brand/yjzqo0gcbjye6j78cfff.png",
                    LogoId = "Brand/yjzqo0gcbjye6j78cfff",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("04d6430b-5665-4a0b-b33f-f782d5da2a58"),
                    BrandName = "Bugatti",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740420222/Brand/x1iiioelr1eduzvlz6gz.png",
                    LogoId = "Brand/x1iiioelr1eduzvlz6gz",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("b9333f92-0e83-4343-973a-760182aea47e"),
                    BrandName = "McLaren",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740420144/Brand/cpxc269y35mhr8pdijlr.png",
                    LogoId = "Brand/cpxc269y35mhr8pdijlr",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("adae589c-555f-48ac-9925-71fa96fa3d88"),
                    BrandName = "Rolls-Royce",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740420078/Brand/jmluhi20qavru6lcvpvc.png",
                    LogoId = "Brand/jmluhi20qavru6lcvpvc",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("7a021389-57ea-453d-b194-3c692735671d"),
                    BrandName = "Pagani",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740419988/Brand/hmvywzznk4hecggkxi3p.png",
                    LogoId = "Brand/hmvywzznk4hecggkxi3p",
                    Status = BrandStatus.Active
                },
                new Brand()
                {
                    Id = new Guid("51ae4906-854f-4a0a-8629-a0ba2656b9b9"),
                    BrandName = "Koenigsegg",
                    CreatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2/25/2025 12:36:40 AM +07:00"),
                    LogoLink = "https://res.cloudinary.com/dt2b5qfoe/image/upload/f_auto,q_auto/v1/Brand/jvcdennahy5k7y8tgcin",
                    LogoId = "Brand/jvcdennahy5k7y8tgcin",
                    Status = BrandStatus.Active
                }
            );
        }
    }
}




