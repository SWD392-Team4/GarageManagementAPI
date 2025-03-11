using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.Appointment;
using GarageManagementAPI.Shared.DataTransferObjects.Appointment.Customer;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class AppointmentMappingProfile : Profile
    {
        public AppointmentMappingProfile()
        {
            CreateMap<CustomerCreateAppointmentDto, Appointment>();
        }
    }
}
