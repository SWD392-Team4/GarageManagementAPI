using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.CarConditionImage;
using GarageManagementAPI.Shared.DataTransferObjects.PackageImage;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class PackageImageMappingProfile : Profile
    {
        public PackageImageMappingProfile()
        {
            CreateMap<PackageImage, PackageImageDto>();
        }
    }

    public class CarConditionImageMappingProfile : Profile
    {
        public CarConditionImageMappingProfile()
        {
            CreateMap<CarConditionImage, CarConditionImageDto>();
        }
    }
}
