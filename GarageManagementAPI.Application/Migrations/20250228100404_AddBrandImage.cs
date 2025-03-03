using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageManagementAPI.Application.Migrations
{
    /// <inheritdoc />
    public partial class AddBrandImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogoId",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "LogoLink",
                table: "Brand");

            migrationBuilder.AddColumn<string>(
                name: "ImageId",
                table: "Brand",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageLink",
                table: "Brand",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("0131e761-bdeb-4fd0-8aba-b3cc0769d0c4"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/wfmlm6uwd5hnguwpbioj", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422439/Brand/wfmlm6uwd5hnguwpbioj.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("04d6430b-5665-4a0b-b33f-f782d5da2a58"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/x1iiioelr1eduzvlz6gz", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740420222/Brand/x1iiioelr1eduzvlz6gz.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("0be257e7-856d-48d6-ab5a-f984a75b67d5"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/zrlnucqkikvx4necltgs", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421187/Brand/zrlnucqkikvx4necltgs.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("14cc790e-323d-4020-b1ac-5ff5bb96336d"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/kx3xsj26x6czy664rjrx", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422018/Brand/kx3xsj26x6czy664rjrx.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/lyu7mi3lyfunwizhju9r", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423615/Brand/lyu7mi3lyfunwizhju9r.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("1f13210f-6d0b-4cb9-86b9-fc0fa5898afd"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/n4vgf2iu2xlddjq0fies", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422392/Brand/n4vgf2iu2xlddjq0fies.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("2254581b-c244-4c41-b5e4-c353629c2105"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/zndqli8qgxhwjmr7fyo5", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421656/Brand/zndqli8qgxhwjmr7fyo5.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("22d61e55-50e5-4dcd-bf40-209fc2fcae12"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/tmplel6lrqlfazu1bhy0", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423698/Brand/tmplel6lrqlfazu1bhy0.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("23e128b8-73fe-4e74-bfdf-97d82911af47"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/gahdhvt1wvon18doxhvy", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421976/Brand/gahdhvt1wvon18doxhvy.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("2c74b21a-5ec4-4dce-b376-b6b0601d7a84"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/qmp6fgd6qktgt52viovi", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422492/Brand/qmp6fgd6qktgt52viovi.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("306fd99b-7914-4c4d-a92b-f3d998f3b772"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/w6ca9jl8nxdrtsluak70", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422988/Brand/w6ca9jl8nxdrtsluak70.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("30e45fc3-a2d1-4006-be2b-9de2b1c5130c"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/qb6avmc6okdc39zg0uzz", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421924/Brand/qb6avmc6okdc39zg0uzz.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/sy90i7nnlc45r3l9xxff", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422553/Brand/sy90i7nnlc45r3l9xxff.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("3c18fcda-19de-42ee-88fa-7f9a5c60268f"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/dcfpdtrz6pqk5b7rkdfn", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740420549/Brand/dcfpdtrz6pqk5b7rkdfn.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("4224e14b-fce0-47cb-904f-0c7c286d45f8"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/qhnes6tgs3i6nsbft8dk", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422160/Brand/qhnes6tgs3i6nsbft8dk.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("47cc8b19-70ce-46f3-aef9-eb933eea2182"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/jh1rqnn0oavjilladcuy", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421861/Brand/jh1rqnn0oavjilladcuy.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("4b3039f3-b460-46be-aa39-e43d4c29af19"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/kchfjjavlom9a4qnywvg", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423772/Brand/kchfjjavlom9a4qnywvg.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("4d8aaaa6-448a-431c-a50f-a313dba5b3e5"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/biocmnahytbpqzvdtj3k", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422333/Brand/biocmnahytbpqzvdtj3k.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("51ae4906-854f-4a0a-8629-a0ba2656b9b9"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/jvcdennahy5k7y8tgcin", "https://res.cloudinary.com/dt2b5qfoe/image/upload/f_auto,q_auto/v1/Brand/jvcdennahy5k7y8tgcin" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("537c1813-334d-41c0-987b-0ed1509475f7"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/elsbmo9uhii4prclhfx2", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421766/Brand/elsbmo9uhii4prclhfx2.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("5b4d0698-cf56-41ff-927f-3226f1146f0f"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/akxxqktdh9mhylbhywxj", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422278/Brand/akxxqktdh9mhylbhywxj.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("61c63482-0890-497e-9013-6c1509e819eb"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/yjzqo0gcbjye6j78cfff", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740420327/Brand/yjzqo0gcbjye6j78cfff.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("6a927f4f-cc77-4d6d-963f-96a14a6a4fa9"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/bn8lek9t1qielpj33asx", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421364/Brand/bn8lek9t1qielpj33asx.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("6ebc86c7-82e2-4ce4-b613-ebaac626bd18"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/dvxwxwkt98k2vm237hb3", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421296/Brand/dvxwxwkt98k2vm237hb3.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("71bd8b35-0d22-4783-8638-78eb48bd5629"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/vkk2c8pgwgsdov9omkyd", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423282/Brand/vkk2c8pgwgsdov9omkyd.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("72d247fb-5249-4ce1-a400-fce2559e7db0"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/dtvvsfc8hclugj3rt6fi", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422660/Brand/dtvvsfc8hclugj3rt6fi.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("793ed2e4-eba2-407e-a814-ab8d5ddcdfc7"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/lovrlrwiei2xukzv6zq3", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422071/Brand/lovrlrwiei2xukzv6zq3.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("7a021389-57ea-453d-b194-3c692735671d"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/hmvywzznk4hecggkxi3p", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740419988/Brand/hmvywzznk4hecggkxi3p.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("7d0e4fb5-6e8e-48fc-ba2b-daa570f5f96f"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/ot1xglmql3kdxpdbwcte", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421522/Brand/ot1xglmql3kdxpdbwcte.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("84062c49-1fe2-4b97-86c4-49e4d0f5449b"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/dpq3tgrogw3ilo6jwqoz", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421768/Brand/dpq3tgrogw3ilo6jwqoz.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("855f8a55-c9d0-4532-81ee-6da2bd0db1f6"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/xqggwm0nnswweukoaoxd", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423926/Brand/xqggwm0nnswweukoaoxd.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("867a1f57-a7dc-4d8a-95f0-9b1e1b086809"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/mkyjol2tpt7jhjmaofaz", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423136/Brand/mkyjol2tpt7jhjmaofaz.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("8d86d786-c02d-43a6-9b3f-3ef15761ba71"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/hnposen4390ckqokcgcq", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421051/Brand/hnposen4390ckqokcgcq.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("91f09ff2-24ed-4d60-b3c5-5e76204a90ff"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/pbdy8azpl3zaj57jqsjh", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423195/Brand/pbdy8azpl3zaj57jqsjh.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("97b8ca2f-9784-4262-a57e-5695f3f0f642"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/zkby3nlbmv7path5ujwj", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421597/Brand/zkby3nlbmv7path5ujwj.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("abadc9e1-c8e6-4f40-b078-47f609d1cf79"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/m5yackgrajh62hnouttj", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423856/Brand/m5yackgrajh62hnouttj.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("adae589c-555f-48ac-9925-71fa96fa3d88"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/jmluhi20qavru6lcvpvc", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740420078/Brand/jmluhi20qavru6lcvpvc.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("b3126c73-0e1e-40fd-8dec-f7c4d2789dd9"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/ifubhf1jsnt9k6xkwhv7", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423064/Brand/ifubhf1jsnt9k6xkwhv7.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("b9333f92-0e83-4343-973a-760182aea47e"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/cpxc269y35mhr8pdijlr", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740420144/Brand/cpxc269y35mhr8pdijlr.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("cee5a4d8-de84-4482-9da9-302e2290cb0f"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/sbmjof2ugzzsuwoyj7r5", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423565/Brand/sbmjof2ugzzsuwoyj7r5.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("d263567a-41b2-407d-b40d-6bad18eb32ca"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/k8qf8xzk746w5ff9j6wx", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740420390/Brand/k8qf8xzk746w5ff9j6wx.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("da9ca2f3-3a68-4311-b189-cc99c3fcebaa"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/jbn02u6cdkbhr9suovy1", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740420465/Brand/jbn02u6cdkbhr9suovy1.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("e5e319f9-ef2a-4ab7-a847-5f0d3c7a1caf"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/diqhpfvayh4esj3vion2", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422609/Brand/diqhpfvayh4esj3vion2.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("e99dfd5c-ffe7-454d-9ae2-c4622eaa8200"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/kkxeemoptvcenvt86l3w", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423366/Brand/kkxeemoptvcenvt86l3w.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("e9a0d0d3-3a43-406a-b465-b630c5d93f6f"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/umb5c1sp4044krzzpo88", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422880/Brand/umb5c1sp4044krzzpo88.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("e9a7beda-ff63-4ac5-92cb-b7fa152c41c2"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/n3dc1tql2hvqydjaekzl", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423480/Brand/n3dc1tql2hvqydjaekzl.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/ulvsdpqvmfvib7i6wxos", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423422/Brand/ulvsdpqvmfvib7i6wxos.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("f7f6b4fc-0e88-4cb6-af7e-c0834bfb2b2c"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/nkhahhkmagpxarghm1us", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422229/Brand/nkhahhkmagpxarghm1us.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("fa7fab24-c298-43cf-b990-341b29a02996"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/lexnrqalxuzivogd6mov", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421444/Brand/lexnrqalxuzivogd6mov.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("ff884ca0-1e63-4bc1-84a1-4048a6eb627e"),
                columns: new[] { "ImageId", "ImageLink" },
                values: new object[] { "Brand/uu8ru4pxd9lywnclld9y", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421127/Brand/uu8ru4pxd9lywnclld9y.png" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "ImageLink",
                table: "Brand");

            migrationBuilder.AddColumn<string>(
                name: "LogoId",
                table: "Brand",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LogoLink",
                table: "Brand",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("0131e761-bdeb-4fd0-8aba-b3cc0769d0c4"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/wfmlm6uwd5hnguwpbioj", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422439/Brand/wfmlm6uwd5hnguwpbioj.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("04d6430b-5665-4a0b-b33f-f782d5da2a58"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/x1iiioelr1eduzvlz6gz", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740420222/Brand/x1iiioelr1eduzvlz6gz.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("0be257e7-856d-48d6-ab5a-f984a75b67d5"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/zrlnucqkikvx4necltgs", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421187/Brand/zrlnucqkikvx4necltgs.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("14cc790e-323d-4020-b1ac-5ff5bb96336d"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/kx3xsj26x6czy664rjrx", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422018/Brand/kx3xsj26x6czy664rjrx.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("1c1ffd05-3b06-48bf-b78c-86b6ef2d3cef"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/lyu7mi3lyfunwizhju9r", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423615/Brand/lyu7mi3lyfunwizhju9r.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("1f13210f-6d0b-4cb9-86b9-fc0fa5898afd"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/n4vgf2iu2xlddjq0fies", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422392/Brand/n4vgf2iu2xlddjq0fies.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("2254581b-c244-4c41-b5e4-c353629c2105"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/zndqli8qgxhwjmr7fyo5", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421656/Brand/zndqli8qgxhwjmr7fyo5.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("22d61e55-50e5-4dcd-bf40-209fc2fcae12"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/tmplel6lrqlfazu1bhy0", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423698/Brand/tmplel6lrqlfazu1bhy0.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("23e128b8-73fe-4e74-bfdf-97d82911af47"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/gahdhvt1wvon18doxhvy", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421976/Brand/gahdhvt1wvon18doxhvy.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("2c74b21a-5ec4-4dce-b376-b6b0601d7a84"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/qmp6fgd6qktgt52viovi", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422492/Brand/qmp6fgd6qktgt52viovi.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("306fd99b-7914-4c4d-a92b-f3d998f3b772"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/w6ca9jl8nxdrtsluak70", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422988/Brand/w6ca9jl8nxdrtsluak70.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("30e45fc3-a2d1-4006-be2b-9de2b1c5130c"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/qb6avmc6okdc39zg0uzz", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421924/Brand/qb6avmc6okdc39zg0uzz.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("350b60f4-40fb-499b-9358-3a06ee2ff5f7"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/sy90i7nnlc45r3l9xxff", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422553/Brand/sy90i7nnlc45r3l9xxff.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("3c18fcda-19de-42ee-88fa-7f9a5c60268f"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/dcfpdtrz6pqk5b7rkdfn", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740420549/Brand/dcfpdtrz6pqk5b7rkdfn.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("4224e14b-fce0-47cb-904f-0c7c286d45f8"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/qhnes6tgs3i6nsbft8dk", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422160/Brand/qhnes6tgs3i6nsbft8dk.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("47cc8b19-70ce-46f3-aef9-eb933eea2182"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/jh1rqnn0oavjilladcuy", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421861/Brand/jh1rqnn0oavjilladcuy.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("4b3039f3-b460-46be-aa39-e43d4c29af19"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/kchfjjavlom9a4qnywvg", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423772/Brand/kchfjjavlom9a4qnywvg.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("4d8aaaa6-448a-431c-a50f-a313dba5b3e5"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/biocmnahytbpqzvdtj3k", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422333/Brand/biocmnahytbpqzvdtj3k.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("51ae4906-854f-4a0a-8629-a0ba2656b9b9"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/jvcdennahy5k7y8tgcin", "https://res.cloudinary.com/dt2b5qfoe/image/upload/f_auto,q_auto/v1/Brand/jvcdennahy5k7y8tgcin" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("537c1813-334d-41c0-987b-0ed1509475f7"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/elsbmo9uhii4prclhfx2", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421766/Brand/elsbmo9uhii4prclhfx2.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("5b4d0698-cf56-41ff-927f-3226f1146f0f"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/akxxqktdh9mhylbhywxj", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422278/Brand/akxxqktdh9mhylbhywxj.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("61c63482-0890-497e-9013-6c1509e819eb"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/yjzqo0gcbjye6j78cfff", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740420327/Brand/yjzqo0gcbjye6j78cfff.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("6a927f4f-cc77-4d6d-963f-96a14a6a4fa9"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/bn8lek9t1qielpj33asx", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421364/Brand/bn8lek9t1qielpj33asx.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("6ebc86c7-82e2-4ce4-b613-ebaac626bd18"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/dvxwxwkt98k2vm237hb3", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421296/Brand/dvxwxwkt98k2vm237hb3.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("71bd8b35-0d22-4783-8638-78eb48bd5629"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/vkk2c8pgwgsdov9omkyd", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423282/Brand/vkk2c8pgwgsdov9omkyd.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("72d247fb-5249-4ce1-a400-fce2559e7db0"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/dtvvsfc8hclugj3rt6fi", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422660/Brand/dtvvsfc8hclugj3rt6fi.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("793ed2e4-eba2-407e-a814-ab8d5ddcdfc7"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/lovrlrwiei2xukzv6zq3", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422071/Brand/lovrlrwiei2xukzv6zq3.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("7a021389-57ea-453d-b194-3c692735671d"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/hmvywzznk4hecggkxi3p", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740419988/Brand/hmvywzznk4hecggkxi3p.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("7d0e4fb5-6e8e-48fc-ba2b-daa570f5f96f"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/ot1xglmql3kdxpdbwcte", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421522/Brand/ot1xglmql3kdxpdbwcte.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("84062c49-1fe2-4b97-86c4-49e4d0f5449b"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/dpq3tgrogw3ilo6jwqoz", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421768/Brand/dpq3tgrogw3ilo6jwqoz.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("855f8a55-c9d0-4532-81ee-6da2bd0db1f6"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/xqggwm0nnswweukoaoxd", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423926/Brand/xqggwm0nnswweukoaoxd.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("867a1f57-a7dc-4d8a-95f0-9b1e1b086809"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/mkyjol2tpt7jhjmaofaz", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423136/Brand/mkyjol2tpt7jhjmaofaz.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("8d86d786-c02d-43a6-9b3f-3ef15761ba71"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/hnposen4390ckqokcgcq", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421051/Brand/hnposen4390ckqokcgcq.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("91f09ff2-24ed-4d60-b3c5-5e76204a90ff"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/pbdy8azpl3zaj57jqsjh", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423195/Brand/pbdy8azpl3zaj57jqsjh.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("97b8ca2f-9784-4262-a57e-5695f3f0f642"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/zkby3nlbmv7path5ujwj", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421597/Brand/zkby3nlbmv7path5ujwj.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("abadc9e1-c8e6-4f40-b078-47f609d1cf79"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/m5yackgrajh62hnouttj", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423856/Brand/m5yackgrajh62hnouttj.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("adae589c-555f-48ac-9925-71fa96fa3d88"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/jmluhi20qavru6lcvpvc", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740420078/Brand/jmluhi20qavru6lcvpvc.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("b3126c73-0e1e-40fd-8dec-f7c4d2789dd9"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/ifubhf1jsnt9k6xkwhv7", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423064/Brand/ifubhf1jsnt9k6xkwhv7.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("b9333f92-0e83-4343-973a-760182aea47e"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/cpxc269y35mhr8pdijlr", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740420144/Brand/cpxc269y35mhr8pdijlr.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("cee5a4d8-de84-4482-9da9-302e2290cb0f"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/sbmjof2ugzzsuwoyj7r5", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423565/Brand/sbmjof2ugzzsuwoyj7r5.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("d263567a-41b2-407d-b40d-6bad18eb32ca"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/k8qf8xzk746w5ff9j6wx", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740420390/Brand/k8qf8xzk746w5ff9j6wx.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("da9ca2f3-3a68-4311-b189-cc99c3fcebaa"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/jbn02u6cdkbhr9suovy1", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740420465/Brand/jbn02u6cdkbhr9suovy1.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("e5e319f9-ef2a-4ab7-a847-5f0d3c7a1caf"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/diqhpfvayh4esj3vion2", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422609/Brand/diqhpfvayh4esj3vion2.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("e99dfd5c-ffe7-454d-9ae2-c4622eaa8200"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/kkxeemoptvcenvt86l3w", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423366/Brand/kkxeemoptvcenvt86l3w.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("e9a0d0d3-3a43-406a-b465-b630c5d93f6f"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/umb5c1sp4044krzzpo88", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422880/Brand/umb5c1sp4044krzzpo88.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("e9a7beda-ff63-4ac5-92cb-b7fa152c41c2"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/n3dc1tql2hvqydjaekzl", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423480/Brand/n3dc1tql2hvqydjaekzl.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("f5fd6ee3-a8b6-452c-9042-146e8afc875f"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/ulvsdpqvmfvib7i6wxos", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740423422/Brand/ulvsdpqvmfvib7i6wxos.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("f7f6b4fc-0e88-4cb6-af7e-c0834bfb2b2c"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/nkhahhkmagpxarghm1us", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740422229/Brand/nkhahhkmagpxarghm1us.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("fa7fab24-c298-43cf-b990-341b29a02996"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/lexnrqalxuzivogd6mov", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421444/Brand/lexnrqalxuzivogd6mov.png" });

            migrationBuilder.UpdateData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: new Guid("ff884ca0-1e63-4bc1-84a1-4048a6eb627e"),
                columns: new[] { "LogoId", "LogoLink" },
                values: new object[] { "Brand/uu8ru4pxd9lywnclld9y", "https://res.cloudinary.com/dt2b5qfoe/image/upload/v1740421127/Brand/uu8ru4pxd9lywnclld9y.png" });
        }
    }
}
