using AutoMapper;

using GarageManagementAPI.Shared.DataTransferObjects.Invoice;
using GarageManagementAPI.Shared.DataTransferObjects.InvoicePackageDetail;

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

    public class InvoiceDetailPackageMappingProfile : Profile
    {
        public InvoiceDetailPackageMappingProfile()
        {
            CreateMap<Entities.Models.InvoicePackageDetail, InvoicePackageDetailDto>()
                .ForMember(dest => dest.PackageHistory, opts =>
                {
                    opts.PreCondition(src => src.PackageHistory != null);
                    opts.MapFrom(src => src.PackageHistory);
                });
        }
    }
}
