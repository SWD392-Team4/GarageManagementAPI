using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.InvoiceSellProduct;
using GarageManagementAPI.Shared.RequestFeatures;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class InvoiceSellProductMappingProfile : Profile
    {
        public InvoiceSellProductMappingProfile()
        {
            CreateMap<InvoiceSellProduct, InvoiceSellProductDto>()
                .ForMember(dest => dest.ProductName, otps =>
                {
                    otps.PreCondition(src => src.Product != null);
                    otps.MapFrom(src => src.Product != null ? src.Product.ProductName : string.Empty);
                });

            CreateMap<InvoiceSellProductDtoForCreation, InvoiceSellProduct>();
        }
    }
}
