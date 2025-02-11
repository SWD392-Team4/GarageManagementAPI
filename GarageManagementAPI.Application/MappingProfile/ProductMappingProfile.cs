using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.Product;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductDtoForCreation, Product>().ReverseMap();
            CreateMap<ProductDtoForUpdate, Product>().ReverseMap();
            CreateMap<ProductDtoForManipulation, Product>().ReverseMap();
        }
    }
}
