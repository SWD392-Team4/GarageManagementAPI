using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.ProductCategory;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class ProductCategoryMappingProfile : Profile
    {
        public ProductCategoryMappingProfile()
        {
            CreateMap<ProductCategory, ProductCategoryDto>();
            CreateMap<ProductCategoryDtoForCreation, ProductCategory>();
            CreateMap<ProductCategoryDtoForUpdate, Brand>().ReverseMap();
            CreateMap<ProductCategoryDtoForManipulation, Brand>();
        }
    }
}
