using AutoMapper;
using GarageManagementAPI.Shared.DataTransferObjects.Invoice;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class InvoiceMappingProfile : Profile
    {
        public InvoiceMappingProfile()
        {
            CreateMap<Entities.Models.Invoice, InvoiceDto>();
            CreateMap<InvoiceDtoForCreation, Entities.Models.Invoice>()
                .ForMember(dest => dest.InvoiceSellProducts, opts =>
                {
                    opts.Ignore();
                });
        }
    }
}
