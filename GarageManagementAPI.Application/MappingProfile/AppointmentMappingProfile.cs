using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.Appointment;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class AppointmentMappingProfile : Profile
    {
        public AppointmentMappingProfile()
        {
            CreateMap<Appointment, AppointmentDto>()
                .ForMember(dest => dest.EmployeeName, opts =>
                {
                    opts.PreCondition(src => src.ApproveByEmployee != null);
                    opts.MapFrom(src => string.Join(' ', src.ApproveByEmployee!.FirstName, src.ApproveByEmployee.LastName));
                })
                .ForMember(dest => dest.GarageName, opts =>
                {
                    opts.PreCondition(src => src.Garage != null);
                    opts.MapFrom(src => src.Garage.Name);
                })
                .ForMember(dest => dest.CarModelName, opts =>
                {
                    opts.PreCondition(src => src.CarModel != null);
                    opts.MapFrom(src => src.CarModel.ModelName);
                });
        }
    }
}
