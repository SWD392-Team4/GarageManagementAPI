using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.InvoiceSellProduct;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class InvoiceSellProductMappingProfile : Profile
    {
        public InvoiceSellProductMappingProfile()
        {
            CreateMap<InvoiceSellProduct, InvoiceSellProductDto>();
            CreateMap<InvoiceSellProductDtoForCreation, InvoiceSellProduct>();
        }
    }
}
