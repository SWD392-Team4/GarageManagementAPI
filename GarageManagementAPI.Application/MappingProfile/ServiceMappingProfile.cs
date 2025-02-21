using AutoMapper;
using GarageManagementAPI.Shared.DataTransferObjects.Service;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            CreateMap<Entities.Models.Service, ServiceDto>();
            CreateMap<ServiceDtoForCreation, Entities.Models.Service>();
            CreateMap<ServiceDtoForUpdate, Entities.Models.Service>().ReverseMap();
            CreateMap<ServiceDtoForManipulation, Entities.Models.Service>();
        }
    }
}
