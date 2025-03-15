using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.Invoice;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class InvoiceMappingProfile : Profile
    {
        public InvoiceMappingProfile()
        {
            CreateMap<Invoice, InvoiceDto>();
            CreateMap<InvoiceDtoForCreation, Invoice>();
        }
    }
}
