using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.Appointment;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class AppointmentMappingProfile : Profile
    {
        public AppointmentMappingProfile()
        {
            CreateMap<AppointmentDtoCreation, Appointment>();
            CreateMap<AppointmentDtoCreationWIthFullInformation, Appointment>();
        }
    }
}
