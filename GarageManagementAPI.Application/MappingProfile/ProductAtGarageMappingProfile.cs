using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.ProductAtGarage;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class ProductAtGarageMappingProfile : Profile
    {
        public ProductAtGarageMappingProfile()
        {
            CreateMap<ProductAtGarage, ProductAtGarageDto>().
                ForMember(dest => dest.ProductName, otps =>
                {
                    otps.PreCondition(otp => otp.Product != null);
                    otps.MapFrom(src => src.Product.ProductName);
                });
            CreateMap<ProductAtGarageForCreation, ProductAtGarage>();
        }
    }
}
