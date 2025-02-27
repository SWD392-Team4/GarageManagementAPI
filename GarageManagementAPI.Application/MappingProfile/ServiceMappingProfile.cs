using AutoMapper;
using GarageManagementAPI.Shared.DataTransferObjects.Service;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            CreateMap<Entities.Models.Service, ServiceDto>()
                .ForMember(dest => dest.Category,
                           otps =>
                           {
                               otps.PreCondition(s => s.CarCategory != null && s.CarCategory.Category != null);
                               otps.MapFrom(s => s.CarCategory!.Category);
                           })
                .ForMember(dest => dest.PartName,
                           otps =>
                           {
                               otps.PreCondition(s => s.CarPart != null && s.CarPart.PartName != null);
                               otps.MapFrom(s => s.CarPart!.PartName);
                           })
                .ForMember(dest => dest.ImageLink, otp =>
                {
                    otp.PreCondition(src => src.ServiceImage != null && src.ServiceImage.Any());
                    otp.MapFrom(src => src.ServiceImage.Select(e => e.ImageLink).ToList());
                })
                ;
            CreateMap<ServiceDtoForCreation, Entities.Models.Service>();
            CreateMap<ServiceDtoForUpdate, Entities.Models.Service>().ReverseMap();
            CreateMap<ServiceDtoForManipulation, Entities.Models.Service>();
        }
    }
}
