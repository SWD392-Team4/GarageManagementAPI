using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.ProductHistory;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class ProductHistoryMappingProfile : Profile
    {
        public ProductHistoryMappingProfile()
        {
            CreateMap<ProductHistory, ProductHistoryDto>();
            CreateMap<ProductHistoryDtoForCreation, ProductHistory>();
            CreateMap<Product, ProductHistory>()
              .ForMember(dest => dest.Id, opt => opt.Ignore())
              .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
        }
    }
}
