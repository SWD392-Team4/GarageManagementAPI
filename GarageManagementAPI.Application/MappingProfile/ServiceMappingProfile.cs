using AutoMapper;
using GarageManagementAPI.Shared.DataTransferObjects.Service;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            CreateMap<Entities.Models.Service, ServiceDto>()
                .ForMember(dest => dest.CarCategory,
                    otps =>
                    {
                        otps.PreCondition(s => s.CarCategory != null);
                        otps.MapFrom(s => s.CarCategory!.Category);
                    })
                .ForMember(dest => dest.CarPart,
                           otps =>
                           {
                               otps.PreCondition(s => s.CarPart != null);
                               otps.MapFrom(s => s.CarPart!.PartName);
                           })
                .ForMember(dest => dest.ImageLink, otp =>
                {
                    otp.PreCondition(src => src.ServiceImage != null && src.ServiceImage.Any());
                    otp.MapFrom(src => src.ServiceImage.Select(e => e.ImageLink).ToList());
                });
            CreateMap<ServiceDtoForCreation, Entities.Models.Service>();
            CreateMap<ServiceDtoForUpdate, Entities.Models.Service>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.ServicePrice))
                .ReverseMap();
            CreateMap<ServiceDtoForManipulation, Entities.Models.Service>();
        }
    }
}
