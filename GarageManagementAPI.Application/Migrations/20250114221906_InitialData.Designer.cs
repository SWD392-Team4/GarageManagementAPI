﻿// <auto-generated />
using System;
using GarageManagementAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GarageManagementAPI.Application.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20250114221906_InitialData")]
    partial class InitialData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GarageManagementAPI.Entities.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CitizenIdentification")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("GarageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GarageId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                            Address = "Thành Phố Hồ Chí Minh",
                            CitizenIdentification = "079203028046",
                            CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                            DateOfBirth = new DateOnly(2003, 11, 17),
                            Email = "nightfury455@gmail.com",
                            Gender = true,
                            Name = "Lê Hoàng Nhật Tân",
                            PhoneNumber = "0343663841",
                            Role = "Mechanic",
                            Status = "Active"
                        },
                        new
                        {
                            Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                            Address = "Thành phố Tây Ninh",
                            CitizenIdentification = "031204029041",
                            CompanyId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                            DateOfBirth = new DateOnly(2003, 3, 6),
                            Email = "huyhanhoppo@gmail.com",
                            Gender = true,
                            Name = "Trần Huy Hanh",
                            PhoneNumber = "0934256427",
                            Role = "Cashier",
                            Status = "Active"
                        },
                        new
                        {
                            Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                            Address = "Thành Phố Hồ Chí Minh",
                            CitizenIdentification = "023403128074",
                            CompanyId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                            DateOfBirth = new DateOnly(2003, 1, 10),
                            Email = "nhntan124@gmail.com",
                            Gender = true,
                            Name = "Nguyễn Hoàng Nhựt Tân",
                            PhoneNumber = "0254677111",
                            Role = "Cashier",
                            Status = "Active"
                        },
                        new
                        {
                            Id = new Guid("58a4c24b-7a4d-48f4-b793-a35a1d88c4d5"),
                            Address = "Thành Phố Hồ Chí Minh",
                            CitizenIdentification = "031452126172",
                            CompanyId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                            DateOfBirth = new DateOnly(2003, 1, 13),
                            Email = "nhnkhanh@gmail.com",
                            Gender = true,
                            Name = "Nguyễn Khánh",
                            PhoneNumber = "0354675122",
                            Role = "Mechanic",
                            Status = "Active"
                        });
                });

            modelBuilder.Entity("GarageManagementAPI.Entities.Models.Garage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Garages");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                            Address = "Toà nhà UOA, 6 Tân Trào, Tân Phú, Quận 7",
                            City = "Hồ Chí Minh",
                            Name = "Revzone Yamaha Motor",
                            PhoneNumber = "0343663841"
                        },
                        new
                        {
                            Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                            Address = "Số 1 Quang Trung, Phường 3, Quận Gò Vấp",
                            City = "Hồ Chí Minh",
                            Name = "Head Việt Thái Quân",
                            PhoneNumber = "02871098198"
                        });
                });

            modelBuilder.Entity("GarageManagementAPI.Entities.Models.Employee", b =>
                {
                    b.HasOne("GarageManagementAPI.Entities.Models.Garage", "Garage")
                        .WithMany("Employees")
                        .HasForeignKey("GarageId");

                    b.Navigation("Garage");
                });

            modelBuilder.Entity("GarageManagementAPI.Entities.Models.Garage", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
