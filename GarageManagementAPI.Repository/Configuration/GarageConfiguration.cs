using Bogus;
using GarageManagementAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageManagementAPI.Repository.Configuration
{
    public class GarageConfiguration : ConfigurationBase<Garage>
    {

        protected override void SeedData(EntityTypeBuilder<Garage> builder)
        {
            
            builder.HasData
            (
                new Garage
                {
                    Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    Name = "Revzone Yamaha Motor",
                    Address = "Toà nhà UOA, 6 Tân Trào, Tân Phú, Quận 7",
                    City = "Hồ Chí Minh",
                    PhoneNumber = "0343663841",
                },
                new Garage
                {
                    Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    Name = "Head Việt Thái Quân",
                    Address = "Số 1 Quang Trung, Phường 3, Quận Gò Vấp",
                    City = "Hồ Chí Minh",
                    PhoneNumber = "02871098198",
                }
            );
        }
    }
}
