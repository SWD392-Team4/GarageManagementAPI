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

            entity.HasMany(u => u.Roles)
                    .WithMany(r => r.Users)
                    .UsingEntity<IdentityUserRole<Guid>>(
                        j => j.HasOne<Roles>().WithMany().HasForeignKey(ur => ur.RoleId),
                        j => j.HasOne<User>().WithMany().HasForeignKey(ur => ur.UserId),
                        j =>
                        {
                            j.HasKey(ur => new { ur.UserId, ur.RoleId });
                            j.ToTable("UserRoles");
                        });
        }

        protected override void SeedData(EntityTypeBuilder<User> entity)
        {
            entity.HasData(
                new User()
                {
                    Id = new Guid("1230a288-3e5e-4ee1-a75c-3fd7af6480a0"),
                    FirstName = "Hanh",
                    LastName = "Trần",
                    Status = UserStatus.Active,
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
                    Status = UserStatus.Active,
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
                    Status = UserStatus.Active,
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
                    Status = UserStatus.Active,
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
                    Status = UserStatus.Active,
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
                , new User()
                {
                    Id = new Guid("773d6761-8990-4408-be8f-321a7659825a"),
                    FirstName = "Customer_1_first_name",
                    LastName = "Customer_1_last_name",
                    Status = UserStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UserName = "customer1",
                    NormalizedUserName = "CUSTOMER1",
                    Email = "customer1@gmail.com",
                    NormalizedEmail = "CUSTOMER1@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", //TurboTrack123!
                    SecurityStamp = "NNC3W4EI4NHQTPOCMMT6KJZVZUAYSQXT",
                    ConcurrencyStamp = "db2f38c8-64ae-438f-a28d-34074e1e4a42",
                    PhoneNumber = "0902596109",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true
                },
                new User()
                {
                    Id = new Guid("67f4a543-7ff4-4db9-bf4a-748d3f9e13b1"),
                    FirstName = "Customer_2_first_name",
                    LastName = "Customer_2_last_name",
                    Status = UserStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UserName = "customer2",
                    NormalizedUserName = "CUSTOMER2",
                    Email = "customer2@gmail.com",
                    NormalizedEmail = "CUSTOMER2@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", //TurboTrack123!
                    SecurityStamp = "A7D5Q2EI4NHYTPOCMMT6KJZVZUAYSQZT",
                    ConcurrencyStamp = "c8e7d1a4-22ab-48a4-9c57-12e334c5b0a6",
                    PhoneNumber = "0901234567",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true
                },
                new User()
                {
                    Id = new Guid("d4b8cfb8-8b97-4d6d-bf1b-90f17fd853f3"),
                    FirstName = "Customer_3_first_name",
                    LastName = "Customer_3_last_name",
                    Status = UserStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UserName = "customer3",
                    NormalizedUserName = "CUSTOMER3",
                    Email = "customer3@gmail.com",
                    NormalizedEmail = "CUSTOMER3@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", //TurboTrack123!
                    SecurityStamp = "K5R8X9EI4NHQTPOCMMT6KJZVZUAYSQXB",
                    ConcurrencyStamp = "13cf3846-0b7a-46d3-a935-6c72d9bc469a",
                    PhoneNumber = "0909876543",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true
                },
                new User()
                {
                    Id = new Guid("f1a3d7c8-3d50-42b7-9b92-b53717b8e7a8"),
                    FirstName = "Customer_4_first_name",
                    LastName = "Customer_4_last_name",
                    Status = UserStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UserName = "customer4",
                    NormalizedUserName = "CUSTOMER4",
                    Email = "customer4@gmail.com",
                    NormalizedEmail = "CUSTOMER4@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", //TurboTrack123!
                    SecurityStamp = "L9M7N8EI4NHQTPOCMMT6KJZVZUAYSQXC",
                    ConcurrencyStamp = "24de4957-1c8b-57e4-b046-7d83eaac57ab",
                    PhoneNumber = "0911122233",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true
                },
                new User()
                {
                    Id = new Guid("a2e4f1b2-6f2d-42f7-a2b5-3a9b8c1d2e3f"),
                    FirstName = "Customer_5_first_name",
                    LastName = "Customer_5_last_name",
                    Status = UserStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UserName = "customer5",
                    NormalizedUserName = "CUSTOMER5",
                    Email = "customer5@gmail.com",
                    NormalizedEmail = "CUSTOMER5@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", //TurboTrack123!
                    SecurityStamp = "P3Q2R1EI4NHQTPOCMMT6KJZVZUAYSQXD",
                    ConcurrencyStamp = "35ef5a68-2d9c-68f5-c157-8e94fbbd68bc",
                    PhoneNumber = "0912233445",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true
                },
                new User()
                {
                    Id = new Guid("b3c5d6e7-f8a9-4b0c-8d1e-2f3a4b5c6d7e"),
                    FirstName = "Customer_6_first_name",
                    LastName = "Customer_6_last_name",
                    Status = UserStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UserName = "customer6",
                    NormalizedUserName = "CUSTOMER6",
                    Email = "customer6@gmail.com",
                    NormalizedEmail = "CUSTOMER6@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", //TurboTrack123!
                    SecurityStamp = "S4T5U6EI4NHQTPOCMMT6KJZVZUAYSQXE",
                    ConcurrencyStamp = "46ff6b79-3ead-4af6-d268-9fabc0cda79d",
                    PhoneNumber = "0913344556",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true
                },
                new User()
                {
                    Id = new Guid("c4d5e6f7-a8b9-4c0d-9e1f-3a4b5c6d7e8f"),
                    FirstName = "Customer_7_first_name",
                    LastName = "Customer_7_last_name",
                    Status = UserStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UserName = "customer7",
                    NormalizedUserName = "CUSTOMER7",
                    Email = "customer7@gmail.com",
                    NormalizedEmail = "CUSTOMER7@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", //TurboTrack123!
                    SecurityStamp = "V7W8X9EI4NHQTPOCMMT6KJZVZUAYSQXF",
                    ConcurrencyStamp = "57a07c8a-4fbe-4b07-e379-afbcde1eb8ae",
                    PhoneNumber = "0914455667",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true
                },
                new User()
                {
                    Id = new Guid("d5e6f7a8-b9c0-4d1e-8f2a-4b5c6d7e8f90"),
                    FirstName = "Customer_8_first_name",
                    LastName = "Customer_8_last_name",
                    Status = UserStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UserName = "customer8",
                    NormalizedUserName = "CUSTOMER8",
                    Email = "customer8@gmail.com",
                    NormalizedEmail = "CUSTOMER8@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", //TurboTrack123!
                    SecurityStamp = "Z1A2B3EI4NHQTPOCMMT6KJZVZUAYSQXG",
                    ConcurrencyStamp = "68b18d9b-50cf-4c18-f48a-bcdef1234a0b",
                    PhoneNumber = "0915566778",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true
                },
                new User()
                {
                    Id = new Guid("e6f7a8b9-c0d1-4e2f-9a3b-5c6d7e8f9012"),
                    FirstName = "Customer_9_first_name",
                    LastName = "Customer_9_last_name",
                    Status = UserStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UserName = "customer9",
                    NormalizedUserName = "CUSTOMER9",
                    Email = "customer9@gmail.com",
                    NormalizedEmail = "CUSTOMER9@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", //TurboTrack123!
                    SecurityStamp = "C4D5E6EI4NHQTPOCMMT6KJZVZUAYSQXH",
                    ConcurrencyStamp = "79c29eac-61d0-4d29-a59b-cdef2345b1c2",
                    PhoneNumber = "0916677889",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true
                },
                new User()
                {
                    Id = new Guid("f7a8b9c0-d1e2-4f3a-8b4c-6d7e8f901234"),
                    FirstName = "Customer_10_first_name",
                    LastName = "Customer_10_last_name",
                    Status = UserStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UserName = "customer10",
                    NormalizedUserName = "CUSTOMER10",
                    Email = "customer10@gmail.com",
                    NormalizedEmail = "CUSTOMER10@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", //TurboTrack123!
                    SecurityStamp = "F7G8H9EI4NHQTPOCMMT6KJZVZUAYSQXI",
                    ConcurrencyStamp = "8ad3afbd-72e1-4e3a-b6ac-def34567c2d3",
                    PhoneNumber = "0917788990",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true
                },

                // Mechanics (10)
                new User()
                {
                    Id = new Guid("0a1b2c3d-4e5f-6789-abcd-ef0123456789"),
                    FirstName = "Mechanic_1_first_name",
                    LastName = "Mechanic_1_last_name",
                    Status = UserStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UserName = "mechanic1",
                    NormalizedUserName = "MECHANIC1",
                    Email = "mechanic1@gmail.com",
                    NormalizedEmail = "MECHANIC1@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", //TurboTrack123!
                    SecurityStamp = "M1N2O3EI4NHQTPOCMMT6KJZVZUAYSQXJ",
                    ConcurrencyStamp = "b2e4f7e1-3c1d-4f09-bcf5-6f23d7d56d9b",
                    PhoneNumber = "0921122334",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true
                },
                new User()
                {
                    Id = new Guid("1b2c3d4e-5f67-89ab-cdef-0123456789ab"),
                    FirstName = "Mechanic_2_first_name",
                    LastName = "Mechanic_2_last_name",
                    Status = UserStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UserName = "mechanic2",
                    NormalizedUserName = "MECHANIC2",
                    Email = "mechanic2@gmail.com",
                    NormalizedEmail = "MECHANIC2@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", //TurboTrack123!
                    SecurityStamp = "K2L3M4EI4NHQTPOCMMT6KJZVZUAYSQXK",
                    ConcurrencyStamp = "c3f5a8e2-4d2e-4a10-cdf6-7e34f8e67ead",
                    PhoneNumber = "0922233445",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true
                },
                new User()
                {
                    Id = new Guid("2c3d4e5f-6789-abcd-ef01-23456789abcd"),
                    FirstName = "Mechanic_3_first_name",
                    LastName = "Mechanic_3_last_name",
                    Status = UserStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UserName = "mechanic3",
                    NormalizedUserName = "MECHANIC3",
                    Email = "mechanic3@gmail.com",
                    NormalizedEmail = "MECHANIC3@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", //TurboTrack123!
                    SecurityStamp = "P5Q6R7EI4NHQTPOCMMT6KJZVZUAYSQXL",
                    ConcurrencyStamp = "d4a6b9e3-5e3f-4b11-def7-8f45a9e78fbe",
                    PhoneNumber = "0923344556",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true
                },
                new User()
                {
                    Id = new Guid("3d4e5f67-89ab-cdef-0123-456789abcdef"),
                    FirstName = "Mechanic_4_first_name",
                    LastName = "Mechanic_4_last_name",
                    Status = UserStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UserName = "mechanic4",
                    NormalizedUserName = "MECHANIC4",
                    Email = "mechanic4@gmail.com",
                    NormalizedEmail = "MECHANIC4@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", //TurboTrack123!
                    SecurityStamp = "S8T9U0EI4NHQTPOCMMT6KJZVZUAYSQXM",
                    ConcurrencyStamp = "e5b7c0e4-6f4a-4c12-ef08-9a56bab89fcf",
                    PhoneNumber = "0924455667",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true
                },
                new User()
                {
                    Id = new Guid("4e5f6789-abcd-ef01-2345-6789abcdef01"),
                    FirstName = "Mechanic_5_first_name",
                    LastName = "Mechanic_5_last_name",
                    Status = UserStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UserName = "mechanic5",
                    NormalizedUserName = "MECHANIC5",
                    Email = "mechanic5@gmail.com",
                    NormalizedEmail = "MECHANIC5@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", //TurboTrack123!
                    SecurityStamp = "V1W2X3EI4NHQTPOCMMT6KJZVZUAYSQXN",
                    ConcurrencyStamp = "f6c8d1e5-7a5b-4d13-ef19-ab67cbc9ad0a",
                    PhoneNumber = "0925566778",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true
                },
                new User()
                {
                    Id = new Guid("5f6789ab-cdef-0123-4567-89abcdef0123"),
                    FirstName = "Mechanic_6_first_name",
                    LastName = "Mechanic_6_last_name",
                    Status = UserStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UserName = "mechanic6",
                    NormalizedUserName = "MECHANIC6",
                    Email = "mechanic6@gmail.com",
                    NormalizedEmail = "MECHANIC6@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", //TurboTrack123!
                    SecurityStamp = "Y4Z5A6EI4NHQTPOCMMT6KJZVZUAYSQXO",
                    ConcurrencyStamp = "a7d9e2f6-8b6c-4e14-ef2a-bc78dcdabd1b",
                    PhoneNumber = "0926677889",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true
                },
                new User()
                {
                    Id = new Guid("6789abcd-ef01-2345-6789-abcdef012345"),
                    FirstName = "Mechanic_7_first_name",
                    LastName = "Mechanic_7_last_name",
                    Status = UserStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UserName = "mechanic7",
                    NormalizedUserName = "MECHANIC7",
                    Email = "mechanic7@gmail.com",
                    NormalizedEmail = "MECHANIC7@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", //TurboTrack123!
                    SecurityStamp = "B7C8D9EI4NHQTPOCMMT6KJZVZUAYSQXP",
                    ConcurrencyStamp = "b8eaf307-9c7d-4f15-ef3b-cd89edcbce2c",
                    PhoneNumber = "0927788990",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true
                },
                new User()
                {
                    Id = new Guid("789abcde-f012-3456-789a-bcdef0123456"),
                    FirstName = "Mechanic_8_first_name",
                    LastName = "Mechanic_8_last_name",
                    Status = UserStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UserName = "mechanic8",
                    NormalizedUserName = "MECHANIC8",
                    Email = "mechanic8@gmail.com",
                    NormalizedEmail = "MECHANIC8@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", //TurboTrack123!
                    SecurityStamp = "E0F1G2EI4NHQTPOCMMT6KJZVZUAYSQXQ",
                    ConcurrencyStamp = "c9f0a418-ad8e-4a16-ef4c-de90feacdf3d",
                    PhoneNumber = "0928899001",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true
                },
                new User()
                {
                    Id = new Guid("89abcdef-0123-4567-89ab-cdef01234567"),
                    FirstName = "Mechanic_9_first_name",
                    LastName = "Mechanic_9_last_name",
                    Status = UserStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UserName = "mechanic9",
                    NormalizedUserName = "MECHANIC9",
                    Email = "mechanic9@gmail.com",
                    NormalizedEmail = "MECHANIC9@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", //TurboTrack123!
                    SecurityStamp = "H3I4J5EI4NHQTPOCMMT6KJZVZUAYSQXR",
                    ConcurrencyStamp = "da012529-be9f-4b17-ef5d-ef01afbd0e4e",
                    PhoneNumber = "0929900112",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true
                },
                new User()
                {
                    Id = new Guid("9abcdef0-1234-5678-9abc-def012345678"),
                    FirstName = "Mechanic_10_first_name",
                    LastName = "Mechanic_10_last_name",
                    Status = UserStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UserName = "mechanic10",
                    NormalizedUserName = "MECHANIC10",
                    Email = "mechanic10@gmail.com",
                    NormalizedEmail = "MECHANIC10@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", //TurboTrack123!
                    SecurityStamp = "K6L7M8EI4NHQTPOCMMT6KJZVZUAYSQXS",
                    ConcurrencyStamp = "eb12363a-cf10-4c18-ef6e-f012becd1f5f",
                    PhoneNumber = "0930011223",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true
                },

                // Cashiers (2)
                new User()
                {
                    Id = new Guid("abcd1234-ef56-7890-abcd-ef1234567890"),
                    FirstName = "Cashier_1_first_name",
                    LastName = "Cashier_1_last_name",
                    Status = UserStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UserName = "cashier1",
                    NormalizedUserName = "CASHIER1",
                    Email = "cashier1@gmail.com",
                    NormalizedEmail = "CASHIER1@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", //TurboTrack123!
                    SecurityStamp = "U2V3W4EI4NHQTPOCMMT6KJZVZUAYSQXU",
                    ConcurrencyStamp = "e89cf584-5b71-4a53-a6c5-4d3fa8db0a67",
                    PhoneNumber = "0931122334",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true
                },
                new User()
                {
                    Id = new Guid("bcde2345-f678-9012-bcde-f23456789012"),
                    FirstName = "Cashier_2_first_name",
                    LastName = "Cashier_2_last_name",
                    Status = UserStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UserName = "cashier2",
                    NormalizedUserName = "CASHIER2",
                    Email = "cashier2@gmail.com",
                    NormalizedEmail = "CASHIER2@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", //TurboTrack123!
                    SecurityStamp = "X5Y6Z7EI4NHQTPOCMMT6KJZVZUAYSQXV",
                    ConcurrencyStamp = "f90df695-6c82-4b64-b7d6-5e4fb9ec1b78",
                    PhoneNumber = "0932233445",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true
                },

                // Warehouse Managers (2)
                new User()
                {
                    Id = new Guid("cdef3456-7890-1234-cdef-345678901234"),
                    FirstName = "Warehouse_1_first_name",
                    LastName = "Warehouse_1_last_name",
                    Status = UserStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UserName = "warehouse1",
                    NormalizedUserName = "WAREHOUSE1",
                    Email = "warehouse1@gmail.com",
                    NormalizedEmail = "WAREHOUSE1@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", //TurboTrack123!
                    SecurityStamp = "A8B9C0EI4NHQTPOCMMT6KJZVZUAYSQXW",
                    ConcurrencyStamp = "a1b2c3d4-e5f6-4a7b-8c9d-0a1b2c3d4e5f",
                    PhoneNumber = "0933344556",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true
                },
                new User()
                {
                    Id = new Guid("def45678-9012-3456-def0-456789012345"),
                    FirstName = "Warehouse_2_first_name",
                    LastName = "Warehouse_2_last_name",
                    Status = UserStatus.Active,
                    CreatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UpdatedAt = DateTimeOffset.Parse("2025-02-01 00:00:00.0000000 +07:00"),
                    UserName = "warehouse2",
                    NormalizedUserName = "WAREHOUSE2",
                    Email = "warehouse2@gmail.com",
                    NormalizedEmail = "WAREHOUSE2@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEFpLNgb8l5j8hIGIH1In9P+i4xj3mHZJHW2klqMNk9owzOYPBbj6f94LmksGXtHhHA==", //TurboTrack123!
                    SecurityStamp = "D1E2F3EI4NHQTPOCMMT6KJZVZUAYSQXX",
                    ConcurrencyStamp = "b2c3d4e5-f6a7-4b8c-9d0e-1b2c3d4e5f60",
                    PhoneNumber = "0934455667",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true
                }
                );
        }
    }
}




