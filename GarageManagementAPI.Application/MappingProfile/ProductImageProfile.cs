using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.ProductImage;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class ProductImageProfile : Profile
    {
        public ProductImageProfile()
        {
            CreateMap<ProductImage, ProductImageDto>();
            CreateMap<ProductImageDtoForCreation, ProductImage>();
            CreateMap<ProductImageDtoForUpdate, ProductImage>().ReverseMap();
            CreateMap<ProductImageDtoForManipulation, ProductImage>();
        }
    }
}
