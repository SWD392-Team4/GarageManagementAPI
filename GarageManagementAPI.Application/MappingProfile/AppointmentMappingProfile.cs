using AutoMapper;

using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.Appointment;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class AppointmentMappingProfile : Profile
    {
        public AppointmentMappingProfile()
        {
            CreateMap<AppointmentDtoForCreation, Appointment>();
            CreateMap<AppointmentDtoForUpdate, Appointment>();
            CreateMap<Appointment, AppointmentDto>()
                .ForMember(dest => dest.ApproveByEmployee, opts =>
                {
                    opts.PreCondition(src => src.ApproveByEmployee != null);
                    opts.MapFrom(src => string.Join(" ", src.ApproveByEmployee!.LastName, src.ApproveByEmployee!.FirstName));
                })
                .ForMember(dest => dest.RejectByEmployee, opts =>
                {
                    opts.PreCondition(src => src.RejecteByEmployee != null);
                    opts.MapFrom(src => string.Join(" ", src.RejecteByEmployee!.LastName, src.RejecteByEmployee!.FirstName));
                });

        }
    }
}
