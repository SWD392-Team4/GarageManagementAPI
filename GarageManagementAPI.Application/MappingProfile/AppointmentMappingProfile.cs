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
            CreateMap<Appointment, AppointmentDto>();

        }
    }
}
