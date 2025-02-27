using AutoMapper;
using GarageManagementAPI.Entities.Models;
using GarageManagementAPI.Shared.DataTransferObjects.ServiceImage;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class ServiceImageMappingProfile : Profile
    {
        public ServiceImageMappingProfile()
        {
            CreateMap<ServiceImage, ServiceImageDto>();
            CreateMap<ServiceImageDtoForUpdate, ServiceImage>().ReverseMap();
            CreateMap<ServiceImageDtoForManipulation, ServiceImage>();
        }
    }
}
