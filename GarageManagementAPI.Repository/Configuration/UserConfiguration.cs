using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Enums;
using GarageManagementAPI.Shared.Enums.SystemStatuss;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class UserConfiguration : ConfigurationBase<User>
    {
        protected override void ModelCreating(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(e => e.Id).HasName("users_id_primary");

            entity.HasIndex(e => e.Email, "users_email_unique").IsUnique();

            entity.HasIndex(e => e.PhoneNumber, "users_phonenumber_unique").IsUnique();


            entity.Property(e => e.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            entity.Property(e => e.ConcurrencyStamp).HasMaxLength(255);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.NormalizedEmail)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(25);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(255);
            entity.Property(e => e.RefreshToken).HasMaxLength(255);
            entity.Property(e => e.SecurityStamp).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(25);


            entity.Property(e => e.Status)
                .HasConversion<string>();
        }

        protected override void SeedData(EntityTypeBuilder<User> entity)
        {
            entity.HasData(
                new User()
                {
                    Id = new Guid("1230a288-3e5e-4ee1-a75c-3fd7af6480a0"),
                    FirstName = "Hanh",
                    LastName = "Trần",
                    Image = "N/A",
                    Status = SystemStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UserName = "hanhthse171828",
                    NormalizedUserName = "HANHTHSE171828",
                    Email = "hanhthse171828@fpt.edu.vn",
                    NormalizedEmail = "HANHTHSE171828@FPT.EDU.VN",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEM1Ha9Qvsjr4ZYn0G3EVnXw9NCOzJAUH5/8W+aVGNQYFCdX3oOOSMtJTvohWbcohuA==", //Hanhthse171828!
                    SecurityStamp = "P7XZM6YDXPFYIY32RM5TXWUN54ISRUSB",
                    ConcurrencyStamp = "6daf287a-eba6-437d-b358-018a073059c9",
                    PhoneNumber = "0902596147",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true
                },
                new User()
                {
                    Id = new Guid("b78245a2-a2bf-45b4-8572-b2c3f1948629"),
                    FirstName = "Tân",
                    LastName = "Nguyễn",
                    Image = "N/A",
                    Status = SystemStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UserName = "tannhnse171836",
                    NormalizedUserName = "TANNHNSE171836",
                    Email = "tannhnse171836@fpt.edu.vn",
                    NormalizedEmail = "TANNHNSE171836@FPT.EDU.VN",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEIAkdif146dK+20v4+41Unot91RU8IPXdeCTz7BFJuTHznQt/EeVm4wX5Uj9l0XYmA==",
                    SecurityStamp = "KLYQWCV3ZURKCJ7LH2HXECD27E5CC3YZ",
                    ConcurrencyStamp = "ea354e65-522c-4931-99e2-cff427b74b14",
                    PhoneNumber = "0902596148",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true
                },
                new User()
                {
                    Id = new Guid("f8a4e60d-3113-4f25-8477-be205b0860c9"),
                    FirstName = "Tân",
                    LastName = "Lê",
                    Image = "N/A",
                    Status = SystemStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UserName = "tanlhnse171831",
                    NormalizedUserName = "TANLHNSE171831",
                    Email = "tanlhnse171831@fpt.edu.vn",
                    NormalizedEmail = "TANLHNSE171831@FPT.EDU.VN",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEE8W3WHfSOaP5A3wiInfQ85VBHjz7kBqx4jZUgJenP7T1ArBJU3JQvHEguudGCBChA==",
                    SecurityStamp = "R44AGPSXQCFMH6LRBGSWBK3PZKZP6LUT",
                    ConcurrencyStamp = "34ab88bc-a7f7-49b1-bdda-50c2a0850b64",
                    PhoneNumber = "0902596143",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true
                },
                new User()
                {
                    Id = new Guid("e2060ff5-5fb9-4b20-a11a-bf6ae4716ad5"),
                    FirstName = "Giang",
                    LastName = "Nguyễn",
                    Image = "N/A",
                    Status = SystemStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UserName = "giangnthse183257",
                    NormalizedUserName = "GIANGNTHSE183257",
                    Email = "giangnthse183257@fpt.edu.vn",
                    NormalizedEmail = "GIANGNTHSE183257@FPT.EDU.VN",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEJxI/AyF6NXvHVHrfnu9kLzmRHOHOq8dDZwRUD9GWWkzLee8u4C8TmYw4A6R3bInDg==",
                    SecurityStamp = "CKQPC56VA55WBN7KB3AXN4PKT4HHRQDA",
                    ConcurrencyStamp = "0834ee87-36fb-4002-844d-12adb9910e3c",
                    PhoneNumber = "0902596142",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true
                }
                , new User()
                {
                    Id = new Guid("de0d20e6-17e6-40e8-8274-c89a66e64fa5"),
                    FirstName = "Khánh",
                    LastName = "Bùi",
                    Image = "N/A",
                    Status = SystemStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UserName = "khanhbdse173224",
                    NormalizedUserName = "KHANHBDSE173224",
                    Email = "khanhbdse173224@fpt.edu.vn",
                    NormalizedEmail = "KHANHBDSE173224@FPT.EDU.VN",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEM8HN46vRsKmlCeYqZXwtRzylfbdmE/IlaRy8NUGvve7BEWIU2SR93NV4bw/bEe8Iw==",
                    SecurityStamp = "NNC3W4EI4NHQTPOCMMT6KJZVZUAYSQXT",
                    ConcurrencyStamp = "db2f38c8-64ae-438f-a28d-34074e1e4a42",
                    PhoneNumber = "0902596149",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true
                }
                );
        }
    }
}




