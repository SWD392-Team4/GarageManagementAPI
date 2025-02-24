using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataBrand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LinkLogo",
                table: "Brand",
                newName: "LogoLink");

            migrationBuilder.AddColumn<string>(
                name: "LogoId",
                table: "Brand",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "BrandName", "CreatedAt", "LogoId", "LogoLink", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0131e761-bdeb-4fd0-8aba-b3cc0769d0c4"), "Kia", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/wfmlm6uwd5hnguwpbioj", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422439/Brand/wfmlm6uwd5hnguwpbioj.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("04d6430b-5665-4a0b-b33f-f782d5da2a58"), "Bugatti", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/x1iiioelr1eduzvlz6gz", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740420222/Brand/x1iiioelr1eduzvlz6gz.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("0be257e7-856d-48d6-ab5a-f984a75b67d5"), "Isuzu", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/zrlnucqkikvx4necltgs", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421187/Brand/zrlnucqkikvx4necltgs.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("14cc790e-323d-4020-b1ac-5ff5bb96336d"), "Honda", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/kx3xsj26x6czy664rjrx", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422018/Brand/kx3xsj26x6czy664rjrx.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"), "Mitsubishi", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/lyu7mi3lyfunwizhju9r", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423615/Brand/lyu7mi3lyfunwizhju9r.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("1f13210f-6d0b-4cb9-86b9-fc0fa5898afd"), "Hyundai", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/n4vgf2iu2xlddjq0fies", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422392/Brand/n4vgf2iu2xlddjq0fies.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("2254581b-c244-4c41-b5e4-c353629c2105"), "Skoda", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/zndqli8qgxhwjmr7fyo5", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421656/Brand/zndqli8qgxhwjmr7fyo5.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("22d61e55-50e5-4dcd-bf40-209fc2fcae12"), "Tesla", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/tmplel6lrqlfazu1bhy0", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423698/Brand/tmplel6lrqlfazu1bhy0.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("23e128b8-73fe-4e74-bfdf-97d82911af47"), "Volkswagen", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/gahdhvt1wvon18doxhvy", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421976/Brand/gahdhvt1wvon18doxhvy.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("2c74b21a-5ec4-4dce-b376-b6b0601d7a84"), "Lexus", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/qmp6fgd6qktgt52viovi", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422492/Brand/qmp6fgd6qktgt52viovi.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("306fd99b-7914-4c4d-a92b-f3d998f3b772"), "Mini", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/w6ca9jl8nxdrtsluak70", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422988/Brand/w6ca9jl8nxdrtsluak70.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("30e45fc3-a2d1-4006-be2b-9de2b1c5130c"), "Ford", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/qb6avmc6okdc39zg0uzz", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421924/Brand/qb6avmc6okdc39zg0uzz.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"), "Dodge", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/sy90i7nnlc45r3l9xxff", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422553/Brand/sy90i7nnlc45r3l9xxff.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("3c18fcda-19de-42ee-88fa-7f9a5c60268f"), "Maserati", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/dcfpdtrz6pqk5b7rkdfn", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740420549/Brand/dcfpdtrz6pqk5b7rkdfn.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("4224e14b-fce0-47cb-904f-0c7c286d45f8"), "Nissan", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/qhnes6tgs3i6nsbft8dk", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422160/Brand/qhnes6tgs3i6nsbft8dk.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("47cc8b19-70ce-46f3-aef9-eb933eea2182"), "Toyota", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/jh1rqnn0oavjilladcuy", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421861/Brand/jh1rqnn0oavjilladcuy.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("4b3039f3-b460-46be-aa39-e43d4c29af19"), "GMC", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/kchfjjavlom9a4qnywvg", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423772/Brand/kchfjjavlom9a4qnywvg.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("4d8aaaa6-448a-431c-a50f-a313dba5b3e5"), "Audi", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/biocmnahytbpqzvdtj3k", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422333/Brand/biocmnahytbpqzvdtj3k.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("51ae4906-854f-4a0a-8629-a0ba2656b9b9"), "Koenigsegg", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/jvcdennahy5k7y8tgcin", "https://res.cloudinary.com/dt2b5qfoe/image/upload/f_auto,q_auto/v1/Brand/jvcdennahy5k7y8tgcin", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("537c1813-334d-41c0-987b-0ed1509475f7"), "Suzuki", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/elsbmo9uhii4prclhfx2", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421766/Brand/elsbmo9uhii4prclhfx2.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("5b4d0698-cf56-41ff-927f-3226f1146f0f"), "BMW", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/akxxqktdh9mhylbhywxj", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422278/Brand/akxxqktdh9mhylbhywxj.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("61c63482-0890-497e-9013-6c1509e819eb"), "Lamborghini", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/yjzqo0gcbjye6j78cfff", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740420327/Brand/yjzqo0gcbjye6j78cfff.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("6a927f4f-cc77-4d6d-963f-96a14a6a4fa9"), "Genesis", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/bn8lek9t1qielpj33asx", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421364/Brand/bn8lek9t1qielpj33asx.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("6ebc86c7-82e2-4ce4-b613-ebaac626bd18"), "Lincoln", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/dvxwxwkt98k2vm237hb3", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421296/Brand/dvxwxwkt98k2vm237hb3.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("71bd8b35-0d22-4783-8638-78eb48bd5629"), "Infiniti", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/vkk2c8pgwgsdov9omkyd", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423282/Brand/vkk2c8pgwgsdov9omkyd.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("72d247fb-5249-4ce1-a400-fce2559e7db0"), "Renault", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/dtvvsfc8hclugj3rt6fi", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422660/Brand/dtvvsfc8hclugj3rt6fi.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("793ed2e4-eba2-407e-a814-ab8d5ddcdfc7"), "Chevrolet", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/lovrlrwiei2xukzv6zq3", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422071/Brand/lovrlrwiei2xukzv6zq3.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("7a021389-57ea-453d-b194-3c692735671d"), "Pagani", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/hmvywzznk4hecggkxi3p", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740419988/Brand/hmvywzznk4hecggkxi3p.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("7d0e4fb5-6e8e-48fc-ba2b-daa570f5f96f"), "Alfa Romeo", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/ot1xglmql3kdxpdbwcte", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421522/Brand/ot1xglmql3kdxpdbwcte.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("84062c49-1fe2-4b97-86c4-49e4d0f5449b"), "Subaru", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/dpq3tgrogw3ilo6jwqoz", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421768/Brand/dpq3tgrogw3ilo6jwqoz.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("855f8a55-c9d0-4532-81ee-6da2bd0db1f6"), "Jeep", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/xqggwm0nnswweukoaoxd", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423926/Brand/xqggwm0nnswweukoaoxd.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("867a1f57-a7dc-4d8a-95f0-9b1e1b086809"), "Acura", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/mkyjol2tpt7jhjmaofaz", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423136/Brand/mkyjol2tpt7jhjmaofaz.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("8d86d786-c02d-43a6-9b3f-3ef15761ba71"), "Aston Martin", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/hnposen4390ckqokcgcq", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421051/Brand/hnposen4390ckqokcgcq.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("91f09ff2-24ed-4d60-b3c5-5e76204a90ff"), "Buick", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/pbdy8azpl3zaj57jqsjh", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423195/Brand/pbdy8azpl3zaj57jqsjh.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("97b8ca2f-9784-4262-a57e-5695f3f0f642"), "Opel", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/zkby3nlbmv7path5ujwj", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421597/Brand/zkby3nlbmv7path5ujwj.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("abadc9e1-c8e6-4f40-b078-47f609d1cf79"), "Cadillac", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/m5yackgrajh62hnouttj", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423856/Brand/m5yackgrajh62hnouttj.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("adae589c-555f-48ac-9925-71fa96fa3d88"), "Rolls-Royce", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/jmluhi20qavru6lcvpvc", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740420078/Brand/jmluhi20qavru6lcvpvc.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("b3126c73-0e1e-40fd-8dec-f7c4d2789dd9"), "Fiat", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/ifubhf1jsnt9k6xkwhv7", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423064/Brand/ifubhf1jsnt9k6xkwhv7.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("b9333f92-0e83-4343-973a-760182aea47e"), "McLaren", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/cpxc269y35mhr8pdijlr", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740420144/Brand/cpxc269y35mhr8pdijlr.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("cee5a4d8-de84-4482-9da9-302e2290cb0f"), "Porsche", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/sbmjof2ugzzsuwoyj7r5", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423565/Brand/sbmjof2ugzzsuwoyj7r5.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("d263567a-41b2-407d-b40d-6bad18eb32ca"), "Ferrari", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/k8qf8xzk746w5ff9j6wx", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740420390/Brand/k8qf8xzk746w5ff9j6wx.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("da9ca2f3-3a68-4311-b189-cc99c3fcebaa"), "Jaguar", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/jbn02u6cdkbhr9suovy1", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740420465/Brand/jbn02u6cdkbhr9suovy1.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("e5e319f9-ef2a-4ab7-a847-5f0d3c7a1caf"), "Peugeot", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/diqhpfvayh4esj3vion2", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422609/Brand/diqhpfvayh4esj3vion2.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("e99dfd5c-ffe7-454d-9ae2-c4622eaa8200"), "Mazda", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/kkxeemoptvcenvt86l3w", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423366/Brand/kkxeemoptvcenvt86l3w.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("e9a0d0d3-3a43-406a-b465-b630c5d93f6f"), "Chrysler", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/umb5c1sp4044krzzpo88", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422880/Brand/umb5c1sp4044krzzpo88.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("e9a7beda-ff63-4ac5-92cb-b7fa152c41c2"), "Volvo", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/n3dc1tql2hvqydjaekzl", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423480/Brand/n3dc1tql2hvqydjaekzl.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"), "Land Rover", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/ulvsdpqvmfvib7i6wxos", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423422/Brand/ulvsdpqvmfvib7i6wxos.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("f7f6b4fc-0e88-4cb6-af7e-c0834bfb2b2c"), "Mercedes-Benz", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/nkhahhkmagpxarghm1us", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422229/Brand/nkhahhkmagpxarghm1us.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("fa7fab24-c298-43cf-b990-341b29a02996"), "Saab", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/lexnrqalxuzivogd6mov", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421444/Brand/lexnrqalxuzivogd6mov.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) },
                    { new Guid("ff884ca0-1e63-4bc1-84a1-4048a6eb627e"), "Bentley", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)), "Brand/uu8ru4pxd9lywnclld9y", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421127/Brand/uu8ru4pxd9lywnclld9y.png", "0", new DateTimeOffset(new DateTime(2025, 2, 25, 0, 36, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 7, 0, 0, 0)) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("0131e761-bdeb-4fd0-8aba-b3cc0769d0c4"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("04d6430b-5665-4a0b-b33f-f782d5da2a58"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("0be257e7-856d-48d6-ab5a-f984a75b67d5"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("14cc790e-323d-4020-b1ac-5ff5bb96336d"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("1f13210f-6d0b-4cb9-86b9-fc0fa5898afd"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("2254581b-c244-4c41-b5e4-c353629c2105"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("22d61e55-50e5-4dcd-bf40-209fc2fcae12"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("23e128b8-73fe-4e74-bfdf-97d82911af47"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("2c74b21a-5ec4-4dce-b376-b6b0601d7a84"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("306fd99b-7914-4c4d-a92b-f3d998f3b772"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("30e45fc3-a2d1-4006-be2b-9de2b1c5130c"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("3c18fcda-19de-42ee-88fa-7f9a5c60268f"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("4224e14b-fce0-47cb-904f-0c7c286d45f8"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("47cc8b19-70ce-46f3-aef9-eb933eea2182"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("4b3039f3-b460-46be-aa39-e43d4c29af19"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("4d8aaaa6-448a-431c-a50f-a313dba5b3e5"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("51ae4906-854f-4a0a-8629-a0ba2656b9b9"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("537c1813-334d-41c0-987b-0ed1509475f7"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("5b4d0698-cf56-41ff-927f-3226f1146f0f"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("61c63482-0890-497e-9013-6c1509e819eb"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("6a927f4f-cc77-4d6d-963f-96a14a6a4fa9"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("6ebc86c7-82e2-4ce4-b613-ebaac626bd18"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("71bd8b35-0d22-4783-8638-78eb48bd5629"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("72d247fb-5249-4ce1-a400-fce2559e7db0"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("793ed2e4-eba2-407e-a814-ab8d5ddcdfc7"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("7a021389-57ea-453d-b194-3c692735671d"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("7d0e4fb5-6e8e-48fc-ba2b-daa570f5f96f"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("84062c49-1fe2-4b97-86c4-49e4d0f5449b"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("855f8a55-c9d0-4532-81ee-6da2bd0db1f6"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("867a1f57-a7dc-4d8a-95f0-9b1e1b086809"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("8d86d786-c02d-43a6-9b3f-3ef15761ba71"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("91f09ff2-24ed-4d60-b3c5-5e76204a90ff"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("97b8ca2f-9784-4262-a57e-5695f3f0f642"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("abadc9e1-c8e6-4f40-b078-47f609d1cf79"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("adae589c-555f-48ac-9925-71fa96fa3d88"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("b3126c73-0e1e-40fd-8dec-f7c4d2789dd9"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("b9333f92-0e83-4343-973a-760182aea47e"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("cee5a4d8-de84-4482-9da9-302e2290cb0f"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("d263567a-41b2-407d-b40d-6bad18eb32ca"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("da9ca2f3-3a68-4311-b189-cc99c3fcebaa"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("e5e319f9-ef2a-4ab7-a847-5f0d3c7a1caf"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("e99dfd5c-ffe7-454d-9ae2-c4622eaa8200"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("e9a0d0d3-3a43-406a-b465-b630c5d93f6f"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("e9a7beda-ff63-4ac5-92cb-b7fa152c41c2"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("f7f6b4fc-0e88-4cb6-af7e-c0834bfb2b2c"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("fa7fab24-c298-43cf-b990-341b29a02996"));

            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("ff884ca0-1e63-4bc1-84a1-4048a6eb627e"));

            migrationBuilder.DropColumn(
                name: "LogoId",
                table: "Brand");

            migrationBuilder.RenameColumn(
                name: "LogoLink",
                table: "Brand",
                newName: "LinkLogo");
        }
    }
}
