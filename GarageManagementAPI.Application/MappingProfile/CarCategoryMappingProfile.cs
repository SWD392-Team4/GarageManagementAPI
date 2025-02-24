using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.CarCategory;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class CarCategoryMappingProfile : Profile
    {
        public CarCategoryMappingProfile()
        {
            CreateMap<CarCategory, CarCategoryDto>();
            CreateMap<CarCategoryDtoForCreate, CarCategory>();
            CreateMap<CarCategoryDtoForUpdate, CarCategory>().ReverseMap();
        }
    }
}
