using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.AppointmentDetail;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class AppointmentDetailMappingProfile : Profile
    {
        public AppointmentDetailMappingProfile()
        {
            CreateMap<AppointmentDetail, AppointmentDetailDto>()
                .ForMember(dest => dest.ServiceName, opts =>
                {
                    opts.PreCondition(dest => dest.ServiceHistory != null);
                    opts.PreCondition(dest => dest.ServiceHistory.Service != null);
                    opts.MapFrom(src => src.ServiceHistory.Service.ServiceName);
                })
                .ForMember(dest => dest.Price, opts =>
                {
                    opts.PreCondition(dest => dest.ServiceHistory != null);
                    opts.MapFrom(src => src.ServiceHistory.Price);
                })
                .ForMember(dest => dest.EstimatedHours, opts =>
                {
                    opts.PreCondition(dest => dest.ServiceHistory != null);
                    opts.PreCondition(dest => dest.ServiceHistory.Service != null);
                    opts.MapFrom(src => src.ServiceHistory.Service.EstimatedHours);
                });

        }
    }
}
