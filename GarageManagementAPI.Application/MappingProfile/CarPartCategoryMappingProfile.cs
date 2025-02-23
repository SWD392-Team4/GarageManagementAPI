using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.CarPartCategory;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class CarPartCategoryMappingProfile : Profile
    {
        public CarPartCategoryMappingProfile()
        {
            CreateMap<CarPartCategory, CarPartCategoryDto>();
            CreateMap<CarPartCategoryDtoForCreation, CarPartCategory>();
            CreateMap<CarPartCategoryDtoForUpdate, CarPartCategory>().ReverseMap();
            CreateMap<CarPartCategoryDtoForManipulation, CarPartCategory>();
        }
    }
}
