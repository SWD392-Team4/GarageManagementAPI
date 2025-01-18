using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.Enum;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class EmployeeConfiguration : ConfigurationBase<Employee>
    {
        protected override void ModelCreating(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Status)
               .HasConversion<string>();

            builder.Property(e => e.Role)
               .HasConversion<string>();
        }

        protected override void SeedData(EntityTypeBuilder<Employee> builder)
        {
            //builder.HasData
            //(
            //    new Employee
            //    {
            //        Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
            //        Name = "Lê Hoàng Nhật Tân",
            //        Address = "Thành Phố Hồ Chí Minh",
            //        DateOfBirth = new DateOnly(2003, 11, 17),
            //        PhoneNumber = "0343663841",
            //        CitizenIdentification = "079203028046",
            //        GarageId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
            //        Email = "nightfury455@gmail.com",
            //        Gender = true,
            //        Role = SystemRole.Mechanic,
            //        Status = EmployeeStatus.Active
            //    },
            //    new Employee
            //    {
            //        Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
            //        Name = "Trần Huy Hanh",
            //        Address = "Thành phố Tây Ninh",
            //        DateOfBirth = new DateOnly(2003, 03, 06),
            //        PhoneNumber = "0934256427",
            //        CitizenIdentification = "031204029041",
            //        GarageId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
            //        Email = "huyhanhoppo@gmail.com",
            //        Gender = true,
            //        Role = SystemRole.Cashier,
            //        Status = EmployeeStatus.Active
            //    }, new Employee
            //    {
            //        Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
            //        Name = "Nguyễn Hoàng Nhựt Tân",
            //        Address = "Thành Phố Hồ Chí Minh",
            //        DateOfBirth = new DateOnly(2003, 1, 10),
            //        PhoneNumber = "0254677111",
            //        CitizenIdentification = "023403128074",
            //        GarageId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
            //        Email = "nhntan124@gmail.com",
            //        Gender = true,
            //        Role = SystemRole.Cashier,
            //        Status = EmployeeStatus.Active
            //    }, new Employee
            //    {
            //        Id = new Guid("58a4c24b-7a4d-48f4-b793-a35a1d88c4d5"),
            //        Name = "Nguyễn Khánh",
            //        Address = "Thành Phố Hồ Chí Minh",
            //        DateOfBirth = new DateOnly(2003, 1, 13),
            //        PhoneNumber = "0354675122",
            //        CitizenIdentification = "031452126172",
            //        GarageId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
            //        Email = "nhnkhanh@gmail.com",
            //        Gender = true,
            //        Role = SystemRole.Mechanic,
            //        Status = EmployeeStatus.Active
            //    }
            //);
        }
    }
}
