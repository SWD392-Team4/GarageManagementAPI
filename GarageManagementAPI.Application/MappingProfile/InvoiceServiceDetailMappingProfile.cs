using AutoMapper;

using GarageManagementAPI.Shared.DataTransferObjects.InvoiceServiceDetail;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class InvoiceServiceDetailMappingProfile : Profile
    {
        public InvoiceServiceDetailMappingProfile()
        {
            CreateMap<Entities.Models.InvoiceServiceDetail, InvoiceServiceDetailDto>()
                .ForMember(dest => dest.ServiceHistory, opts =>
                {
                    opts.PreCondition(src => src.ServiceHistory != null);
                    opts.MapFrom(src => src.ServiceHistory);
                })
                .ForMember(dest => dest.Service, opts =>
                {
                    opts.PreCondition(src => src.ServiceHistory != null);
                    opts.MapFrom(src => src.ServiceHistory.Service);
                });
        }
    }
}
