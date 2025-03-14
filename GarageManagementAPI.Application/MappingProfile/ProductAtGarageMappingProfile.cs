using AutoMapper;
using GarageManagementAPI.Entities.Models;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class ProductAtGarageMappingProfile : Profile
    {
        public ProductAtGarageMappingProfile()
        {
            CreateMap<ProductAtGarage, ProductAtGarageDto>();
            CreateMap<ProductAtGarageForCreation, ProductAtGarage>();
        }
    }
}
