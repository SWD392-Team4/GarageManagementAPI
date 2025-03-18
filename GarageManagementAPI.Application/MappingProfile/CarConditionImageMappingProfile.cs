using AutoMapper;

using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.CarConditionImage;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class CarConditionImageMappingProfile : Profile
    {
        public CarConditionImageMappingProfile()
        {
            CreateMap<CarConditionImage, CarConditionImageDto>();
        }
    }
}
