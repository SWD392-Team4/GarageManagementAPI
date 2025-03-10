using AutoMapper;
using GarageManagementAPI.Shared.DataTransferObjects.Service;

namespace GarageManagementAPI.Application.MappingProfile
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            CreateMap<Entities.Models.Service, ServiceDto>()
                .ForMember(dest => dest.CarCategoryId,
                otps =>
                {
                    otps.PreCondition(c => c.CarCategory != null);
                    otps.MapFrom(c => c.CarCategory.Id);
                })
                .ForMember(dest => dest.CarCategory,
                           otps =>
                           {
                               otps.PreCondition(s => s.CarCategory != null && s.CarCategory.Category != null);
                               otps.MapFrom(s => s.CarCategory!.Category);
                           })
                .ForMember(dest => dest.CarPartId,
                otps =>
                {
                    otps.PreCondition(c => c.CarPart != null);
                    otps.MapFrom(c => c.CarPart.Id);
                })
                .ForMember(dest => dest.CarPart,
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
                 .ForMember(dest => dest.Price, opt =>
                 {
                     //Any() checks whether there is at least one item in the ProductHistories collection of the src object. Specifically, it returns a boolean value (true or false): LINQ 
                     opt.PreCondition(src => src.ServiceHistories != null && src.ServiceHistories.Any());
                     opt.MapFrom(src => src.ServiceHistories
                         .OrderByDescending(h => h.CreatedAt)
                         .First()
                         .Price
                     );
                 });
            CreateMap<ServiceDtoForCreation, Entities.Models.Service>();
            CreateMap<ServiceDtoForUpdate, Entities.Models.Service>().ReverseMap();
            CreateMap<ServiceDtoForManipulation, Entities.Models.Service>();
        }
    }
}
