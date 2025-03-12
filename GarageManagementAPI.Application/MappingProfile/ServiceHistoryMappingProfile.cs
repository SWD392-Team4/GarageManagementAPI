using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.ServiceHistory;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class ServiceHistoryMappingProfile : Profile
    {
        public ServiceHistoryMappingProfile()
        {
            CreateMap<ServiceHistory, ServiceHistoryDto>();
            CreateMap<Entities.Models.Service, ServiceHistory>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ServiceId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
        }
    }
}
